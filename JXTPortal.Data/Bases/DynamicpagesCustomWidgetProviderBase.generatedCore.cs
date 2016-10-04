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
	/// This class is the base class for any <see cref="DynamicpagesCustomWidgetProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class DynamicpagesCustomWidgetProviderBaseCore : EntityProviderBase<JXTPortal.Entities.DynamicpagesCustomWidget, JXTPortal.Entities.DynamicpagesCustomWidgetKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.DynamicpagesCustomWidgetKey key)
		{
			return Delete(transactionManager, key.DynamicPageId, key.CustomWidgetId, key.Position);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_dynamicPageId">. Primary Key.</param>
		/// <param name="_customWidgetId">. Primary Key.</param>
		/// <param name="_position">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _dynamicPageId, System.Int32 _customWidgetId, System.Int32 _position)
		{
			return Delete(null, _dynamicPageId, _customWidgetId, _position);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageId">. Primary Key.</param>
		/// <param name="_customWidgetId">. Primary Key.</param>
		/// <param name="_position">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _dynamicPageId, System.Int32 _customWidgetId, System.Int32 _position);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Dynamicpa__Custo__40AFAAA8 key.
		///		FK__Dynamicpa__Custo__40AFAAA8 Description: 
		/// </summary>
		/// <param name="_customWidgetId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicpagesCustomWidget objects.</returns>
		public TList<DynamicpagesCustomWidget> GetByCustomWidgetId(System.Int32 _customWidgetId)
		{
			int count = -1;
			return GetByCustomWidgetId(_customWidgetId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Dynamicpa__Custo__40AFAAA8 key.
		///		FK__Dynamicpa__Custo__40AFAAA8 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customWidgetId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicpagesCustomWidget objects.</returns>
		/// <remarks></remarks>
		public TList<DynamicpagesCustomWidget> GetByCustomWidgetId(TransactionManager transactionManager, System.Int32 _customWidgetId)
		{
			int count = -1;
			return GetByCustomWidgetId(transactionManager, _customWidgetId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Dynamicpa__Custo__40AFAAA8 key.
		///		FK__Dynamicpa__Custo__40AFAAA8 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customWidgetId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicpagesCustomWidget objects.</returns>
		public TList<DynamicpagesCustomWidget> GetByCustomWidgetId(TransactionManager transactionManager, System.Int32 _customWidgetId, int start, int pageLength)
		{
			int count = -1;
			return GetByCustomWidgetId(transactionManager, _customWidgetId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Dynamicpa__Custo__40AFAAA8 key.
		///		fkDynamicpaCusto40Afaaa8 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customWidgetId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicpagesCustomWidget objects.</returns>
		public TList<DynamicpagesCustomWidget> GetByCustomWidgetId(System.Int32 _customWidgetId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCustomWidgetId(null, _customWidgetId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Dynamicpa__Custo__40AFAAA8 key.
		///		fkDynamicpaCusto40Afaaa8 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customWidgetId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicpagesCustomWidget objects.</returns>
		public TList<DynamicpagesCustomWidget> GetByCustomWidgetId(System.Int32 _customWidgetId, int start, int pageLength,out int count)
		{
			return GetByCustomWidgetId(null, _customWidgetId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Dynamicpa__Custo__40AFAAA8 key.
		///		FK__Dynamicpa__Custo__40AFAAA8 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_customWidgetId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicpagesCustomWidget objects.</returns>
		public abstract TList<DynamicpagesCustomWidget> GetByCustomWidgetId(TransactionManager transactionManager, System.Int32 _customWidgetId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Dynamicpa__Dynam__3FBB866F key.
		///		FK__Dynamicpa__Dynam__3FBB866F Description: 
		/// </summary>
		/// <param name="_dynamicPageId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicpagesCustomWidget objects.</returns>
		public TList<DynamicpagesCustomWidget> GetByDynamicPageId(System.Int32 _dynamicPageId)
		{
			int count = -1;
			return GetByDynamicPageId(_dynamicPageId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Dynamicpa__Dynam__3FBB866F key.
		///		FK__Dynamicpa__Dynam__3FBB866F Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicpagesCustomWidget objects.</returns>
		/// <remarks></remarks>
		public TList<DynamicpagesCustomWidget> GetByDynamicPageId(TransactionManager transactionManager, System.Int32 _dynamicPageId)
		{
			int count = -1;
			return GetByDynamicPageId(transactionManager, _dynamicPageId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__Dynamicpa__Dynam__3FBB866F key.
		///		FK__Dynamicpa__Dynam__3FBB866F Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicpagesCustomWidget objects.</returns>
		public TList<DynamicpagesCustomWidget> GetByDynamicPageId(TransactionManager transactionManager, System.Int32 _dynamicPageId, int start, int pageLength)
		{
			int count = -1;
			return GetByDynamicPageId(transactionManager, _dynamicPageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Dynamicpa__Dynam__3FBB866F key.
		///		fkDynamicpaDynam3Fbb866f Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_dynamicPageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicpagesCustomWidget objects.</returns>
		public TList<DynamicpagesCustomWidget> GetByDynamicPageId(System.Int32 _dynamicPageId, int start, int pageLength)
		{
			int count =  -1;
			return GetByDynamicPageId(null, _dynamicPageId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Dynamicpa__Dynam__3FBB866F key.
		///		fkDynamicpaDynam3Fbb866f Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_dynamicPageId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicpagesCustomWidget objects.</returns>
		public TList<DynamicpagesCustomWidget> GetByDynamicPageId(System.Int32 _dynamicPageId, int start, int pageLength,out int count)
		{
			return GetByDynamicPageId(null, _dynamicPageId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__Dynamicpa__Dynam__3FBB866F key.
		///		FK__Dynamicpa__Dynam__3FBB866F Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.DynamicpagesCustomWidget objects.</returns>
		public abstract TList<DynamicpagesCustomWidget> GetByDynamicPageId(TransactionManager transactionManager, System.Int32 _dynamicPageId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.DynamicpagesCustomWidget Get(TransactionManager transactionManager, JXTPortal.Entities.DynamicpagesCustomWidgetKey key, int start, int pageLength)
		{
			return GetByDynamicPageIdCustomWidgetIdPosition(transactionManager, key.DynamicPageId, key.CustomWidgetId, key.Position, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__Dynamicp__685EECE93DD33DFD index.
		/// </summary>
		/// <param name="_dynamicPageId"></param>
		/// <param name="_customWidgetId"></param>
		/// <param name="_position"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicpagesCustomWidget"/> class.</returns>
		public JXTPortal.Entities.DynamicpagesCustomWidget GetByDynamicPageIdCustomWidgetIdPosition(System.Int32 _dynamicPageId, System.Int32 _customWidgetId, System.Int32 _position)
		{
			int count = -1;
			return GetByDynamicPageIdCustomWidgetIdPosition(null,_dynamicPageId, _customWidgetId, _position, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Dynamicp__685EECE93DD33DFD index.
		/// </summary>
		/// <param name="_dynamicPageId"></param>
		/// <param name="_customWidgetId"></param>
		/// <param name="_position"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicpagesCustomWidget"/> class.</returns>
		public JXTPortal.Entities.DynamicpagesCustomWidget GetByDynamicPageIdCustomWidgetIdPosition(System.Int32 _dynamicPageId, System.Int32 _customWidgetId, System.Int32 _position, int start, int pageLength)
		{
			int count = -1;
			return GetByDynamicPageIdCustomWidgetIdPosition(null, _dynamicPageId, _customWidgetId, _position, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Dynamicp__685EECE93DD33DFD index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageId"></param>
		/// <param name="_customWidgetId"></param>
		/// <param name="_position"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicpagesCustomWidget"/> class.</returns>
		public JXTPortal.Entities.DynamicpagesCustomWidget GetByDynamicPageIdCustomWidgetIdPosition(TransactionManager transactionManager, System.Int32 _dynamicPageId, System.Int32 _customWidgetId, System.Int32 _position)
		{
			int count = -1;
			return GetByDynamicPageIdCustomWidgetIdPosition(transactionManager, _dynamicPageId, _customWidgetId, _position, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Dynamicp__685EECE93DD33DFD index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageId"></param>
		/// <param name="_customWidgetId"></param>
		/// <param name="_position"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicpagesCustomWidget"/> class.</returns>
		public JXTPortal.Entities.DynamicpagesCustomWidget GetByDynamicPageIdCustomWidgetIdPosition(TransactionManager transactionManager, System.Int32 _dynamicPageId, System.Int32 _customWidgetId, System.Int32 _position, int start, int pageLength)
		{
			int count = -1;
			return GetByDynamicPageIdCustomWidgetIdPosition(transactionManager, _dynamicPageId, _customWidgetId, _position, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Dynamicp__685EECE93DD33DFD index.
		/// </summary>
		/// <param name="_dynamicPageId"></param>
		/// <param name="_customWidgetId"></param>
		/// <param name="_position"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicpagesCustomWidget"/> class.</returns>
		public JXTPortal.Entities.DynamicpagesCustomWidget GetByDynamicPageIdCustomWidgetIdPosition(System.Int32 _dynamicPageId, System.Int32 _customWidgetId, System.Int32 _position, int start, int pageLength, out int count)
		{
			return GetByDynamicPageIdCustomWidgetIdPosition(null, _dynamicPageId, _customWidgetId, _position, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__Dynamicp__685EECE93DD33DFD index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_dynamicPageId"></param>
		/// <param name="_customWidgetId"></param>
		/// <param name="_position"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.DynamicpagesCustomWidget"/> class.</returns>
		public abstract JXTPortal.Entities.DynamicpagesCustomWidget GetByDynamicPageIdCustomWidgetIdPosition(TransactionManager transactionManager, System.Int32 _dynamicPageId, System.Int32 _customWidgetId, System.Int32 _position, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region DynamicpagesCustomWidget_GetByDynamicPageId 
		
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_GetByDynamicPageId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDynamicPageId(System.Int32? dynamicPageId)
		{
			return GetByDynamicPageId(null, 0, int.MaxValue , dynamicPageId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_GetByDynamicPageId' stored procedure. 
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
		///	This method wrap the 'DynamicpagesCustomWidget_GetByDynamicPageId' stored procedure. 
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
		///	This method wrap the 'DynamicpagesCustomWidget_GetByDynamicPageId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByDynamicPageId(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageId);
		
		#endregion
		
		#region DynamicpagesCustomWidget_GetByDynamicPageIdCustomWidgetIdPosition 
		
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_GetByDynamicPageIdCustomWidgetIdPosition' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="position"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDynamicPageIdCustomWidgetIdPosition(System.Int32? dynamicPageId, System.Int32? customWidgetId, System.Int32? position)
		{
			return GetByDynamicPageIdCustomWidgetIdPosition(null, 0, int.MaxValue , dynamicPageId, customWidgetId, position);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_GetByDynamicPageIdCustomWidgetIdPosition' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="position"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDynamicPageIdCustomWidgetIdPosition(int start, int pageLength, System.Int32? dynamicPageId, System.Int32? customWidgetId, System.Int32? position)
		{
			return GetByDynamicPageIdCustomWidgetIdPosition(null, start, pageLength , dynamicPageId, customWidgetId, position);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_GetByDynamicPageIdCustomWidgetIdPosition' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="position"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDynamicPageIdCustomWidgetIdPosition(TransactionManager transactionManager, System.Int32? dynamicPageId, System.Int32? customWidgetId, System.Int32? position)
		{
			return GetByDynamicPageIdCustomWidgetIdPosition(transactionManager, 0, int.MaxValue , dynamicPageId, customWidgetId, position);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_GetByDynamicPageIdCustomWidgetIdPosition' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="position"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByDynamicPageIdCustomWidgetIdPosition(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageId, System.Int32? customWidgetId, System.Int32? position);
		
		#endregion
		
		#region DynamicpagesCustomWidget_Insert 
		
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_Insert' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="position"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? dynamicPageId, System.Int32? customWidgetId, System.Int32? position, System.Int32? sequence)
		{
			 Insert(null, 0, int.MaxValue , dynamicPageId, customWidgetId, position, sequence);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_Insert' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="position"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? dynamicPageId, System.Int32? customWidgetId, System.Int32? position, System.Int32? sequence)
		{
			 Insert(null, start, pageLength , dynamicPageId, customWidgetId, position, sequence);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_Insert' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="position"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? dynamicPageId, System.Int32? customWidgetId, System.Int32? position, System.Int32? sequence)
		{
			 Insert(transactionManager, 0, int.MaxValue , dynamicPageId, customWidgetId, position, sequence);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_Insert' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="position"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageId, System.Int32? customWidgetId, System.Int32? position, System.Int32? sequence);
		
		#endregion
		
		#region DynamicpagesCustomWidget_Get_List 
		
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_Get_List' stored procedure. 
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
		///	This method wrap the 'DynamicpagesCustomWidget_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region DynamicpagesCustomWidget_GetPaged 
		
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_GetPaged' stored procedure. 
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
		///	This method wrap the 'DynamicpagesCustomWidget_GetPaged' stored procedure. 
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
		///	This method wrap the 'DynamicpagesCustomWidget_GetPaged' stored procedure. 
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
		///	This method wrap the 'DynamicpagesCustomWidget_GetPaged' stored procedure. 
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
		
		#region DynamicpagesCustomWidget_Update 
		
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_Update' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="originalDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="originalCustomWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="position"> A <c>System.Int32?</c> instance.</param>
		/// <param name="originalPosition"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? dynamicPageId, System.Int32? originalDynamicPageId, System.Int32? customWidgetId, System.Int32? originalCustomWidgetId, System.Int32? position, System.Int32? originalPosition, System.Int32? sequence)
		{
			 Update(null, 0, int.MaxValue , dynamicPageId, originalDynamicPageId, customWidgetId, originalCustomWidgetId, position, originalPosition, sequence);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_Update' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="originalDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="originalCustomWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="position"> A <c>System.Int32?</c> instance.</param>
		/// <param name="originalPosition"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? dynamicPageId, System.Int32? originalDynamicPageId, System.Int32? customWidgetId, System.Int32? originalCustomWidgetId, System.Int32? position, System.Int32? originalPosition, System.Int32? sequence)
		{
			 Update(null, start, pageLength , dynamicPageId, originalDynamicPageId, customWidgetId, originalCustomWidgetId, position, originalPosition, sequence);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_Update' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="originalDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="originalCustomWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="position"> A <c>System.Int32?</c> instance.</param>
		/// <param name="originalPosition"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? dynamicPageId, System.Int32? originalDynamicPageId, System.Int32? customWidgetId, System.Int32? originalCustomWidgetId, System.Int32? position, System.Int32? originalPosition, System.Int32? sequence)
		{
			 Update(transactionManager, 0, int.MaxValue , dynamicPageId, originalDynamicPageId, customWidgetId, originalCustomWidgetId, position, originalPosition, sequence);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_Update' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="originalDynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="originalCustomWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="position"> A <c>System.Int32?</c> instance.</param>
		/// <param name="originalPosition"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageId, System.Int32? originalDynamicPageId, System.Int32? customWidgetId, System.Int32? originalCustomWidgetId, System.Int32? position, System.Int32? originalPosition, System.Int32? sequence);
		
		#endregion
		
		#region DynamicpagesCustomWidget_CustomGetByDynamicPageIDPosition 
		
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_CustomGetByDynamicPageIDPosition' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="position"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetByDynamicPageIDPosition(System.Int32? dynamicPageId, System.Int32? position)
		{
			return CustomGetByDynamicPageIDPosition(null, 0, int.MaxValue , dynamicPageId, position);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_CustomGetByDynamicPageIDPosition' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="position"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetByDynamicPageIDPosition(int start, int pageLength, System.Int32? dynamicPageId, System.Int32? position)
		{
			return CustomGetByDynamicPageIDPosition(null, start, pageLength , dynamicPageId, position);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_CustomGetByDynamicPageIDPosition' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="position"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet CustomGetByDynamicPageIDPosition(TransactionManager transactionManager, System.Int32? dynamicPageId, System.Int32? position)
		{
			return CustomGetByDynamicPageIDPosition(transactionManager, 0, int.MaxValue , dynamicPageId, position);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_CustomGetByDynamicPageIDPosition' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="position"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet CustomGetByDynamicPageIDPosition(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageId, System.Int32? position);
		
		#endregion
		
		#region DynamicpagesCustomWidget_Find 
		
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="position"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(System.Boolean? searchUsingOr, System.Int32? dynamicPageId, System.Int32? customWidgetId, System.Int32? position, System.Int32? sequence)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, dynamicPageId, customWidgetId, position, sequence);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="position"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? dynamicPageId, System.Int32? customWidgetId, System.Int32? position, System.Int32? sequence)
		{
			return Find(null, start, pageLength , searchUsingOr, dynamicPageId, customWidgetId, position, sequence);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="position"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? dynamicPageId, System.Int32? customWidgetId, System.Int32? position, System.Int32? sequence)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, dynamicPageId, customWidgetId, position, sequence);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="position"> A <c>System.Int32?</c> instance.</param>
		/// <param name="sequence"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? dynamicPageId, System.Int32? customWidgetId, System.Int32? position, System.Int32? sequence);
		
		#endregion
		
		#region DynamicpagesCustomWidget_GetByCustomWidgetId 
		
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_GetByCustomWidgetId' stored procedure. 
		/// </summary>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByCustomWidgetId(System.Int32? customWidgetId)
		{
			return GetByCustomWidgetId(null, 0, int.MaxValue , customWidgetId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_GetByCustomWidgetId' stored procedure. 
		/// </summary>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByCustomWidgetId(int start, int pageLength, System.Int32? customWidgetId)
		{
			return GetByCustomWidgetId(null, start, pageLength , customWidgetId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_GetByCustomWidgetId' stored procedure. 
		/// </summary>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByCustomWidgetId(TransactionManager transactionManager, System.Int32? customWidgetId)
		{
			return GetByCustomWidgetId(transactionManager, 0, int.MaxValue , customWidgetId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_GetByCustomWidgetId' stored procedure. 
		/// </summary>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByCustomWidgetId(TransactionManager transactionManager, int start, int pageLength , System.Int32? customWidgetId);
		
		#endregion
		
		#region DynamicpagesCustomWidget_CustomSelect 
		
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_CustomSelect' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="position"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicpagesCustomWidget&gt;"/> instance.</returns>
		public TList<DynamicpagesCustomWidget> CustomSelect(System.Int32? dynamicPageId, System.Int32? customWidgetId, System.Int32? position)
		{
			return CustomSelect(null, 0, int.MaxValue , dynamicPageId, customWidgetId, position);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_CustomSelect' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="position"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicpagesCustomWidget&gt;"/> instance.</returns>
		public TList<DynamicpagesCustomWidget> CustomSelect(int start, int pageLength, System.Int32? dynamicPageId, System.Int32? customWidgetId, System.Int32? position)
		{
			return CustomSelect(null, start, pageLength , dynamicPageId, customWidgetId, position);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_CustomSelect' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="position"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicpagesCustomWidget&gt;"/> instance.</returns>
		public TList<DynamicpagesCustomWidget> CustomSelect(TransactionManager transactionManager, System.Int32? dynamicPageId, System.Int32? customWidgetId, System.Int32? position)
		{
			return CustomSelect(transactionManager, 0, int.MaxValue , dynamicPageId, customWidgetId, position);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_CustomSelect' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="position"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;DynamicpagesCustomWidget&gt;"/> instance.</returns>
		public abstract TList<DynamicpagesCustomWidget> CustomSelect(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageId, System.Int32? customWidgetId, System.Int32? position);
		
		#endregion
		
		#region DynamicpagesCustomWidget_CustomDelete 
		
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_CustomDelete' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="position"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomDelete(System.Int32? dynamicPageId, System.Int32? customWidgetId, System.Int32? position)
		{
			 CustomDelete(null, 0, int.MaxValue , dynamicPageId, customWidgetId, position);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_CustomDelete' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="position"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomDelete(int start, int pageLength, System.Int32? dynamicPageId, System.Int32? customWidgetId, System.Int32? position)
		{
			 CustomDelete(null, start, pageLength , dynamicPageId, customWidgetId, position);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_CustomDelete' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="position"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void CustomDelete(TransactionManager transactionManager, System.Int32? dynamicPageId, System.Int32? customWidgetId, System.Int32? position)
		{
			 CustomDelete(transactionManager, 0, int.MaxValue , dynamicPageId, customWidgetId, position);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_CustomDelete' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="position"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void CustomDelete(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageId, System.Int32? customWidgetId, System.Int32? position);
		
		#endregion
		
		#region DynamicpagesCustomWidget_GetByDynamicPageIdCustomWidgetId 
		
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_GetByDynamicPageIdCustomWidgetId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDynamicPageIdCustomWidgetId(System.Int32? dynamicPageId, System.Int32? customWidgetId)
		{
			return GetByDynamicPageIdCustomWidgetId(null, 0, int.MaxValue , dynamicPageId, customWidgetId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_GetByDynamicPageIdCustomWidgetId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDynamicPageIdCustomWidgetId(int start, int pageLength, System.Int32? dynamicPageId, System.Int32? customWidgetId)
		{
			return GetByDynamicPageIdCustomWidgetId(null, start, pageLength , dynamicPageId, customWidgetId);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_GetByDynamicPageIdCustomWidgetId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public DataSet GetByDynamicPageIdCustomWidgetId(TransactionManager transactionManager, System.Int32? dynamicPageId, System.Int32? customWidgetId)
		{
			return GetByDynamicPageIdCustomWidgetId(transactionManager, 0, int.MaxValue , dynamicPageId, customWidgetId);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_GetByDynamicPageIdCustomWidgetId' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="DataSet"/> instance.</returns>
		public abstract DataSet GetByDynamicPageIdCustomWidgetId(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageId, System.Int32? customWidgetId);
		
		#endregion
		
		#region DynamicpagesCustomWidget_Delete 
		
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_Delete' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="position"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? dynamicPageId, System.Int32? customWidgetId, System.Int32? position)
		{
			 Delete(null, 0, int.MaxValue , dynamicPageId, customWidgetId, position);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_Delete' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="position"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? dynamicPageId, System.Int32? customWidgetId, System.Int32? position)
		{
			 Delete(null, start, pageLength , dynamicPageId, customWidgetId, position);
		}
				
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_Delete' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="position"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? dynamicPageId, System.Int32? customWidgetId, System.Int32? position)
		{
			 Delete(transactionManager, 0, int.MaxValue , dynamicPageId, customWidgetId, position);
		}
		
		/// <summary>
		///	This method wrap the 'DynamicpagesCustomWidget_Delete' stored procedure. 
		/// </summary>
		/// <param name="dynamicPageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="customWidgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="position"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? dynamicPageId, System.Int32? customWidgetId, System.Int32? position);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;DynamicpagesCustomWidget&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;DynamicpagesCustomWidget&gt;"/></returns>
		public static TList<DynamicpagesCustomWidget> Fill(IDataReader reader, TList<DynamicpagesCustomWidget> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.DynamicpagesCustomWidget c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("DynamicpagesCustomWidget")
					.Append("|").Append((System.Int32)reader[((int)DynamicpagesCustomWidgetColumn.DynamicPageId - 1)])
					.Append("|").Append((System.Int32)reader[((int)DynamicpagesCustomWidgetColumn.CustomWidgetId - 1)])
					.Append("|").Append((System.Int32)reader[((int)DynamicpagesCustomWidgetColumn.Position - 1)]).ToString();
					c = EntityManager.LocateOrCreate<DynamicpagesCustomWidget>(
					key.ToString(), // EntityTrackingKey
					"DynamicpagesCustomWidget",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.DynamicpagesCustomWidget();
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
					c.DynamicPageId = (System.Int32)reader[((int)DynamicpagesCustomWidgetColumn.DynamicPageId - 1)];
					c.OriginalDynamicPageId = c.DynamicPageId;
					c.CustomWidgetId = (System.Int32)reader[((int)DynamicpagesCustomWidgetColumn.CustomWidgetId - 1)];
					c.OriginalCustomWidgetId = c.CustomWidgetId;
					c.Position = (System.Int32)reader[((int)DynamicpagesCustomWidgetColumn.Position - 1)];
					c.OriginalPosition = c.Position;
					c.Sequence = (System.Int32)reader[((int)DynamicpagesCustomWidgetColumn.Sequence - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.DynamicpagesCustomWidget"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.DynamicpagesCustomWidget"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.DynamicpagesCustomWidget entity)
		{
			if (!reader.Read()) return;
			
			entity.DynamicPageId = (System.Int32)reader[((int)DynamicpagesCustomWidgetColumn.DynamicPageId - 1)];
			entity.OriginalDynamicPageId = (System.Int32)reader["DynamicPageID"];
			entity.CustomWidgetId = (System.Int32)reader[((int)DynamicpagesCustomWidgetColumn.CustomWidgetId - 1)];
			entity.OriginalCustomWidgetId = (System.Int32)reader["CustomWidgetID"];
			entity.Position = (System.Int32)reader[((int)DynamicpagesCustomWidgetColumn.Position - 1)];
			entity.OriginalPosition = (System.Int32)reader["Position"];
			entity.Sequence = (System.Int32)reader[((int)DynamicpagesCustomWidgetColumn.Sequence - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.DynamicpagesCustomWidget"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.DynamicpagesCustomWidget"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.DynamicpagesCustomWidget entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.DynamicPageId = (System.Int32)dataRow["DynamicPageID"];
			entity.OriginalDynamicPageId = (System.Int32)dataRow["DynamicPageID"];
			entity.CustomWidgetId = (System.Int32)dataRow["CustomWidgetID"];
			entity.OriginalCustomWidgetId = (System.Int32)dataRow["CustomWidgetID"];
			entity.Position = (System.Int32)dataRow["Position"];
			entity.OriginalPosition = (System.Int32)dataRow["Position"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.DynamicpagesCustomWidget"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.DynamicpagesCustomWidget Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.DynamicpagesCustomWidget entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region CustomWidgetIdSource	
			if (CanDeepLoad(entity, "CustomWidget|CustomWidgetIdSource", deepLoadType, innerList) 
				&& entity.CustomWidgetIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.CustomWidgetId;
				CustomWidget tmpEntity = EntityManager.LocateEntity<CustomWidget>(EntityLocator.ConstructKeyFromPkItems(typeof(CustomWidget), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CustomWidgetIdSource = tmpEntity;
				else
					entity.CustomWidgetIdSource = DataRepository.CustomWidgetProvider.GetByCustomWidgetId(transactionManager, entity.CustomWidgetId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CustomWidgetIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CustomWidgetIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CustomWidgetProvider.DeepLoad(transactionManager, entity.CustomWidgetIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CustomWidgetIdSource

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
		/// Deep Save the entire object graph of the JXTPortal.Entities.DynamicpagesCustomWidget object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.DynamicpagesCustomWidget instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.DynamicpagesCustomWidget Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.DynamicpagesCustomWidget entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region CustomWidgetIdSource
			if (CanDeepSave(entity, "CustomWidget|CustomWidgetIdSource", deepSaveType, innerList) 
				&& entity.CustomWidgetIdSource != null)
			{
				DataRepository.CustomWidgetProvider.Save(transactionManager, entity.CustomWidgetIdSource);
				entity.CustomWidgetId = entity.CustomWidgetIdSource.CustomWidgetId;
			}
			#endregion 
			
			#region DynamicPageIdSource
			if (CanDeepSave(entity, "DynamicPages|DynamicPageIdSource", deepSaveType, innerList) 
				&& entity.DynamicPageIdSource != null)
			{
				DataRepository.DynamicPagesProvider.Save(transactionManager, entity.DynamicPageIdSource);
				entity.DynamicPageId = entity.DynamicPageIdSource.DynamicPageId;
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
	
	#region DynamicpagesCustomWidgetChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.DynamicpagesCustomWidget</c>
	///</summary>
	public enum DynamicpagesCustomWidgetChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>CustomWidget</c> at CustomWidgetIdSource
		///</summary>
		[ChildEntityType(typeof(CustomWidget))]
		CustomWidget,
			
		///<summary>
		/// Composite Property for <c>DynamicPages</c> at DynamicPageIdSource
		///</summary>
		[ChildEntityType(typeof(DynamicPages))]
		DynamicPages,
		}
	
	#endregion DynamicpagesCustomWidgetChildEntityTypes
	
	#region DynamicpagesCustomWidgetFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;DynamicpagesCustomWidgetColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicpagesCustomWidget"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicpagesCustomWidgetFilterBuilder : SqlFilterBuilder<DynamicpagesCustomWidgetColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicpagesCustomWidgetFilterBuilder class.
		/// </summary>
		public DynamicpagesCustomWidgetFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DynamicpagesCustomWidgetFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DynamicpagesCustomWidgetFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DynamicpagesCustomWidgetFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DynamicpagesCustomWidgetFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DynamicpagesCustomWidgetFilterBuilder
	
	#region DynamicpagesCustomWidgetParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;DynamicpagesCustomWidgetColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicpagesCustomWidget"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicpagesCustomWidgetParameterBuilder : ParameterizedSqlFilterBuilder<DynamicpagesCustomWidgetColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicpagesCustomWidgetParameterBuilder class.
		/// </summary>
		public DynamicpagesCustomWidgetParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the DynamicpagesCustomWidgetParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public DynamicpagesCustomWidgetParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the DynamicpagesCustomWidgetParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public DynamicpagesCustomWidgetParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion DynamicpagesCustomWidgetParameterBuilder
	
	#region DynamicpagesCustomWidgetSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;DynamicpagesCustomWidgetColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicpagesCustomWidget"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class DynamicpagesCustomWidgetSortBuilder : SqlSortBuilder<DynamicpagesCustomWidgetColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicpagesCustomWidgetSqlSortBuilder class.
		/// </summary>
		public DynamicpagesCustomWidgetSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion DynamicpagesCustomWidgetSortBuilder
	
} // end namespace
