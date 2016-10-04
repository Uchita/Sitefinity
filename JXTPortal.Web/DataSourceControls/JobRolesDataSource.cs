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
	/// Represents the DataRepository.JobRolesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(JobRolesDataSourceDesigner))]
	public class JobRolesDataSource : ProviderDataSource<JobRoles, JobRolesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobRolesDataSource class.
		/// </summary>
		public JobRolesDataSource() : base(new JobRolesService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the JobRolesDataSourceView used by the JobRolesDataSource.
		/// </summary>
		protected JobRolesDataSourceView JobRolesView
		{
			get { return ( View as JobRolesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the JobRolesDataSource control invokes to retrieve data.
		/// </summary>
		public JobRolesSelectMethod SelectMethod
		{
			get
			{
				JobRolesSelectMethod selectMethod = JobRolesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (JobRolesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the JobRolesDataSourceView class that is to be
		/// used by the JobRolesDataSource.
		/// </summary>
		/// <returns>An instance of the JobRolesDataSourceView class.</returns>
		protected override BaseDataSourceView<JobRoles, JobRolesKey> GetNewDataSourceView()
		{
			return new JobRolesDataSourceView(this, DefaultViewName);
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
	/// Supports the JobRolesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class JobRolesDataSourceView : ProviderDataSourceView<JobRoles, JobRolesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobRolesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the JobRolesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public JobRolesDataSourceView(JobRolesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal JobRolesDataSource JobRolesOwner
		{
			get { return Owner as JobRolesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal JobRolesSelectMethod SelectMethod
		{
			get { return JobRolesOwner.SelectMethod; }
			set { JobRolesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal JobRolesService JobRolesProvider
		{
			get { return Provider as JobRolesService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<JobRoles> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<JobRoles> results = null;
			JobRoles item;
			count = 0;
			
			System.Int32 _jobRoleId;
			System.Int32? _jobArchiveId_nullable;
			System.Int32? _jobId_nullable;
			System.Int32? _roleId_nullable;

			switch ( SelectMethod )
			{
				case JobRolesSelectMethod.Get:
					JobRolesKey entityKey  = new JobRolesKey();
					entityKey.Load(values);
					item = JobRolesProvider.Get(entityKey);
					results = new TList<JobRoles>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case JobRolesSelectMethod.GetAll:
                    results = JobRolesProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case JobRolesSelectMethod.GetPaged:
					results = JobRolesProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case JobRolesSelectMethod.Find:
					if ( FilterParameters != null )
						results = JobRolesProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = JobRolesProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case JobRolesSelectMethod.GetByJobRoleId:
					_jobRoleId = ( values["JobRoleId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["JobRoleId"], typeof(System.Int32)) : (int)0;
					item = JobRolesProvider.GetByJobRoleId(_jobRoleId);
					results = new TList<JobRoles>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case JobRolesSelectMethod.GetByJobArchiveId:
					_jobArchiveId_nullable = (System.Int32?) EntityUtil.ChangeType(values["JobArchiveId"], typeof(System.Int32?));
					results = JobRolesProvider.GetByJobArchiveId(_jobArchiveId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case JobRolesSelectMethod.GetByJobId:
					_jobId_nullable = (System.Int32?) EntityUtil.ChangeType(values["JobId"], typeof(System.Int32?));
					results = JobRolesProvider.GetByJobId(_jobId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case JobRolesSelectMethod.GetByRoleId:
					_roleId_nullable = (System.Int32?) EntityUtil.ChangeType(values["RoleId"], typeof(System.Int32?));
					results = JobRolesProvider.GetByRoleId(_roleId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == JobRolesSelectMethod.Get || SelectMethod == JobRolesSelectMethod.GetByJobRoleId )
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
				JobRoles entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					JobRolesProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<JobRoles> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			JobRolesProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region JobRolesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the JobRolesDataSource class.
	/// </summary>
	public class JobRolesDataSourceDesigner : ProviderDataSourceDesigner<JobRoles, JobRolesKey>
	{
		/// <summary>
		/// Initializes a new instance of the JobRolesDataSourceDesigner class.
		/// </summary>
		public JobRolesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public JobRolesSelectMethod SelectMethod
		{
			get { return ((JobRolesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new JobRolesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region JobRolesDataSourceActionList

	/// <summary>
	/// Supports the JobRolesDataSourceDesigner class.
	/// </summary>
	internal class JobRolesDataSourceActionList : DesignerActionList
	{
		private JobRolesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the JobRolesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public JobRolesDataSourceActionList(JobRolesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public JobRolesSelectMethod SelectMethod
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

	#endregion JobRolesDataSourceActionList
	
	#endregion JobRolesDataSourceDesigner
	
	#region JobRolesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the JobRolesDataSource.SelectMethod property.
	/// </summary>
	public enum JobRolesSelectMethod
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
		/// Represents the GetByJobRoleId method.
		/// </summary>
		GetByJobRoleId,
		/// <summary>
		/// Represents the GetByJobArchiveId method.
		/// </summary>
		GetByJobArchiveId,
		/// <summary>
		/// Represents the GetByJobId method.
		/// </summary>
		GetByJobId,
		/// <summary>
		/// Represents the GetByRoleId method.
		/// </summary>
		GetByRoleId
	}
	
	#endregion JobRolesSelectMethod

	#region JobRolesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobRolesFilter : SqlFilter<JobRolesColumn>
	{
	}
	
	#endregion JobRolesFilter

	#region JobRolesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobRolesExpressionBuilder : SqlExpressionBuilder<JobRolesColumn>
	{
	}
	
	#endregion JobRolesExpressionBuilder	

	#region JobRolesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;JobRolesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="JobRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobRolesProperty : ChildEntityProperty<JobRolesChildEntityTypes>
	{
	}
	
	#endregion JobRolesProperty
}

