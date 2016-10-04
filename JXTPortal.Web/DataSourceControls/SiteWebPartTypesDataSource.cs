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
	/// Represents the DataRepository.SiteWebPartTypesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(SiteWebPartTypesDataSourceDesigner))]
	public class SiteWebPartTypesDataSource : ProviderDataSource<SiteWebPartTypes, SiteWebPartTypesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteWebPartTypesDataSource class.
		/// </summary>
		public SiteWebPartTypesDataSource() : base(new SiteWebPartTypesService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the SiteWebPartTypesDataSourceView used by the SiteWebPartTypesDataSource.
		/// </summary>
		protected SiteWebPartTypesDataSourceView SiteWebPartTypesView
		{
			get { return ( View as SiteWebPartTypesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the SiteWebPartTypesDataSource control invokes to retrieve data.
		/// </summary>
		public SiteWebPartTypesSelectMethod SelectMethod
		{
			get
			{
				SiteWebPartTypesSelectMethod selectMethod = SiteWebPartTypesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (SiteWebPartTypesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the SiteWebPartTypesDataSourceView class that is to be
		/// used by the SiteWebPartTypesDataSource.
		/// </summary>
		/// <returns>An instance of the SiteWebPartTypesDataSourceView class.</returns>
		protected override BaseDataSourceView<SiteWebPartTypes, SiteWebPartTypesKey> GetNewDataSourceView()
		{
			return new SiteWebPartTypesDataSourceView(this, DefaultViewName);
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
	/// Supports the SiteWebPartTypesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class SiteWebPartTypesDataSourceView : ProviderDataSourceView<SiteWebPartTypes, SiteWebPartTypesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteWebPartTypesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the SiteWebPartTypesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public SiteWebPartTypesDataSourceView(SiteWebPartTypesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal SiteWebPartTypesDataSource SiteWebPartTypesOwner
		{
			get { return Owner as SiteWebPartTypesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal SiteWebPartTypesSelectMethod SelectMethod
		{
			get { return SiteWebPartTypesOwner.SelectMethod; }
			set { SiteWebPartTypesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal SiteWebPartTypesService SiteWebPartTypesProvider
		{
			get { return Provider as SiteWebPartTypesService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<SiteWebPartTypes> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<SiteWebPartTypes> results = null;
			SiteWebPartTypes item;
			count = 0;
			
			System.Int32 _siteWebPartTypeId;

			switch ( SelectMethod )
			{
				case SiteWebPartTypesSelectMethod.Get:
					SiteWebPartTypesKey entityKey  = new SiteWebPartTypesKey();
					entityKey.Load(values);
					item = SiteWebPartTypesProvider.Get(entityKey);
					results = new TList<SiteWebPartTypes>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case SiteWebPartTypesSelectMethod.GetAll:
                    results = SiteWebPartTypesProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case SiteWebPartTypesSelectMethod.GetPaged:
					results = SiteWebPartTypesProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case SiteWebPartTypesSelectMethod.Find:
					if ( FilterParameters != null )
						results = SiteWebPartTypesProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = SiteWebPartTypesProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case SiteWebPartTypesSelectMethod.GetBySiteWebPartTypeId:
					_siteWebPartTypeId = ( values["SiteWebPartTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteWebPartTypeId"], typeof(System.Int32)) : (int)0;
					item = SiteWebPartTypesProvider.GetBySiteWebPartTypeId(_siteWebPartTypeId);
					results = new TList<SiteWebPartTypes>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
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
			if ( SelectMethod == SiteWebPartTypesSelectMethod.Get || SelectMethod == SiteWebPartTypesSelectMethod.GetBySiteWebPartTypeId )
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
				SiteWebPartTypes entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					SiteWebPartTypesProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<SiteWebPartTypes> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			SiteWebPartTypesProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region SiteWebPartTypesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the SiteWebPartTypesDataSource class.
	/// </summary>
	public class SiteWebPartTypesDataSourceDesigner : ProviderDataSourceDesigner<SiteWebPartTypes, SiteWebPartTypesKey>
	{
		/// <summary>
		/// Initializes a new instance of the SiteWebPartTypesDataSourceDesigner class.
		/// </summary>
		public SiteWebPartTypesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SiteWebPartTypesSelectMethod SelectMethod
		{
			get { return ((SiteWebPartTypesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new SiteWebPartTypesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region SiteWebPartTypesDataSourceActionList

	/// <summary>
	/// Supports the SiteWebPartTypesDataSourceDesigner class.
	/// </summary>
	internal class SiteWebPartTypesDataSourceActionList : DesignerActionList
	{
		private SiteWebPartTypesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the SiteWebPartTypesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public SiteWebPartTypesDataSourceActionList(SiteWebPartTypesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SiteWebPartTypesSelectMethod SelectMethod
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

	#endregion SiteWebPartTypesDataSourceActionList
	
	#endregion SiteWebPartTypesDataSourceDesigner
	
	#region SiteWebPartTypesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the SiteWebPartTypesDataSource.SelectMethod property.
	/// </summary>
	public enum SiteWebPartTypesSelectMethod
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
		/// Represents the GetBySiteWebPartTypeId method.
		/// </summary>
		GetBySiteWebPartTypeId
	}
	
	#endregion SiteWebPartTypesSelectMethod

	#region SiteWebPartTypesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteWebPartTypes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteWebPartTypesFilter : SqlFilter<SiteWebPartTypesColumn>
	{
	}
	
	#endregion SiteWebPartTypesFilter

	#region SiteWebPartTypesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteWebPartTypes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteWebPartTypesExpressionBuilder : SqlExpressionBuilder<SiteWebPartTypesColumn>
	{
	}
	
	#endregion SiteWebPartTypesExpressionBuilder	

	#region SiteWebPartTypesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;SiteWebPartTypesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="SiteWebPartTypes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteWebPartTypesProperty : ChildEntityProperty<SiteWebPartTypesChildEntityTypes>
	{
	}
	
	#endregion SiteWebPartTypesProperty
}

