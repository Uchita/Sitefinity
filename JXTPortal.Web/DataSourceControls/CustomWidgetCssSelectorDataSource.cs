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
	/// Represents the DataRepository.CustomWidgetCssSelectorProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CustomWidgetCssSelectorDataSourceDesigner))]
	public class CustomWidgetCssSelectorDataSource : ProviderDataSource<CustomWidgetCssSelector, CustomWidgetCssSelectorKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomWidgetCssSelectorDataSource class.
		/// </summary>
		public CustomWidgetCssSelectorDataSource() : base(new CustomWidgetCssSelectorService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CustomWidgetCssSelectorDataSourceView used by the CustomWidgetCssSelectorDataSource.
		/// </summary>
		protected CustomWidgetCssSelectorDataSourceView CustomWidgetCssSelectorView
		{
			get { return ( View as CustomWidgetCssSelectorDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CustomWidgetCssSelectorDataSource control invokes to retrieve data.
		/// </summary>
		public CustomWidgetCssSelectorSelectMethod SelectMethod
		{
			get
			{
				CustomWidgetCssSelectorSelectMethod selectMethod = CustomWidgetCssSelectorSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CustomWidgetCssSelectorSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CustomWidgetCssSelectorDataSourceView class that is to be
		/// used by the CustomWidgetCssSelectorDataSource.
		/// </summary>
		/// <returns>An instance of the CustomWidgetCssSelectorDataSourceView class.</returns>
		protected override BaseDataSourceView<CustomWidgetCssSelector, CustomWidgetCssSelectorKey> GetNewDataSourceView()
		{
			return new CustomWidgetCssSelectorDataSourceView(this, DefaultViewName);
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
	/// Supports the CustomWidgetCssSelectorDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CustomWidgetCssSelectorDataSourceView : ProviderDataSourceView<CustomWidgetCssSelector, CustomWidgetCssSelectorKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CustomWidgetCssSelectorDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CustomWidgetCssSelectorDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CustomWidgetCssSelectorDataSourceView(CustomWidgetCssSelectorDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CustomWidgetCssSelectorDataSource CustomWidgetCssSelectorOwner
		{
			get { return Owner as CustomWidgetCssSelectorDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CustomWidgetCssSelectorSelectMethod SelectMethod
		{
			get { return CustomWidgetCssSelectorOwner.SelectMethod; }
			set { CustomWidgetCssSelectorOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CustomWidgetCssSelectorService CustomWidgetCssSelectorProvider
		{
			get { return Provider as CustomWidgetCssSelectorService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<CustomWidgetCssSelector> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<CustomWidgetCssSelector> results = null;
			CustomWidgetCssSelector item;
			count = 0;
			
			System.Int32 _customWidgetCssSelectorId;
			System.Int32 _siteId;

			switch ( SelectMethod )
			{
				case CustomWidgetCssSelectorSelectMethod.Get:
					CustomWidgetCssSelectorKey entityKey  = new CustomWidgetCssSelectorKey();
					entityKey.Load(values);
					item = CustomWidgetCssSelectorProvider.Get(entityKey);
					results = new TList<CustomWidgetCssSelector>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CustomWidgetCssSelectorSelectMethod.GetAll:
                    results = CustomWidgetCssSelectorProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CustomWidgetCssSelectorSelectMethod.GetPaged:
					results = CustomWidgetCssSelectorProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CustomWidgetCssSelectorSelectMethod.Find:
					if ( FilterParameters != null )
						results = CustomWidgetCssSelectorProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CustomWidgetCssSelectorProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CustomWidgetCssSelectorSelectMethod.GetByCustomWidgetCssSelectorId:
					_customWidgetCssSelectorId = ( values["CustomWidgetCssSelectorId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CustomWidgetCssSelectorId"], typeof(System.Int32)) : (int)0;
					item = CustomWidgetCssSelectorProvider.GetByCustomWidgetCssSelectorId(_customWidgetCssSelectorId);
					results = new TList<CustomWidgetCssSelector>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case CustomWidgetCssSelectorSelectMethod.GetBySiteId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					results = CustomWidgetCssSelectorProvider.GetBySiteId(_siteId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == CustomWidgetCssSelectorSelectMethod.Get || SelectMethod == CustomWidgetCssSelectorSelectMethod.GetByCustomWidgetCssSelectorId )
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
				CustomWidgetCssSelector entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					CustomWidgetCssSelectorProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<CustomWidgetCssSelector> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			CustomWidgetCssSelectorProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CustomWidgetCssSelectorDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CustomWidgetCssSelectorDataSource class.
	/// </summary>
	public class CustomWidgetCssSelectorDataSourceDesigner : ProviderDataSourceDesigner<CustomWidgetCssSelector, CustomWidgetCssSelectorKey>
	{
		/// <summary>
		/// Initializes a new instance of the CustomWidgetCssSelectorDataSourceDesigner class.
		/// </summary>
		public CustomWidgetCssSelectorDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CustomWidgetCssSelectorSelectMethod SelectMethod
		{
			get { return ((CustomWidgetCssSelectorDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CustomWidgetCssSelectorDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CustomWidgetCssSelectorDataSourceActionList

	/// <summary>
	/// Supports the CustomWidgetCssSelectorDataSourceDesigner class.
	/// </summary>
	internal class CustomWidgetCssSelectorDataSourceActionList : DesignerActionList
	{
		private CustomWidgetCssSelectorDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CustomWidgetCssSelectorDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CustomWidgetCssSelectorDataSourceActionList(CustomWidgetCssSelectorDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CustomWidgetCssSelectorSelectMethod SelectMethod
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

	#endregion CustomWidgetCssSelectorDataSourceActionList
	
	#endregion CustomWidgetCssSelectorDataSourceDesigner
	
	#region CustomWidgetCssSelectorSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CustomWidgetCssSelectorDataSource.SelectMethod property.
	/// </summary>
	public enum CustomWidgetCssSelectorSelectMethod
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
		/// Represents the GetByCustomWidgetCssSelectorId method.
		/// </summary>
		GetByCustomWidgetCssSelectorId,
		/// <summary>
		/// Represents the GetBySiteId method.
		/// </summary>
		GetBySiteId
	}
	
	#endregion CustomWidgetCssSelectorSelectMethod

	#region CustomWidgetCssSelectorFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomWidgetCssSelector"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomWidgetCssSelectorFilter : SqlFilter<CustomWidgetCssSelectorColumn>
	{
	}
	
	#endregion CustomWidgetCssSelectorFilter

	#region CustomWidgetCssSelectorExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="CustomWidgetCssSelector"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomWidgetCssSelectorExpressionBuilder : SqlExpressionBuilder<CustomWidgetCssSelectorColumn>
	{
	}
	
	#endregion CustomWidgetCssSelectorExpressionBuilder	

	#region CustomWidgetCssSelectorProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CustomWidgetCssSelectorChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="CustomWidgetCssSelector"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CustomWidgetCssSelectorProperty : ChildEntityProperty<CustomWidgetCssSelectorChildEntityTypes>
	{
	}
	
	#endregion CustomWidgetCssSelectorProperty
}

