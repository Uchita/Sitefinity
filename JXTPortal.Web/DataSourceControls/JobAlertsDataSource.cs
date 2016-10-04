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
	/// Represents the DataRepository.JobAlertsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(JobAlertsDataSourceDesigner))]
	public class JobAlertsDataSource : ProviderDataSource<JobAlerts, JobAlertsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobAlertsDataSource class.
		/// </summary>
		public JobAlertsDataSource() : base(new JobAlertsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the JobAlertsDataSourceView used by the JobAlertsDataSource.
		/// </summary>
		protected JobAlertsDataSourceView JobAlertsView
		{
			get { return ( View as JobAlertsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the JobAlertsDataSource control invokes to retrieve data.
		/// </summary>
		public JobAlertsSelectMethod SelectMethod
		{
			get
			{
				JobAlertsSelectMethod selectMethod = JobAlertsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (JobAlertsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the JobAlertsDataSourceView class that is to be
		/// used by the JobAlertsDataSource.
		/// </summary>
		/// <returns>An instance of the JobAlertsDataSourceView class.</returns>
		protected override BaseDataSourceView<JobAlerts, JobAlertsKey> GetNewDataSourceView()
		{
			return new JobAlertsDataSourceView(this, DefaultViewName);
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
	/// Supports the JobAlertsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class JobAlertsDataSourceView : ProviderDataSourceView<JobAlerts, JobAlertsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobAlertsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the JobAlertsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public JobAlertsDataSourceView(JobAlertsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal JobAlertsDataSource JobAlertsOwner
		{
			get { return Owner as JobAlertsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal JobAlertsSelectMethod SelectMethod
		{
			get { return JobAlertsOwner.SelectMethod; }
			set { JobAlertsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal JobAlertsService JobAlertsProvider
		{
			get { return Provider as JobAlertsService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<JobAlerts> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<JobAlerts> results = null;
			JobAlerts item;
			count = 0;
			
			System.Int32 _jobAlertId;
			System.Int32? _currencyId_nullable;
			System.Int32 _memberId;
			System.Int32? _salaryTypeId_nullable;
			System.Int32 _siteId;

			switch ( SelectMethod )
			{
				case JobAlertsSelectMethod.Get:
					JobAlertsKey entityKey  = new JobAlertsKey();
					entityKey.Load(values);
					item = JobAlertsProvider.Get(entityKey);
					results = new TList<JobAlerts>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case JobAlertsSelectMethod.GetAll:
                    results = JobAlertsProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case JobAlertsSelectMethod.GetPaged:
					results = JobAlertsProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case JobAlertsSelectMethod.Find:
					if ( FilterParameters != null )
						results = JobAlertsProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = JobAlertsProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case JobAlertsSelectMethod.GetByJobAlertId:
					_jobAlertId = ( values["JobAlertId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["JobAlertId"], typeof(System.Int32)) : (int)0;
					item = JobAlertsProvider.GetByJobAlertId(_jobAlertId);
					results = new TList<JobAlerts>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case JobAlertsSelectMethod.GetByCurrencyId:
					_currencyId_nullable = (System.Int32?) EntityUtil.ChangeType(values["CurrencyId"], typeof(System.Int32?));
					results = JobAlertsProvider.GetByCurrencyId(_currencyId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case JobAlertsSelectMethod.GetByMemberId:
					_memberId = ( values["MemberId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["MemberId"], typeof(System.Int32)) : (int)0;
					results = JobAlertsProvider.GetByMemberId(_memberId, this.StartIndex, this.PageSize, out count);
					break;
				case JobAlertsSelectMethod.GetBySalaryTypeId:
					_salaryTypeId_nullable = (System.Int32?) EntityUtil.ChangeType(values["SalaryTypeId"], typeof(System.Int32?));
					results = JobAlertsProvider.GetBySalaryTypeId(_salaryTypeId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case JobAlertsSelectMethod.GetBySiteId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					results = JobAlertsProvider.GetBySiteId(_siteId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == JobAlertsSelectMethod.Get || SelectMethod == JobAlertsSelectMethod.GetByJobAlertId )
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
				JobAlerts entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					JobAlertsProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<JobAlerts> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			JobAlertsProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region JobAlertsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the JobAlertsDataSource class.
	/// </summary>
	public class JobAlertsDataSourceDesigner : ProviderDataSourceDesigner<JobAlerts, JobAlertsKey>
	{
		/// <summary>
		/// Initializes a new instance of the JobAlertsDataSourceDesigner class.
		/// </summary>
		public JobAlertsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public JobAlertsSelectMethod SelectMethod
		{
			get { return ((JobAlertsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new JobAlertsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region JobAlertsDataSourceActionList

	/// <summary>
	/// Supports the JobAlertsDataSourceDesigner class.
	/// </summary>
	internal class JobAlertsDataSourceActionList : DesignerActionList
	{
		private JobAlertsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the JobAlertsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public JobAlertsDataSourceActionList(JobAlertsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public JobAlertsSelectMethod SelectMethod
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

	#endregion JobAlertsDataSourceActionList
	
	#endregion JobAlertsDataSourceDesigner
	
	#region JobAlertsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the JobAlertsDataSource.SelectMethod property.
	/// </summary>
	public enum JobAlertsSelectMethod
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
		/// Represents the GetByJobAlertId method.
		/// </summary>
		GetByJobAlertId,
		/// <summary>
		/// Represents the GetByCurrencyId method.
		/// </summary>
		GetByCurrencyId,
		/// <summary>
		/// Represents the GetByMemberId method.
		/// </summary>
		GetByMemberId,
		/// <summary>
		/// Represents the GetBySalaryTypeId method.
		/// </summary>
		GetBySalaryTypeId,
		/// <summary>
		/// Represents the GetBySiteId method.
		/// </summary>
		GetBySiteId
	}
	
	#endregion JobAlertsSelectMethod

	#region JobAlertsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobAlerts"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobAlertsFilter : SqlFilter<JobAlertsColumn>
	{
	}
	
	#endregion JobAlertsFilter

	#region JobAlertsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobAlerts"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobAlertsExpressionBuilder : SqlExpressionBuilder<JobAlertsColumn>
	{
	}
	
	#endregion JobAlertsExpressionBuilder	

	#region JobAlertsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;JobAlertsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="JobAlerts"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobAlertsProperty : ChildEntityProperty<JobAlertsChildEntityTypes>
	{
	}
	
	#endregion JobAlertsProperty
}

