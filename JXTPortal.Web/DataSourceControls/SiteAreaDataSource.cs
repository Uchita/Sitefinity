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
	/// Represents the DataRepository.SiteAreaProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(SiteAreaDataSourceDesigner))]
	public class SiteAreaDataSource : ProviderDataSource<SiteArea, SiteAreaKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteAreaDataSource class.
		/// </summary>
		public SiteAreaDataSource() : base(new SiteAreaService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the SiteAreaDataSourceView used by the SiteAreaDataSource.
		/// </summary>
		protected SiteAreaDataSourceView SiteAreaView
		{
			get { return ( View as SiteAreaDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the SiteAreaDataSource control invokes to retrieve data.
		/// </summary>
		public SiteAreaSelectMethod SelectMethod
		{
			get
			{
				SiteAreaSelectMethod selectMethod = SiteAreaSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (SiteAreaSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the SiteAreaDataSourceView class that is to be
		/// used by the SiteAreaDataSource.
		/// </summary>
		/// <returns>An instance of the SiteAreaDataSourceView class.</returns>
		protected override BaseDataSourceView<SiteArea, SiteAreaKey> GetNewDataSourceView()
		{
			return new SiteAreaDataSourceView(this, DefaultViewName);
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
	/// Supports the SiteAreaDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class SiteAreaDataSourceView : ProviderDataSourceView<SiteArea, SiteAreaKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteAreaDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the SiteAreaDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public SiteAreaDataSourceView(SiteAreaDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal SiteAreaDataSource SiteAreaOwner
		{
			get { return Owner as SiteAreaDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal SiteAreaSelectMethod SelectMethod
		{
			get { return SiteAreaOwner.SelectMethod; }
			set { SiteAreaOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal SiteAreaService SiteAreaProvider
		{
			get { return Provider as SiteAreaService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<SiteArea> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<SiteArea> results = null;
			SiteArea item;
			count = 0;
			
			System.Int32 _siteAreaId;
			System.Int32 _areaId;
			System.Int32 _siteId;

			switch ( SelectMethod )
			{
				case SiteAreaSelectMethod.Get:
					SiteAreaKey entityKey  = new SiteAreaKey();
					entityKey.Load(values);
					item = SiteAreaProvider.Get(entityKey);
					results = new TList<SiteArea>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case SiteAreaSelectMethod.GetAll:
                    results = SiteAreaProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case SiteAreaSelectMethod.GetPaged:
					results = SiteAreaProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case SiteAreaSelectMethod.Find:
					if ( FilterParameters != null )
						results = SiteAreaProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = SiteAreaProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case SiteAreaSelectMethod.GetBySiteAreaId:
					_siteAreaId = ( values["SiteAreaId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteAreaId"], typeof(System.Int32)) : (int)0;
					item = SiteAreaProvider.GetBySiteAreaId(_siteAreaId);
					results = new TList<SiteArea>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case SiteAreaSelectMethod.GetByAreaId:
					_areaId = ( values["AreaId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AreaId"], typeof(System.Int32)) : (int)0;
					results = SiteAreaProvider.GetByAreaId(_areaId, this.StartIndex, this.PageSize, out count);
					break;
				case SiteAreaSelectMethod.GetBySiteId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					results = SiteAreaProvider.GetBySiteId(_siteId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == SiteAreaSelectMethod.Get || SelectMethod == SiteAreaSelectMethod.GetBySiteAreaId )
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
				SiteArea entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					SiteAreaProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<SiteArea> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			SiteAreaProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region SiteAreaDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the SiteAreaDataSource class.
	/// </summary>
	public class SiteAreaDataSourceDesigner : ProviderDataSourceDesigner<SiteArea, SiteAreaKey>
	{
		/// <summary>
		/// Initializes a new instance of the SiteAreaDataSourceDesigner class.
		/// </summary>
		public SiteAreaDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SiteAreaSelectMethod SelectMethod
		{
			get { return ((SiteAreaDataSource) DataSource).SelectMethod; }
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
				actions.Add(new SiteAreaDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region SiteAreaDataSourceActionList

	/// <summary>
	/// Supports the SiteAreaDataSourceDesigner class.
	/// </summary>
	internal class SiteAreaDataSourceActionList : DesignerActionList
	{
		private SiteAreaDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the SiteAreaDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public SiteAreaDataSourceActionList(SiteAreaDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SiteAreaSelectMethod SelectMethod
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

	#endregion SiteAreaDataSourceActionList
	
	#endregion SiteAreaDataSourceDesigner
	
	#region SiteAreaSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the SiteAreaDataSource.SelectMethod property.
	/// </summary>
	public enum SiteAreaSelectMethod
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
		/// Represents the GetBySiteAreaId method.
		/// </summary>
		GetBySiteAreaId,
		/// <summary>
		/// Represents the GetByAreaId method.
		/// </summary>
		GetByAreaId,
		/// <summary>
		/// Represents the GetBySiteId method.
		/// </summary>
		GetBySiteId
	}
	
	#endregion SiteAreaSelectMethod

	#region SiteAreaFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteArea"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteAreaFilter : SqlFilter<SiteAreaColumn>
	{
	}
	
	#endregion SiteAreaFilter

	#region SiteAreaExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteArea"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteAreaExpressionBuilder : SqlExpressionBuilder<SiteAreaColumn>
	{
	}
	
	#endregion SiteAreaExpressionBuilder	

	#region SiteAreaProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;SiteAreaChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="SiteArea"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteAreaProperty : ChildEntityProperty<SiteAreaChildEntityTypes>
	{
	}
	
	#endregion SiteAreaProperty
}

