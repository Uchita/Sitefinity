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
	/// Represents the DataRepository.JobAreaProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(JobAreaDataSourceDesigner))]
	public class JobAreaDataSource : ProviderDataSource<JobArea, JobAreaKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobAreaDataSource class.
		/// </summary>
		public JobAreaDataSource() : base(new JobAreaService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the JobAreaDataSourceView used by the JobAreaDataSource.
		/// </summary>
		protected JobAreaDataSourceView JobAreaView
		{
			get { return ( View as JobAreaDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the JobAreaDataSource control invokes to retrieve data.
		/// </summary>
		public JobAreaSelectMethod SelectMethod
		{
			get
			{
				JobAreaSelectMethod selectMethod = JobAreaSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (JobAreaSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the JobAreaDataSourceView class that is to be
		/// used by the JobAreaDataSource.
		/// </summary>
		/// <returns>An instance of the JobAreaDataSourceView class.</returns>
		protected override BaseDataSourceView<JobArea, JobAreaKey> GetNewDataSourceView()
		{
			return new JobAreaDataSourceView(this, DefaultViewName);
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
	/// Supports the JobAreaDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class JobAreaDataSourceView : ProviderDataSourceView<JobArea, JobAreaKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobAreaDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the JobAreaDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public JobAreaDataSourceView(JobAreaDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal JobAreaDataSource JobAreaOwner
		{
			get { return Owner as JobAreaDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal JobAreaSelectMethod SelectMethod
		{
			get { return JobAreaOwner.SelectMethod; }
			set { JobAreaOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal JobAreaService JobAreaProvider
		{
			get { return Provider as JobAreaService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<JobArea> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<JobArea> results = null;
			JobArea item;
			count = 0;
			
			System.Int32 _jobAreaId;
			System.Int32 _areaId;
			System.Int32? _jobArchiveId_nullable;
			System.Int32? _jobId_nullable;

			switch ( SelectMethod )
			{
				case JobAreaSelectMethod.Get:
					JobAreaKey entityKey  = new JobAreaKey();
					entityKey.Load(values);
					item = JobAreaProvider.Get(entityKey);
					results = new TList<JobArea>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case JobAreaSelectMethod.GetAll:
                    results = JobAreaProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case JobAreaSelectMethod.GetPaged:
					results = JobAreaProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case JobAreaSelectMethod.Find:
					if ( FilterParameters != null )
						results = JobAreaProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = JobAreaProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case JobAreaSelectMethod.GetByJobAreaId:
					_jobAreaId = ( values["JobAreaId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["JobAreaId"], typeof(System.Int32)) : (int)0;
					item = JobAreaProvider.GetByJobAreaId(_jobAreaId);
					results = new TList<JobArea>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case JobAreaSelectMethod.GetByAreaId:
					_areaId = ( values["AreaId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AreaId"], typeof(System.Int32)) : (int)0;
					results = JobAreaProvider.GetByAreaId(_areaId, this.StartIndex, this.PageSize, out count);
					break;
				case JobAreaSelectMethod.GetByJobArchiveId:
					_jobArchiveId_nullable = (System.Int32?) EntityUtil.ChangeType(values["JobArchiveId"], typeof(System.Int32?));
					results = JobAreaProvider.GetByJobArchiveId(_jobArchiveId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case JobAreaSelectMethod.GetByJobId:
					_jobId_nullable = (System.Int32?) EntityUtil.ChangeType(values["JobId"], typeof(System.Int32?));
					results = JobAreaProvider.GetByJobId(_jobId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == JobAreaSelectMethod.Get || SelectMethod == JobAreaSelectMethod.GetByJobAreaId )
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
				JobArea entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					JobAreaProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<JobArea> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			JobAreaProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region JobAreaDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the JobAreaDataSource class.
	/// </summary>
	public class JobAreaDataSourceDesigner : ProviderDataSourceDesigner<JobArea, JobAreaKey>
	{
		/// <summary>
		/// Initializes a new instance of the JobAreaDataSourceDesigner class.
		/// </summary>
		public JobAreaDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public JobAreaSelectMethod SelectMethod
		{
			get { return ((JobAreaDataSource) DataSource).SelectMethod; }
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
				actions.Add(new JobAreaDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region JobAreaDataSourceActionList

	/// <summary>
	/// Supports the JobAreaDataSourceDesigner class.
	/// </summary>
	internal class JobAreaDataSourceActionList : DesignerActionList
	{
		private JobAreaDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the JobAreaDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public JobAreaDataSourceActionList(JobAreaDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public JobAreaSelectMethod SelectMethod
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

	#endregion JobAreaDataSourceActionList
	
	#endregion JobAreaDataSourceDesigner
	
	#region JobAreaSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the JobAreaDataSource.SelectMethod property.
	/// </summary>
	public enum JobAreaSelectMethod
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
		/// Represents the GetByJobAreaId method.
		/// </summary>
		GetByJobAreaId,
		/// <summary>
		/// Represents the GetByAreaId method.
		/// </summary>
		GetByAreaId,
		/// <summary>
		/// Represents the GetByJobArchiveId method.
		/// </summary>
		GetByJobArchiveId,
		/// <summary>
		/// Represents the GetByJobId method.
		/// </summary>
		GetByJobId
	}
	
	#endregion JobAreaSelectMethod

	#region JobAreaFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobArea"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobAreaFilter : SqlFilter<JobAreaColumn>
	{
	}
	
	#endregion JobAreaFilter

	#region JobAreaExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobArea"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobAreaExpressionBuilder : SqlExpressionBuilder<JobAreaColumn>
	{
	}
	
	#endregion JobAreaExpressionBuilder	

	#region JobAreaProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;JobAreaChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="JobArea"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobAreaProperty : ChildEntityProperty<JobAreaChildEntityTypes>
	{
	}
	
	#endregion JobAreaProperty
}

