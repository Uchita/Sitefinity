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
	/// Represents the DataRepository.ViewSiteAdvertisersProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[CLSCompliant(true)]
	[Designer(typeof(ViewSiteAdvertisersDataSourceDesigner))]
	public class ViewSiteAdvertisersDataSource : ReadOnlyDataSource<ViewSiteAdvertisers>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ViewSiteAdvertisersDataSource class.
		/// </summary>
		public ViewSiteAdvertisersDataSource() : base(new ViewSiteAdvertisersService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ViewSiteAdvertisersDataSourceView used by the ViewSiteAdvertisersDataSource.
		/// </summary>
		protected ViewSiteAdvertisersDataSourceView ViewSiteAdvertisersView
		{
			get { return ( View as ViewSiteAdvertisersDataSourceView ); }
		}
		
		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ViewSiteAdvertisersDataSourceView class that is to be
		/// used by the ViewSiteAdvertisersDataSource.
		/// </summary>
		/// <returns>An instance of the ViewSiteAdvertisersDataSourceView class.</returns>
		protected override BaseDataSourceView<ViewSiteAdvertisers, Object> GetNewDataSourceView()
		{
			return new ViewSiteAdvertisersDataSourceView(this, DefaultViewName);
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
	/// Supports the ViewSiteAdvertisersDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ViewSiteAdvertisersDataSourceView : ReadOnlyDataSourceView<ViewSiteAdvertisers>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ViewSiteAdvertisersDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ViewSiteAdvertisersDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ViewSiteAdvertisersDataSourceView(ViewSiteAdvertisersDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ViewSiteAdvertisersDataSource ViewSiteAdvertisersOwner
		{
			get { return Owner as ViewSiteAdvertisersDataSource; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ViewSiteAdvertisersService ViewSiteAdvertisersProvider
		{
			get { return Provider as ViewSiteAdvertisersService; }
		}

		#endregion Properties
		
		#region Methods
		
		#endregion Methods
	}

	#region ViewSiteAdvertisersDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ViewSiteAdvertisersDataSource class.
	/// </summary>
	public class ViewSiteAdvertisersDataSourceDesigner : ReadOnlyDataSourceDesigner<ViewSiteAdvertisers>
	{
	}

	#endregion ViewSiteAdvertisersDataSourceDesigner

	#region ViewSiteAdvertisersFilter

	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ViewSiteAdvertisers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ViewSiteAdvertisersFilter : SqlFilter<ViewSiteAdvertisersColumn>
	{
	}

	#endregion ViewSiteAdvertisersFilter

	#region ViewSiteAdvertisersExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ViewSiteAdvertisers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ViewSiteAdvertisersExpressionBuilder : SqlExpressionBuilder<ViewSiteAdvertisersColumn>
	{
	}
	
	#endregion ViewSiteAdvertisersExpressionBuilder		
}

