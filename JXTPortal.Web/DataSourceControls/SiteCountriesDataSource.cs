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
	/// Represents the DataRepository.SiteCountriesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(SiteCountriesDataSourceDesigner))]
	public class SiteCountriesDataSource : ProviderDataSource<SiteCountries, SiteCountriesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteCountriesDataSource class.
		/// </summary>
		public SiteCountriesDataSource() : base(new SiteCountriesService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the SiteCountriesDataSourceView used by the SiteCountriesDataSource.
		/// </summary>
		protected SiteCountriesDataSourceView SiteCountriesView
		{
			get { return ( View as SiteCountriesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the SiteCountriesDataSource control invokes to retrieve data.
		/// </summary>
		public SiteCountriesSelectMethod SelectMethod
		{
			get
			{
				SiteCountriesSelectMethod selectMethod = SiteCountriesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (SiteCountriesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the SiteCountriesDataSourceView class that is to be
		/// used by the SiteCountriesDataSource.
		/// </summary>
		/// <returns>An instance of the SiteCountriesDataSourceView class.</returns>
		protected override BaseDataSourceView<SiteCountries, SiteCountriesKey> GetNewDataSourceView()
		{
			return new SiteCountriesDataSourceView(this, DefaultViewName);
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
	/// Supports the SiteCountriesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class SiteCountriesDataSourceView : ProviderDataSourceView<SiteCountries, SiteCountriesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the SiteCountriesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the SiteCountriesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public SiteCountriesDataSourceView(SiteCountriesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal SiteCountriesDataSource SiteCountriesOwner
		{
			get { return Owner as SiteCountriesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal SiteCountriesSelectMethod SelectMethod
		{
			get { return SiteCountriesOwner.SelectMethod; }
			set { SiteCountriesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal SiteCountriesService SiteCountriesProvider
		{
			get { return Provider as SiteCountriesService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<SiteCountries> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<SiteCountries> results = null;
			SiteCountries item;
			count = 0;
			
			System.Int32 _siteId;
			System.Int32 _countryId;
			System.Int32 _siteCountryId;

			switch ( SelectMethod )
			{
				case SiteCountriesSelectMethod.Get:
					SiteCountriesKey entityKey  = new SiteCountriesKey();
					entityKey.Load(values);
					item = SiteCountriesProvider.Get(entityKey);
					results = new TList<SiteCountries>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case SiteCountriesSelectMethod.GetAll:
                    results = SiteCountriesProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case SiteCountriesSelectMethod.GetPaged:
					results = SiteCountriesProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case SiteCountriesSelectMethod.Find:
					if ( FilterParameters != null )
						results = SiteCountriesProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = SiteCountriesProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case SiteCountriesSelectMethod.GetBySiteCountryId:
					_siteCountryId = ( values["SiteCountryId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteCountryId"], typeof(System.Int32)) : (int)0;
					item = SiteCountriesProvider.GetBySiteCountryId(_siteCountryId);
					results = new TList<SiteCountries>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case SiteCountriesSelectMethod.GetBySiteIdCountryId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					_countryId = ( values["CountryId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CountryId"], typeof(System.Int32)) : (int)0;
					item = SiteCountriesProvider.GetBySiteIdCountryId(_siteId, _countryId);
					results = new TList<SiteCountries>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				case SiteCountriesSelectMethod.GetByCountryId:
					_countryId = ( values["CountryId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CountryId"], typeof(System.Int32)) : (int)0;
					results = SiteCountriesProvider.GetByCountryId(_countryId, this.StartIndex, this.PageSize, out count);
					break;
				case SiteCountriesSelectMethod.GetBySiteId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					results = SiteCountriesProvider.GetBySiteId(_siteId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == SiteCountriesSelectMethod.Get || SelectMethod == SiteCountriesSelectMethod.GetBySiteCountryId )
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
				SiteCountries entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					SiteCountriesProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<SiteCountries> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			SiteCountriesProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region SiteCountriesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the SiteCountriesDataSource class.
	/// </summary>
	public class SiteCountriesDataSourceDesigner : ProviderDataSourceDesigner<SiteCountries, SiteCountriesKey>
	{
		/// <summary>
		/// Initializes a new instance of the SiteCountriesDataSourceDesigner class.
		/// </summary>
		public SiteCountriesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SiteCountriesSelectMethod SelectMethod
		{
			get { return ((SiteCountriesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new SiteCountriesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region SiteCountriesDataSourceActionList

	/// <summary>
	/// Supports the SiteCountriesDataSourceDesigner class.
	/// </summary>
	internal class SiteCountriesDataSourceActionList : DesignerActionList
	{
		private SiteCountriesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the SiteCountriesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public SiteCountriesDataSourceActionList(SiteCountriesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public SiteCountriesSelectMethod SelectMethod
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

	#endregion SiteCountriesDataSourceActionList
	
	#endregion SiteCountriesDataSourceDesigner
	
	#region SiteCountriesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the SiteCountriesDataSource.SelectMethod property.
	/// </summary>
	public enum SiteCountriesSelectMethod
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
		/// Represents the GetBySiteIdCountryId method.
		/// </summary>
		GetBySiteIdCountryId,
		/// <summary>
		/// Represents the GetBySiteCountryId method.
		/// </summary>
		GetBySiteCountryId,
		/// <summary>
		/// Represents the GetByCountryId method.
		/// </summary>
		GetByCountryId,
		/// <summary>
		/// Represents the GetBySiteId method.
		/// </summary>
		GetBySiteId
	}
	
	#endregion SiteCountriesSelectMethod

	#region SiteCountriesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteCountries"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteCountriesFilter : SqlFilter<SiteCountriesColumn>
	{
	}
	
	#endregion SiteCountriesFilter

	#region SiteCountriesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="SiteCountries"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteCountriesExpressionBuilder : SqlExpressionBuilder<SiteCountriesColumn>
	{
	}
	
	#endregion SiteCountriesExpressionBuilder	

	#region SiteCountriesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;SiteCountriesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="SiteCountries"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class SiteCountriesProperty : ChildEntityProperty<SiteCountriesChildEntityTypes>
	{
	}
	
	#endregion SiteCountriesProperty
}

