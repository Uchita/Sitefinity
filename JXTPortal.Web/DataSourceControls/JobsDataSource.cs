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
	/// Represents the DataRepository.JobsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(JobsDataSourceDesigner))]
	public class JobsDataSource : ProviderDataSource<Jobs, JobsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobsDataSource class.
		/// </summary>
		public JobsDataSource() : base(new JobsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the JobsDataSourceView used by the JobsDataSource.
		/// </summary>
		protected JobsDataSourceView JobsView
		{
			get { return ( View as JobsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the JobsDataSource control invokes to retrieve data.
		/// </summary>
		public JobsSelectMethod SelectMethod
		{
			get
			{
				JobsSelectMethod selectMethod = JobsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (JobsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the JobsDataSourceView class that is to be
		/// used by the JobsDataSource.
		/// </summary>
		/// <returns>An instance of the JobsDataSourceView class.</returns>
		protected override BaseDataSourceView<Jobs, JobsKey> GetNewDataSourceView()
		{
			return new JobsDataSourceView(this, DefaultViewName);
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
	/// Supports the JobsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class JobsDataSourceView : ProviderDataSourceView<Jobs, JobsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the JobsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public JobsDataSourceView(JobsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal JobsDataSource JobsOwner
		{
			get { return Owner as JobsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal JobsSelectMethod SelectMethod
		{
			get { return JobsOwner.SelectMethod; }
			set { JobsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal JobsService JobsProvider
		{
			get { return Provider as JobsService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Jobs> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Jobs> results = null;
			Jobs item;
			count = 0;
			
			System.Int32? _expired_nullable;
			System.Int32? _advertiserId_nullable;
			System.DateTime _expiryDate;
			System.Boolean _billed;
			System.Int32 _workTypeId;
			System.Int32 _jobId;
			System.Int32 _currencyId;
			System.Int32 _salaryTypeId;
			System.Decimal _salaryLowerBand;
			System.Decimal _salaryUpperBand;
			System.Int32 _siteId;
			System.Int32? _enteredByAdvertiserUserId_nullable;
			System.Int32? _jobTemplateId_nullable;
			System.Int32? _lastModifiedByAdvertiserUserId_nullable;
			System.Int32? _lastModifiedByAdminUserId_nullable;

			switch ( SelectMethod )
			{
				case JobsSelectMethod.Get:
					JobsKey entityKey  = new JobsKey();
					entityKey.Load(values);
					item = JobsProvider.Get(entityKey);
					results = new TList<Jobs>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case JobsSelectMethod.GetAll:
                    results = JobsProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case JobsSelectMethod.GetPaged:
					results = JobsProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case JobsSelectMethod.Find:
					if ( FilterParameters != null )
						results = JobsProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = JobsProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case JobsSelectMethod.GetByJobId:
					_jobId = ( values["JobId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["JobId"], typeof(System.Int32)) : (int)0;
					item = JobsProvider.GetByJobId(_jobId);
					results = new TList<Jobs>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case JobsSelectMethod.GetByExpiredAdvertiserIdExpiryDate:
					_expired_nullable = (System.Int32?) EntityUtil.ChangeType(values["Expired"], typeof(System.Int32?));
					_advertiserId_nullable = (System.Int32?) EntityUtil.ChangeType(values["AdvertiserId"], typeof(System.Int32?));
					_expiryDate = ( values["ExpiryDate"] != null ) ? (System.DateTime) EntityUtil.ChangeType(values["ExpiryDate"], typeof(System.DateTime)) : DateTime.MinValue;
					results = JobsProvider.GetByExpiredAdvertiserIdExpiryDate(_expired_nullable, _advertiserId_nullable, _expiryDate, this.StartIndex, this.PageSize, out count);
					break;
				case JobsSelectMethod.GetByExpiredBilledExpiryDate:
					_expired_nullable = (System.Int32?) EntityUtil.ChangeType(values["Expired"], typeof(System.Int32?));
					_billed = ( values["Billed"] != null ) ? (System.Boolean) EntityUtil.ChangeType(values["Billed"], typeof(System.Boolean)) : false;
					_expiryDate = ( values["ExpiryDate"] != null ) ? (System.DateTime) EntityUtil.ChangeType(values["ExpiryDate"], typeof(System.DateTime)) : DateTime.MinValue;
					results = JobsProvider.GetByExpiredBilledExpiryDate(_expired_nullable, _billed, _expiryDate, this.StartIndex, this.PageSize, out count);
					break;
				case JobsSelectMethod.GetByExpiredExpiryDate:
					_expired_nullable = (System.Int32?) EntityUtil.ChangeType(values["Expired"], typeof(System.Int32?));
					_expiryDate = ( values["ExpiryDate"] != null ) ? (System.DateTime) EntityUtil.ChangeType(values["ExpiryDate"], typeof(System.DateTime)) : DateTime.MinValue;
					results = JobsProvider.GetByExpiredExpiryDate(_expired_nullable, _expiryDate, this.StartIndex, this.PageSize, out count);
					break;
				case JobsSelectMethod.GetByWorkTypeIdJobIdAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandExpiredExpiryDate:
					_workTypeId = ( values["WorkTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["WorkTypeId"], typeof(System.Int32)) : (int)0;
					_jobId = ( values["JobId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["JobId"], typeof(System.Int32)) : (int)0;
					_advertiserId_nullable = (System.Int32?) EntityUtil.ChangeType(values["AdvertiserId"], typeof(System.Int32?));
					_currencyId = ( values["CurrencyId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CurrencyId"], typeof(System.Int32)) : (int)0;
					_salaryTypeId = ( values["SalaryTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SalaryTypeId"], typeof(System.Int32)) : (int)0;
					_salaryLowerBand = ( values["SalaryLowerBand"] != null ) ? (System.Decimal) EntityUtil.ChangeType(values["SalaryLowerBand"], typeof(System.Decimal)) : 0.0m;
					_salaryUpperBand = ( values["SalaryUpperBand"] != null ) ? (System.Decimal) EntityUtil.ChangeType(values["SalaryUpperBand"], typeof(System.Decimal)) : 0.0m;
					_expired_nullable = (System.Int32?) EntityUtil.ChangeType(values["Expired"], typeof(System.Int32?));
					_expiryDate = ( values["ExpiryDate"] != null ) ? (System.DateTime) EntityUtil.ChangeType(values["ExpiryDate"], typeof(System.DateTime)) : DateTime.MinValue;
					results = JobsProvider.GetByWorkTypeIdJobIdAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandExpiredExpiryDate(_workTypeId, _jobId, _advertiserId_nullable, _currencyId, _salaryTypeId, _salaryLowerBand, _salaryUpperBand, _expired_nullable, _expiryDate, this.StartIndex, this.PageSize, out count);
					break;
				case JobsSelectMethod.GetBySiteIdBilledAdvertiserId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					_billed = ( values["Billed"] != null ) ? (System.Boolean) EntityUtil.ChangeType(values["Billed"], typeof(System.Boolean)) : false;
					_advertiserId_nullable = (System.Int32?) EntityUtil.ChangeType(values["AdvertiserId"], typeof(System.Int32?));
					results = JobsProvider.GetBySiteIdBilledAdvertiserId(_siteId, _billed, _advertiserId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case JobsSelectMethod.GetBySiteIdExpiredBilledAdvertiserIdEnteredByAdvertiserUserId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					_expired_nullable = (System.Int32?) EntityUtil.ChangeType(values["Expired"], typeof(System.Int32?));
					_billed = ( values["Billed"] != null ) ? (System.Boolean) EntityUtil.ChangeType(values["Billed"], typeof(System.Boolean)) : false;
					_advertiserId_nullable = (System.Int32?) EntityUtil.ChangeType(values["AdvertiserId"], typeof(System.Int32?));
					_enteredByAdvertiserUserId_nullable = (System.Int32?) EntityUtil.ChangeType(values["EnteredByAdvertiserUserId"], typeof(System.Int32?));
					results = JobsProvider.GetBySiteIdExpiredBilledAdvertiserIdEnteredByAdvertiserUserId(_siteId, _expired_nullable, _billed, _advertiserId_nullable, _enteredByAdvertiserUserId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case JobsSelectMethod.GetByAdvertiserId:
					_advertiserId_nullable = (System.Int32?) EntityUtil.ChangeType(values["AdvertiserId"], typeof(System.Int32?));
					results = JobsProvider.GetByAdvertiserId(_advertiserId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case JobsSelectMethod.GetByCurrencyId:
					_currencyId = ( values["CurrencyId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CurrencyId"], typeof(System.Int32)) : (int)0;
					results = JobsProvider.GetByCurrencyId(_currencyId, this.StartIndex, this.PageSize, out count);
					break;
				case JobsSelectMethod.GetByJobTemplateId:
					_jobTemplateId_nullable = (System.Int32?) EntityUtil.ChangeType(values["JobTemplateId"], typeof(System.Int32?));
					results = JobsProvider.GetByJobTemplateId(_jobTemplateId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case JobsSelectMethod.GetByLastModifiedByAdvertiserUserId:
					_lastModifiedByAdvertiserUserId_nullable = (System.Int32?) EntityUtil.ChangeType(values["LastModifiedByAdvertiserUserId"], typeof(System.Int32?));
					results = JobsProvider.GetByLastModifiedByAdvertiserUserId(_lastModifiedByAdvertiserUserId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case JobsSelectMethod.GetByLastModifiedByAdminUserId:
					_lastModifiedByAdminUserId_nullable = (System.Int32?) EntityUtil.ChangeType(values["LastModifiedByAdminUserId"], typeof(System.Int32?));
					results = JobsProvider.GetByLastModifiedByAdminUserId(_lastModifiedByAdminUserId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case JobsSelectMethod.GetBySalaryTypeId:
					_salaryTypeId = ( values["SalaryTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SalaryTypeId"], typeof(System.Int32)) : (int)0;
					results = JobsProvider.GetBySalaryTypeId(_salaryTypeId, this.StartIndex, this.PageSize, out count);
					break;
				case JobsSelectMethod.GetBySiteId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					results = JobsProvider.GetBySiteId(_siteId, this.StartIndex, this.PageSize, out count);
					break;
				case JobsSelectMethod.GetByWorkTypeId:
					_workTypeId = ( values["WorkTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["WorkTypeId"], typeof(System.Int32)) : (int)0;
					results = JobsProvider.GetByWorkTypeId(_workTypeId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == JobsSelectMethod.Get || SelectMethod == JobsSelectMethod.GetByJobId )
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
				Jobs entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					JobsProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Jobs> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			JobsProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region JobsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the JobsDataSource class.
	/// </summary>
	public class JobsDataSourceDesigner : ProviderDataSourceDesigner<Jobs, JobsKey>
	{
		/// <summary>
		/// Initializes a new instance of the JobsDataSourceDesigner class.
		/// </summary>
		public JobsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public JobsSelectMethod SelectMethod
		{
			get { return ((JobsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new JobsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region JobsDataSourceActionList

	/// <summary>
	/// Supports the JobsDataSourceDesigner class.
	/// </summary>
	internal class JobsDataSourceActionList : DesignerActionList
	{
		private JobsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the JobsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public JobsDataSourceActionList(JobsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public JobsSelectMethod SelectMethod
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

	#endregion JobsDataSourceActionList
	
	#endregion JobsDataSourceDesigner
	
	#region JobsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the JobsDataSource.SelectMethod property.
	/// </summary>
	public enum JobsSelectMethod
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
		/// Represents the GetByExpiredAdvertiserIdExpiryDate method.
		/// </summary>
		GetByExpiredAdvertiserIdExpiryDate,
		/// <summary>
		/// Represents the GetByExpiredBilledExpiryDate method.
		/// </summary>
		GetByExpiredBilledExpiryDate,
		/// <summary>
		/// Represents the GetByExpiredExpiryDate method.
		/// </summary>
		GetByExpiredExpiryDate,
		/// <summary>
		/// Represents the GetByWorkTypeIdJobIdAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandExpiredExpiryDate method.
		/// </summary>
		GetByWorkTypeIdJobIdAdvertiserIdCurrencyIdSalaryTypeIdSalaryLowerBandSalaryUpperBandExpiredExpiryDate,
		/// <summary>
		/// Represents the GetBySiteIdBilledAdvertiserId method.
		/// </summary>
		GetBySiteIdBilledAdvertiserId,
		/// <summary>
		/// Represents the GetBySiteIdExpiredBilledAdvertiserIdEnteredByAdvertiserUserId method.
		/// </summary>
		GetBySiteIdExpiredBilledAdvertiserIdEnteredByAdvertiserUserId,
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
	
	#endregion JobsSelectMethod

	#region JobsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Jobs"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobsFilter : SqlFilter<JobsColumn>
	{
	}
	
	#endregion JobsFilter

	#region JobsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Jobs"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobsExpressionBuilder : SqlExpressionBuilder<JobsColumn>
	{
	}
	
	#endregion JobsExpressionBuilder	

	#region JobsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;JobsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Jobs"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobsProperty : ChildEntityProperty<JobsChildEntityTypes>
	{
	}
	
	#endregion JobsProperty
}

