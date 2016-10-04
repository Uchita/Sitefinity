#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using JXTPortal.Entities;
using JXTPortal.Data;
using JXTPortal.Data.Bases;
using JXTPortal;
#endregion

namespace JXTPortal.Web.Data
{
	/// <summary>
	/// Represents the DataRepository.ViewJobSearchProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(ViewJobSearchDataSourceDesigner))]
	public class ViewJobSearchDataSource : ReadOnlyDataSource<ViewJobSearch>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ViewJobSearchDataSource class.
		/// </summary>
		public ViewJobSearchDataSource() : base(new ViewJobSearchService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ViewJobSearchDataSourceView used by the ViewJobSearchDataSource.
		/// </summary>
		protected ViewJobSearchDataSourceView ViewJobSearchView
		{
			get { return ( View as ViewJobSearchDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ViewJobSearchDataSource control invokes to retrieve data.
		/// </summary>
		public new ViewJobSearchSelectMethod SelectMethod
		{
			get
			{
				ViewJobSearchSelectMethod selectMethod = ViewJobSearchSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ViewJobSearchSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ViewJobSearchDataSourceView class that is to be
		/// used by the ViewJobSearchDataSource.
		/// </summary>
		/// <returns>An instance of the ViewJobSearchDataSourceView class.</returns>
		protected override BaseDataSourceView<ViewJobSearch, Object> GetNewDataSourceView()
		{
			return new ViewJobSearchDataSourceView(this, DefaultViewName);
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
	/// Supports the ViewJobSearchDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ViewJobSearchDataSourceView : ReadOnlyDataSourceView<ViewJobSearch>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ViewJobSearchDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ViewJobSearchDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ViewJobSearchDataSourceView(ViewJobSearchDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ViewJobSearchDataSource ViewJobSearchOwner
		{
			get { return Owner as ViewJobSearchDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal new ViewJobSearchSelectMethod SelectMethod
		{
			get { return ViewJobSearchOwner.SelectMethod; }
			set { ViewJobSearchOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ViewJobSearchService ViewJobSearchProvider
		{
			get { return Provider as ViewJobSearchService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ViewJobSearch> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			
			IList<ViewJobSearch> results = null;
			// ViewJobSearch item;
			count = 0;
			
			System.String sp939_Keyword;
			System.Int32? sp939_SiteId;
			System.Int32? sp939_AdvertiserId;
			System.Int32? sp939_CurrencyId;
			System.Decimal? sp939_SalaryLowerBand;
			System.Decimal? sp939_SalaryUpperBand;
			System.Int32? sp939_SalaryTypeId;
			System.Int32? sp939_WorkTypeId;
			System.Int32? sp939_ProfessionId;
			System.String sp939_RoleId;
			System.Int32? sp939_CountryId;
			System.Int32? sp939_LocationId;
			System.String sp939_AreaId;
			System.DateTime? sp939_DateFrom;
			System.Int32? sp939_PageIndex;
			System.Int32? sp939_PageSize;
			System.String sp939_OrderBy;
			System.String sp939_JobTypeIds;
			System.Int32? sp941_SiteId;
			System.Int32? sp941_ProfessionId;
			System.String sp941_RoleId;
			System.String sp941_OrderBy;
			System.Int32? sp941_PageSize;

			switch ( SelectMethod )
			{
				case ViewJobSearchSelectMethod.Get:
					results = ViewJobSearchProvider.Get(WhereClause, OrderBy, StartIndex, PageSize, out count);
                    break;
				case ViewJobSearchSelectMethod.GetPaged:
					results = ViewJobSearchProvider.GetPaged(WhereClause, OrderBy, StartIndex, PageSize, out count);
					break;
				case ViewJobSearchSelectMethod.GetAll:
					results = ViewJobSearchProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ViewJobSearchSelectMethod.Find:
					results = ViewJobSearchProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
                    break;
				// Custom
				case ViewJobSearchSelectMethod.GetBySearchFilter:
					sp939_Keyword = (System.String) EntityUtil.ChangeType(values["Keyword"], typeof(System.String));
					sp939_SiteId = (System.Int32?) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32?));
					sp939_AdvertiserId = (System.Int32?) EntityUtil.ChangeType(values["AdvertiserId"], typeof(System.Int32?));
					sp939_CurrencyId = (System.Int32?) EntityUtil.ChangeType(values["CurrencyId"], typeof(System.Int32?));
					sp939_SalaryLowerBand = (System.Decimal?) EntityUtil.ChangeType(values["SalaryLowerBand"], typeof(System.Decimal?));
					sp939_SalaryUpperBand = (System.Decimal?) EntityUtil.ChangeType(values["SalaryUpperBand"], typeof(System.Decimal?));
					sp939_SalaryTypeId = (System.Int32?) EntityUtil.ChangeType(values["SalaryTypeId"], typeof(System.Int32?));
					sp939_WorkTypeId = (System.Int32?) EntityUtil.ChangeType(values["WorkTypeId"], typeof(System.Int32?));
					sp939_ProfessionId = (System.Int32?) EntityUtil.ChangeType(values["ProfessionId"], typeof(System.Int32?));
					sp939_RoleId = (System.String) EntityUtil.ChangeType(values["RoleId"], typeof(System.String));
					sp939_CountryId = (System.Int32?) EntityUtil.ChangeType(values["CountryId"], typeof(System.Int32?));
					sp939_LocationId = (System.Int32?) EntityUtil.ChangeType(values["LocationId"], typeof(System.Int32?));
					sp939_AreaId = (System.String) EntityUtil.ChangeType(values["AreaId"], typeof(System.String));
					sp939_DateFrom = (System.DateTime?) EntityUtil.ChangeType(values["DateFrom"], typeof(System.DateTime?));
					sp939_PageIndex = (System.Int32?) EntityUtil.ChangeType(values["PageIndex"], typeof(System.Int32?));
					sp939_PageSize = (System.Int32?) EntityUtil.ChangeType(values["PageSize"], typeof(System.Int32?));
					sp939_OrderBy = (System.String) EntityUtil.ChangeType(values["OrderBy"], typeof(System.String));
					sp939_JobTypeIds = (System.String) EntityUtil.ChangeType(values["JobTypeIds"], typeof(System.String));
					results = ViewJobSearchProvider.GetBySearchFilter(sp939_Keyword, sp939_SiteId, sp939_AdvertiserId, sp939_CurrencyId, sp939_SalaryLowerBand, sp939_SalaryUpperBand, sp939_SalaryTypeId, sp939_WorkTypeId, sp939_ProfessionId, sp939_RoleId, sp939_CountryId, sp939_LocationId, sp939_AreaId, sp939_DateFrom, sp939_PageIndex, sp939_PageSize, sp939_OrderBy, sp939_JobTypeIds, StartIndex, PageSize);
					break;
				case ViewJobSearchSelectMethod.GetPremiumSearchFilter:
					sp941_SiteId = (System.Int32?) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32?));
					sp941_ProfessionId = (System.Int32?) EntityUtil.ChangeType(values["ProfessionId"], typeof(System.Int32?));
					sp941_RoleId = (System.String) EntityUtil.ChangeType(values["RoleId"], typeof(System.String));
					sp941_OrderBy = (System.String) EntityUtil.ChangeType(values["OrderBy"], typeof(System.String));
					sp941_PageSize = (System.Int32?) EntityUtil.ChangeType(values["PageSize"], typeof(System.Int32?));
					results = ViewJobSearchProvider.GetPremiumSearchFilter(sp941_SiteId, sp941_ProfessionId, sp941_RoleId, sp941_OrderBy, sp941_PageSize, StartIndex, PageSize);
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
		
		#endregion Methods
	}

	#region ViewJobSearchSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ViewJobSearchDataSource.SelectMethod property.
	/// </summary>
	public enum ViewJobSearchSelectMethod
	{
		/// <summary>
		/// Represents the Get method.
		/// </summary>
		Get,
		/// <summary>
		/// Represents the GetPaged method.
		/// </summary>
		GetPaged,
		/// <summary>
		/// Represents the GetAll method.
		/// </summary>
		GetAll,
		/// <summary>
		/// Represents the Find method.
		/// </summary>
		Find,
		/// <summary>
		/// Represents the GetBySearchFilter method.
		/// </summary>
		GetBySearchFilter,
		/// <summary>
		/// Represents the GetPremiumSearchFilter method.
		/// </summary>
		GetPremiumSearchFilter
	}
	
	#endregion ViewJobSearchSelectMethod
	
	#region ViewJobSearchDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ViewJobSearchDataSource class.
	/// </summary>
	public class ViewJobSearchDataSourceDesigner : ReadOnlyDataSourceDesigner<ViewJobSearch>
	{
		/// <summary>
		/// Initializes a new instance of the ViewJobSearchDataSourceDesigner class.
		/// </summary>
		public ViewJobSearchDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public new ViewJobSearchSelectMethod SelectMethod
		{
			get { return ((ViewJobSearchDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ViewJobSearchDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ViewJobSearchDataSourceActionList

	/// <summary>
	/// Supports the ViewJobSearchDataSourceDesigner class.
	/// </summary>
	internal class ViewJobSearchDataSourceActionList : DesignerActionList
	{
		private ViewJobSearchDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ViewJobSearchDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ViewJobSearchDataSourceActionList(ViewJobSearchDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ViewJobSearchSelectMethod SelectMethod
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

	#endregion ViewJobSearchDataSourceActionList

	#endregion ViewJobSearchDataSourceDesigner

	#region ViewJobSearchFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ViewJobSearch"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ViewJobSearchFilter : SqlFilter<ViewJobSearchColumn>
	{
	}

	#endregion ViewJobSearchFilter

	#region ViewJobSearchExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ViewJobSearch"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ViewJobSearchExpressionBuilder : SqlExpressionBuilder<ViewJobSearchColumn>
	{
	}
	
	#endregion ViewJobSearchExpressionBuilder		
}

