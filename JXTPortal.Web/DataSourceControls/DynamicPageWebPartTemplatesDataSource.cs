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
	/// Represents the DataRepository.DynamicPageWebPartTemplatesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(DynamicPageWebPartTemplatesDataSourceDesigner))]
	public class DynamicPageWebPartTemplatesDataSource : ProviderDataSource<DynamicPageWebPartTemplates, DynamicPageWebPartTemplatesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicPageWebPartTemplatesDataSource class.
		/// </summary>
		public DynamicPageWebPartTemplatesDataSource() : base(new DynamicPageWebPartTemplatesService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the DynamicPageWebPartTemplatesDataSourceView used by the DynamicPageWebPartTemplatesDataSource.
		/// </summary>
		protected DynamicPageWebPartTemplatesDataSourceView DynamicPageWebPartTemplatesView
		{
			get { return ( View as DynamicPageWebPartTemplatesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DynamicPageWebPartTemplatesDataSource control invokes to retrieve data.
		/// </summary>
		public DynamicPageWebPartTemplatesSelectMethod SelectMethod
		{
			get
			{
				DynamicPageWebPartTemplatesSelectMethod selectMethod = DynamicPageWebPartTemplatesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (DynamicPageWebPartTemplatesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the DynamicPageWebPartTemplatesDataSourceView class that is to be
		/// used by the DynamicPageWebPartTemplatesDataSource.
		/// </summary>
		/// <returns>An instance of the DynamicPageWebPartTemplatesDataSourceView class.</returns>
		protected override BaseDataSourceView<DynamicPageWebPartTemplates, DynamicPageWebPartTemplatesKey> GetNewDataSourceView()
		{
			return new DynamicPageWebPartTemplatesDataSourceView(this, DefaultViewName);
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
	/// Supports the DynamicPageWebPartTemplatesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class DynamicPageWebPartTemplatesDataSourceView : ProviderDataSourceView<DynamicPageWebPartTemplates, DynamicPageWebPartTemplatesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the DynamicPageWebPartTemplatesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the DynamicPageWebPartTemplatesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public DynamicPageWebPartTemplatesDataSourceView(DynamicPageWebPartTemplatesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal DynamicPageWebPartTemplatesDataSource DynamicPageWebPartTemplatesOwner
		{
			get { return Owner as DynamicPageWebPartTemplatesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal DynamicPageWebPartTemplatesSelectMethod SelectMethod
		{
			get { return DynamicPageWebPartTemplatesOwner.SelectMethod; }
			set { DynamicPageWebPartTemplatesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal DynamicPageWebPartTemplatesService DynamicPageWebPartTemplatesProvider
		{
			get { return Provider as DynamicPageWebPartTemplatesService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<DynamicPageWebPartTemplates> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<DynamicPageWebPartTemplates> results = null;
			DynamicPageWebPartTemplates item;
			count = 0;
			
			System.Int32 _dynamicPageWebPartTemplateId;
			System.Int32 _lastModifiedBy;
			System.Int32 _siteId;
			System.Int32? sp143_SiteId;
			System.Int32? sp141_DynamicPageWebPartTemplateId;
			System.Boolean? sp139_SearchUsingOr;
			System.Int32? sp139_DynamicPageWebPartTemplateId;
			System.String sp139_DynamicPageWebPartName;
			System.Int32? sp139_SiteId;
			System.DateTime? sp139_LastModified;
			System.Int32? sp139_LastModifiedBy;
			System.Int32? sp142_LastModifiedBy;

			switch ( SelectMethod )
			{
				case DynamicPageWebPartTemplatesSelectMethod.Get:
					DynamicPageWebPartTemplatesKey entityKey  = new DynamicPageWebPartTemplatesKey();
					entityKey.Load(values);
					item = DynamicPageWebPartTemplatesProvider.Get(entityKey);
					results = new TList<DynamicPageWebPartTemplates>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case DynamicPageWebPartTemplatesSelectMethod.GetAll:
                    results = DynamicPageWebPartTemplatesProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case DynamicPageWebPartTemplatesSelectMethod.GetPaged:
					results = DynamicPageWebPartTemplatesProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case DynamicPageWebPartTemplatesSelectMethod.Find:
					if ( FilterParameters != null )
						results = DynamicPageWebPartTemplatesProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = DynamicPageWebPartTemplatesProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case DynamicPageWebPartTemplatesSelectMethod.GetByDynamicPageWebPartTemplateId:
					_dynamicPageWebPartTemplateId = ( values["DynamicPageWebPartTemplateId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["DynamicPageWebPartTemplateId"], typeof(System.Int32)) : (int)0;
					item = DynamicPageWebPartTemplatesProvider.GetByDynamicPageWebPartTemplateId(_dynamicPageWebPartTemplateId);
					results = new TList<DynamicPageWebPartTemplates>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case DynamicPageWebPartTemplatesSelectMethod.GetByLastModifiedBy:
					_lastModifiedBy = ( values["LastModifiedBy"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["LastModifiedBy"], typeof(System.Int32)) : (int)0;
					results = DynamicPageWebPartTemplatesProvider.GetByLastModifiedBy(_lastModifiedBy, this.StartIndex, this.PageSize, out count);
					break;
				case DynamicPageWebPartTemplatesSelectMethod.GetBySiteId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					results = DynamicPageWebPartTemplatesProvider.GetBySiteId(_siteId, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				// Custom
				
				case DynamicPageWebPartTemplatesSelectMethod.Get_List:
					results = DynamicPageWebPartTemplatesProvider.Get_List(StartIndex, PageSize);
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
			if ( SelectMethod == DynamicPageWebPartTemplatesSelectMethod.Get || SelectMethod == DynamicPageWebPartTemplatesSelectMethod.GetByDynamicPageWebPartTemplateId )
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
				DynamicPageWebPartTemplates entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					DynamicPageWebPartTemplatesProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<DynamicPageWebPartTemplates> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			DynamicPageWebPartTemplatesProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region DynamicPageWebPartTemplatesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the DynamicPageWebPartTemplatesDataSource class.
	/// </summary>
	public class DynamicPageWebPartTemplatesDataSourceDesigner : ProviderDataSourceDesigner<DynamicPageWebPartTemplates, DynamicPageWebPartTemplatesKey>
	{
		/// <summary>
		/// Initializes a new instance of the DynamicPageWebPartTemplatesDataSourceDesigner class.
		/// </summary>
		public DynamicPageWebPartTemplatesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DynamicPageWebPartTemplatesSelectMethod SelectMethod
		{
			get { return ((DynamicPageWebPartTemplatesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new DynamicPageWebPartTemplatesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region DynamicPageWebPartTemplatesDataSourceActionList

	/// <summary>
	/// Supports the DynamicPageWebPartTemplatesDataSourceDesigner class.
	/// </summary>
	internal class DynamicPageWebPartTemplatesDataSourceActionList : DesignerActionList
	{
		private DynamicPageWebPartTemplatesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the DynamicPageWebPartTemplatesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public DynamicPageWebPartTemplatesDataSourceActionList(DynamicPageWebPartTemplatesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public DynamicPageWebPartTemplatesSelectMethod SelectMethod
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

	#endregion DynamicPageWebPartTemplatesDataSourceActionList
	
	#endregion DynamicPageWebPartTemplatesDataSourceDesigner
	
	#region DynamicPageWebPartTemplatesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the DynamicPageWebPartTemplatesDataSource.SelectMethod property.
	/// </summary>
	public enum DynamicPageWebPartTemplatesSelectMethod
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
		/// Represents the GetByDynamicPageWebPartTemplateId method.
		/// </summary>
		GetByDynamicPageWebPartTemplateId,
		/// <summary>
		/// Represents the GetByLastModifiedBy method.
		/// </summary>
		GetByLastModifiedBy,
		/// <summary>
		/// Represents the GetBySiteId method.
		/// </summary>
		GetBySiteId,
		/// <summary>
		/// Represents the Get_List method.
		/// </summary>
		Get_List
	}
	
	#endregion DynamicPageWebPartTemplatesSelectMethod

	#region DynamicPageWebPartTemplatesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicPageWebPartTemplates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicPageWebPartTemplatesFilter : SqlFilter<DynamicPageWebPartTemplatesColumn>
	{
	}
	
	#endregion DynamicPageWebPartTemplatesFilter

	#region DynamicPageWebPartTemplatesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicPageWebPartTemplates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicPageWebPartTemplatesExpressionBuilder : SqlExpressionBuilder<DynamicPageWebPartTemplatesColumn>
	{
	}
	
	#endregion DynamicPageWebPartTemplatesExpressionBuilder	

	#region DynamicPageWebPartTemplatesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;DynamicPageWebPartTemplatesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="DynamicPageWebPartTemplates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class DynamicPageWebPartTemplatesProperty : ChildEntityProperty<DynamicPageWebPartTemplatesChildEntityTypes>
	{
	}
	
	#endregion DynamicPageWebPartTemplatesProperty
}

