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
	/// Represents the DataRepository.WebServiceLogProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(WebServiceLogDataSourceDesigner))]
	public class WebServiceLogDataSource : ProviderDataSource<WebServiceLog, WebServiceLogKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WebServiceLogDataSource class.
		/// </summary>
		public WebServiceLogDataSource() : base(new WebServiceLogService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the WebServiceLogDataSourceView used by the WebServiceLogDataSource.
		/// </summary>
		protected WebServiceLogDataSourceView WebServiceLogView
		{
			get { return ( View as WebServiceLogDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the WebServiceLogDataSource control invokes to retrieve data.
		/// </summary>
		public WebServiceLogSelectMethod SelectMethod
		{
			get
			{
				WebServiceLogSelectMethod selectMethod = WebServiceLogSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (WebServiceLogSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the WebServiceLogDataSourceView class that is to be
		/// used by the WebServiceLogDataSource.
		/// </summary>
		/// <returns>An instance of the WebServiceLogDataSourceView class.</returns>
		protected override BaseDataSourceView<WebServiceLog, WebServiceLogKey> GetNewDataSourceView()
		{
			return new WebServiceLogDataSourceView(this, DefaultViewName);
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
	/// Supports the WebServiceLogDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class WebServiceLogDataSourceView : ProviderDataSourceView<WebServiceLog, WebServiceLogKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the WebServiceLogDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the WebServiceLogDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public WebServiceLogDataSourceView(WebServiceLogDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal WebServiceLogDataSource WebServiceLogOwner
		{
			get { return Owner as WebServiceLogDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal WebServiceLogSelectMethod SelectMethod
		{
			get { return WebServiceLogOwner.SelectMethod; }
			set { WebServiceLogOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal WebServiceLogService WebServiceLogProvider
		{
			get { return Provider as WebServiceLogService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<WebServiceLog> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<WebServiceLog> results = null;
			WebServiceLog item;
			count = 0;
			
			System.Int32 _webServiceLogId;
			System.Int32 _siteId;

			switch ( SelectMethod )
			{
				case WebServiceLogSelectMethod.Get:
					WebServiceLogKey entityKey  = new WebServiceLogKey();
					entityKey.Load(values);
					item = WebServiceLogProvider.Get(entityKey);
					results = new TList<WebServiceLog>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case WebServiceLogSelectMethod.GetAll:
                    results = WebServiceLogProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case WebServiceLogSelectMethod.GetPaged:
					results = WebServiceLogProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case WebServiceLogSelectMethod.Find:
					if ( FilterParameters != null )
						results = WebServiceLogProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = WebServiceLogProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case WebServiceLogSelectMethod.GetByWebServiceLogId:
					_webServiceLogId = ( values["WebServiceLogId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["WebServiceLogId"], typeof(System.Int32)) : (int)0;
					item = WebServiceLogProvider.GetByWebServiceLogId(_webServiceLogId);
					results = new TList<WebServiceLog>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case WebServiceLogSelectMethod.GetBySiteId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					results = WebServiceLogProvider.GetBySiteId(_siteId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == WebServiceLogSelectMethod.Get || SelectMethod == WebServiceLogSelectMethod.GetByWebServiceLogId )
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
				WebServiceLog entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					WebServiceLogProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<WebServiceLog> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			WebServiceLogProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region WebServiceLogDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the WebServiceLogDataSource class.
	/// </summary>
	public class WebServiceLogDataSourceDesigner : ProviderDataSourceDesigner<WebServiceLog, WebServiceLogKey>
	{
		/// <summary>
		/// Initializes a new instance of the WebServiceLogDataSourceDesigner class.
		/// </summary>
		public WebServiceLogDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public WebServiceLogSelectMethod SelectMethod
		{
			get { return ((WebServiceLogDataSource) DataSource).SelectMethod; }
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
				actions.Add(new WebServiceLogDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region WebServiceLogDataSourceActionList

	/// <summary>
	/// Supports the WebServiceLogDataSourceDesigner class.
	/// </summary>
	internal class WebServiceLogDataSourceActionList : DesignerActionList
	{
		private WebServiceLogDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the WebServiceLogDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public WebServiceLogDataSourceActionList(WebServiceLogDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public WebServiceLogSelectMethod SelectMethod
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

	#endregion WebServiceLogDataSourceActionList
	
	#endregion WebServiceLogDataSourceDesigner
	
	#region WebServiceLogSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the WebServiceLogDataSource.SelectMethod property.
	/// </summary>
	public enum WebServiceLogSelectMethod
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
		/// Represents the GetByWebServiceLogId method.
		/// </summary>
		GetByWebServiceLogId,
		/// <summary>
		/// Represents the GetBySiteId method.
		/// </summary>
		GetBySiteId
	}
	
	#endregion WebServiceLogSelectMethod

	#region WebServiceLogFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WebServiceLog"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WebServiceLogFilter : SqlFilter<WebServiceLogColumn>
	{
	}
	
	#endregion WebServiceLogFilter

	#region WebServiceLogExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="WebServiceLog"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WebServiceLogExpressionBuilder : SqlExpressionBuilder<WebServiceLogColumn>
	{
	}
	
	#endregion WebServiceLogExpressionBuilder	

	#region WebServiceLogProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;WebServiceLogChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="WebServiceLog"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class WebServiceLogProperty : ChildEntityProperty<WebServiceLogChildEntityTypes>
	{
	}
	
	#endregion WebServiceLogProperty
}

