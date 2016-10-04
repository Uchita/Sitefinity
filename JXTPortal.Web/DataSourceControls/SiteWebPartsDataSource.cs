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
	/// Represents the DataRepository.SiteWebPartsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(SiteWebPartsDataSourceDesigner))]
	public class SiteWebPartsDataSource : ProviderDataSource<SiteWebParts, SiteWebPartsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteWebPartsDataSource class.
		/// </summary>
		public SiteWebPartsDataSource() : base(new SiteWebPartsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the SiteWebPartsDataSourceView used by the SiteWebPartsDataSource.
		/// </summary>
		protected SiteWebPartsDataSourceView SiteWebPartsView
		{
			get { return ( View as SiteWebPartsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the SiteWebPartsDataSource control invokes to retrieve data.
		/// </summary>
		public SiteWebPartsSelectMethod SelectMethod
		{
			get
			{
				SiteWebPartsSelectMethod selectMethod = SiteWebPartsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (SiteWebPartsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the SiteWebPartsDataSourceView class that is to be
		/// used by the SiteWebPartsDataSource.
		/// </summary>
		/// <returns>An instance of the SiteWebPartsDataSourceView class.</returns>
		protected override BaseDataSourceView<SiteWebParts, SiteWebPartsKey> GetNewDataSourceView()
		{
			return new SiteWebPartsDataSourceView(this, DefaultViewName);
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
	/// Supports the SiteWebPartsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class SiteWebPartsDataSourceView : ProviderDataSourceView<SiteWebParts, SiteWebPartsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteWebPartsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the SiteWebPartsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public SiteWebPartsDataSourceView(SiteWebPartsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal SiteWebPartsDataSource SiteWebPartsOwner
		{
			get { return Owner as SiteWebPartsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal SiteWebPartsSelectMethod SelectMethod
		{
			get { return SiteWebPartsOwner.SelectMethod; }
			set { SiteWebPartsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal SiteWebPartsService SiteWebPartsProvider
		{
			get { return Provider as SiteWebPartsService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<SiteWebParts> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<SiteWebParts> results = null;
			SiteWebParts item;
			count = 0;
			
			System.Int32 _siteWebPartId;
			System.Int32 _siteId;
			System.Int32 _siteWebPartTypeId;
			System.Int32? sp599_SiteId;
			System.Int32? sp601_SiteWebPartTypeId;
			System.Int32? sp597_DynamicPageWebPartTemplateId;
			System.Boolean? sp595_SearchUsingOr;
			System.Int32? sp595_SiteWebPartId;
			System.Int32? sp595_SiteId;
			System.String sp595_SiteWebPartName;
			System.Int32? sp595_SiteWebPartTypeId;
			System.String sp595_SiteWebPartHtml;
			System.Int32? sp600_SiteWebPartId;

			switch ( SelectMethod )
			{
				case SiteWebPartsSelectMethod.Get:
					SiteWebPartsKey entityKey  = new SiteWebPartsKey();
					entityKey.Load(values);
					item = SiteWebPartsProvider.Get(entityKey);
					results = new TList<SiteWebParts>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case SiteWebPartsSelectMethod.GetAll:
                    results = SiteWebPartsProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case SiteWebPartsSelectMethod.GetPaged:
					results = SiteWebPartsProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case SiteWebPartsSelectMethod.Find:
					if ( FilterParameters != null )
						results = SiteWebPartsProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = SiteWebPartsProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case SiteWebPartsSelectMethod.GetBySiteWebPartId:
					_siteWebPartId = ( values["SiteWebPartId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteWebPartId"], typeof(System.Int32)) : (int)0;
					item = SiteWebPartsProvider.GetBySiteWebPartId(_siteWebPartId);
					results = new TList<SiteWebParts>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case SiteWebPartsSelectMethod.GetBySiteId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					results = SiteWebPartsProvider.GetBySiteId(_siteId, this.StartIndex, this.PageSize, out count);
					break;
				case SiteWebPartsSelectMethod.GetBySiteWebPartTypeId:
					_siteWebPartTypeId = ( values["SiteWebPartTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteWebPartTypeId"], typeof(System.Int32)) : (int)0;
					results = SiteWebPartsProvider.GetBySiteWebPartTypeId(_siteWebPartTypeId, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				// Custom
				
				case SiteWebPartsSelectMethod.Get_List:
					results = SiteWebPartsProvider.Get_List(StartIndex, PageSize);
					break;
				
				case SiteWebPartsSelectMethod.GetByDynamicPageContainerID:
					sp597_DynamicPageWebPartTemplateId = (System.Int32?) EntityUtil.ChangeType(values["DynamicPageWebPartTemplateId"], typeof(System.Int32?));
					results = SiteWebPartsProvider.GetByDynamicPageContainerID(sp597_DynamicPageWebPartTemplateId, StartIndex, PageSize);
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
			if ( SelectMethod == SiteWebPartsSelectMethod.Get || SelectMethod == SiteWebPartsSelectMethod.GetBySiteWebPartId )
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
				SiteWebParts entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					SiteWebPartsProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<SiteWebParts> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			SiteWebPartsProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region SiteWebPartsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the SiteWebPartsDataSource class.
	/// </summary>
	public class SiteWebPartsDataSourceDesigner : ProviderDataSourceDesigner<SiteWebParts, SiteWebPartsKey>
	{
		/// <summary>
		/// Initializes a new instance of the SiteWebPartsDataSourceDesigner class.
		/// </summary>
		public SiteWebPartsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SiteWebPartsSelectMethod SelectMethod
		{
			get { return ((SiteWebPartsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new SiteWebPartsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region SiteWebPartsDataSourceActionList

	/// <summary>
	/// Supports the SiteWebPartsDataSourceDesigner class.
	/// </summary>
	internal class SiteWebPartsDataSourceActionList : DesignerActionList
	{
		private SiteWebPartsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the SiteWebPartsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public SiteWebPartsDataSourceActionList(SiteWebPartsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SiteWebPartsSelectMethod SelectMethod
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

	#endregion SiteWebPartsDataSourceActionList
	
	#endregion SiteWebPartsDataSourceDesigner
	
	#region SiteWebPartsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the SiteWebPartsDataSource.SelectMethod property.
	/// </summary>
	public enum SiteWebPartsSelectMethod
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
		/// Represents the GetBySiteWebPartId method.
		/// </summary>
		GetBySiteWebPartId,
		/// <summary>
		/// Represents the GetBySiteId method.
		/// </summary>
		GetBySiteId,
		/// <summary>
		/// Represents the GetBySiteWebPartTypeId method.
		/// </summary>
		GetBySiteWebPartTypeId,
		/// <summary>
		/// Represents the Get_List method.
		/// </summary>
		Get_List,
		/// <summary>
		/// Represents the GetByDynamicPageContainerID method.
		/// </summary>
		GetByDynamicPageContainerID
	}
	
	#endregion SiteWebPartsSelectMethod

	#region SiteWebPartsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteWebParts"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteWebPartsFilter : SqlFilter<SiteWebPartsColumn>
	{
	}
	
	#endregion SiteWebPartsFilter

	#region SiteWebPartsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteWebParts"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteWebPartsExpressionBuilder : SqlExpressionBuilder<SiteWebPartsColumn>
	{
	}
	
	#endregion SiteWebPartsExpressionBuilder	

	#region SiteWebPartsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;SiteWebPartsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="SiteWebParts"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteWebPartsProperty : ChildEntityProperty<SiteWebPartsChildEntityTypes>
	{
	}
	
	#endregion SiteWebPartsProperty
}

