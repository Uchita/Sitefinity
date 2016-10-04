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
	/// Represents the DataRepository.CustomWidgetProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CustomWidgetDataSourceDesigner))]
	public class CustomWidgetDataSource : ProviderDataSource<CustomWidget, CustomWidgetKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomWidgetDataSource class.
		/// </summary>
		public CustomWidgetDataSource() : base(new CustomWidgetService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CustomWidgetDataSourceView used by the CustomWidgetDataSource.
		/// </summary>
		protected CustomWidgetDataSourceView CustomWidgetView
		{
			get { return ( View as CustomWidgetDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CustomWidgetDataSource control invokes to retrieve data.
		/// </summary>
		public CustomWidgetSelectMethod SelectMethod
		{
			get
			{
				CustomWidgetSelectMethod selectMethod = CustomWidgetSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CustomWidgetSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CustomWidgetDataSourceView class that is to be
		/// used by the CustomWidgetDataSource.
		/// </summary>
		/// <returns>An instance of the CustomWidgetDataSourceView class.</returns>
		protected override BaseDataSourceView<CustomWidget, CustomWidgetKey> GetNewDataSourceView()
		{
			return new CustomWidgetDataSourceView(this, DefaultViewName);
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
	/// Supports the CustomWidgetDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CustomWidgetDataSourceView : ProviderDataSourceView<CustomWidget, CustomWidgetKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomWidgetDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CustomWidgetDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CustomWidgetDataSourceView(CustomWidgetDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CustomWidgetDataSource CustomWidgetOwner
		{
			get { return Owner as CustomWidgetDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CustomWidgetSelectMethod SelectMethod
		{
			get { return CustomWidgetOwner.SelectMethod; }
			set { CustomWidgetOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CustomWidgetService CustomWidgetProvider
		{
			get { return Provider as CustomWidgetService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<CustomWidget> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<CustomWidget> results = null;
			CustomWidget item;
			count = 0;
			
			System.Int32 _customWidgetId;
			System.Int32 _customWidgetCssSelectorId;
			System.Int32 _siteId;

			switch ( SelectMethod )
			{
				case CustomWidgetSelectMethod.Get:
					CustomWidgetKey entityKey  = new CustomWidgetKey();
					entityKey.Load(values);
					item = CustomWidgetProvider.Get(entityKey);
					results = new TList<CustomWidget>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CustomWidgetSelectMethod.GetAll:
                    results = CustomWidgetProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CustomWidgetSelectMethod.GetPaged:
					results = CustomWidgetProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CustomWidgetSelectMethod.Find:
					if ( FilterParameters != null )
						results = CustomWidgetProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CustomWidgetProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CustomWidgetSelectMethod.GetByCustomWidgetId:
					_customWidgetId = ( values["CustomWidgetId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomWidgetId"], typeof(System.Int32)) : (int)0;
					item = CustomWidgetProvider.GetByCustomWidgetId(_customWidgetId);
					results = new TList<CustomWidget>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case CustomWidgetSelectMethod.GetByCustomWidgetCssSelectorId:
					_customWidgetCssSelectorId = ( values["CustomWidgetCssSelectorId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomWidgetCssSelectorId"], typeof(System.Int32)) : (int)0;
					results = CustomWidgetProvider.GetByCustomWidgetCssSelectorId(_customWidgetCssSelectorId, this.StartIndex, this.PageSize, out count);
					break;
				case CustomWidgetSelectMethod.GetBySiteId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					results = CustomWidgetProvider.GetBySiteId(_siteId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == CustomWidgetSelectMethod.Get || SelectMethod == CustomWidgetSelectMethod.GetByCustomWidgetId )
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
				CustomWidget entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					CustomWidgetProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<CustomWidget> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			CustomWidgetProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CustomWidgetDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CustomWidgetDataSource class.
	/// </summary>
	public class CustomWidgetDataSourceDesigner : ProviderDataSourceDesigner<CustomWidget, CustomWidgetKey>
	{
		/// <summary>
		/// Initializes a new instance of the CustomWidgetDataSourceDesigner class.
		/// </summary>
		public CustomWidgetDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CustomWidgetSelectMethod SelectMethod
		{
			get { return ((CustomWidgetDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CustomWidgetDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CustomWidgetDataSourceActionList

	/// <summary>
	/// Supports the CustomWidgetDataSourceDesigner class.
	/// </summary>
	internal class CustomWidgetDataSourceActionList : DesignerActionList
	{
		private CustomWidgetDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CustomWidgetDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CustomWidgetDataSourceActionList(CustomWidgetDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CustomWidgetSelectMethod SelectMethod
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

	#endregion CustomWidgetDataSourceActionList
	
	#endregion CustomWidgetDataSourceDesigner
	
	#region CustomWidgetSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CustomWidgetDataSource.SelectMethod property.
	/// </summary>
	public enum CustomWidgetSelectMethod
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
		/// Represents the GetByCustomWidgetId method.
		/// </summary>
		GetByCustomWidgetId,
		/// <summary>
		/// Represents the GetByCustomWidgetCssSelectorId method.
		/// </summary>
		GetByCustomWidgetCssSelectorId,
		/// <summary>
		/// Represents the GetBySiteId method.
		/// </summary>
		GetBySiteId
	}
	
	#endregion CustomWidgetSelectMethod

	#region CustomWidgetFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomWidget"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomWidgetFilter : SqlFilter<CustomWidgetColumn>
	{
	}
	
	#endregion CustomWidgetFilter

	#region CustomWidgetExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomWidget"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomWidgetExpressionBuilder : SqlExpressionBuilder<CustomWidgetColumn>
	{
	}
	
	#endregion CustomWidgetExpressionBuilder	

	#region CustomWidgetProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CustomWidgetChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="CustomWidget"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomWidgetProperty : ChildEntityProperty<CustomWidgetChildEntityTypes>
	{
	}
	
	#endregion CustomWidgetProperty
}

