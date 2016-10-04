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
	/// Represents the DataRepository.SiteLocationProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(SiteLocationDataSourceDesigner))]
	public class SiteLocationDataSource : ProviderDataSource<SiteLocation, SiteLocationKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteLocationDataSource class.
		/// </summary>
		public SiteLocationDataSource() : base(new SiteLocationService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the SiteLocationDataSourceView used by the SiteLocationDataSource.
		/// </summary>
		protected SiteLocationDataSourceView SiteLocationView
		{
			get { return ( View as SiteLocationDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the SiteLocationDataSource control invokes to retrieve data.
		/// </summary>
		public SiteLocationSelectMethod SelectMethod
		{
			get
			{
				SiteLocationSelectMethod selectMethod = SiteLocationSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (SiteLocationSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the SiteLocationDataSourceView class that is to be
		/// used by the SiteLocationDataSource.
		/// </summary>
		/// <returns>An instance of the SiteLocationDataSourceView class.</returns>
		protected override BaseDataSourceView<SiteLocation, SiteLocationKey> GetNewDataSourceView()
		{
			return new SiteLocationDataSourceView(this, DefaultViewName);
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
	/// Supports the SiteLocationDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class SiteLocationDataSourceView : ProviderDataSourceView<SiteLocation, SiteLocationKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteLocationDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the SiteLocationDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public SiteLocationDataSourceView(SiteLocationDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal SiteLocationDataSource SiteLocationOwner
		{
			get { return Owner as SiteLocationDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal SiteLocationSelectMethod SelectMethod
		{
			get { return SiteLocationOwner.SelectMethod; }
			set { SiteLocationOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal SiteLocationService SiteLocationProvider
		{
			get { return Provider as SiteLocationService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<SiteLocation> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<SiteLocation> results = null;
			SiteLocation item;
			count = 0;
			
			System.Int32 _siteLocationId;
			System.Int32 _locationId;
			System.Int32 _siteId;
			System.Int32? sp618_LocationId;
			System.String sp622_WhereClause;
			System.String sp622_OrderBy;
			System.Int32? sp622_PageIndex;
			System.Int32? sp622_PageSize;
			System.Int32? sp620_SiteId;
			System.String sp620_FriendlyUrl;
			System.Int32? sp619_SiteId;
			System.Int32? sp621_SiteLocationId;
			System.Boolean? sp615_SearchUsingOr;
			System.Int32? sp615_SiteLocationId;
			System.Int32? sp615_LocationId;
			System.Int32? sp615_SiteId;
			System.String sp615_SiteLocationName;
			System.Boolean? sp615_Valid;
			System.String sp615_SiteLocationFriendlyUrl;

			switch ( SelectMethod )
			{
				case SiteLocationSelectMethod.Get:
					SiteLocationKey entityKey  = new SiteLocationKey();
					entityKey.Load(values);
					item = SiteLocationProvider.Get(entityKey);
					results = new TList<SiteLocation>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case SiteLocationSelectMethod.GetAll:
                    results = SiteLocationProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case SiteLocationSelectMethod.GetPaged:
					results = SiteLocationProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case SiteLocationSelectMethod.Find:
					if ( FilterParameters != null )
						results = SiteLocationProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = SiteLocationProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case SiteLocationSelectMethod.GetBySiteLocationId:
					_siteLocationId = ( values["SiteLocationId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteLocationId"], typeof(System.Int32)) : (int)0;
					item = SiteLocationProvider.GetBySiteLocationId(_siteLocationId);
					results = new TList<SiteLocation>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case SiteLocationSelectMethod.GetByLocationId:
					_locationId = ( values["LocationId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["LocationId"], typeof(System.Int32)) : (int)0;
					results = SiteLocationProvider.GetByLocationId(_locationId, this.StartIndex, this.PageSize, out count);
					break;
				case SiteLocationSelectMethod.GetBySiteId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					results = SiteLocationProvider.GetBySiteId(_siteId, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				// Custom
				case SiteLocationSelectMethod.Get_List:
					results = SiteLocationProvider.Get_List(StartIndex, PageSize);
					break;
				case SiteLocationSelectMethod.GetBySiteIdFriendlyUrl:
					sp620_SiteId = (System.Int32?) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32?));
					sp620_FriendlyUrl = (System.String) EntityUtil.ChangeType(values["FriendlyUrl"], typeof(System.String));
					results = SiteLocationProvider.GetBySiteIdFriendlyUrl(sp620_SiteId, sp620_FriendlyUrl, StartIndex, PageSize);
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
			if ( SelectMethod == SiteLocationSelectMethod.Get || SelectMethod == SiteLocationSelectMethod.GetBySiteLocationId )
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
				SiteLocation entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					SiteLocationProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<SiteLocation> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			SiteLocationProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region SiteLocationDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the SiteLocationDataSource class.
	/// </summary>
	public class SiteLocationDataSourceDesigner : ProviderDataSourceDesigner<SiteLocation, SiteLocationKey>
	{
		/// <summary>
		/// Initializes a new instance of the SiteLocationDataSourceDesigner class.
		/// </summary>
		public SiteLocationDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SiteLocationSelectMethod SelectMethod
		{
			get { return ((SiteLocationDataSource) DataSource).SelectMethod; }
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
				actions.Add(new SiteLocationDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region SiteLocationDataSourceActionList

	/// <summary>
	/// Supports the SiteLocationDataSourceDesigner class.
	/// </summary>
	internal class SiteLocationDataSourceActionList : DesignerActionList
	{
		private SiteLocationDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the SiteLocationDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public SiteLocationDataSourceActionList(SiteLocationDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SiteLocationSelectMethod SelectMethod
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

	#endregion SiteLocationDataSourceActionList
	
	#endregion SiteLocationDataSourceDesigner
	
	#region SiteLocationSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the SiteLocationDataSource.SelectMethod property.
	/// </summary>
	public enum SiteLocationSelectMethod
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
		/// Represents the GetBySiteLocationId method.
		/// </summary>
		GetBySiteLocationId,
		/// <summary>
		/// Represents the GetByLocationId method.
		/// </summary>
		GetByLocationId,
		/// <summary>
		/// Represents the GetBySiteId method.
		/// </summary>
		GetBySiteId,
		/// <summary>
		/// Represents the Get_List method.
		/// </summary>
		Get_List,
		/// <summary>
		/// Represents the GetBySiteIdFriendlyUrl method.
		/// </summary>
		GetBySiteIdFriendlyUrl
	}
	
	#endregion SiteLocationSelectMethod

	#region SiteLocationFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteLocation"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteLocationFilter : SqlFilter<SiteLocationColumn>
	{
	}
	
	#endregion SiteLocationFilter

	#region SiteLocationExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteLocation"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteLocationExpressionBuilder : SqlExpressionBuilder<SiteLocationColumn>
	{
	}
	
	#endregion SiteLocationExpressionBuilder	

	#region SiteLocationProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;SiteLocationChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="SiteLocation"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteLocationProperty : ChildEntityProperty<SiteLocationChildEntityTypes>
	{
	}
	
	#endregion SiteLocationProperty
}

