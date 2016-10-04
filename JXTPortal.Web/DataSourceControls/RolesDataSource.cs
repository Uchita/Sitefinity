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
	/// Represents the DataRepository.RolesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(RolesDataSourceDesigner))]
	public class RolesDataSource : ProviderDataSource<Roles, RolesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RolesDataSource class.
		/// </summary>
		public RolesDataSource() : base(new RolesService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the RolesDataSourceView used by the RolesDataSource.
		/// </summary>
		protected RolesDataSourceView RolesView
		{
			get { return ( View as RolesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the RolesDataSource control invokes to retrieve data.
		/// </summary>
		public RolesSelectMethod SelectMethod
		{
			get
			{
				RolesSelectMethod selectMethod = RolesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (RolesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the RolesDataSourceView class that is to be
		/// used by the RolesDataSource.
		/// </summary>
		/// <returns>An instance of the RolesDataSourceView class.</returns>
		protected override BaseDataSourceView<Roles, RolesKey> GetNewDataSourceView()
		{
			return new RolesDataSourceView(this, DefaultViewName);
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
	/// Supports the RolesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class RolesDataSourceView : ProviderDataSourceView<Roles, RolesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the RolesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the RolesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public RolesDataSourceView(RolesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal RolesDataSource RolesOwner
		{
			get { return Owner as RolesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal RolesSelectMethod SelectMethod
		{
			get { return RolesOwner.SelectMethod; }
			set { RolesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal RolesService RolesProvider
		{
			get { return Provider as RolesService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Roles> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Roles> results = null;
			Roles item;
			count = 0;
			
			System.Int32 _roleId;
			System.Int32 _professionId;
			System.Int32? sp487_ProfessionId;
			System.Boolean? sp485_SearchUsingOr;
			System.Int32? sp485_RoleId;
			System.Int32? sp485_ProfessionId;
			System.String sp485_RoleName;
			System.Boolean? sp485_Valid;
			System.String sp485_MetaTitle;
			System.String sp485_MetaKeywords;
			System.String sp485_MetaDescription;
			System.Int32? sp488_RoleId;

			switch ( SelectMethod )
			{
				case RolesSelectMethod.Get:
					RolesKey entityKey  = new RolesKey();
					entityKey.Load(values);
					item = RolesProvider.Get(entityKey);
					results = new TList<Roles>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case RolesSelectMethod.GetAll:
                    results = RolesProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case RolesSelectMethod.GetPaged:
					results = RolesProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case RolesSelectMethod.Find:
					if ( FilterParameters != null )
						results = RolesProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = RolesProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case RolesSelectMethod.GetByRoleId:
					_roleId = ( values["RoleId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["RoleId"], typeof(System.Int32)) : (int)0;
					item = RolesProvider.GetByRoleId(_roleId);
					results = new TList<Roles>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case RolesSelectMethod.GetByProfessionId:
					_professionId = ( values["ProfessionId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProfessionId"], typeof(System.Int32)) : (int)0;
					results = RolesProvider.GetByProfessionId(_professionId, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				// Custom
				case RolesSelectMethod.Get_List:
					results = RolesProvider.Get_List(StartIndex, PageSize);
					break;
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
			if ( SelectMethod == RolesSelectMethod.Get || SelectMethod == RolesSelectMethod.GetByRoleId )
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
				Roles entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					RolesProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Roles> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			RolesProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region RolesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the RolesDataSource class.
	/// </summary>
	public class RolesDataSourceDesigner : ProviderDataSourceDesigner<Roles, RolesKey>
	{
		/// <summary>
		/// Initializes a new instance of the RolesDataSourceDesigner class.
		/// </summary>
		public RolesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public RolesSelectMethod SelectMethod
		{
			get { return ((RolesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new RolesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region RolesDataSourceActionList

	/// <summary>
	/// Supports the RolesDataSourceDesigner class.
	/// </summary>
	internal class RolesDataSourceActionList : DesignerActionList
	{
		private RolesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the RolesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public RolesDataSourceActionList(RolesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public RolesSelectMethod SelectMethod
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

	#endregion RolesDataSourceActionList
	
	#endregion RolesDataSourceDesigner
	
	#region RolesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the RolesDataSource.SelectMethod property.
	/// </summary>
	public enum RolesSelectMethod
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
		/// Represents the GetByRoleId method.
		/// </summary>
		GetByRoleId,
		/// <summary>
		/// Represents the GetByProfessionId method.
		/// </summary>
		GetByProfessionId,
		/// <summary>
		/// Represents the Get_List method.
		/// </summary>
		Get_List
	}
	
	#endregion RolesSelectMethod

	#region RolesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Roles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RolesFilter : SqlFilter<RolesColumn>
	{
	}
	
	#endregion RolesFilter

	#region RolesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Roles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RolesExpressionBuilder : SqlExpressionBuilder<RolesColumn>
	{
	}
	
	#endregion RolesExpressionBuilder	

	#region RolesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;RolesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Roles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class RolesProperty : ChildEntityProperty<RolesChildEntityTypes>
	{
	}
	
	#endregion RolesProperty
}

