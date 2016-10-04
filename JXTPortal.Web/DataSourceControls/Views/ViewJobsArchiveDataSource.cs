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
	/// Represents the DataRepository.ViewJobsArchiveProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(ViewJobsArchiveDataSourceDesigner))]
	public class ViewJobsArchiveDataSource : ReadOnlyDataSource<ViewJobsArchive>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ViewJobsArchiveDataSource class.
		/// </summary>
		public ViewJobsArchiveDataSource() : base(new ViewJobsArchiveService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ViewJobsArchiveDataSourceView used by the ViewJobsArchiveDataSource.
		/// </summary>
		protected ViewJobsArchiveDataSourceView ViewJobsArchiveView
		{
			get { return ( View as ViewJobsArchiveDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ViewJobsArchiveDataSource control invokes to retrieve data.
		/// </summary>
		public new ViewJobsArchiveSelectMethod SelectMethod
		{
			get
			{
				ViewJobsArchiveSelectMethod selectMethod = ViewJobsArchiveSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ViewJobsArchiveSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ViewJobsArchiveDataSourceView class that is to be
		/// used by the ViewJobsArchiveDataSource.
		/// </summary>
		/// <returns>An instance of the ViewJobsArchiveDataSourceView class.</returns>
		protected override BaseDataSourceView<ViewJobsArchive, Object> GetNewDataSourceView()
		{
			return new ViewJobsArchiveDataSourceView(this, DefaultViewName);
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
	/// Supports the ViewJobsArchiveDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ViewJobsArchiveDataSourceView : ReadOnlyDataSourceView<ViewJobsArchive>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ViewJobsArchiveDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ViewJobsArchiveDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ViewJobsArchiveDataSourceView(ViewJobsArchiveDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ViewJobsArchiveDataSource ViewJobsArchiveOwner
		{
			get { return Owner as ViewJobsArchiveDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal new ViewJobsArchiveSelectMethod SelectMethod
		{
			get { return ViewJobsArchiveOwner.SelectMethod; }
			set { ViewJobsArchiveOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ViewJobsArchiveService ViewJobsArchiveProvider
		{
			get { return Provider as ViewJobsArchiveService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<ViewJobsArchive> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			
			IList<ViewJobsArchive> results = null;
			// ViewJobsArchive item;
			count = 0;
			
			System.Int32? sp879_JobId;
			System.Int32? sp879_SiteId;

			switch ( SelectMethod )
			{
				case ViewJobsArchiveSelectMethod.Get:
					results = ViewJobsArchiveProvider.Get(WhereClause, OrderBy, StartIndex, PageSize, out count);
                    break;
				case ViewJobsArchiveSelectMethod.GetPaged:
					results = ViewJobsArchiveProvider.GetPaged(WhereClause, OrderBy, StartIndex, PageSize, out count);
					break;
				case ViewJobsArchiveSelectMethod.GetAll:
					results = ViewJobsArchiveProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ViewJobsArchiveSelectMethod.Find:
					results = ViewJobsArchiveProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
                    break;
				// Custom
				case ViewJobsArchiveSelectMethod.GetByID:
					sp879_JobId = (System.Int32?) EntityUtil.ChangeType(values["JobId"], typeof(System.Int32?));
					sp879_SiteId = (System.Int32?) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32?));
					results = ViewJobsArchiveProvider.GetByID(sp879_JobId, sp879_SiteId, StartIndex, PageSize);
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

	#region ViewJobsArchiveSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ViewJobsArchiveDataSource.SelectMethod property.
	/// </summary>
	public enum ViewJobsArchiveSelectMethod
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
	
	#endregion ViewJobsArchiveSelectMethod
	
	#region ViewJobsArchiveDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ViewJobsArchiveDataSource class.
	/// </summary>
	public class ViewJobsArchiveDataSourceDesigner : ReadOnlyDataSourceDesigner<ViewJobsArchive>
	{
		/// <summary>
		/// Initializes a new instance of the ViewJobsArchiveDataSourceDesigner class.
		/// </summary>
		public ViewJobsArchiveDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public new ViewJobsArchiveSelectMethod SelectMethod
		{
			get { return ((ViewJobsArchiveDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ViewJobsArchiveDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ViewJobsArchiveDataSourceActionList

	/// <summary>
	/// Supports the ViewJobsArchiveDataSourceDesigner class.
	/// </summary>
	internal class ViewJobsArchiveDataSourceActionList : DesignerActionList
	{
		private ViewJobsArchiveDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ViewJobsArchiveDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ViewJobsArchiveDataSourceActionList(ViewJobsArchiveDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ViewJobsArchiveSelectMethod SelectMethod
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

	#endregion ViewJobsArchiveDataSourceActionList

	#endregion ViewJobsArchiveDataSourceDesigner

	#region ViewJobsArchiveFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ViewJobsArchive"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ViewJobsArchiveFilter : SqlFilter<ViewJobsArchiveColumn>
	{
	}

	#endregion ViewJobsArchiveFilter

	#region ViewJobsArchiveExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ViewJobsArchive"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ViewJobsArchiveExpressionBuilder : SqlExpressionBuilder<ViewJobsArchiveColumn>
	{
	}
	
	#endregion ViewJobsArchiveExpressionBuilder		
}

