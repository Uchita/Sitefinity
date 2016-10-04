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
	/// Represents the DataRepository.DynamicPageWebPartTemplatesLinkProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DynamicPageWebPartTemplatesLinkDataSourceDesigner))]
	public class DynamicPageWebPartTemplatesLinkDataSource : ProviderDataSource<DynamicPageWebPartTemplatesLink, DynamicPageWebPartTemplatesLinkKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicPageWebPartTemplatesLinkDataSource class.
		/// </summary>
		public DynamicPageWebPartTemplatesLinkDataSource() : base(new DynamicPageWebPartTemplatesLinkService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DynamicPageWebPartTemplatesLinkDataSourceView used by the DynamicPageWebPartTemplatesLinkDataSource.
		/// </summary>
		protected DynamicPageWebPartTemplatesLinkDataSourceView DynamicPageWebPartTemplatesLinkView
		{
			get { return ( View as DynamicPageWebPartTemplatesLinkDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DynamicPageWebPartTemplatesLinkDataSource control invokes to retrieve data.
		/// </summary>
		public DynamicPageWebPartTemplatesLinkSelectMethod SelectMethod
		{
			get
			{
				DynamicPageWebPartTemplatesLinkSelectMethod selectMethod = DynamicPageWebPartTemplatesLinkSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DynamicPageWebPartTemplatesLinkSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DynamicPageWebPartTemplatesLinkDataSourceView class that is to be
		/// used by the DynamicPageWebPartTemplatesLinkDataSource.
		/// </summary>
		/// <returns>An instance of the DynamicPageWebPartTemplatesLinkDataSourceView class.</returns>
		protected override BaseDataSourceView<DynamicPageWebPartTemplatesLink, DynamicPageWebPartTemplatesLinkKey> GetNewDataSourceView()
		{
			return new DynamicPageWebPartTemplatesLinkDataSourceView(this, DefaultViewName);
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
	/// Supports the DynamicPageWebPartTemplatesLinkDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DynamicPageWebPartTemplatesLinkDataSourceView : ProviderDataSourceView<DynamicPageWebPartTemplatesLink, DynamicPageWebPartTemplatesLinkKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicPageWebPartTemplatesLinkDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DynamicPageWebPartTemplatesLinkDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DynamicPageWebPartTemplatesLinkDataSourceView(DynamicPageWebPartTemplatesLinkDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DynamicPageWebPartTemplatesLinkDataSource DynamicPageWebPartTemplatesLinkOwner
		{
			get { return Owner as DynamicPageWebPartTemplatesLinkDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DynamicPageWebPartTemplatesLinkSelectMethod SelectMethod
		{
			get { return DynamicPageWebPartTemplatesLinkOwner.SelectMethod; }
			set { DynamicPageWebPartTemplatesLinkOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DynamicPageWebPartTemplatesLinkService DynamicPageWebPartTemplatesLinkProvider
		{
			get { return Provider as DynamicPageWebPartTemplatesLinkService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<DynamicPageWebPartTemplatesLink> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<DynamicPageWebPartTemplatesLink> results = null;
			DynamicPageWebPartTemplatesLink item;
			count = 0;
			
			System.Int32 _dynamicPageWebPartTemplateId;
			System.Int32 _siteWebPartId;
			System.Int32 _dynamicPageWebPartTemplatesLinkId;

			switch ( SelectMethod )
			{
				case DynamicPageWebPartTemplatesLinkSelectMethod.Get:
					DynamicPageWebPartTemplatesLinkKey entityKey  = new DynamicPageWebPartTemplatesLinkKey();
					entityKey.Load(values);
					item = DynamicPageWebPartTemplatesLinkProvider.Get(entityKey);
					results = new TList<DynamicPageWebPartTemplatesLink>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DynamicPageWebPartTemplatesLinkSelectMethod.GetAll:
                    results = DynamicPageWebPartTemplatesLinkProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case DynamicPageWebPartTemplatesLinkSelectMethod.GetPaged:
					results = DynamicPageWebPartTemplatesLinkProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DynamicPageWebPartTemplatesLinkSelectMethod.Find:
					if ( FilterParameters != null )
						results = DynamicPageWebPartTemplatesLinkProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DynamicPageWebPartTemplatesLinkProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DynamicPageWebPartTemplatesLinkSelectMethod.GetByDynamicPageWebPartTemplatesLinkId:
					_dynamicPageWebPartTemplatesLinkId = ( values["DynamicPageWebPartTemplatesLinkId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["DynamicPageWebPartTemplatesLinkId"], typeof(System.Int32)) : (int)0;
					item = DynamicPageWebPartTemplatesLinkProvider.GetByDynamicPageWebPartTemplatesLinkId(_dynamicPageWebPartTemplatesLinkId);
					results = new TList<DynamicPageWebPartTemplatesLink>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case DynamicPageWebPartTemplatesLinkSelectMethod.GetByDynamicPageWebPartTemplateIdSiteWebPartId:
					_dynamicPageWebPartTemplateId = ( values["DynamicPageWebPartTemplateId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["DynamicPageWebPartTemplateId"], typeof(System.Int32)) : (int)0;
					_siteWebPartId = ( values["SiteWebPartId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteWebPartId"], typeof(System.Int32)) : (int)0;
					item = DynamicPageWebPartTemplatesLinkProvider.GetByDynamicPageWebPartTemplateIdSiteWebPartId(_dynamicPageWebPartTemplateId, _siteWebPartId);
					results = new TList<DynamicPageWebPartTemplatesLink>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				case DynamicPageWebPartTemplatesLinkSelectMethod.GetByDynamicPageWebPartTemplateId:
					_dynamicPageWebPartTemplateId = ( values["DynamicPageWebPartTemplateId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["DynamicPageWebPartTemplateId"], typeof(System.Int32)) : (int)0;
					results = DynamicPageWebPartTemplatesLinkProvider.GetByDynamicPageWebPartTemplateId(_dynamicPageWebPartTemplateId, this.StartIndex, this.PageSize, out count);
					break;
				case DynamicPageWebPartTemplatesLinkSelectMethod.GetBySiteWebPartId:
					_siteWebPartId = ( values["SiteWebPartId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteWebPartId"], typeof(System.Int32)) : (int)0;
					results = DynamicPageWebPartTemplatesLinkProvider.GetBySiteWebPartId(_siteWebPartId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == DynamicPageWebPartTemplatesLinkSelectMethod.Get || SelectMethod == DynamicPageWebPartTemplatesLinkSelectMethod.GetByDynamicPageWebPartTemplatesLinkId )
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
				DynamicPageWebPartTemplatesLink entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					DynamicPageWebPartTemplatesLinkProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<DynamicPageWebPartTemplatesLink> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			DynamicPageWebPartTemplatesLinkProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DynamicPageWebPartTemplatesLinkDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DynamicPageWebPartTemplatesLinkDataSource class.
	/// </summary>
	public class DynamicPageWebPartTemplatesLinkDataSourceDesigner : ProviderDataSourceDesigner<DynamicPageWebPartTemplatesLink, DynamicPageWebPartTemplatesLinkKey>
	{
		/// <summary>
		/// Initializes a new instance of the DynamicPageWebPartTemplatesLinkDataSourceDesigner class.
		/// </summary>
		public DynamicPageWebPartTemplatesLinkDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DynamicPageWebPartTemplatesLinkSelectMethod SelectMethod
		{
			get { return ((DynamicPageWebPartTemplatesLinkDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DynamicPageWebPartTemplatesLinkDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DynamicPageWebPartTemplatesLinkDataSourceActionList

	/// <summary>
	/// Supports the DynamicPageWebPartTemplatesLinkDataSourceDesigner class.
	/// </summary>
	internal class DynamicPageWebPartTemplatesLinkDataSourceActionList : DesignerActionList
	{
		private DynamicPageWebPartTemplatesLinkDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DynamicPageWebPartTemplatesLinkDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DynamicPageWebPartTemplatesLinkDataSourceActionList(DynamicPageWebPartTemplatesLinkDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DynamicPageWebPartTemplatesLinkSelectMethod SelectMethod
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

	#endregion DynamicPageWebPartTemplatesLinkDataSourceActionList
	
	#endregion DynamicPageWebPartTemplatesLinkDataSourceDesigner
	
	#region DynamicPageWebPartTemplatesLinkSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DynamicPageWebPartTemplatesLinkDataSource.SelectMethod property.
	/// </summary>
	public enum DynamicPageWebPartTemplatesLinkSelectMethod
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
		/// Represents the GetByDynamicPageWebPartTemplateIdSiteWebPartId method.
		/// </summary>
		GetByDynamicPageWebPartTemplateIdSiteWebPartId,
		/// <summary>
		/// Represents the GetByDynamicPageWebPartTemplatesLinkId method.
		/// </summary>
		GetByDynamicPageWebPartTemplatesLinkId,
		/// <summary>
		/// Represents the GetByDynamicPageWebPartTemplateId method.
		/// </summary>
		GetByDynamicPageWebPartTemplateId,
		/// <summary>
		/// Represents the GetBySiteWebPartId method.
		/// </summary>
		GetBySiteWebPartId
	}
	
	#endregion DynamicPageWebPartTemplatesLinkSelectMethod

	#region DynamicPageWebPartTemplatesLinkFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicPageWebPartTemplatesLink"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicPageWebPartTemplatesLinkFilter : SqlFilter<DynamicPageWebPartTemplatesLinkColumn>
	{
	}
	
	#endregion DynamicPageWebPartTemplatesLinkFilter

	#region DynamicPageWebPartTemplatesLinkExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicPageWebPartTemplatesLink"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicPageWebPartTemplatesLinkExpressionBuilder : SqlExpressionBuilder<DynamicPageWebPartTemplatesLinkColumn>
	{
	}
	
	#endregion DynamicPageWebPartTemplatesLinkExpressionBuilder	

	#region DynamicPageWebPartTemplatesLinkProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DynamicPageWebPartTemplatesLinkChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicPageWebPartTemplatesLink"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicPageWebPartTemplatesLinkProperty : ChildEntityProperty<DynamicPageWebPartTemplatesLinkChildEntityTypes>
	{
	}
	
	#endregion DynamicPageWebPartTemplatesLinkProperty
}

