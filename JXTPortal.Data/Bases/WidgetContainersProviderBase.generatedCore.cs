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
	/// This class is the base class for any <see cref="WidgetContainersProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class WidgetContainersProviderBaseCore : EntityProviderBase<JXTPortal.Entities.WidgetContainers, JXTPortal.Entities.WidgetContainersKey>
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
		public override bool Delete(TransactionManager transactionManager, JXTPortal.Entities.WidgetContainersKey key)
		{
			return Delete(transactionManager, key.WidgetId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_widgetId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _widgetId)
		{
			return Delete(null, _widgetId);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_widgetId">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _widgetId);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WidgetCon__Defau__53591940 key.
		///		FK__WidgetCon__Defau__53591940 Description: 
		/// </summary>
		/// <param name="_defaultProfessionId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.WidgetContainers objects.</returns>
		public TList<WidgetContainers> GetByDefaultProfessionId(System.Int32? _defaultProfessionId)
		{
			int count = -1;
			return GetByDefaultProfessionId(_defaultProfessionId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WidgetCon__Defau__53591940 key.
		///		FK__WidgetCon__Defau__53591940 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_defaultProfessionId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.WidgetContainers objects.</returns>
		/// <remarks></remarks>
		public TList<WidgetContainers> GetByDefaultProfessionId(TransactionManager transactionManager, System.Int32? _defaultProfessionId)
		{
			int count = -1;
			return GetByDefaultProfessionId(transactionManager, _defaultProfessionId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__WidgetCon__Defau__53591940 key.
		///		FK__WidgetCon__Defau__53591940 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_defaultProfessionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.WidgetContainers objects.</returns>
		public TList<WidgetContainers> GetByDefaultProfessionId(TransactionManager transactionManager, System.Int32? _defaultProfessionId, int start, int pageLength)
		{
			int count = -1;
			return GetByDefaultProfessionId(transactionManager, _defaultProfessionId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WidgetCon__Defau__53591940 key.
		///		fkWidgetConDefau53591940 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_defaultProfessionId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.WidgetContainers objects.</returns>
		public TList<WidgetContainers> GetByDefaultProfessionId(System.Int32? _defaultProfessionId, int start, int pageLength)
		{
			int count =  -1;
			return GetByDefaultProfessionId(null, _defaultProfessionId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WidgetCon__Defau__53591940 key.
		///		fkWidgetConDefau53591940 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_defaultProfessionId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.WidgetContainers objects.</returns>
		public TList<WidgetContainers> GetByDefaultProfessionId(System.Int32? _defaultProfessionId, int start, int pageLength,out int count)
		{
			return GetByDefaultProfessionId(null, _defaultProfessionId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WidgetCon__Defau__53591940 key.
		///		FK__WidgetCon__Defau__53591940 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_defaultProfessionId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.WidgetContainers objects.</returns>
		public abstract TList<WidgetContainers> GetByDefaultProfessionId(TransactionManager transactionManager, System.Int32? _defaultProfessionId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WidgetCon__Defau__544D3D79 key.
		///		FK__WidgetCon__Defau__544D3D79 Description: 
		/// </summary>
		/// <param name="_defaultCountryId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.WidgetContainers objects.</returns>
		public TList<WidgetContainers> GetByDefaultCountryId(System.Int32? _defaultCountryId)
		{
			int count = -1;
			return GetByDefaultCountryId(_defaultCountryId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WidgetCon__Defau__544D3D79 key.
		///		FK__WidgetCon__Defau__544D3D79 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_defaultCountryId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.WidgetContainers objects.</returns>
		/// <remarks></remarks>
		public TList<WidgetContainers> GetByDefaultCountryId(TransactionManager transactionManager, System.Int32? _defaultCountryId)
		{
			int count = -1;
			return GetByDefaultCountryId(transactionManager, _defaultCountryId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__WidgetCon__Defau__544D3D79 key.
		///		FK__WidgetCon__Defau__544D3D79 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_defaultCountryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.WidgetContainers objects.</returns>
		public TList<WidgetContainers> GetByDefaultCountryId(TransactionManager transactionManager, System.Int32? _defaultCountryId, int start, int pageLength)
		{
			int count = -1;
			return GetByDefaultCountryId(transactionManager, _defaultCountryId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WidgetCon__Defau__544D3D79 key.
		///		fkWidgetConDefau544d3d79 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_defaultCountryId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.WidgetContainers objects.</returns>
		public TList<WidgetContainers> GetByDefaultCountryId(System.Int32? _defaultCountryId, int start, int pageLength)
		{
			int count =  -1;
			return GetByDefaultCountryId(null, _defaultCountryId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WidgetCon__Defau__544D3D79 key.
		///		fkWidgetConDefau544d3d79 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_defaultCountryId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.WidgetContainers objects.</returns>
		public TList<WidgetContainers> GetByDefaultCountryId(System.Int32? _defaultCountryId, int start, int pageLength,out int count)
		{
			return GetByDefaultCountryId(null, _defaultCountryId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WidgetCon__Defau__544D3D79 key.
		///		FK__WidgetCon__Defau__544D3D79 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_defaultCountryId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.WidgetContainers objects.</returns>
		public abstract TList<WidgetContainers> GetByDefaultCountryId(TransactionManager transactionManager, System.Int32? _defaultCountryId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WidgetCon__Defau__554161B2 key.
		///		FK__WidgetCon__Defau__554161B2 Description: 
		/// </summary>
		/// <param name="_defaultLocationId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.WidgetContainers objects.</returns>
		public TList<WidgetContainers> GetByDefaultLocationId(System.Int32? _defaultLocationId)
		{
			int count = -1;
			return GetByDefaultLocationId(_defaultLocationId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WidgetCon__Defau__554161B2 key.
		///		FK__WidgetCon__Defau__554161B2 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_defaultLocationId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.WidgetContainers objects.</returns>
		/// <remarks></remarks>
		public TList<WidgetContainers> GetByDefaultLocationId(TransactionManager transactionManager, System.Int32? _defaultLocationId)
		{
			int count = -1;
			return GetByDefaultLocationId(transactionManager, _defaultLocationId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__WidgetCon__Defau__554161B2 key.
		///		FK__WidgetCon__Defau__554161B2 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_defaultLocationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.WidgetContainers objects.</returns>
		public TList<WidgetContainers> GetByDefaultLocationId(TransactionManager transactionManager, System.Int32? _defaultLocationId, int start, int pageLength)
		{
			int count = -1;
			return GetByDefaultLocationId(transactionManager, _defaultLocationId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WidgetCon__Defau__554161B2 key.
		///		fkWidgetConDefau554161b2 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_defaultLocationId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.WidgetContainers objects.</returns>
		public TList<WidgetContainers> GetByDefaultLocationId(System.Int32? _defaultLocationId, int start, int pageLength)
		{
			int count =  -1;
			return GetByDefaultLocationId(null, _defaultLocationId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WidgetCon__Defau__554161B2 key.
		///		fkWidgetConDefau554161b2 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_defaultLocationId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.WidgetContainers objects.</returns>
		public TList<WidgetContainers> GetByDefaultLocationId(System.Int32? _defaultLocationId, int start, int pageLength,out int count)
		{
			return GetByDefaultLocationId(null, _defaultLocationId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WidgetCon__Defau__554161B2 key.
		///		FK__WidgetCon__Defau__554161B2 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_defaultLocationId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.WidgetContainers objects.</returns>
		public abstract TList<WidgetContainers> GetByDefaultLocationId(TransactionManager transactionManager, System.Int32? _defaultLocationId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WidgetCon__Langu__4DA03FEA key.
		///		FK__WidgetCon__Langu__4DA03FEA Description: 
		/// </summary>
		/// <param name="_languageId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.WidgetContainers objects.</returns>
		public TList<WidgetContainers> GetByLanguageId(System.Int32 _languageId)
		{
			int count = -1;
			return GetByLanguageId(_languageId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WidgetCon__Langu__4DA03FEA key.
		///		FK__WidgetCon__Langu__4DA03FEA Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_languageId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.WidgetContainers objects.</returns>
		/// <remarks></remarks>
		public TList<WidgetContainers> GetByLanguageId(TransactionManager transactionManager, System.Int32 _languageId)
		{
			int count = -1;
			return GetByLanguageId(transactionManager, _languageId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__WidgetCon__Langu__4DA03FEA key.
		///		FK__WidgetCon__Langu__4DA03FEA Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.WidgetContainers objects.</returns>
		public TList<WidgetContainers> GetByLanguageId(TransactionManager transactionManager, System.Int32 _languageId, int start, int pageLength)
		{
			int count = -1;
			return GetByLanguageId(transactionManager, _languageId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WidgetCon__Langu__4DA03FEA key.
		///		fkWidgetConLangu4Da03Fea Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_languageId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.WidgetContainers objects.</returns>
		public TList<WidgetContainers> GetByLanguageId(System.Int32 _languageId, int start, int pageLength)
		{
			int count =  -1;
			return GetByLanguageId(null, _languageId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WidgetCon__Langu__4DA03FEA key.
		///		fkWidgetConLangu4Da03Fea Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_languageId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.WidgetContainers objects.</returns>
		public TList<WidgetContainers> GetByLanguageId(System.Int32 _languageId, int start, int pageLength,out int count)
		{
			return GetByLanguageId(null, _languageId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WidgetCon__Langu__4DA03FEA key.
		///		FK__WidgetCon__Langu__4DA03FEA Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_languageId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.WidgetContainers objects.</returns>
		public abstract TList<WidgetContainers> GetByLanguageId(TransactionManager transactionManager, System.Int32 _languageId, int start, int pageLength, out int count);
		
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WidgetCon__SiteI__4CAC1BB1 key.
		///		FK__WidgetCon__SiteI__4CAC1BB1 Description: 
		/// </summary>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.WidgetContainers objects.</returns>
		public TList<WidgetContainers> GetBySiteId(System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(_siteId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WidgetCon__SiteI__4CAC1BB1 key.
		///		FK__WidgetCon__SiteI__4CAC1BB1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.WidgetContainers objects.</returns>
		/// <remarks></remarks>
		public TList<WidgetContainers> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK__WidgetCon__SiteI__4CAC1BB1 key.
		///		FK__WidgetCon__SiteI__4CAC1BB1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.WidgetContainers objects.</returns>
		public TList<WidgetContainers> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength)
		{
			int count = -1;
			return GetBySiteId(transactionManager, _siteId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WidgetCon__SiteI__4CAC1BB1 key.
		///		fkWidgetConSitei4Cac1Bb1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.WidgetContainers objects.</returns>
		public TList<WidgetContainers> GetBySiteId(System.Int32 _siteId, int start, int pageLength)
		{
			int count =  -1;
			return GetBySiteId(null, _siteId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WidgetCon__SiteI__4CAC1BB1 key.
		///		fkWidgetConSitei4Cac1Bb1 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_siteId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of JXTPortal.Entities.WidgetContainers objects.</returns>
		public TList<WidgetContainers> GetBySiteId(System.Int32 _siteId, int start, int pageLength,out int count)
		{
			return GetBySiteId(null, _siteId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__WidgetCon__SiteI__4CAC1BB1 key.
		///		FK__WidgetCon__SiteI__4CAC1BB1 Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_siteId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of JXTPortal.Entities.WidgetContainers objects.</returns>
		public abstract TList<WidgetContainers> GetBySiteId(TransactionManager transactionManager, System.Int32 _siteId, int start, int pageLength, out int count);
		
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
		public override JXTPortal.Entities.WidgetContainers Get(TransactionManager transactionManager, JXTPortal.Entities.WidgetContainersKey key, int start, int pageLength)
		{
			return GetByWidgetId(transactionManager, key.WidgetId, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key PK__WidgetContainers__4BB7F778 index.
		/// </summary>
		/// <param name="_widgetId"></param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.WidgetContainers"/> class.</returns>
		public JXTPortal.Entities.WidgetContainers GetByWidgetId(System.Int32 _widgetId)
		{
			int count = -1;
			return GetByWidgetId(null,_widgetId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__WidgetContainers__4BB7F778 index.
		/// </summary>
		/// <param name="_widgetId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.WidgetContainers"/> class.</returns>
		public JXTPortal.Entities.WidgetContainers GetByWidgetId(System.Int32 _widgetId, int start, int pageLength)
		{
			int count = -1;
			return GetByWidgetId(null, _widgetId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__WidgetContainers__4BB7F778 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_widgetId"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.WidgetContainers"/> class.</returns>
		public JXTPortal.Entities.WidgetContainers GetByWidgetId(TransactionManager transactionManager, System.Int32 _widgetId)
		{
			int count = -1;
			return GetByWidgetId(transactionManager, _widgetId, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__WidgetContainers__4BB7F778 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_widgetId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.WidgetContainers"/> class.</returns>
		public JXTPortal.Entities.WidgetContainers GetByWidgetId(TransactionManager transactionManager, System.Int32 _widgetId, int start, int pageLength)
		{
			int count = -1;
			return GetByWidgetId(transactionManager, _widgetId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__WidgetContainers__4BB7F778 index.
		/// </summary>
		/// <param name="_widgetId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.WidgetContainers"/> class.</returns>
		public JXTPortal.Entities.WidgetContainers GetByWidgetId(System.Int32 _widgetId, int start, int pageLength, out int count)
		{
			return GetByWidgetId(null, _widgetId, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the PK__WidgetContainers__4BB7F778 index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_widgetId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="JXTPortal.Entities.WidgetContainers"/> class.</returns>
		public abstract JXTPortal.Entities.WidgetContainers GetByWidgetId(TransactionManager transactionManager, System.Int32 _widgetId, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#region WidgetContainers_Insert 
		
		/// <summary>
		///	This method wrap the 'WidgetContainers_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="widgetName"> A <c>System.String</c> instance.</param>
		/// <param name="widgetDomain"> A <c>System.String</c> instance.</param>
		/// <param name="widgetContainerClass"> A <c>System.String</c> instance.</param>
		/// <param name="widgetContainerHeaderClass"> A <c>System.String</c> instance.</param>
		/// <param name="widgetItemClass"> A <c>System.String</c> instance.</param>
		/// <param name="widgetJobLinkCss"> A <c>System.String</c> instance.</param>
		/// <param name="widgetItemLinkImageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showJobs"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showCompanies"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showSite"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showPeople"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobHtml"> A <c>System.String</c> instance.</param>
		/// <param name="companyHtml"> A <c>System.String</c> instance.</param>
		/// <param name="siteHtml"> A <c>System.String</c> instance.</param>
		/// <param name="peopleHtml"> A <c>System.String</c> instance.</param>
		/// <param name="javascript"> A <c>System.String</c> instance.</param>
		/// <param name="searchCss"> A <c>System.String</c> instance.</param>
		/// <param name="defaultProfessionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="width"> A <c>System.Int32?</c> instance.</param>
		/// <param name="height"> A <c>System.Int32?</c> instance.</param>
		/// <param name="onAdvancedSearch"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="widgetId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(System.Int32? siteId, System.Int32? languageId, System.String widgetName, System.String widgetDomain, System.String widgetContainerClass, System.String widgetContainerHeaderClass, System.String widgetItemClass, System.String widgetJobLinkCss, System.Int32? widgetItemLinkImageId, System.Boolean? valid, System.Boolean? showJobs, System.Boolean? showCompanies, System.Boolean? showSite, System.Boolean? showPeople, System.String jobHtml, System.String companyHtml, System.String siteHtml, System.String peopleHtml, System.String javascript, System.String searchCss, System.Int32? defaultProfessionId, System.Int32? defaultCountryId, System.Int32? defaultLocationId, System.Int32? width, System.Int32? height, System.Boolean? onAdvancedSearch, ref System.Int32? widgetId)
		{
			 Insert(null, 0, int.MaxValue , siteId, languageId, widgetName, widgetDomain, widgetContainerClass, widgetContainerHeaderClass, widgetItemClass, widgetJobLinkCss, widgetItemLinkImageId, valid, showJobs, showCompanies, showSite, showPeople, jobHtml, companyHtml, siteHtml, peopleHtml, javascript, searchCss, defaultProfessionId, defaultCountryId, defaultLocationId, width, height, onAdvancedSearch, ref widgetId);
		}
		
		/// <summary>
		///	This method wrap the 'WidgetContainers_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="widgetName"> A <c>System.String</c> instance.</param>
		/// <param name="widgetDomain"> A <c>System.String</c> instance.</param>
		/// <param name="widgetContainerClass"> A <c>System.String</c> instance.</param>
		/// <param name="widgetContainerHeaderClass"> A <c>System.String</c> instance.</param>
		/// <param name="widgetItemClass"> A <c>System.String</c> instance.</param>
		/// <param name="widgetJobLinkCss"> A <c>System.String</c> instance.</param>
		/// <param name="widgetItemLinkImageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showJobs"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showCompanies"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showSite"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showPeople"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobHtml"> A <c>System.String</c> instance.</param>
		/// <param name="companyHtml"> A <c>System.String</c> instance.</param>
		/// <param name="siteHtml"> A <c>System.String</c> instance.</param>
		/// <param name="peopleHtml"> A <c>System.String</c> instance.</param>
		/// <param name="javascript"> A <c>System.String</c> instance.</param>
		/// <param name="searchCss"> A <c>System.String</c> instance.</param>
		/// <param name="defaultProfessionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="width"> A <c>System.Int32?</c> instance.</param>
		/// <param name="height"> A <c>System.Int32?</c> instance.</param>
		/// <param name="onAdvancedSearch"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="widgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(int start, int pageLength, System.Int32? siteId, System.Int32? languageId, System.String widgetName, System.String widgetDomain, System.String widgetContainerClass, System.String widgetContainerHeaderClass, System.String widgetItemClass, System.String widgetJobLinkCss, System.Int32? widgetItemLinkImageId, System.Boolean? valid, System.Boolean? showJobs, System.Boolean? showCompanies, System.Boolean? showSite, System.Boolean? showPeople, System.String jobHtml, System.String companyHtml, System.String siteHtml, System.String peopleHtml, System.String javascript, System.String searchCss, System.Int32? defaultProfessionId, System.Int32? defaultCountryId, System.Int32? defaultLocationId, System.Int32? width, System.Int32? height, System.Boolean? onAdvancedSearch, ref System.Int32? widgetId)
		{
			 Insert(null, start, pageLength , siteId, languageId, widgetName, widgetDomain, widgetContainerClass, widgetContainerHeaderClass, widgetItemClass, widgetJobLinkCss, widgetItemLinkImageId, valid, showJobs, showCompanies, showSite, showPeople, jobHtml, companyHtml, siteHtml, peopleHtml, javascript, searchCss, defaultProfessionId, defaultCountryId, defaultLocationId, width, height, onAdvancedSearch, ref widgetId);
		}
				
		/// <summary>
		///	This method wrap the 'WidgetContainers_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="widgetName"> A <c>System.String</c> instance.</param>
		/// <param name="widgetDomain"> A <c>System.String</c> instance.</param>
		/// <param name="widgetContainerClass"> A <c>System.String</c> instance.</param>
		/// <param name="widgetContainerHeaderClass"> A <c>System.String</c> instance.</param>
		/// <param name="widgetItemClass"> A <c>System.String</c> instance.</param>
		/// <param name="widgetJobLinkCss"> A <c>System.String</c> instance.</param>
		/// <param name="widgetItemLinkImageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showJobs"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showCompanies"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showSite"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showPeople"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobHtml"> A <c>System.String</c> instance.</param>
		/// <param name="companyHtml"> A <c>System.String</c> instance.</param>
		/// <param name="siteHtml"> A <c>System.String</c> instance.</param>
		/// <param name="peopleHtml"> A <c>System.String</c> instance.</param>
		/// <param name="javascript"> A <c>System.String</c> instance.</param>
		/// <param name="searchCss"> A <c>System.String</c> instance.</param>
		/// <param name="defaultProfessionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="width"> A <c>System.Int32?</c> instance.</param>
		/// <param name="height"> A <c>System.Int32?</c> instance.</param>
		/// <param name="onAdvancedSearch"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="widgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Insert(TransactionManager transactionManager, System.Int32? siteId, System.Int32? languageId, System.String widgetName, System.String widgetDomain, System.String widgetContainerClass, System.String widgetContainerHeaderClass, System.String widgetItemClass, System.String widgetJobLinkCss, System.Int32? widgetItemLinkImageId, System.Boolean? valid, System.Boolean? showJobs, System.Boolean? showCompanies, System.Boolean? showSite, System.Boolean? showPeople, System.String jobHtml, System.String companyHtml, System.String siteHtml, System.String peopleHtml, System.String javascript, System.String searchCss, System.Int32? defaultProfessionId, System.Int32? defaultCountryId, System.Int32? defaultLocationId, System.Int32? width, System.Int32? height, System.Boolean? onAdvancedSearch, ref System.Int32? widgetId)
		{
			 Insert(transactionManager, 0, int.MaxValue , siteId, languageId, widgetName, widgetDomain, widgetContainerClass, widgetContainerHeaderClass, widgetItemClass, widgetJobLinkCss, widgetItemLinkImageId, valid, showJobs, showCompanies, showSite, showPeople, jobHtml, companyHtml, siteHtml, peopleHtml, javascript, searchCss, defaultProfessionId, defaultCountryId, defaultLocationId, width, height, onAdvancedSearch, ref widgetId);
		}
		
		/// <summary>
		///	This method wrap the 'WidgetContainers_Insert' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="widgetName"> A <c>System.String</c> instance.</param>
		/// <param name="widgetDomain"> A <c>System.String</c> instance.</param>
		/// <param name="widgetContainerClass"> A <c>System.String</c> instance.</param>
		/// <param name="widgetContainerHeaderClass"> A <c>System.String</c> instance.</param>
		/// <param name="widgetItemClass"> A <c>System.String</c> instance.</param>
		/// <param name="widgetJobLinkCss"> A <c>System.String</c> instance.</param>
		/// <param name="widgetItemLinkImageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showJobs"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showCompanies"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showSite"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showPeople"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobHtml"> A <c>System.String</c> instance.</param>
		/// <param name="companyHtml"> A <c>System.String</c> instance.</param>
		/// <param name="siteHtml"> A <c>System.String</c> instance.</param>
		/// <param name="peopleHtml"> A <c>System.String</c> instance.</param>
		/// <param name="javascript"> A <c>System.String</c> instance.</param>
		/// <param name="searchCss"> A <c>System.String</c> instance.</param>
		/// <param name="defaultProfessionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="width"> A <c>System.Int32?</c> instance.</param>
		/// <param name="height"> A <c>System.Int32?</c> instance.</param>
		/// <param name="onAdvancedSearch"> A <c>System.Boolean?</c> instance.</param>
			/// <param name="widgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Insert(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId, System.Int32? languageId, System.String widgetName, System.String widgetDomain, System.String widgetContainerClass, System.String widgetContainerHeaderClass, System.String widgetItemClass, System.String widgetJobLinkCss, System.Int32? widgetItemLinkImageId, System.Boolean? valid, System.Boolean? showJobs, System.Boolean? showCompanies, System.Boolean? showSite, System.Boolean? showPeople, System.String jobHtml, System.String companyHtml, System.String siteHtml, System.String peopleHtml, System.String javascript, System.String searchCss, System.Int32? defaultProfessionId, System.Int32? defaultCountryId, System.Int32? defaultLocationId, System.Int32? width, System.Int32? height, System.Boolean? onAdvancedSearch, ref System.Int32? widgetId);
		
		#endregion
		
		#region WidgetContainers_GetByDefaultLocationId 
		
		
		
		/// <summary>
		///	This method wrap the 'WidgetContainers_GetByDefaultLocationId' stored procedure. 
		/// </summary>
		/// <param name="defaultLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WidgetContainers&gt;"/> instance.</returns>
		public TList<WidgetContainers> GetByDefaultLocationId(int start, int pageLength, System.Int32? defaultLocationId)
		{
			return GetByDefaultLocationId(null, start, pageLength , defaultLocationId);
		}
				
		
		
		/// <summary>
		///	This method wrap the 'WidgetContainers_GetByDefaultLocationId' stored procedure. 
		/// </summary>
		/// <param name="defaultLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WidgetContainers&gt;"/> instance.</returns>
		public abstract TList<WidgetContainers> GetByDefaultLocationId(TransactionManager transactionManager, int start, int pageLength , System.Int32? defaultLocationId);
		
		#endregion
		
		#region WidgetContainers_GetBySiteId 
		
		/// <summary>
		///	This method wrap the 'WidgetContainers_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WidgetContainers&gt;"/> instance.</returns>
		public TList<WidgetContainers> GetBySiteId(System.Int32? siteId)
		{
			return GetBySiteId(null, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'WidgetContainers_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WidgetContainers&gt;"/> instance.</returns>
		public TList<WidgetContainers> GetBySiteId(int start, int pageLength, System.Int32? siteId)
		{
			return GetBySiteId(null, start, pageLength , siteId);
		}
				
		/// <summary>
		///	This method wrap the 'WidgetContainers_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WidgetContainers&gt;"/> instance.</returns>
		public TList<WidgetContainers> GetBySiteId(TransactionManager transactionManager, System.Int32? siteId)
		{
			return GetBySiteId(transactionManager, 0, int.MaxValue , siteId);
		}
		
		/// <summary>
		///	This method wrap the 'WidgetContainers_GetBySiteId' stored procedure. 
		/// </summary>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WidgetContainers&gt;"/> instance.</returns>
		public abstract TList<WidgetContainers> GetBySiteId(TransactionManager transactionManager, int start, int pageLength , System.Int32? siteId);
		
		#endregion
		
		#region WidgetContainers_Get_List 
		
		/// <summary>
		///	This method wrap the 'WidgetContainers_Get_List' stored procedure. 
		/// </summary>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WidgetContainers&gt;"/> instance.</returns>
		public TList<WidgetContainers> Get_List()
		{
			return Get_List(null, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'WidgetContainers_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WidgetContainers&gt;"/> instance.</returns>
		public TList<WidgetContainers> Get_List(int start, int pageLength)
		{
			return Get_List(null, start, pageLength );
		}
				
		/// <summary>
		///	This method wrap the 'WidgetContainers_Get_List' stored procedure. 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WidgetContainers&gt;"/> instance.</returns>
		public TList<WidgetContainers> Get_List(TransactionManager transactionManager)
		{
			return Get_List(transactionManager, 0, int.MaxValue );
		}
		
		/// <summary>
		///	This method wrap the 'WidgetContainers_Get_List' stored procedure. 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WidgetContainers&gt;"/> instance.</returns>
		public abstract TList<WidgetContainers> Get_List(TransactionManager transactionManager, int start, int pageLength );
		
		#endregion
		
		#region WidgetContainers_GetByDefaultProfessionId 
		
		/// <summary>
		///	This method wrap the 'WidgetContainers_GetByDefaultProfessionId' stored procedure. 
		/// </summary>
		/// <param name="defaultProfessionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WidgetContainers&gt;"/> instance.</returns>
		public TList<WidgetContainers> GetByDefaultProfessionId(int start, int pageLength, System.Int32? defaultProfessionId)
		{
			return GetByDefaultProfessionId(null, start, pageLength , defaultProfessionId);
		}
				
		
		
		/// <summary>
		///	This method wrap the 'WidgetContainers_GetByDefaultProfessionId' stored procedure. 
		/// </summary>
		/// <param name="defaultProfessionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WidgetContainers&gt;"/> instance.</returns>
		public abstract TList<WidgetContainers> GetByDefaultProfessionId(TransactionManager transactionManager, int start, int pageLength , System.Int32? defaultProfessionId);
		
		#endregion
		
		#region WidgetContainers_GetByWidgetId 
		
		/// <summary>
		///	This method wrap the 'WidgetContainers_GetByWidgetId' stored procedure. 
		/// </summary>
		/// <param name="widgetId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WidgetContainers&gt;"/> instance.</returns>
		public TList<WidgetContainers> GetByWidgetId(System.Int32? widgetId)
		{
			return GetByWidgetId(null, 0, int.MaxValue , widgetId);
		}
		
		/// <summary>
		///	This method wrap the 'WidgetContainers_GetByWidgetId' stored procedure. 
		/// </summary>
		/// <param name="widgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WidgetContainers&gt;"/> instance.</returns>
		public TList<WidgetContainers> GetByWidgetId(int start, int pageLength, System.Int32? widgetId)
		{
			return GetByWidgetId(null, start, pageLength , widgetId);
		}
				
		/// <summary>
		///	This method wrap the 'WidgetContainers_GetByWidgetId' stored procedure. 
		/// </summary>
		/// <param name="widgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WidgetContainers&gt;"/> instance.</returns>
		public TList<WidgetContainers> GetByWidgetId(TransactionManager transactionManager, System.Int32? widgetId)
		{
			return GetByWidgetId(transactionManager, 0, int.MaxValue , widgetId);
		}
		
		/// <summary>
		///	This method wrap the 'WidgetContainers_GetByWidgetId' stored procedure. 
		/// </summary>
		/// <param name="widgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WidgetContainers&gt;"/> instance.</returns>
		public abstract TList<WidgetContainers> GetByWidgetId(TransactionManager transactionManager, int start, int pageLength , System.Int32? widgetId);
		
		#endregion
		
		#region WidgetContainers_GetByDefaultCountryId 
		
		/// <summary>
		///	This method wrap the 'WidgetContainers_GetByDefaultCountryId' stored procedure. 
		/// </summary>
		/// <param name="defaultCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WidgetContainers&gt;"/> instance.</returns>
		public TList<WidgetContainers> GetByDefaultCountryId(int start, int pageLength, System.Int32? defaultCountryId)
		{
			return GetByDefaultCountryId(null, start, pageLength , defaultCountryId);
		}
				
		
		
		/// <summary>
		///	This method wrap the 'WidgetContainers_GetByDefaultCountryId' stored procedure. 
		/// </summary>
		/// <param name="defaultCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WidgetContainers&gt;"/> instance.</returns>
		public abstract TList<WidgetContainers> GetByDefaultCountryId(TransactionManager transactionManager, int start, int pageLength , System.Int32? defaultCountryId);
		
		#endregion
		
		#region WidgetContainers_Find 
		
		/// <summary>
		///	This method wrap the 'WidgetContainers_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="widgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="widgetName"> A <c>System.String</c> instance.</param>
		/// <param name="widgetDomain"> A <c>System.String</c> instance.</param>
		/// <param name="widgetContainerClass"> A <c>System.String</c> instance.</param>
		/// <param name="widgetContainerHeaderClass"> A <c>System.String</c> instance.</param>
		/// <param name="widgetItemClass"> A <c>System.String</c> instance.</param>
		/// <param name="widgetJobLinkCss"> A <c>System.String</c> instance.</param>
		/// <param name="widgetItemLinkImageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showJobs"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showCompanies"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showSite"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showPeople"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobHtml"> A <c>System.String</c> instance.</param>
		/// <param name="companyHtml"> A <c>System.String</c> instance.</param>
		/// <param name="siteHtml"> A <c>System.String</c> instance.</param>
		/// <param name="peopleHtml"> A <c>System.String</c> instance.</param>
		/// <param name="javascript"> A <c>System.String</c> instance.</param>
		/// <param name="searchCss"> A <c>System.String</c> instance.</param>
		/// <param name="defaultProfessionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="width"> A <c>System.Int32?</c> instance.</param>
		/// <param name="height"> A <c>System.Int32?</c> instance.</param>
		/// <param name="onAdvancedSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WidgetContainers&gt;"/> instance.</returns>
		public TList<WidgetContainers> Find(System.Boolean? searchUsingOr, System.Int32? widgetId, System.Int32? siteId, System.Int32? languageId, System.String widgetName, System.String widgetDomain, System.String widgetContainerClass, System.String widgetContainerHeaderClass, System.String widgetItemClass, System.String widgetJobLinkCss, System.Int32? widgetItemLinkImageId, System.Boolean? valid, System.Boolean? showJobs, System.Boolean? showCompanies, System.Boolean? showSite, System.Boolean? showPeople, System.String jobHtml, System.String companyHtml, System.String siteHtml, System.String peopleHtml, System.String javascript, System.String searchCss, System.Int32? defaultProfessionId, System.Int32? defaultCountryId, System.Int32? defaultLocationId, System.Int32? width, System.Int32? height, System.Boolean? onAdvancedSearch)
		{
			return Find(null, 0, int.MaxValue , searchUsingOr, widgetId, siteId, languageId, widgetName, widgetDomain, widgetContainerClass, widgetContainerHeaderClass, widgetItemClass, widgetJobLinkCss, widgetItemLinkImageId, valid, showJobs, showCompanies, showSite, showPeople, jobHtml, companyHtml, siteHtml, peopleHtml, javascript, searchCss, defaultProfessionId, defaultCountryId, defaultLocationId, width, height, onAdvancedSearch);
		}
		
		/// <summary>
		///	This method wrap the 'WidgetContainers_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="widgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="widgetName"> A <c>System.String</c> instance.</param>
		/// <param name="widgetDomain"> A <c>System.String</c> instance.</param>
		/// <param name="widgetContainerClass"> A <c>System.String</c> instance.</param>
		/// <param name="widgetContainerHeaderClass"> A <c>System.String</c> instance.</param>
		/// <param name="widgetItemClass"> A <c>System.String</c> instance.</param>
		/// <param name="widgetJobLinkCss"> A <c>System.String</c> instance.</param>
		/// <param name="widgetItemLinkImageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showJobs"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showCompanies"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showSite"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showPeople"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobHtml"> A <c>System.String</c> instance.</param>
		/// <param name="companyHtml"> A <c>System.String</c> instance.</param>
		/// <param name="siteHtml"> A <c>System.String</c> instance.</param>
		/// <param name="peopleHtml"> A <c>System.String</c> instance.</param>
		/// <param name="javascript"> A <c>System.String</c> instance.</param>
		/// <param name="searchCss"> A <c>System.String</c> instance.</param>
		/// <param name="defaultProfessionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="width"> A <c>System.Int32?</c> instance.</param>
		/// <param name="height"> A <c>System.Int32?</c> instance.</param>
		/// <param name="onAdvancedSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WidgetContainers&gt;"/> instance.</returns>
		public TList<WidgetContainers> Find(int start, int pageLength, System.Boolean? searchUsingOr, System.Int32? widgetId, System.Int32? siteId, System.Int32? languageId, System.String widgetName, System.String widgetDomain, System.String widgetContainerClass, System.String widgetContainerHeaderClass, System.String widgetItemClass, System.String widgetJobLinkCss, System.Int32? widgetItemLinkImageId, System.Boolean? valid, System.Boolean? showJobs, System.Boolean? showCompanies, System.Boolean? showSite, System.Boolean? showPeople, System.String jobHtml, System.String companyHtml, System.String siteHtml, System.String peopleHtml, System.String javascript, System.String searchCss, System.Int32? defaultProfessionId, System.Int32? defaultCountryId, System.Int32? defaultLocationId, System.Int32? width, System.Int32? height, System.Boolean? onAdvancedSearch)
		{
			return Find(null, start, pageLength , searchUsingOr, widgetId, siteId, languageId, widgetName, widgetDomain, widgetContainerClass, widgetContainerHeaderClass, widgetItemClass, widgetJobLinkCss, widgetItemLinkImageId, valid, showJobs, showCompanies, showSite, showPeople, jobHtml, companyHtml, siteHtml, peopleHtml, javascript, searchCss, defaultProfessionId, defaultCountryId, defaultLocationId, width, height, onAdvancedSearch);
		}
				
		/// <summary>
		///	This method wrap the 'WidgetContainers_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="widgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="widgetName"> A <c>System.String</c> instance.</param>
		/// <param name="widgetDomain"> A <c>System.String</c> instance.</param>
		/// <param name="widgetContainerClass"> A <c>System.String</c> instance.</param>
		/// <param name="widgetContainerHeaderClass"> A <c>System.String</c> instance.</param>
		/// <param name="widgetItemClass"> A <c>System.String</c> instance.</param>
		/// <param name="widgetJobLinkCss"> A <c>System.String</c> instance.</param>
		/// <param name="widgetItemLinkImageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showJobs"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showCompanies"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showSite"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showPeople"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobHtml"> A <c>System.String</c> instance.</param>
		/// <param name="companyHtml"> A <c>System.String</c> instance.</param>
		/// <param name="siteHtml"> A <c>System.String</c> instance.</param>
		/// <param name="peopleHtml"> A <c>System.String</c> instance.</param>
		/// <param name="javascript"> A <c>System.String</c> instance.</param>
		/// <param name="searchCss"> A <c>System.String</c> instance.</param>
		/// <param name="defaultProfessionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="width"> A <c>System.Int32?</c> instance.</param>
		/// <param name="height"> A <c>System.Int32?</c> instance.</param>
		/// <param name="onAdvancedSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WidgetContainers&gt;"/> instance.</returns>
		public TList<WidgetContainers> Find(TransactionManager transactionManager, System.Boolean? searchUsingOr, System.Int32? widgetId, System.Int32? siteId, System.Int32? languageId, System.String widgetName, System.String widgetDomain, System.String widgetContainerClass, System.String widgetContainerHeaderClass, System.String widgetItemClass, System.String widgetJobLinkCss, System.Int32? widgetItemLinkImageId, System.Boolean? valid, System.Boolean? showJobs, System.Boolean? showCompanies, System.Boolean? showSite, System.Boolean? showPeople, System.String jobHtml, System.String companyHtml, System.String siteHtml, System.String peopleHtml, System.String javascript, System.String searchCss, System.Int32? defaultProfessionId, System.Int32? defaultCountryId, System.Int32? defaultLocationId, System.Int32? width, System.Int32? height, System.Boolean? onAdvancedSearch)
		{
			return Find(transactionManager, 0, int.MaxValue , searchUsingOr, widgetId, siteId, languageId, widgetName, widgetDomain, widgetContainerClass, widgetContainerHeaderClass, widgetItemClass, widgetJobLinkCss, widgetItemLinkImageId, valid, showJobs, showCompanies, showSite, showPeople, jobHtml, companyHtml, siteHtml, peopleHtml, javascript, searchCss, defaultProfessionId, defaultCountryId, defaultLocationId, width, height, onAdvancedSearch);
		}
		
		/// <summary>
		///	This method wrap the 'WidgetContainers_Find' stored procedure. 
		/// </summary>
		/// <param name="searchUsingOr"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="widgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="widgetName"> A <c>System.String</c> instance.</param>
		/// <param name="widgetDomain"> A <c>System.String</c> instance.</param>
		/// <param name="widgetContainerClass"> A <c>System.String</c> instance.</param>
		/// <param name="widgetContainerHeaderClass"> A <c>System.String</c> instance.</param>
		/// <param name="widgetItemClass"> A <c>System.String</c> instance.</param>
		/// <param name="widgetJobLinkCss"> A <c>System.String</c> instance.</param>
		/// <param name="widgetItemLinkImageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showJobs"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showCompanies"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showSite"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showPeople"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobHtml"> A <c>System.String</c> instance.</param>
		/// <param name="companyHtml"> A <c>System.String</c> instance.</param>
		/// <param name="siteHtml"> A <c>System.String</c> instance.</param>
		/// <param name="peopleHtml"> A <c>System.String</c> instance.</param>
		/// <param name="javascript"> A <c>System.String</c> instance.</param>
		/// <param name="searchCss"> A <c>System.String</c> instance.</param>
		/// <param name="defaultProfessionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="width"> A <c>System.Int32?</c> instance.</param>
		/// <param name="height"> A <c>System.Int32?</c> instance.</param>
		/// <param name="onAdvancedSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WidgetContainers&gt;"/> instance.</returns>
		public abstract TList<WidgetContainers> Find(TransactionManager transactionManager, int start, int pageLength , System.Boolean? searchUsingOr, System.Int32? widgetId, System.Int32? siteId, System.Int32? languageId, System.String widgetName, System.String widgetDomain, System.String widgetContainerClass, System.String widgetContainerHeaderClass, System.String widgetItemClass, System.String widgetJobLinkCss, System.Int32? widgetItemLinkImageId, System.Boolean? valid, System.Boolean? showJobs, System.Boolean? showCompanies, System.Boolean? showSite, System.Boolean? showPeople, System.String jobHtml, System.String companyHtml, System.String siteHtml, System.String peopleHtml, System.String javascript, System.String searchCss, System.Int32? defaultProfessionId, System.Int32? defaultCountryId, System.Int32? defaultLocationId, System.Int32? width, System.Int32? height, System.Boolean? onAdvancedSearch);
		
		#endregion
		
		#region WidgetContainers_GetByLanguageId 
		
		/// <summary>
		///	This method wrap the 'WidgetContainers_GetByLanguageId' stored procedure. 
		/// </summary>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WidgetContainers&gt;"/> instance.</returns>
		public TList<WidgetContainers> GetByLanguageId(System.Int32? languageId)
		{
			return GetByLanguageId(null, 0, int.MaxValue , languageId);
		}
		
		/// <summary>
		///	This method wrap the 'WidgetContainers_GetByLanguageId' stored procedure. 
		/// </summary>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WidgetContainers&gt;"/> instance.</returns>
		public TList<WidgetContainers> GetByLanguageId(int start, int pageLength, System.Int32? languageId)
		{
			return GetByLanguageId(null, start, pageLength , languageId);
		}
				
		/// <summary>
		///	This method wrap the 'WidgetContainers_GetByLanguageId' stored procedure. 
		/// </summary>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WidgetContainers&gt;"/> instance.</returns>
		public TList<WidgetContainers> GetByLanguageId(TransactionManager transactionManager, System.Int32? languageId)
		{
			return GetByLanguageId(transactionManager, 0, int.MaxValue , languageId);
		}
		
		/// <summary>
		///	This method wrap the 'WidgetContainers_GetByLanguageId' stored procedure. 
		/// </summary>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WidgetContainers&gt;"/> instance.</returns>
		public abstract TList<WidgetContainers> GetByLanguageId(TransactionManager transactionManager, int start, int pageLength , System.Int32? languageId);
		
		#endregion
		
		#region WidgetContainers_GetPaged 
		
		/// <summary>
		///	This method wrap the 'WidgetContainers_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WidgetContainers&gt;"/> instance.</returns>
		public TList<WidgetContainers> GetPaged(System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'WidgetContainers_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WidgetContainers&gt;"/> instance.</returns>
		public TList<WidgetContainers> GetPaged(int start, int pageLength, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(null, start, pageLength , whereClause, orderBy, pageIndex, pageSize);
		}
				
		/// <summary>
		///	This method wrap the 'WidgetContainers_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WidgetContainers&gt;"/> instance.</returns>
		public TList<WidgetContainers> GetPaged(TransactionManager transactionManager, System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize)
		{
			return GetPaged(transactionManager, 0, int.MaxValue , whereClause, orderBy, pageIndex, pageSize);
		}
		
		/// <summary>
		///	This method wrap the 'WidgetContainers_GetPaged' stored procedure. 
		/// </summary>
		/// <param name="whereClause"> A <c>System.String</c> instance.</param>
		/// <param name="orderBy"> A <c>System.String</c> instance.</param>
		/// <param name="pageIndex"> A <c>System.Int32?</c> instance.</param>
		/// <param name="pageSize"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		/// <returns>A <see cref="TList&lt;WidgetContainers&gt;"/> instance.</returns>
		public abstract TList<WidgetContainers> GetPaged(TransactionManager transactionManager, int start, int pageLength , System.String whereClause, System.String orderBy, System.Int32? pageIndex, System.Int32? pageSize);
		
		#endregion
		
		#region WidgetContainers_Update 
		
		/// <summary>
		///	This method wrap the 'WidgetContainers_Update' stored procedure. 
		/// </summary>
		/// <param name="widgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="widgetName"> A <c>System.String</c> instance.</param>
		/// <param name="widgetDomain"> A <c>System.String</c> instance.</param>
		/// <param name="widgetContainerClass"> A <c>System.String</c> instance.</param>
		/// <param name="widgetContainerHeaderClass"> A <c>System.String</c> instance.</param>
		/// <param name="widgetItemClass"> A <c>System.String</c> instance.</param>
		/// <param name="widgetJobLinkCss"> A <c>System.String</c> instance.</param>
		/// <param name="widgetItemLinkImageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showJobs"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showCompanies"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showSite"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showPeople"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobHtml"> A <c>System.String</c> instance.</param>
		/// <param name="companyHtml"> A <c>System.String</c> instance.</param>
		/// <param name="siteHtml"> A <c>System.String</c> instance.</param>
		/// <param name="peopleHtml"> A <c>System.String</c> instance.</param>
		/// <param name="javascript"> A <c>System.String</c> instance.</param>
		/// <param name="searchCss"> A <c>System.String</c> instance.</param>
		/// <param name="defaultProfessionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="width"> A <c>System.Int32?</c> instance.</param>
		/// <param name="height"> A <c>System.Int32?</c> instance.</param>
		/// <param name="onAdvancedSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(System.Int32? widgetId, System.Int32? siteId, System.Int32? languageId, System.String widgetName, System.String widgetDomain, System.String widgetContainerClass, System.String widgetContainerHeaderClass, System.String widgetItemClass, System.String widgetJobLinkCss, System.Int32? widgetItemLinkImageId, System.Boolean? valid, System.Boolean? showJobs, System.Boolean? showCompanies, System.Boolean? showSite, System.Boolean? showPeople, System.String jobHtml, System.String companyHtml, System.String siteHtml, System.String peopleHtml, System.String javascript, System.String searchCss, System.Int32? defaultProfessionId, System.Int32? defaultCountryId, System.Int32? defaultLocationId, System.Int32? width, System.Int32? height, System.Boolean? onAdvancedSearch)
		{
			 Update(null, 0, int.MaxValue , widgetId, siteId, languageId, widgetName, widgetDomain, widgetContainerClass, widgetContainerHeaderClass, widgetItemClass, widgetJobLinkCss, widgetItemLinkImageId, valid, showJobs, showCompanies, showSite, showPeople, jobHtml, companyHtml, siteHtml, peopleHtml, javascript, searchCss, defaultProfessionId, defaultCountryId, defaultLocationId, width, height, onAdvancedSearch);
		}
		
		/// <summary>
		///	This method wrap the 'WidgetContainers_Update' stored procedure. 
		/// </summary>
		/// <param name="widgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="widgetName"> A <c>System.String</c> instance.</param>
		/// <param name="widgetDomain"> A <c>System.String</c> instance.</param>
		/// <param name="widgetContainerClass"> A <c>System.String</c> instance.</param>
		/// <param name="widgetContainerHeaderClass"> A <c>System.String</c> instance.</param>
		/// <param name="widgetItemClass"> A <c>System.String</c> instance.</param>
		/// <param name="widgetJobLinkCss"> A <c>System.String</c> instance.</param>
		/// <param name="widgetItemLinkImageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showJobs"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showCompanies"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showSite"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showPeople"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobHtml"> A <c>System.String</c> instance.</param>
		/// <param name="companyHtml"> A <c>System.String</c> instance.</param>
		/// <param name="siteHtml"> A <c>System.String</c> instance.</param>
		/// <param name="peopleHtml"> A <c>System.String</c> instance.</param>
		/// <param name="javascript"> A <c>System.String</c> instance.</param>
		/// <param name="searchCss"> A <c>System.String</c> instance.</param>
		/// <param name="defaultProfessionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="width"> A <c>System.Int32?</c> instance.</param>
		/// <param name="height"> A <c>System.Int32?</c> instance.</param>
		/// <param name="onAdvancedSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(int start, int pageLength, System.Int32? widgetId, System.Int32? siteId, System.Int32? languageId, System.String widgetName, System.String widgetDomain, System.String widgetContainerClass, System.String widgetContainerHeaderClass, System.String widgetItemClass, System.String widgetJobLinkCss, System.Int32? widgetItemLinkImageId, System.Boolean? valid, System.Boolean? showJobs, System.Boolean? showCompanies, System.Boolean? showSite, System.Boolean? showPeople, System.String jobHtml, System.String companyHtml, System.String siteHtml, System.String peopleHtml, System.String javascript, System.String searchCss, System.Int32? defaultProfessionId, System.Int32? defaultCountryId, System.Int32? defaultLocationId, System.Int32? width, System.Int32? height, System.Boolean? onAdvancedSearch)
		{
			 Update(null, start, pageLength , widgetId, siteId, languageId, widgetName, widgetDomain, widgetContainerClass, widgetContainerHeaderClass, widgetItemClass, widgetJobLinkCss, widgetItemLinkImageId, valid, showJobs, showCompanies, showSite, showPeople, jobHtml, companyHtml, siteHtml, peopleHtml, javascript, searchCss, defaultProfessionId, defaultCountryId, defaultLocationId, width, height, onAdvancedSearch);
		}
				
		/// <summary>
		///	This method wrap the 'WidgetContainers_Update' stored procedure. 
		/// </summary>
		/// <param name="widgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="widgetName"> A <c>System.String</c> instance.</param>
		/// <param name="widgetDomain"> A <c>System.String</c> instance.</param>
		/// <param name="widgetContainerClass"> A <c>System.String</c> instance.</param>
		/// <param name="widgetContainerHeaderClass"> A <c>System.String</c> instance.</param>
		/// <param name="widgetItemClass"> A <c>System.String</c> instance.</param>
		/// <param name="widgetJobLinkCss"> A <c>System.String</c> instance.</param>
		/// <param name="widgetItemLinkImageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showJobs"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showCompanies"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showSite"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showPeople"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobHtml"> A <c>System.String</c> instance.</param>
		/// <param name="companyHtml"> A <c>System.String</c> instance.</param>
		/// <param name="siteHtml"> A <c>System.String</c> instance.</param>
		/// <param name="peopleHtml"> A <c>System.String</c> instance.</param>
		/// <param name="javascript"> A <c>System.String</c> instance.</param>
		/// <param name="searchCss"> A <c>System.String</c> instance.</param>
		/// <param name="defaultProfessionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="width"> A <c>System.Int32?</c> instance.</param>
		/// <param name="height"> A <c>System.Int32?</c> instance.</param>
		/// <param name="onAdvancedSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Update(TransactionManager transactionManager, System.Int32? widgetId, System.Int32? siteId, System.Int32? languageId, System.String widgetName, System.String widgetDomain, System.String widgetContainerClass, System.String widgetContainerHeaderClass, System.String widgetItemClass, System.String widgetJobLinkCss, System.Int32? widgetItemLinkImageId, System.Boolean? valid, System.Boolean? showJobs, System.Boolean? showCompanies, System.Boolean? showSite, System.Boolean? showPeople, System.String jobHtml, System.String companyHtml, System.String siteHtml, System.String peopleHtml, System.String javascript, System.String searchCss, System.Int32? defaultProfessionId, System.Int32? defaultCountryId, System.Int32? defaultLocationId, System.Int32? width, System.Int32? height, System.Boolean? onAdvancedSearch)
		{
			 Update(transactionManager, 0, int.MaxValue , widgetId, siteId, languageId, widgetName, widgetDomain, widgetContainerClass, widgetContainerHeaderClass, widgetItemClass, widgetJobLinkCss, widgetItemLinkImageId, valid, showJobs, showCompanies, showSite, showPeople, jobHtml, companyHtml, siteHtml, peopleHtml, javascript, searchCss, defaultProfessionId, defaultCountryId, defaultLocationId, width, height, onAdvancedSearch);
		}
		
		/// <summary>
		///	This method wrap the 'WidgetContainers_Update' stored procedure. 
		/// </summary>
		/// <param name="widgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="siteId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="languageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="widgetName"> A <c>System.String</c> instance.</param>
		/// <param name="widgetDomain"> A <c>System.String</c> instance.</param>
		/// <param name="widgetContainerClass"> A <c>System.String</c> instance.</param>
		/// <param name="widgetContainerHeaderClass"> A <c>System.String</c> instance.</param>
		/// <param name="widgetItemClass"> A <c>System.String</c> instance.</param>
		/// <param name="widgetJobLinkCss"> A <c>System.String</c> instance.</param>
		/// <param name="widgetItemLinkImageId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="valid"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showJobs"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showCompanies"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showSite"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="showPeople"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="jobHtml"> A <c>System.String</c> instance.</param>
		/// <param name="companyHtml"> A <c>System.String</c> instance.</param>
		/// <param name="siteHtml"> A <c>System.String</c> instance.</param>
		/// <param name="peopleHtml"> A <c>System.String</c> instance.</param>
		/// <param name="javascript"> A <c>System.String</c> instance.</param>
		/// <param name="searchCss"> A <c>System.String</c> instance.</param>
		/// <param name="defaultProfessionId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultCountryId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="defaultLocationId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="width"> A <c>System.Int32?</c> instance.</param>
		/// <param name="height"> A <c>System.Int32?</c> instance.</param>
		/// <param name="onAdvancedSearch"> A <c>System.Boolean?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Update(TransactionManager transactionManager, int start, int pageLength , System.Int32? widgetId, System.Int32? siteId, System.Int32? languageId, System.String widgetName, System.String widgetDomain, System.String widgetContainerClass, System.String widgetContainerHeaderClass, System.String widgetItemClass, System.String widgetJobLinkCss, System.Int32? widgetItemLinkImageId, System.Boolean? valid, System.Boolean? showJobs, System.Boolean? showCompanies, System.Boolean? showSite, System.Boolean? showPeople, System.String jobHtml, System.String companyHtml, System.String siteHtml, System.String peopleHtml, System.String javascript, System.String searchCss, System.Int32? defaultProfessionId, System.Int32? defaultCountryId, System.Int32? defaultLocationId, System.Int32? width, System.Int32? height, System.Boolean? onAdvancedSearch);
		
		#endregion
		
		#region WidgetContainers_Delete 
		
		/// <summary>
		///	This method wrap the 'WidgetContainers_Delete' stored procedure. 
		/// </summary>
		/// <param name="widgetId"> A <c>System.Int32?</c> instance.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(System.Int32? widgetId)
		{
			 Delete(null, 0, int.MaxValue , widgetId);
		}
		
		/// <summary>
		///	This method wrap the 'WidgetContainers_Delete' stored procedure. 
		/// </summary>
		/// <param name="widgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(int start, int pageLength, System.Int32? widgetId)
		{
			 Delete(null, start, pageLength , widgetId);
		}
				
		/// <summary>
		///	This method wrap the 'WidgetContainers_Delete' stored procedure. 
		/// </summary>
		/// <param name="widgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public void Delete(TransactionManager transactionManager, System.Int32? widgetId)
		{
			 Delete(transactionManager, 0, int.MaxValue , widgetId);
		}
		
		/// <summary>
		///	This method wrap the 'WidgetContainers_Delete' stored procedure. 
		/// </summary>
		/// <param name="widgetId"> A <c>System.Int32?</c> instance.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remark>This method is generate from a stored procedure.</remark>
		public abstract void Delete(TransactionManager transactionManager, int start, int pageLength , System.Int32? widgetId);
		
		#endregion
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a TList&lt;WidgetContainers&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="TList&lt;WidgetContainers&gt;"/></returns>
		public static TList<WidgetContainers> Fill(IDataReader reader, TList<WidgetContainers> rows, int start, int pageLength)
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
				
				JXTPortal.Entities.WidgetContainers c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("WidgetContainers")
					.Append("|").Append((System.Int32)reader[((int)WidgetContainersColumn.WidgetId - 1)]).ToString();
					c = EntityManager.LocateOrCreate<WidgetContainers>(
					key.ToString(), // EntityTrackingKey
					"WidgetContainers",  //Creational Type
					entityCreationFactoryType,  //Factory used to create entity
					enableEntityTracking); // Track this entity?
				}
				else
				{
					c = new JXTPortal.Entities.WidgetContainers();
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
					c.WidgetId = (System.Int32)reader[((int)WidgetContainersColumn.WidgetId - 1)];
					c.SiteId = (System.Int32)reader[((int)WidgetContainersColumn.SiteId - 1)];
					c.LanguageId = (System.Int32)reader[((int)WidgetContainersColumn.LanguageId - 1)];
					c.WidgetName = (reader.IsDBNull(((int)WidgetContainersColumn.WidgetName - 1)))?null:(System.String)reader[((int)WidgetContainersColumn.WidgetName - 1)];
					c.WidgetDomain = (reader.IsDBNull(((int)WidgetContainersColumn.WidgetDomain - 1)))?null:(System.String)reader[((int)WidgetContainersColumn.WidgetDomain - 1)];
					c.WidgetContainerClass = (reader.IsDBNull(((int)WidgetContainersColumn.WidgetContainerClass - 1)))?null:(System.String)reader[((int)WidgetContainersColumn.WidgetContainerClass - 1)];
					c.WidgetContainerHeaderClass = (reader.IsDBNull(((int)WidgetContainersColumn.WidgetContainerHeaderClass - 1)))?null:(System.String)reader[((int)WidgetContainersColumn.WidgetContainerHeaderClass - 1)];
					c.WidgetItemClass = (reader.IsDBNull(((int)WidgetContainersColumn.WidgetItemClass - 1)))?null:(System.String)reader[((int)WidgetContainersColumn.WidgetItemClass - 1)];
					c.WidgetJobLinkCss = (reader.IsDBNull(((int)WidgetContainersColumn.WidgetJobLinkCss - 1)))?null:(System.String)reader[((int)WidgetContainersColumn.WidgetJobLinkCss - 1)];
					c.WidgetItemLinkImageId = (reader.IsDBNull(((int)WidgetContainersColumn.WidgetItemLinkImageId - 1)))?null:(System.Int32?)reader[((int)WidgetContainersColumn.WidgetItemLinkImageId - 1)];
					c.Valid = (reader.IsDBNull(((int)WidgetContainersColumn.Valid - 1)))?null:(System.Boolean?)reader[((int)WidgetContainersColumn.Valid - 1)];
					c.ShowJobs = (reader.IsDBNull(((int)WidgetContainersColumn.ShowJobs - 1)))?null:(System.Boolean?)reader[((int)WidgetContainersColumn.ShowJobs - 1)];
					c.ShowCompanies = (reader.IsDBNull(((int)WidgetContainersColumn.ShowCompanies - 1)))?null:(System.Boolean?)reader[((int)WidgetContainersColumn.ShowCompanies - 1)];
					c.ShowSite = (reader.IsDBNull(((int)WidgetContainersColumn.ShowSite - 1)))?null:(System.Boolean?)reader[((int)WidgetContainersColumn.ShowSite - 1)];
					c.ShowPeople = (reader.IsDBNull(((int)WidgetContainersColumn.ShowPeople - 1)))?null:(System.Boolean?)reader[((int)WidgetContainersColumn.ShowPeople - 1)];
					c.JobHtml = (reader.IsDBNull(((int)WidgetContainersColumn.JobHtml - 1)))?null:(System.String)reader[((int)WidgetContainersColumn.JobHtml - 1)];
					c.CompanyHtml = (reader.IsDBNull(((int)WidgetContainersColumn.CompanyHtml - 1)))?null:(System.String)reader[((int)WidgetContainersColumn.CompanyHtml - 1)];
					c.SiteHtml = (reader.IsDBNull(((int)WidgetContainersColumn.SiteHtml - 1)))?null:(System.String)reader[((int)WidgetContainersColumn.SiteHtml - 1)];
					c.PeopleHtml = (reader.IsDBNull(((int)WidgetContainersColumn.PeopleHtml - 1)))?null:(System.String)reader[((int)WidgetContainersColumn.PeopleHtml - 1)];
					c.Javascript = (reader.IsDBNull(((int)WidgetContainersColumn.Javascript - 1)))?null:(System.String)reader[((int)WidgetContainersColumn.Javascript - 1)];
					c.SearchCss = (reader.IsDBNull(((int)WidgetContainersColumn.SearchCss - 1)))?null:(System.String)reader[((int)WidgetContainersColumn.SearchCss - 1)];
					c.DefaultProfessionId = (reader.IsDBNull(((int)WidgetContainersColumn.DefaultProfessionId - 1)))?null:(System.Int32?)reader[((int)WidgetContainersColumn.DefaultProfessionId - 1)];
					c.DefaultCountryId = (reader.IsDBNull(((int)WidgetContainersColumn.DefaultCountryId - 1)))?null:(System.Int32?)reader[((int)WidgetContainersColumn.DefaultCountryId - 1)];
					c.DefaultLocationId = (reader.IsDBNull(((int)WidgetContainersColumn.DefaultLocationId - 1)))?null:(System.Int32?)reader[((int)WidgetContainersColumn.DefaultLocationId - 1)];
					c.Width = (reader.IsDBNull(((int)WidgetContainersColumn.Width - 1)))?null:(System.Int32?)reader[((int)WidgetContainersColumn.Width - 1)];
					c.Height = (reader.IsDBNull(((int)WidgetContainersColumn.Height - 1)))?null:(System.Int32?)reader[((int)WidgetContainersColumn.Height - 1)];
					c.OnAdvancedSearch = (reader.IsDBNull(((int)WidgetContainersColumn.OnAdvancedSearch - 1)))?null:(System.Boolean?)reader[((int)WidgetContainersColumn.OnAdvancedSearch - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.WidgetContainers"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.WidgetContainers"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, JXTPortal.Entities.WidgetContainers entity)
		{
			if (!reader.Read()) return;
			
			entity.WidgetId = (System.Int32)reader[((int)WidgetContainersColumn.WidgetId - 1)];
			entity.SiteId = (System.Int32)reader[((int)WidgetContainersColumn.SiteId - 1)];
			entity.LanguageId = (System.Int32)reader[((int)WidgetContainersColumn.LanguageId - 1)];
			entity.WidgetName = (reader.IsDBNull(((int)WidgetContainersColumn.WidgetName - 1)))?null:(System.String)reader[((int)WidgetContainersColumn.WidgetName - 1)];
			entity.WidgetDomain = (reader.IsDBNull(((int)WidgetContainersColumn.WidgetDomain - 1)))?null:(System.String)reader[((int)WidgetContainersColumn.WidgetDomain - 1)];
			entity.WidgetContainerClass = (reader.IsDBNull(((int)WidgetContainersColumn.WidgetContainerClass - 1)))?null:(System.String)reader[((int)WidgetContainersColumn.WidgetContainerClass - 1)];
			entity.WidgetContainerHeaderClass = (reader.IsDBNull(((int)WidgetContainersColumn.WidgetContainerHeaderClass - 1)))?null:(System.String)reader[((int)WidgetContainersColumn.WidgetContainerHeaderClass - 1)];
			entity.WidgetItemClass = (reader.IsDBNull(((int)WidgetContainersColumn.WidgetItemClass - 1)))?null:(System.String)reader[((int)WidgetContainersColumn.WidgetItemClass - 1)];
			entity.WidgetJobLinkCss = (reader.IsDBNull(((int)WidgetContainersColumn.WidgetJobLinkCss - 1)))?null:(System.String)reader[((int)WidgetContainersColumn.WidgetJobLinkCss - 1)];
			entity.WidgetItemLinkImageId = (reader.IsDBNull(((int)WidgetContainersColumn.WidgetItemLinkImageId - 1)))?null:(System.Int32?)reader[((int)WidgetContainersColumn.WidgetItemLinkImageId - 1)];
			entity.Valid = (reader.IsDBNull(((int)WidgetContainersColumn.Valid - 1)))?null:(System.Boolean?)reader[((int)WidgetContainersColumn.Valid - 1)];
			entity.ShowJobs = (reader.IsDBNull(((int)WidgetContainersColumn.ShowJobs - 1)))?null:(System.Boolean?)reader[((int)WidgetContainersColumn.ShowJobs - 1)];
			entity.ShowCompanies = (reader.IsDBNull(((int)WidgetContainersColumn.ShowCompanies - 1)))?null:(System.Boolean?)reader[((int)WidgetContainersColumn.ShowCompanies - 1)];
			entity.ShowSite = (reader.IsDBNull(((int)WidgetContainersColumn.ShowSite - 1)))?null:(System.Boolean?)reader[((int)WidgetContainersColumn.ShowSite - 1)];
			entity.ShowPeople = (reader.IsDBNull(((int)WidgetContainersColumn.ShowPeople - 1)))?null:(System.Boolean?)reader[((int)WidgetContainersColumn.ShowPeople - 1)];
			entity.JobHtml = (reader.IsDBNull(((int)WidgetContainersColumn.JobHtml - 1)))?null:(System.String)reader[((int)WidgetContainersColumn.JobHtml - 1)];
			entity.CompanyHtml = (reader.IsDBNull(((int)WidgetContainersColumn.CompanyHtml - 1)))?null:(System.String)reader[((int)WidgetContainersColumn.CompanyHtml - 1)];
			entity.SiteHtml = (reader.IsDBNull(((int)WidgetContainersColumn.SiteHtml - 1)))?null:(System.String)reader[((int)WidgetContainersColumn.SiteHtml - 1)];
			entity.PeopleHtml = (reader.IsDBNull(((int)WidgetContainersColumn.PeopleHtml - 1)))?null:(System.String)reader[((int)WidgetContainersColumn.PeopleHtml - 1)];
			entity.Javascript = (reader.IsDBNull(((int)WidgetContainersColumn.Javascript - 1)))?null:(System.String)reader[((int)WidgetContainersColumn.Javascript - 1)];
			entity.SearchCss = (reader.IsDBNull(((int)WidgetContainersColumn.SearchCss - 1)))?null:(System.String)reader[((int)WidgetContainersColumn.SearchCss - 1)];
			entity.DefaultProfessionId = (reader.IsDBNull(((int)WidgetContainersColumn.DefaultProfessionId - 1)))?null:(System.Int32?)reader[((int)WidgetContainersColumn.DefaultProfessionId - 1)];
			entity.DefaultCountryId = (reader.IsDBNull(((int)WidgetContainersColumn.DefaultCountryId - 1)))?null:(System.Int32?)reader[((int)WidgetContainersColumn.DefaultCountryId - 1)];
			entity.DefaultLocationId = (reader.IsDBNull(((int)WidgetContainersColumn.DefaultLocationId - 1)))?null:(System.Int32?)reader[((int)WidgetContainersColumn.DefaultLocationId - 1)];
			entity.Width = (reader.IsDBNull(((int)WidgetContainersColumn.Width - 1)))?null:(System.Int32?)reader[((int)WidgetContainersColumn.Width - 1)];
			entity.Height = (reader.IsDBNull(((int)WidgetContainersColumn.Height - 1)))?null:(System.Int32?)reader[((int)WidgetContainersColumn.Height - 1)];
			entity.OnAdvancedSearch = (reader.IsDBNull(((int)WidgetContainersColumn.OnAdvancedSearch - 1)))?null:(System.Boolean?)reader[((int)WidgetContainersColumn.OnAdvancedSearch - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="JXTPortal.Entities.WidgetContainers"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="JXTPortal.Entities.WidgetContainers"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, JXTPortal.Entities.WidgetContainers entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.WidgetId = (System.Int32)dataRow["WidgetID"];
			entity.SiteId = (System.Int32)dataRow["SiteID"];
			entity.LanguageId = (System.Int32)dataRow["LanguageID"];
			entity.WidgetName = Convert.IsDBNull(dataRow["WidgetName"]) ? null : (System.String)dataRow["WidgetName"];
			entity.WidgetDomain = Convert.IsDBNull(dataRow["WidgetDomain"]) ? null : (System.String)dataRow["WidgetDomain"];
			entity.WidgetContainerClass = Convert.IsDBNull(dataRow["WidgetContainerClass"]) ? null : (System.String)dataRow["WidgetContainerClass"];
			entity.WidgetContainerHeaderClass = Convert.IsDBNull(dataRow["WidgetContainerHeaderClass"]) ? null : (System.String)dataRow["WidgetContainerHeaderClass"];
			entity.WidgetItemClass = Convert.IsDBNull(dataRow["WidgetItemClass"]) ? null : (System.String)dataRow["WidgetItemClass"];
			entity.WidgetJobLinkCss = Convert.IsDBNull(dataRow["WidgetJobLinkCSS"]) ? null : (System.String)dataRow["WidgetJobLinkCSS"];
			entity.WidgetItemLinkImageId = Convert.IsDBNull(dataRow["WidgetItemLinkImageID"]) ? null : (System.Int32?)dataRow["WidgetItemLinkImageID"];
			entity.Valid = Convert.IsDBNull(dataRow["Valid"]) ? null : (System.Boolean?)dataRow["Valid"];
			entity.ShowJobs = Convert.IsDBNull(dataRow["ShowJobs"]) ? null : (System.Boolean?)dataRow["ShowJobs"];
			entity.ShowCompanies = Convert.IsDBNull(dataRow["ShowCompanies"]) ? null : (System.Boolean?)dataRow["ShowCompanies"];
			entity.ShowSite = Convert.IsDBNull(dataRow["ShowSite"]) ? null : (System.Boolean?)dataRow["ShowSite"];
			entity.ShowPeople = Convert.IsDBNull(dataRow["ShowPeople"]) ? null : (System.Boolean?)dataRow["ShowPeople"];
			entity.JobHtml = Convert.IsDBNull(dataRow["JobHtml"]) ? null : (System.String)dataRow["JobHtml"];
			entity.CompanyHtml = Convert.IsDBNull(dataRow["CompanyHtml"]) ? null : (System.String)dataRow["CompanyHtml"];
			entity.SiteHtml = Convert.IsDBNull(dataRow["SiteHtml"]) ? null : (System.String)dataRow["SiteHtml"];
			entity.PeopleHtml = Convert.IsDBNull(dataRow["PeopleHtml"]) ? null : (System.String)dataRow["PeopleHtml"];
			entity.Javascript = Convert.IsDBNull(dataRow["Javascript"]) ? null : (System.String)dataRow["Javascript"];
			entity.SearchCss = Convert.IsDBNull(dataRow["SearchCSS"]) ? null : (System.String)dataRow["SearchCSS"];
			entity.DefaultProfessionId = Convert.IsDBNull(dataRow["DefaultProfessionID"]) ? null : (System.Int32?)dataRow["DefaultProfessionID"];
			entity.DefaultCountryId = Convert.IsDBNull(dataRow["DefaultCountryID"]) ? null : (System.Int32?)dataRow["DefaultCountryID"];
			entity.DefaultLocationId = Convert.IsDBNull(dataRow["DefaultLocationID"]) ? null : (System.Int32?)dataRow["DefaultLocationID"];
			entity.Width = Convert.IsDBNull(dataRow["Width"]) ? null : (System.Int32?)dataRow["Width"];
			entity.Height = Convert.IsDBNull(dataRow["Height"]) ? null : (System.Int32?)dataRow["Height"];
			entity.OnAdvancedSearch = Convert.IsDBNull(dataRow["OnAdvancedSearch"]) ? null : (System.Boolean?)dataRow["OnAdvancedSearch"];
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
		/// <param name="entity">The <see cref="JXTPortal.Entities.WidgetContainers"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">JXTPortal.Entities.WidgetContainers Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		public override void DeepLoad(TransactionManager transactionManager, JXTPortal.Entities.WidgetContainers entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region DefaultProfessionIdSource	
			if (CanDeepLoad(entity, "Profession|DefaultProfessionIdSource", deepLoadType, innerList) 
				&& entity.DefaultProfessionIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.DefaultProfessionId ?? (int)0);
				Profession tmpEntity = EntityManager.LocateEntity<Profession>(EntityLocator.ConstructKeyFromPkItems(typeof(Profession), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.DefaultProfessionIdSource = tmpEntity;
				else
					entity.DefaultProfessionIdSource = DataRepository.ProfessionProvider.GetByProfessionId(transactionManager, (entity.DefaultProfessionId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DefaultProfessionIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.DefaultProfessionIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.ProfessionProvider.DeepLoad(transactionManager, entity.DefaultProfessionIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion DefaultProfessionIdSource

			#region DefaultCountryIdSource	
			if (CanDeepLoad(entity, "Countries|DefaultCountryIdSource", deepLoadType, innerList) 
				&& entity.DefaultCountryIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.DefaultCountryId ?? (int)0);
				Countries tmpEntity = EntityManager.LocateEntity<Countries>(EntityLocator.ConstructKeyFromPkItems(typeof(Countries), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.DefaultCountryIdSource = tmpEntity;
				else
					entity.DefaultCountryIdSource = DataRepository.CountriesProvider.GetByCountryId(transactionManager, (entity.DefaultCountryId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DefaultCountryIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.DefaultCountryIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CountriesProvider.DeepLoad(transactionManager, entity.DefaultCountryIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion DefaultCountryIdSource

			#region DefaultLocationIdSource	
			if (CanDeepLoad(entity, "Location|DefaultLocationIdSource", deepLoadType, innerList) 
				&& entity.DefaultLocationIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = (entity.DefaultLocationId ?? (int)0);
				Location tmpEntity = EntityManager.LocateEntity<Location>(EntityLocator.ConstructKeyFromPkItems(typeof(Location), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.DefaultLocationIdSource = tmpEntity;
				else
					entity.DefaultLocationIdSource = DataRepository.LocationProvider.GetByLocationId(transactionManager, (entity.DefaultLocationId ?? (int)0));		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'DefaultLocationIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.DefaultLocationIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.LocationProvider.DeepLoad(transactionManager, entity.DefaultLocationIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion DefaultLocationIdSource

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
		/// Deep Save the entire object graph of the JXTPortal.Entities.WidgetContainers object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">JXTPortal.Entities.WidgetContainers instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">JXTPortal.Entities.WidgetContainers Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		public override bool DeepSave(TransactionManager transactionManager, JXTPortal.Entities.WidgetContainers entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region DefaultProfessionIdSource
			if (CanDeepSave(entity, "Profession|DefaultProfessionIdSource", deepSaveType, innerList) 
				&& entity.DefaultProfessionIdSource != null)
			{
				DataRepository.ProfessionProvider.Save(transactionManager, entity.DefaultProfessionIdSource);
				entity.DefaultProfessionId = entity.DefaultProfessionIdSource.ProfessionId;
			}
			#endregion 
			
			#region DefaultCountryIdSource
			if (CanDeepSave(entity, "Countries|DefaultCountryIdSource", deepSaveType, innerList) 
				&& entity.DefaultCountryIdSource != null)
			{
				DataRepository.CountriesProvider.Save(transactionManager, entity.DefaultCountryIdSource);
				entity.DefaultCountryId = entity.DefaultCountryIdSource.CountryId;
			}
			#endregion 
			
			#region DefaultLocationIdSource
			if (CanDeepSave(entity, "Location|DefaultLocationIdSource", deepSaveType, innerList) 
				&& entity.DefaultLocationIdSource != null)
			{
				DataRepository.LocationProvider.Save(transactionManager, entity.DefaultLocationIdSource);
				entity.DefaultLocationId = entity.DefaultLocationIdSource.LocationId;
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
	
	#region WidgetContainersChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>JXTPortal.Entities.WidgetContainers</c>
	///</summary>
	public enum WidgetContainersChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Profession</c> at DefaultProfessionIdSource
		///</summary>
		[ChildEntityType(typeof(Profession))]
		Profession,
			
		///<summary>
		/// Composite Property for <c>Countries</c> at DefaultCountryIdSource
		///</summary>
		[ChildEntityType(typeof(Countries))]
		Countries,
			
		///<summary>
		/// Composite Property for <c>Location</c> at DefaultLocationIdSource
		///</summary>
		[ChildEntityType(typeof(Location))]
		Location,
			
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
	
	#endregion WidgetContainersChildEntityTypes
	
	#region WidgetContainersFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;WidgetContainersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WidgetContainers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WidgetContainersFilterBuilder : SqlFilterBuilder<WidgetContainersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WidgetContainersFilterBuilder class.
		/// </summary>
		public WidgetContainersFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the WidgetContainersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WidgetContainersFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WidgetContainersFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WidgetContainersFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WidgetContainersFilterBuilder
	
	#region WidgetContainersParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;WidgetContainersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WidgetContainers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WidgetContainersParameterBuilder : ParameterizedSqlFilterBuilder<WidgetContainersColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WidgetContainersParameterBuilder class.
		/// </summary>
		public WidgetContainersParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the WidgetContainersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public WidgetContainersParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the WidgetContainersParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public WidgetContainersParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion WidgetContainersParameterBuilder
	
	#region WidgetContainersSortBuilder
    
    /// <summary>
    /// A strongly-typed instance of the <see cref="SqlSortBuilder&lt;WidgetContainersColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WidgetContainers"/> object.
    /// </summary>
    [CLSCompliant(true)]
    public class WidgetContainersSortBuilder : SqlSortBuilder<WidgetContainersColumn>
    {
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WidgetContainersSqlSortBuilder class.
		/// </summary>
		public WidgetContainersSortBuilder() : base() { }

		#endregion Constructors

    }    
    #endregion WidgetContainersSortBuilder
	
} // end namespace
