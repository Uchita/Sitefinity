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
	/// Represents the DataRepository.CountriesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(CountriesDataSourceDesigner))]
	public class CountriesDataSource : ProviderDataSource<Countries, CountriesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CountriesDataSource class.
		/// </summary>
		public CountriesDataSource() : base(new CountriesService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the CountriesDataSourceView used by the CountriesDataSource.
		/// </summary>
		protected CountriesDataSourceView CountriesView
		{
			get { return ( View as CountriesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the CountriesDataSource control invokes to retrieve data.
		/// </summary>
		public CountriesSelectMethod SelectMethod
		{
			get
			{
				CountriesSelectMethod selectMethod = CountriesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (CountriesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the CountriesDataSourceView class that is to be
		/// used by the CountriesDataSource.
		/// </summary>
		/// <returns>An instance of the CountriesDataSourceView class.</returns>
		protected override BaseDataSourceView<Countries, CountriesKey> GetNewDataSourceView()
		{
			return new CountriesDataSourceView(this, DefaultViewName);
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
	/// Supports the CountriesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class CountriesDataSourceView : ProviderDataSourceView<Countries, CountriesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the CountriesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the CountriesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public CountriesDataSourceView(CountriesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal CountriesDataSource CountriesOwner
		{
			get { return Owner as CountriesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal CountriesSelectMethod SelectMethod
		{
			get { return CountriesOwner.SelectMethod; }
			set { CountriesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal CountriesService CountriesProvider
		{
			get { return Provider as CountriesService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Countries> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Countries> results = null;
			Countries item;
			count = 0;
			
			System.Int32 _countryId;

			switch ( SelectMethod )
			{
				case CountriesSelectMethod.Get:
					CountriesKey entityKey  = new CountriesKey();
					entityKey.Load(values);
					item = CountriesProvider.Get(entityKey);
					results = new TList<Countries>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case CountriesSelectMethod.GetAll:
                    results = CountriesProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case CountriesSelectMethod.GetPaged:
					results = CountriesProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case CountriesSelectMethod.Find:
					if ( FilterParameters != null )
						results = CountriesProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = CountriesProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case CountriesSelectMethod.GetByCountryId:
					_countryId = ( values["CountryId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CountryId"], typeof(System.Int32)) : (int)0;
					item = CountriesProvider.GetByCountryId(_countryId);
					results = new TList<Countries>();
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
			if ( SelectMethod == CountriesSelectMethod.Get || SelectMethod == CountriesSelectMethod.GetByCountryId )
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
				Countries entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					CountriesProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Countries> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			CountriesProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region CountriesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the CountriesDataSource class.
	/// </summary>
	public class CountriesDataSourceDesigner : ProviderDataSourceDesigner<Countries, CountriesKey>
	{
		/// <summary>
		/// Initializes a new instance of the CountriesDataSourceDesigner class.
		/// </summary>
		public CountriesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CountriesSelectMethod SelectMethod
		{
			get { return ((CountriesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new CountriesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region CountriesDataSourceActionList

	/// <summary>
	/// Supports the CountriesDataSourceDesigner class.
	/// </summary>
	internal class CountriesDataSourceActionList : DesignerActionList
	{
		private CountriesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the CountriesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public CountriesDataSourceActionList(CountriesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public CountriesSelectMethod SelectMethod
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

	#endregion CountriesDataSourceActionList
	
	#endregion CountriesDataSourceDesigner
	
	#region CountriesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the CountriesDataSource.SelectMethod property.
	/// </summary>
	public enum CountriesSelectMethod
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
		/// Represents the GetByCountryId method.
		/// </summary>
		GetByCountryId
	}
	
	#endregion CountriesSelectMethod

	#region CountriesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Countries"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CountriesFilter : SqlFilter<CountriesColumn>
	{
	}
	
	#endregion CountriesFilter

	#region CountriesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Countries"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CountriesExpressionBuilder : SqlExpressionBuilder<CountriesColumn>
	{
	}
	
	#endregion CountriesExpressionBuilder	

	#region CountriesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;CountriesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Countries"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class CountriesProperty : ChildEntityProperty<CountriesChildEntityTypes>
	{
	}
	
	#endregion CountriesProperty
}

