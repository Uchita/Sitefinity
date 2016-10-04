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
	/// Represents the DataRepository.EnquiriesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(EnquiriesDataSourceDesigner))]
	public class EnquiriesDataSource : ProviderDataSource<Enquiries, EnquiriesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EnquiriesDataSource class.
		/// </summary>
		public EnquiriesDataSource() : base(new EnquiriesService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the EnquiriesDataSourceView used by the EnquiriesDataSource.
		/// </summary>
		protected EnquiriesDataSourceView EnquiriesView
		{
			get { return ( View as EnquiriesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the EnquiriesDataSource control invokes to retrieve data.
		/// </summary>
		public EnquiriesSelectMethod SelectMethod
		{
			get
			{
				EnquiriesSelectMethod selectMethod = EnquiriesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (EnquiriesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the EnquiriesDataSourceView class that is to be
		/// used by the EnquiriesDataSource.
		/// </summary>
		/// <returns>An instance of the EnquiriesDataSourceView class.</returns>
		protected override BaseDataSourceView<Enquiries, EnquiriesKey> GetNewDataSourceView()
		{
			return new EnquiriesDataSourceView(this, DefaultViewName);
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
	/// Supports the EnquiriesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class EnquiriesDataSourceView : ProviderDataSourceView<Enquiries, EnquiriesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EnquiriesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the EnquiriesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public EnquiriesDataSourceView(EnquiriesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal EnquiriesDataSource EnquiriesOwner
		{
			get { return Owner as EnquiriesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal EnquiriesSelectMethod SelectMethod
		{
			get { return EnquiriesOwner.SelectMethod; }
			set { EnquiriesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal EnquiriesService EnquiriesProvider
		{
			get { return Provider as EnquiriesService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Enquiries> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Enquiries> results = null;
			Enquiries item;
			count = 0;
			
			System.Int32 _enquiryId;
			System.Int32 _siteId;
			System.Int32? sp197_SiteId;
			System.Int32? sp196_EnquiryId;
			System.Boolean? sp194_SearchUsingOr;
			System.Int32? sp194_EnquiryId;
			System.Int32? sp194_SiteId;
			System.String sp194_Name;
			System.String sp194_Email;
			System.String sp194_ContactPhone;
			System.String sp194_Content;

			switch ( SelectMethod )
			{
				case EnquiriesSelectMethod.Get:
					EnquiriesKey entityKey  = new EnquiriesKey();
					entityKey.Load(values);
					item = EnquiriesProvider.Get(entityKey);
					results = new TList<Enquiries>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case EnquiriesSelectMethod.GetAll:
                    results = EnquiriesProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case EnquiriesSelectMethod.GetPaged:
					results = EnquiriesProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case EnquiriesSelectMethod.Find:
					if ( FilterParameters != null )
						results = EnquiriesProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = EnquiriesProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case EnquiriesSelectMethod.GetByEnquiryId:
					_enquiryId = ( values["EnquiryId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["EnquiryId"], typeof(System.Int32)) : (int)0;
					item = EnquiriesProvider.GetByEnquiryId(_enquiryId);
					results = new TList<Enquiries>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case EnquiriesSelectMethod.GetBySiteId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					results = EnquiriesProvider.GetBySiteId(_siteId, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				// Custom
				
				case EnquiriesSelectMethod.Get_List:
					results = EnquiriesProvider.Get_List(StartIndex, PageSize);
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
			if ( SelectMethod == EnquiriesSelectMethod.Get || SelectMethod == EnquiriesSelectMethod.GetByEnquiryId )
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
				Enquiries entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					EnquiriesProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Enquiries> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			EnquiriesProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region EnquiriesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the EnquiriesDataSource class.
	/// </summary>
	public class EnquiriesDataSourceDesigner : ProviderDataSourceDesigner<Enquiries, EnquiriesKey>
	{
		/// <summary>
		/// Initializes a new instance of the EnquiriesDataSourceDesigner class.
		/// </summary>
		public EnquiriesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public EnquiriesSelectMethod SelectMethod
		{
			get { return ((EnquiriesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new EnquiriesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region EnquiriesDataSourceActionList

	/// <summary>
	/// Supports the EnquiriesDataSourceDesigner class.
	/// </summary>
	internal class EnquiriesDataSourceActionList : DesignerActionList
	{
		private EnquiriesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the EnquiriesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public EnquiriesDataSourceActionList(EnquiriesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public EnquiriesSelectMethod SelectMethod
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

	#endregion EnquiriesDataSourceActionList
	
	#endregion EnquiriesDataSourceDesigner
	
	#region EnquiriesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the EnquiriesDataSource.SelectMethod property.
	/// </summary>
	public enum EnquiriesSelectMethod
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
		/// Represents the GetByEnquiryId method.
		/// </summary>
		GetByEnquiryId,
		/// <summary>
		/// Represents the GetBySiteId method.
		/// </summary>
		GetBySiteId,
		/// <summary>
		/// Represents the Get_List method.
		/// </summary>
		Get_List
	}
	
	#endregion EnquiriesSelectMethod

	#region EnquiriesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Enquiries"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EnquiriesFilter : SqlFilter<EnquiriesColumn>
	{
	}
	
	#endregion EnquiriesFilter

	#region EnquiriesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Enquiries"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EnquiriesExpressionBuilder : SqlExpressionBuilder<EnquiriesColumn>
	{
	}
	
	#endregion EnquiriesExpressionBuilder	

	#region EnquiriesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;EnquiriesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Enquiries"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EnquiriesProperty : ChildEntityProperty<EnquiriesChildEntityTypes>
	{
	}
	
	#endregion EnquiriesProperty
}

