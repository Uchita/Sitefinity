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
	/// Represents the DataRepository.ViewJobsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(ViewJobsDataSourceDesigner))]
	public class ViewJobsDataSource : ReadOnlyDataSource<ViewJobs>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ViewJobsDataSource class.
		/// </summary>
		public ViewJobsDataSource() : base(new ViewJobsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ViewJobsDataSourceView used by the ViewJobsDataSource.
		/// </summary>
		protected ViewJobsDataSourceView ViewJobsView
		{
			get { return ( View as ViewJobsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ViewJobsDataSource control invokes to retrieve data.
		/// </summary>
		public new ViewJobsSelectMethod SelectMethod
		{
			get
			{
				ViewJobsSelectMethod selectMethod = ViewJobsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ViewJobsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ViewJobsDataSourceView class that is to be
		/// used by the ViewJobsDataSource.
		/// </summary>
		/// <returns>An instance of the ViewJobsDataSourceView class.</returns>
		protected override BaseDataSourceView<ViewJobs, Object> GetNewDataSourceView()
		{
			return new ViewJobsDataSourceView(this, DefaultViewName);
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
	/// Supports the ViewJobsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ViewJobsDataSourceView : ReadOnlyDataSourceView<ViewJobs>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ViewJobsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ViewJobsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ViewJobsDataSourceView(ViewJobsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ViewJobsDataSource ViewJobsOwner
		{
			get { return Owner as ViewJobsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal new ViewJobsSelectMethod SelectMethod
		{
			get { return ViewJobsOwner.SelectMethod; }
			set { ViewJobsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ViewJobsService ViewJobsProvider
		{
			get { return Provider as ViewJobsService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ViewJobs> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			
			IList<ViewJobs> results = null;
			// ViewJobs item;
			count = 0;
			
			System.Int32? sp875_JobId;
			System.Int32? sp875_SiteId;

			switch ( SelectMethod )
			{
				case ViewJobsSelectMethod.Get:
					results = ViewJobsProvider.Get(WhereClause, OrderBy, StartIndex, PageSize, out count);
                    break;
				case ViewJobsSelectMethod.GetPaged:
					results = ViewJobsProvider.GetPaged(WhereClause, OrderBy, StartIndex, PageSize, out count);
					break;
				case ViewJobsSelectMethod.GetAll:
					results = ViewJobsProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ViewJobsSelectMethod.Find:
					results = ViewJobsProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
                    break;
				// Custom
				case ViewJobsSelectMethod.GetByID:
					sp875_JobId = (System.Int32?) EntityUtil.ChangeType(values["JobId"], typeof(System.Int32?));
					sp875_SiteId = (System.Int32?) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32?));
					results = ViewJobsProvider.GetByID(sp875_JobId, sp875_SiteId, StartIndex, PageSize);
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

	#region ViewJobsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ViewJobsDataSource.SelectMethod property.
	/// </summary>
	public enum ViewJobsSelectMethod
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
		/// Represents the GetByID method.
		/// </summary>
		GetByID
	}
	
	#endregion ViewJobsSelectMethod
	
	#region ViewJobsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ViewJobsDataSource class.
	/// </summary>
	public class ViewJobsDataSourceDesigner : ReadOnlyDataSourceDesigner<ViewJobs>
	{
		/// <summary>
		/// Initializes a new instance of the ViewJobsDataSourceDesigner class.
		/// </summary>
		public ViewJobsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public new ViewJobsSelectMethod SelectMethod
		{
			get { return ((ViewJobsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ViewJobsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ViewJobsDataSourceActionList

	/// <summary>
	/// Supports the ViewJobsDataSourceDesigner class.
	/// </summary>
	internal class ViewJobsDataSourceActionList : DesignerActionList
	{
		private ViewJobsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ViewJobsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ViewJobsDataSourceActionList(ViewJobsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ViewJobsSelectMethod SelectMethod
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

	#endregion ViewJobsDataSourceActionList

	#endregion ViewJobsDataSourceDesigner

	#region ViewJobsFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ViewJobs"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ViewJobsFilter : SqlFilter<ViewJobsColumn>
	{
	}

	#endregion ViewJobsFilter

	#region ViewJobsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ViewJobs"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ViewJobsExpressionBuilder : SqlExpressionBuilder<ViewJobsColumn>
	{
	}
	
	#endregion ViewJobsExpressionBuilder		
}

