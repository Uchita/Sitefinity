#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.Design;

using JXTPortal.Entities;
using JXTPortal.Data;
using JXTPortal.Data.Bases;
using JXTPortal;
#endregion

namespace JXTPortal.Web.Data
{
	/// <summary>
	/// Represents the DataRepository.JobsArchiveProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(JobsArchiveDataSourceDesigner))]
	public class JobsArchiveDataSource : ProviderDataSource<JobsArchive, JobsArchiveKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobsArchiveDataSource class.
		/// </summary>
		public JobsArchiveDataSource() : base(new JobsArchiveService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the JobsArchiveDataSourceView used by the JobsArchiveDataSource.
		/// </summary>
		protected JobsArchiveDataSourceView JobsArchiveView
		{
			get { return ( View as JobsArchiveDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the JobsArchiveDataSource control invokes to retrieve data.
		/// </summary>
		public JobsArchiveSelectMethod SelectMethod
		{
			get
			{
				JobsArchiveSelectMethod selectMethod = JobsArchiveSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (JobsArchiveSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the JobsArchiveDataSourceView class that is to be
		/// used by the JobsArchiveDataSource.
		/// </summary>
		/// <returns>An instance of the JobsArchiveDataSourceView class.</returns>
		protected override BaseDataSourceView<JobsArchive, JobsArchiveKey> GetNewDataSourceView()
		{
			return new JobsArchiveDataSourceView(this, DefaultViewName);
		}
		
		/// <summary>
        /// Creates a cache hashing key based on the startIndex, pageSize and the SelectMethod being used.
        /// </summary>
        /// <param name="startIndex">The current start row index.</param>
        /// <param name="pageSize">The current page size.</param>
        /// <returns>A string that can be used as a key for caching purposes.</returns>
		protected override string CacheHashKey(int startIndex, int pageSize)
        {
			return String.Format("{0}:{1}:{2}", SelectMethod, startIndex, pageSize);
        }
		
		#endregion Methods
	}
	
	/// <summary>
	/// Supports the JobsArchiveDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class JobsArchiveDataSourceView : ProviderDataSourceView<JobsArchive, JobsArchiveKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobsArchiveDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the JobsArchiveDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public JobsArchiveDataSourceView(JobsArchiveDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal JobsArchiveDataSource JobsArchiveOwner
		{
			get { return Owner as JobsArchiveDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal JobsArchiveSelectMethod SelectMethod
		{
			get { return JobsArchiveOwner.SelectMethod; }
			set { JobsArchiveOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal JobsArchiveService JobsArchiveProvider
		{
			get { return Provider as JobsArchiveService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<JobsArchive> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<JobsArchive> results = null;
			JobsArchive item;
			count = 0;
			
			System.Int32? _addressStatus_nullable;
			System.Int32? _advertiserId_nullable;
			System.Int32 _currencyId;
			System.Int32 _salaryTypeId;
			System.Decimal _salaryLowerBand;
			System.Decimal _salaryUpperBand;
			System.Int32 _workTypeId;
			System.Int32? _expired_nullable;
			System.DateTime _expiryDate;
			System.Int32 _siteId;
			System.Boolean _billed;
			System.DateTime _datePosted;
			System.Int32 _jobId;
			System.Int32? _jobTemplateId_nullable;
			System.Int32? _lastModifiedByAdvertiserUserId_nullable;
			System.Int32? _lastModifiedByAdminUserId_nullable;

			switch ( SelectMethod )
			{
				case JobsArchiveSelectMethod.Get:
					JobsArchiveKey entityKey  = new JobsArchiveKey();
					entityKey.Load(values);
					item = JobsArchiveProvider.Get(entityKey);
					results = new TList<JobsArchive>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case JobsArchiveSelectMethod.GetAll:
                    results = JobsArchiveProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case JobsArchiveSelectMethod.GetPaged:
					results = JobsArchiveProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case JobsArchiveSelectMethod.Find:
					if ( FilterParameters != null )
						results = JobsArchiveProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = JobsArchiveProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case JobsArchiveSelectMethod.GetByJobId:
					_jobId = ( values["JobId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["JobId"], typeof(System.Int32)) : (int)0;
					item = JobsArchiveProvider.GetByJobId(_jobId);
					results = new TList<JobsArchive>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case JobsArchiveSelectMethod.GetByAddressStatus:
					_addressStatus_nullable = (System.Int32?) EntityUtil.ChangeType(values["AddressStatus"], typeof(System.Int32?));
					results = JobsArchiveProvider.GetByAddressStatus(_addressStatus_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case JobsArchiveSelectMethod.GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate:
					_advertiserId_nullable = (System.Int32?) EntityUtil.ChangeType(values["AdvertiserId"], typeof(System.Int32?));
					_currencyId = ( values["CurrencyId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CurrencyId"], typeof(System.Int32)) : (int)0;
					_salaryTypeId = ( values["SalaryTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SalaryTypeId"], typeof(System.Int32)) : (int)0;
					_salaryLowerBand = ( values["SalaryLowerBand"] != null ) ? (System.Decimal) EntityUtil.ChangeType(values["SalaryLowerBand"], typeof(System.Decimal)) : 0.0m;
					_salaryUpperBand = ( values["SalaryUpperBand"] != null ) ? (System.Decimal) EntityUtil.ChangeType(values["SalaryUpperBand"], typeof(System.Decimal)) : 0.0m;
					_workTypeId = ( values["WorkTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["WorkTypeId"], typeof(System.Int32)) : (int)0;
					_expired_nullable = (System.Int32?) EntityUtil.ChangeType(values["Expired"], typeof(System.Int32?));
					_expiryDate = ( values["ExpiryDate"] != null ) ? (System.DateTime) EntityUtil.ChangeType(values["ExpiryDate"], typeof(System.DateTime)) : DateTime.MinValue;
					results = JobsArchiveProvider.GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate(_advertiserId_nullable, _currencyId, _salaryTypeId, _salaryLowerBand, _salaryUpperBand, _workTypeId, _expired_nullable, _expiryDate, this.StartIndex, this.PageSize, out count);
					break;
				case JobsArchiveSelectMethod.GetBySiteIdBilledAdvertiserId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					_billed = ( values["Billed"] != null ) ? (System.Boolean) EntityUtil.ChangeType(values["Billed"], typeof(System.Boolean)) : false;
					_advertiserId_nullable = (System.Int32?) EntityUtil.ChangeType(values["AdvertiserId"], typeof(System.Int32?));
					results = JobsArchiveProvider.GetBySiteIdBilledAdvertiserId(_siteId, _billed, _advertiserId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case JobsArchiveSelectMethod.GetBySiteIdBilledAdvertiserIdDatePosted:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					_billed = ( values["Billed"] != null ) ? (System.Boolean) EntityUtil.ChangeType(values["Billed"], typeof(System.Boolean)) : false;
					_advertiserId_nullable = (System.Int32?) EntityUtil.ChangeType(values["AdvertiserId"], typeof(System.Int32?));
					_datePosted = ( values["DatePosted"] != null ) ? (System.DateTime) EntityUtil.ChangeType(values["DatePosted"], typeof(System.DateTime)) : DateTime.MinValue;
					results = JobsArchiveProvider.GetBySiteIdBilledAdvertiserIdDatePosted(_siteId, _billed, _advertiserId_nullable, _datePosted, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case JobsArchiveSelectMethod.GetByAdvertiserId:
					_advertiserId_nullable = (System.Int32?) EntityUtil.ChangeType(values["AdvertiserId"], typeof(System.Int32?));
					results = JobsArchiveProvider.GetByAdvertiserId(_advertiserId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case JobsArchiveSelectMethod.GetByCurrencyId:
					_currencyId = ( values["CurrencyId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CurrencyId"], typeof(System.Int32)) : (int)0;
					results = JobsArchiveProvider.GetByCurrencyId(_currencyId, this.StartIndex, this.PageSize, out count);
					break;
				case JobsArchiveSelectMethod.GetByJobTemplateId:
					_jobTemplateId_nullable = (System.Int32?) EntityUtil.ChangeType(values["JobTemplateId"], typeof(System.Int32?));
					results = JobsArchiveProvider.GetByJobTemplateId(_jobTemplateId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case JobsArchiveSelectMethod.GetByLastModifiedByAdvertiserUserId:
					_lastModifiedByAdvertiserUserId_nullable = (System.Int32?) EntityUtil.ChangeType(values["LastModifiedByAdvertiserUserId"], typeof(System.Int32?));
					results = JobsArchiveProvider.GetByLastModifiedByAdvertiserUserId(_lastModifiedByAdvertiserUserId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case JobsArchiveSelectMethod.GetByLastModifiedByAdminUserId:
					_lastModifiedByAdminUserId_nullable = (System.Int32?) EntityUtil.ChangeType(values["LastModifiedByAdminUserId"], typeof(System.Int32?));
					results = JobsArchiveProvider.GetByLastModifiedByAdminUserId(_lastModifiedByAdminUserId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case JobsArchiveSelectMethod.GetBySalaryTypeId:
					_salaryTypeId = ( values["SalaryTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SalaryTypeId"], typeof(System.Int32)) : (int)0;
					results = JobsArchiveProvider.GetBySalaryTypeId(_salaryTypeId, this.StartIndex, this.PageSize, out count);
					break;
				case JobsArchiveSelectMethod.GetBySiteId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					results = JobsArchiveProvider.GetBySiteId(_siteId, this.StartIndex, this.PageSize, out count);
					break;
				case JobsArchiveSelectMethod.GetByWorkTypeId:
					_workTypeId = ( values["WorkTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["WorkTypeId"], typeof(System.Int32)) : (int)0;
					results = JobsArchiveProvider.GetByWorkTypeId(_workTypeId, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				// Custom
				default:
					break;
			}

			if ( results != null && count < 1 )
			{
				count = results.Count;

				if ( !String.IsNullOrEmpty(CustomMethodRecordCountParamName) )
				{
					object objCustomCount = EntityUtil.ChangeType(customOutput[CustomMethodRecordCountParamName], typeof(Int32));
					
					if ( objCustomCount != null )
					{
						count = (int) objCustomCount;
					}
				}
			}
			
			return results;
		}
		
		/// <summary>
		/// Gets the values of any supplied parameters for internal caching.
		/// </summary>
		/// <param name="values">An IDictionary object of name/value pairs.</param>
		protected override void GetSelectParameters(IDictionary values)
		{
			if ( SelectMethod == JobsArchiveSelectMethod.Get || SelectMethod == JobsArchiveSelectMethod.GetByJobId )
			{
				EntityId = GetEntityKey(values);
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation for the current entity if it has
		/// not already been performed.
		/// </summary>
		internal override void DeepLoad()
		{
			if ( !IsDeepLoaded )
			{
				JobsArchive entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					JobsArchiveProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
					// set loaded flag
					IsDeepLoaded = true;
				}
			}
		}

		/// <summary>
		/// Performs a DeepLoad operation on the specified entity collection.
		/// </summary>
		/// <param name="entityList"></param>
		/// <param name="properties"></param>
		internal override void DeepLoad(TList<JobsArchive> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			JobsArchiveProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region JobsArchiveDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the JobsArchiveDataSource class.
	/// </summary>
	public class JobsArchiveDataSourceDesigner : ProviderDataSourceDesigner<JobsArchive, JobsArchiveKey>
	{
		/// <summary>
		/// Initializes a new instance of the JobsArchiveDataSourceDesigner class.
		/// </summary>
		public JobsArchiveDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public JobsArchiveSelectMethod SelectMethod
		{
			get { return ((JobsArchiveDataSource) DataSource).SelectMethod; }
			set { SetPropertyValue("SelectMethod", value); }
		}

		/// <summary>Gets the designer action list collection for this designer.</summary>
		/// <returns>The <see cref="T:System.ComponentModel.Design.DesignerActionListCollection"/>
		/// associated with this designer.</returns>
		public override DesignerActionListCollection ActionLists
		{
			get
			{
				DesignerActionListCollection actions = new DesignerActionListCollection();
				actions.Add(new JobsArchiveDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region JobsArchiveDataSourceActionList

	/// <summary>
	/// Supports the JobsArchiveDataSourceDesigner class.
	/// </summary>
	internal class JobsArchiveDataSourceActionList : DesignerActionList
	{
		private JobsArchiveDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the JobsArchiveDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public JobsArchiveDataSourceActionList(JobsArchiveDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public JobsArchiveSelectMethod SelectMethod
		{
			get { return _designer.SelectMethod; }
			set { _designer.SelectMethod = value; }
		}

		/// <summary>
		/// Returns the collection of <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// objects contained in the list.
		/// </summary>
		/// <returns>A <see cref="T:System.ComponentModel.Design.DesignerActionItem"/>
		/// array that contains the items in this list.</returns>
		public override DesignerActionItemCollection GetSortedActionItems()
		{
			DesignerActionItemCollection items = new DesignerActionItemCollection();
			items.Add(new DesignerActionPropertyItem("SelectMethod", "Select Method", "Methods"));
			return items;
		}
	}

	#endregion JobsArchiveDataSourceActionList
	
	#endregion JobsArchiveDataSourceDesigner
	
	#region JobsArchiveSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the JobsArchiveDataSource.SelectMethod property.
	/// </summary>
	public enum JobsArchiveSelectMethod
	{
		/// <summary>
		/// Represents the Get method.
		/// </summary>
		Get,
		/// <summary>
		/// Represents the GetAll method.
		/// </summary>
		GetAll,
		/// <summary>
		/// Represents the GetPaged method.
		/// </summary>
		GetPaged,
		/// <summary>
		/// Represents the Find method.
		/// </summary>
		Find,
		/// <summary>
		/// Represents the GetByAddressStatus method.
		/// </summary>
		GetByAddressStatus,
		/// <summary>
		/// Represents the GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate method.
		/// </summary>
		GetByAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandWorkTypeIdExpiredExpiryDate,
		/// <summary>
		/// Represents the GetBySiteIdBilledAdvertiserId method.
		/// </summary>
		GetBySiteIdBilledAdvertiserId,
		/// <summary>
		/// Represents the GetBySiteIdBilledAdvertiserIdDatePosted method.
		/// </summary>
		GetBySiteIdBilledAdvertiserIdDatePosted,
		/// <summary>
		/// Represents the GetByJobId method.
		/// </summary>
		GetByJobId,
		/// <summary>
		/// Represents the GetByAdvertiserId method.
		/// </summary>
		GetByAdvertiserId,
		/// <summary>
		/// Represents the GetByCurrencyId method.
		/// </summary>
		GetByCurrencyId,
		/// <summary>
		/// Represents the GetByJobTemplateId method.
		/// </summary>
		GetByJobTemplateId,
		/// <summary>
		/// Represents the GetByLastModifiedByAdvertiserUserId method.
		/// </summary>
		GetByLastModifiedByAdvertiserUserId,
		/// <summary>
		/// Represents the GetByLastModifiedByAdminUserId method.
		/// </summary>
		GetByLastModifiedByAdminUserId,
		/// <summary>
		/// Represents the GetBySalaryTypeId method.
		/// </summary>
		GetBySalaryTypeId,
		/// <summary>
		/// Represents the GetBySiteId method.
		/// </summary>
		GetBySiteId,
		/// <summary>
		/// Represents the GetByWorkTypeId method.
		/// </summary>
		GetByWorkTypeId
	}
	
	#endregion JobsArchiveSelectMethod

	#region JobsArchiveFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobsArchive"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobsArchiveFilter : SqlFilter<JobsArchiveColumn>
	{
	}
	
	#endregion JobsArchiveFilter

	#region JobsArchiveExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobsArchive"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobsArchiveExpressionBuilder : SqlExpressionBuilder<JobsArchiveColumn>
	{
	}
	
	#endregion JobsArchiveExpressionBuilder	

	#region JobsArchiveProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;JobsArchiveChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="JobsArchive"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobsArchiveProperty : ChildEntityProperty<JobsArchiveChildEntityTypes>
	{
	}
	
	#endregion JobsArchiveProperty
}

