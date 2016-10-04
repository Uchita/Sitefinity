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
	/// Represents the DataRepository.SiteRolesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(SiteRolesDataSourceDesigner))]
	public class SiteRolesDataSource : ProviderDataSource<SiteRoles, SiteRolesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteRolesDataSource class.
		/// </summary>
		public SiteRolesDataSource() : base(new SiteRolesService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the SiteRolesDataSourceView used by the SiteRolesDataSource.
		/// </summary>
		protected SiteRolesDataSourceView SiteRolesView
		{
			get { return ( View as SiteRolesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the SiteRolesDataSource control invokes to retrieve data.
		/// </summary>
		public SiteRolesSelectMethod SelectMethod
		{
			get
			{
				SiteRolesSelectMethod selectMethod = SiteRolesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (SiteRolesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the SiteRolesDataSourceView class that is to be
		/// used by the SiteRolesDataSource.
		/// </summary>
		/// <returns>An instance of the SiteRolesDataSourceView class.</returns>
		protected override BaseDataSourceView<SiteRoles, SiteRolesKey> GetNewDataSourceView()
		{
			return new SiteRolesDataSourceView(this, DefaultViewName);
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
	/// Supports the SiteRolesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class SiteRolesDataSourceView : ProviderDataSourceView<SiteRoles, SiteRolesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteRolesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the SiteRolesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public SiteRolesDataSourceView(SiteRolesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal SiteRolesDataSource SiteRolesOwner
		{
			get { return Owner as SiteRolesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal SiteRolesSelectMethod SelectMethod
		{
			get { return SiteRolesOwner.SelectMethod; }
			set { SiteRolesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal SiteRolesService SiteRolesProvider
		{
			get { return Provider as SiteRolesService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<SiteRoles> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<SiteRoles> results = null;
			SiteRoles item;
			count = 0;
			
			System.Int32 _siteId;
			System.Int32 _siteRoleId;
			System.String _siteRoleFriendlyUrl_nullable;
			System.Int32 _roleId;
			System.Int32? sp723_SiteId;
			System.String sp723_FriendlyUrl;
			System.Int32? sp720_SiteId;
			System.Int32? sp720_ProfessionId;

			switch ( SelectMethod )
			{
				case SiteRolesSelectMethod.Get:
					SiteRolesKey entityKey  = new SiteRolesKey();
					entityKey.Load(values);
					item = SiteRolesProvider.Get(entityKey);
					results = new TList<SiteRoles>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case SiteRolesSelectMethod.GetAll:
                    results = SiteRolesProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case SiteRolesSelectMethod.GetPaged:
					results = SiteRolesProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case SiteRolesSelectMethod.Find:
					if ( FilterParameters != null )
						results = SiteRolesProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = SiteRolesProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case SiteRolesSelectMethod.GetBySiteRoleId:
					_siteRoleId = ( values["SiteRoleId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteRoleId"], typeof(System.Int32)) : (int)0;
					item = SiteRolesProvider.GetBySiteRoleId(_siteRoleId);
					results = new TList<SiteRoles>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case SiteRolesSelectMethod.GetBySiteId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					results = SiteRolesProvider.GetBySiteId(_siteId, this.StartIndex, this.PageSize, out count);
					break;
				case SiteRolesSelectMethod.GetBySiteIdSiteRoleFriendlyUrl:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					_siteRoleFriendlyUrl_nullable = (System.String) EntityUtil.ChangeType(values["SiteRoleFriendlyUrl"], typeof(System.String));
					results = SiteRolesProvider.GetBySiteIdSiteRoleFriendlyUrl(_siteId, _siteRoleFriendlyUrl_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case SiteRolesSelectMethod.GetBySiteIdRoleId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					_roleId = ( values["RoleId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["RoleId"], typeof(System.Int32)) : (int)0;
					results = SiteRolesProvider.GetBySiteIdRoleId(_siteId, _roleId, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				case SiteRolesSelectMethod.GetByRoleId:
					_roleId = ( values["RoleId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["RoleId"], typeof(System.Int32)) : (int)0;
					results = SiteRolesProvider.GetByRoleId(_roleId, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				// Custom
				case SiteRolesSelectMethod.GetBySiteIdFriendlyUrl:
					sp723_SiteId = (System.Int32?) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32?));
					sp723_FriendlyUrl = (System.String) EntityUtil.ChangeType(values["FriendlyUrl"], typeof(System.String));
					results = SiteRolesProvider.GetBySiteIdFriendlyUrl(sp723_SiteId, sp723_FriendlyUrl, StartIndex, PageSize);
					break;
				case SiteRolesSelectMethod.GetByProfessionID:
					sp720_SiteId = (System.Int32?) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32?));
					sp720_ProfessionId = (System.Int32?) EntityUtil.ChangeType(values["ProfessionId"], typeof(System.Int32?));
					results = SiteRolesProvider.GetByProfessionID(sp720_SiteId, sp720_ProfessionId, StartIndex, PageSize);
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
			if ( SelectMethod == SiteRolesSelectMethod.Get || SelectMethod == SiteRolesSelectMethod.GetBySiteRoleId )
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
				SiteRoles entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					SiteRolesProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<SiteRoles> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			SiteRolesProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region SiteRolesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the SiteRolesDataSource class.
	/// </summary>
	public class SiteRolesDataSourceDesigner : ProviderDataSourceDesigner<SiteRoles, SiteRolesKey>
	{
		/// <summary>
		/// Initializes a new instance of the SiteRolesDataSourceDesigner class.
		/// </summary>
		public SiteRolesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SiteRolesSelectMethod SelectMethod
		{
			get { return ((SiteRolesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new SiteRolesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region SiteRolesDataSourceActionList

	/// <summary>
	/// Supports the SiteRolesDataSourceDesigner class.
	/// </summary>
	internal class SiteRolesDataSourceActionList : DesignerActionList
	{
		private SiteRolesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the SiteRolesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public SiteRolesDataSourceActionList(SiteRolesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SiteRolesSelectMethod SelectMethod
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

	#endregion SiteRolesDataSourceActionList
	
	#endregion SiteRolesDataSourceDesigner
	
	#region SiteRolesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the SiteRolesDataSource.SelectMethod property.
	/// </summary>
	public enum SiteRolesSelectMethod
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
		/// Represents the GetBySiteId method.
		/// </summary>
		GetBySiteId,
		/// <summary>
		/// Represents the GetBySiteRoleId method.
		/// </summary>
		GetBySiteRoleId,
		/// <summary>
		/// Represents the GetBySiteIdSiteRoleFriendlyUrl method.
		/// </summary>
		GetBySiteIdSiteRoleFriendlyUrl,
		/// <summary>
		/// Represents the GetBySiteIdRoleId method.
		/// </summary>
		GetBySiteIdRoleId,
		/// <summary>
		/// Represents the GetByRoleId method.
		/// </summary>
		GetByRoleId,
		/// <summary>
		/// Represents the GetBySiteIdFriendlyUrl method.
		/// </summary>
		GetBySiteIdFriendlyUrl,
		/// <summary>
		/// Represents the GetByProfessionID method.
		/// </summary>
		GetByProfessionID
	}
	
	#endregion SiteRolesSelectMethod

	#region SiteRolesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteRolesFilter : SqlFilter<SiteRolesColumn>
	{
	}
	
	#endregion SiteRolesFilter

	#region SiteRolesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteRolesExpressionBuilder : SqlExpressionBuilder<SiteRolesColumn>
	{
	}
	
	#endregion SiteRolesExpressionBuilder	

	#region SiteRolesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;SiteRolesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="SiteRoles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteRolesProperty : ChildEntityProperty<SiteRolesChildEntityTypes>
	{
	}
	
	#endregion SiteRolesProperty
}

