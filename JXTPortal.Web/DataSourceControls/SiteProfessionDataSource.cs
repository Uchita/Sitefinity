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
	/// Represents the DataRepository.SiteProfessionProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(SiteProfessionDataSourceDesigner))]
	public class SiteProfessionDataSource : ProviderDataSource<SiteProfession, SiteProfessionKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteProfessionDataSource class.
		/// </summary>
		public SiteProfessionDataSource() : base(new SiteProfessionService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the SiteProfessionDataSourceView used by the SiteProfessionDataSource.
		/// </summary>
		protected SiteProfessionDataSourceView SiteProfessionView
		{
			get { return ( View as SiteProfessionDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the SiteProfessionDataSource control invokes to retrieve data.
		/// </summary>
		public SiteProfessionSelectMethod SelectMethod
		{
			get
			{
				SiteProfessionSelectMethod selectMethod = SiteProfessionSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (SiteProfessionSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the SiteProfessionDataSourceView class that is to be
		/// used by the SiteProfessionDataSource.
		/// </summary>
		/// <returns>An instance of the SiteProfessionDataSourceView class.</returns>
		protected override BaseDataSourceView<SiteProfession, SiteProfessionKey> GetNewDataSourceView()
		{
			return new SiteProfessionDataSourceView(this, DefaultViewName);
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
	/// Supports the SiteProfessionDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class SiteProfessionDataSourceView : ProviderDataSourceView<SiteProfession, SiteProfessionKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteProfessionDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the SiteProfessionDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public SiteProfessionDataSourceView(SiteProfessionDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal SiteProfessionDataSource SiteProfessionOwner
		{
			get { return Owner as SiteProfessionDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal SiteProfessionSelectMethod SelectMethod
		{
			get { return SiteProfessionOwner.SelectMethod; }
			set { SiteProfessionOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal SiteProfessionService SiteProfessionProvider
		{
			get { return Provider as SiteProfessionService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<SiteProfession> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<SiteProfession> results = null;
			SiteProfession item;
			count = 0;
			
			System.Int32 _siteId;
			System.Int32 _professionId;
			System.Int32 _siteProfessionId;
			System.Int32? sp689_SiteId;
			System.String sp689_SiteProfessionFriendlyUrl;
			System.Int32? sp690_SiteId;
			System.Int32? sp690_ProfessionId;

			switch ( SelectMethod )
			{
				case SiteProfessionSelectMethod.Get:
					SiteProfessionKey entityKey  = new SiteProfessionKey();
					entityKey.Load(values);
					item = SiteProfessionProvider.Get(entityKey);
					results = new TList<SiteProfession>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case SiteProfessionSelectMethod.GetAll:
                    results = SiteProfessionProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case SiteProfessionSelectMethod.GetPaged:
					results = SiteProfessionProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case SiteProfessionSelectMethod.Find:
					if ( FilterParameters != null )
						results = SiteProfessionProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = SiteProfessionProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case SiteProfessionSelectMethod.GetBySiteProfessionId:
					_siteProfessionId = ( values["SiteProfessionId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteProfessionId"], typeof(System.Int32)) : (int)0;
					item = SiteProfessionProvider.GetBySiteProfessionId(_siteProfessionId);
					results = new TList<SiteProfession>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case SiteProfessionSelectMethod.GetBySiteId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					results = SiteProfessionProvider.GetBySiteId(_siteId, this.StartIndex, this.PageSize, out count);
					break;
				case SiteProfessionSelectMethod.GetByProfessionId:
					_professionId = ( values["ProfessionId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProfessionId"], typeof(System.Int32)) : (int)0;
					results = SiteProfessionProvider.GetByProfessionId(_professionId, this.StartIndex, this.PageSize, out count);
					break;
				// FK
				// M:M
				// Custom
				case SiteProfessionSelectMethod.CustomGetBySiteIDFriendlyUrl:
					sp689_SiteId = (System.Int32?) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32?));
					sp689_SiteProfessionFriendlyUrl = (System.String) EntityUtil.ChangeType(values["SiteProfessionFriendlyUrl"], typeof(System.String));
					results = SiteProfessionProvider.CustomGetBySiteIDFriendlyUrl(sp689_SiteId, sp689_SiteProfessionFriendlyUrl, StartIndex, PageSize);
					break;
				case SiteProfessionSelectMethod.CustomGetBySiteIDProfessionID:
					sp690_SiteId = (System.Int32?) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32?));
					sp690_ProfessionId = (System.Int32?) EntityUtil.ChangeType(values["ProfessionId"], typeof(System.Int32?));
					results = SiteProfessionProvider.CustomGetBySiteIDProfessionID(sp690_SiteId, sp690_ProfessionId, StartIndex, PageSize);
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
			if ( SelectMethod == SiteProfessionSelectMethod.Get || SelectMethod == SiteProfessionSelectMethod.GetBySiteProfessionId )
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
				SiteProfession entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					SiteProfessionProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<SiteProfession> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			SiteProfessionProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region SiteProfessionDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the SiteProfessionDataSource class.
	/// </summary>
	public class SiteProfessionDataSourceDesigner : ProviderDataSourceDesigner<SiteProfession, SiteProfessionKey>
	{
		/// <summary>
		/// Initializes a new instance of the SiteProfessionDataSourceDesigner class.
		/// </summary>
		public SiteProfessionDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SiteProfessionSelectMethod SelectMethod
		{
			get { return ((SiteProfessionDataSource) DataSource).SelectMethod; }
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
				actions.Add(new SiteProfessionDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region SiteProfessionDataSourceActionList

	/// <summary>
	/// Supports the SiteProfessionDataSourceDesigner class.
	/// </summary>
	internal class SiteProfessionDataSourceActionList : DesignerActionList
	{
		private SiteProfessionDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the SiteProfessionDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public SiteProfessionDataSourceActionList(SiteProfessionDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SiteProfessionSelectMethod SelectMethod
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

	#endregion SiteProfessionDataSourceActionList
	
	#endregion SiteProfessionDataSourceDesigner
	
	#region SiteProfessionSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the SiteProfessionDataSource.SelectMethod property.
	/// </summary>
	public enum SiteProfessionSelectMethod
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
		/// Represents the GetByProfessionId method.
		/// </summary>
		GetByProfessionId,
		/// <summary>
		/// Represents the GetBySiteProfessionId method.
		/// </summary>
		GetBySiteProfessionId,
		/// <summary>
		/// Represents the CustomGetBySiteIDFriendlyUrl method.
		/// </summary>
		CustomGetBySiteIDFriendlyUrl,
		/// <summary>
		/// Represents the CustomGetBySiteIDProfessionID method.
		/// </summary>
		CustomGetBySiteIDProfessionID
	}
	
	#endregion SiteProfessionSelectMethod

	#region SiteProfessionFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteProfession"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteProfessionFilter : SqlFilter<SiteProfessionColumn>
	{
	}
	
	#endregion SiteProfessionFilter

	#region SiteProfessionExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteProfession"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteProfessionExpressionBuilder : SqlExpressionBuilder<SiteProfessionColumn>
	{
	}
	
	#endregion SiteProfessionExpressionBuilder	

	#region SiteProfessionProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;SiteProfessionChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="SiteProfession"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteProfessionProperty : ChildEntityProperty<SiteProfessionChildEntityTypes>
	{
	}
	
	#endregion SiteProfessionProperty
}

