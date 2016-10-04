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
	/// Represents the DataRepository.SitesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(SitesDataSourceDesigner))]
	public class SitesDataSource : ProviderDataSource<Sites, SitesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SitesDataSource class.
		/// </summary>
		public SitesDataSource() : base(new SitesService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the SitesDataSourceView used by the SitesDataSource.
		/// </summary>
		protected SitesDataSourceView SitesView
		{
			get { return ( View as SitesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the SitesDataSource control invokes to retrieve data.
		/// </summary>
		public SitesSelectMethod SelectMethod
		{
			get
			{
				SitesSelectMethod selectMethod = SitesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (SitesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the SitesDataSourceView class that is to be
		/// used by the SitesDataSource.
		/// </summary>
		/// <returns>An instance of the SitesDataSourceView class.</returns>
		protected override BaseDataSourceView<Sites, SitesKey> GetNewDataSourceView()
		{
			return new SitesDataSourceView(this, DefaultViewName);
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
	/// Supports the SitesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class SitesDataSourceView : ProviderDataSourceView<Sites, SitesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SitesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the SitesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public SitesDataSourceView(SitesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal SitesDataSource SitesOwner
		{
			get { return Owner as SitesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal SitesSelectMethod SelectMethod
		{
			get { return SitesOwner.SelectMethod; }
			set { SitesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal SitesService SitesProvider
		{
			get { return Provider as SitesService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Sites> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Sites> results = null;
			Sites item;
			count = 0;
			
			System.Int32 _siteId;
			System.String _mobileUrl;
			System.Int32? _lastModifiedBy_nullable;

			switch ( SelectMethod )
			{
				case SitesSelectMethod.Get:
					SitesKey entityKey  = new SitesKey();
					entityKey.Load(values);
					item = SitesProvider.Get(entityKey);
					results = new TList<Sites>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case SitesSelectMethod.GetAll:
                    results = SitesProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case SitesSelectMethod.GetPaged:
					results = SitesProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case SitesSelectMethod.Find:
					if ( FilterParameters != null )
						results = SitesProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = SitesProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case SitesSelectMethod.GetBySiteId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					item = SitesProvider.GetBySiteId(_siteId);
					results = new TList<Sites>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case SitesSelectMethod.GetByMobileUrl:
					_mobileUrl = ( values["MobileUrl"] != null ) ? (System.String) EntityUtil.ChangeType(values["MobileUrl"], typeof(System.String)) : string.Empty;
					item = SitesProvider.GetByMobileUrl(_mobileUrl);
					results = new TList<Sites>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				case SitesSelectMethod.GetByLastModifiedBy:
					_lastModifiedBy_nullable = (System.Int32?) EntityUtil.ChangeType(values["LastModifiedBy"], typeof(System.Int32?));
					results = SitesProvider.GetByLastModifiedBy(_lastModifiedBy_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == SitesSelectMethod.Get || SelectMethod == SitesSelectMethod.GetBySiteId )
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
				Sites entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					SitesProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Sites> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			SitesProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region SitesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the SitesDataSource class.
	/// </summary>
	public class SitesDataSourceDesigner : ProviderDataSourceDesigner<Sites, SitesKey>
	{
		/// <summary>
		/// Initializes a new instance of the SitesDataSourceDesigner class.
		/// </summary>
		public SitesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SitesSelectMethod SelectMethod
		{
			get { return ((SitesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new SitesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region SitesDataSourceActionList

	/// <summary>
	/// Supports the SitesDataSourceDesigner class.
	/// </summary>
	internal class SitesDataSourceActionList : DesignerActionList
	{
		private SitesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the SitesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public SitesDataSourceActionList(SitesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SitesSelectMethod SelectMethod
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

	#endregion SitesDataSourceActionList
	
	#endregion SitesDataSourceDesigner
	
	#region SitesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the SitesDataSource.SelectMethod property.
	/// </summary>
	public enum SitesSelectMethod
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
		/// Represents the GetByMobileUrl method.
		/// </summary>
		GetByMobileUrl,
		/// <summary>
		/// Represents the GetByLastModifiedBy method.
		/// </summary>
		GetByLastModifiedBy
	}
	
	#endregion SitesSelectMethod

	#region SitesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Sites"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SitesFilter : SqlFilter<SitesColumn>
	{
	}
	
	#endregion SitesFilter

	#region SitesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Sites"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SitesExpressionBuilder : SqlExpressionBuilder<SitesColumn>
	{
	}
	
	#endregion SitesExpressionBuilder	

	#region SitesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;SitesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Sites"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SitesProperty : ChildEntityProperty<SitesChildEntityTypes>
	{
	}
	
	#endregion SitesProperty
}

