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
	/// Represents the DataRepository.AdminRolesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AdminRolesDataSourceDesigner))]
	public class AdminRolesDataSource : ProviderDataSource<AdminRoles, AdminRolesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminRolesDataSource class.
		/// </summary>
		public AdminRolesDataSource() : base(new AdminRolesService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AdminRolesDataSourceView used by the AdminRolesDataSource.
		/// </summary>
		protected AdminRolesDataSourceView AdminRolesView
		{
			get { return ( View as AdminRolesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AdminRolesDataSource control invokes to retrieve data.
		/// </summary>
		public AdminRolesSelectMethod SelectMethod
		{
			get
			{
				AdminRolesSelectMethod selectMethod = AdminRolesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AdminRolesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AdminRolesDataSourceView class that is to be
		/// used by the AdminRolesDataSource.
		/// </summary>
		/// <returns>An instance of the AdminRolesDataSourceView class.</returns>
		protected override BaseDataSourceView<AdminRoles, AdminRolesKey> GetNewDataSourceView()
		{
			return new AdminRolesDataSourceView(this, DefaultViewName);
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
	/// Supports the AdminRolesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AdminRolesDataSourceView : ProviderDataSourceView<AdminRoles, AdminRolesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdminRolesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AdminRolesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AdminRolesDataSourceView(AdminRolesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AdminRolesDataSource AdminRolesOwner
		{
			get { return Owner as AdminRolesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AdminRolesSelectMethod SelectMethod
		{
			get { return AdminRolesOwner.SelectMethod; }
			set { AdminRolesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AdminRolesService AdminRolesProvider
		{
			get { return Provider as AdminRolesService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AdminRoles> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AdminRoles> results = null;
			AdminRoles item;
			count = 0;
			
			System.Int32 _adminRoleId;

			switch ( SelectMethod )
			{
				case AdminRolesSelectMethod.Get:
					AdminRolesKey entityKey  = new AdminRolesKey();
					entityKey.Load(values);
					item = AdminRolesProvider.Get(entityKey);
					results = new TList<AdminRoles>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AdminRolesSelectMethod.GetAll:
                    results = AdminRolesProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AdminRolesSelectMethod.GetPaged:
					results = AdminRolesProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AdminRolesSelectMethod.Find:
					if ( FilterParameters != null )
						results = AdminRolesProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AdminRolesProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AdminRolesSelectMethod.GetByAdminRoleId:
					_adminRoleId = ( values["AdminRoleId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AdminRoleId"], typeof(System.Int32)) : (int)0;
					item = AdminRolesProvider.GetByAdminRoleId(_adminRoleId);
					results = new TList<AdminRoles>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
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
			if ( SelectMethod == AdminRolesSelectMethod.Get || SelectMethod == AdminRolesSelectMethod.GetByAdminRoleId )
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
				AdminRoles entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AdminRolesProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<AdminRoles> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AdminRolesProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AdminRolesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AdminRolesDataSource class.
	/// </summary>
	public class AdminRolesDataSourceDesigner : ProviderDataSourceDesigner<AdminRoles, AdminRolesKey>
	{
		/// <summary>
		/// Initializes a new instance of the AdminRolesDataSourceDesigner class.
		/// </summary>
		public AdminRolesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AdminRolesSelectMethod SelectMethod
		{
			get { return ((AdminRolesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AdminRolesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AdminRolesDataSourceActionList

	/// <summary>
	/// Supports the AdminRolesDataSourceDesigner class.
	/// </summary>
	internal class AdminRolesDataSourceActionList : DesignerActionList
	{
		private AdminRolesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AdminRolesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AdminRolesDataSourceActionList(AdminRolesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AdminRolesSelectMethod SelectMethod
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

	#endregion AdminRolesDataSourceActionList
	
	#endregion AdminRolesDataSourceDesigner
	
	#region AdminRolesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AdminRolesDataSource.SelectMethod property.
	/// </summary>
	public enum AdminRolesSelectMethod
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
		/// Represents the GetByAdminRoleId method.
		/// </summary>
		GetByAdminRoleId
	}
	
	#endregion AdminRolesSelectMethod

	#region AdminRolesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminRolesFilter : SqlFilter<AdminRolesColumn>
	{
	}
	
	#endregion AdminRolesFilter

	#region AdminRolesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdminRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminRolesExpressionBuilder : SqlExpressionBuilder<AdminRolesColumn>
	{
	}
	
	#endregion AdminRolesExpressionBuilder	

	#region AdminRolesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AdminRolesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AdminRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdminRolesProperty : ChildEntityProperty<AdminRolesChildEntityTypes>
	{
	}
	
	#endregion AdminRolesProperty
}

