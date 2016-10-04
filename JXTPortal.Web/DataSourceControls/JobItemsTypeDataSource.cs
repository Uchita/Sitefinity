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
	/// Represents the DataRepository.JobItemsTypeProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(JobItemsTypeDataSourceDesigner))]
	public class JobItemsTypeDataSource : ProviderDataSource<JobItemsType, JobItemsTypeKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobItemsTypeDataSource class.
		/// </summary>
		public JobItemsTypeDataSource() : base(new JobItemsTypeService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the JobItemsTypeDataSourceView used by the JobItemsTypeDataSource.
		/// </summary>
		protected JobItemsTypeDataSourceView JobItemsTypeView
		{
			get { return ( View as JobItemsTypeDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the JobItemsTypeDataSource control invokes to retrieve data.
		/// </summary>
		public JobItemsTypeSelectMethod SelectMethod
		{
			get
			{
				JobItemsTypeSelectMethod selectMethod = JobItemsTypeSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (JobItemsTypeSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the JobItemsTypeDataSourceView class that is to be
		/// used by the JobItemsTypeDataSource.
		/// </summary>
		/// <returns>An instance of the JobItemsTypeDataSourceView class.</returns>
		protected override BaseDataSourceView<JobItemsType, JobItemsTypeKey> GetNewDataSourceView()
		{
			return new JobItemsTypeDataSourceView(this, DefaultViewName);
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
	/// Supports the JobItemsTypeDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class JobItemsTypeDataSourceView : ProviderDataSourceView<JobItemsType, JobItemsTypeKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobItemsTypeDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the JobItemsTypeDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public JobItemsTypeDataSourceView(JobItemsTypeDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal JobItemsTypeDataSource JobItemsTypeOwner
		{
			get { return Owner as JobItemsTypeDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal JobItemsTypeSelectMethod SelectMethod
		{
			get { return JobItemsTypeOwner.SelectMethod; }
			set { JobItemsTypeOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal JobItemsTypeService JobItemsTypeProvider
		{
			get { return Provider as JobItemsTypeService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<JobItemsType> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<JobItemsType> results = null;
			JobItemsType item;
			count = 0;
			
			System.Int32 _jobItemTypeId;
			System.Int32 _lastModifiedBy;
			System.Int32 _siteId;
			System.Int32 _advertiserId;

			switch ( SelectMethod )
			{
				case JobItemsTypeSelectMethod.Get:
					JobItemsTypeKey entityKey  = new JobItemsTypeKey();
					entityKey.Load(values);
					item = JobItemsTypeProvider.Get(entityKey);
					results = new TList<JobItemsType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case JobItemsTypeSelectMethod.GetAll:
                    results = JobItemsTypeProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case JobItemsTypeSelectMethod.GetPaged:
					results = JobItemsTypeProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case JobItemsTypeSelectMethod.Find:
					if ( FilterParameters != null )
						results = JobItemsTypeProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = JobItemsTypeProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case JobItemsTypeSelectMethod.GetByJobItemTypeId:
					_jobItemTypeId = ( values["JobItemTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["JobItemTypeId"], typeof(System.Int32)) : (int)0;
					item = JobItemsTypeProvider.GetByJobItemTypeId(_jobItemTypeId);
					results = new TList<JobItemsType>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case JobItemsTypeSelectMethod.GetByLastModifiedBy:
					_lastModifiedBy = ( values["LastModifiedBy"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["LastModifiedBy"], typeof(System.Int32)) : (int)0;
					results = JobItemsTypeProvider.GetByLastModifiedBy(_lastModifiedBy, this.StartIndex, this.PageSize, out count);
					break;
				case JobItemsTypeSelectMethod.GetBySiteId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					results = JobItemsTypeProvider.GetBySiteId(_siteId, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				case JobItemsTypeSelectMethod.GetByAdvertiserIdFromAdvertiserJobPricing:
					_advertiserId = ( values["AdvertiserId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AdvertiserId"], typeof(System.Int32)) : (int)0;
					results = JobItemsTypeProvider.GetByAdvertiserIdFromAdvertiserJobPricing(_advertiserId, this.StartIndex, this.PageSize, out count);
					break;
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
			if ( SelectMethod == JobItemsTypeSelectMethod.Get || SelectMethod == JobItemsTypeSelectMethod.GetByJobItemTypeId )
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
				JobItemsType entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					JobItemsTypeProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<JobItemsType> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			JobItemsTypeProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region JobItemsTypeDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the JobItemsTypeDataSource class.
	/// </summary>
	public class JobItemsTypeDataSourceDesigner : ProviderDataSourceDesigner<JobItemsType, JobItemsTypeKey>
	{
		/// <summary>
		/// Initializes a new instance of the JobItemsTypeDataSourceDesigner class.
		/// </summary>
		public JobItemsTypeDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public JobItemsTypeSelectMethod SelectMethod
		{
			get { return ((JobItemsTypeDataSource) DataSource).SelectMethod; }
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
				actions.Add(new JobItemsTypeDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region JobItemsTypeDataSourceActionList

	/// <summary>
	/// Supports the JobItemsTypeDataSourceDesigner class.
	/// </summary>
	internal class JobItemsTypeDataSourceActionList : DesignerActionList
	{
		private JobItemsTypeDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the JobItemsTypeDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public JobItemsTypeDataSourceActionList(JobItemsTypeDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public JobItemsTypeSelectMethod SelectMethod
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

	#endregion JobItemsTypeDataSourceActionList
	
	#endregion JobItemsTypeDataSourceDesigner
	
	#region JobItemsTypeSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the JobItemsTypeDataSource.SelectMethod property.
	/// </summary>
	public enum JobItemsTypeSelectMethod
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
		/// Represents the GetByJobItemTypeId method.
		/// </summary>
		GetByJobItemTypeId,
		/// <summary>
		/// Represents the GetByLastModifiedBy method.
		/// </summary>
		GetByLastModifiedBy,
		/// <summary>
		/// Represents the GetBySiteId method.
		/// </summary>
		GetBySiteId,
		/// <summary>
		/// Represents the GetByAdvertiserIdFromAdvertiserJobPricing method.
		/// </summary>
		GetByAdvertiserIdFromAdvertiserJobPricing
	}
	
	#endregion JobItemsTypeSelectMethod

	#region JobItemsTypeFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobItemsType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobItemsTypeFilter : SqlFilter<JobItemsTypeColumn>
	{
	}
	
	#endregion JobItemsTypeFilter

	#region JobItemsTypeExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobItemsType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobItemsTypeExpressionBuilder : SqlExpressionBuilder<JobItemsTypeColumn>
	{
	}
	
	#endregion JobItemsTypeExpressionBuilder	

	#region JobItemsTypeProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;JobItemsTypeChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="JobItemsType"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobItemsTypeProperty : ChildEntityProperty<JobItemsTypeChildEntityTypes>
	{
	}
	
	#endregion JobItemsTypeProperty
}

