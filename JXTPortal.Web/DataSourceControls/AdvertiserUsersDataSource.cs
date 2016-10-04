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
	/// Represents the DataRepository.AdvertiserUsersProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(AdvertiserUsersDataSourceDesigner))]
	public class AdvertiserUsersDataSource : ProviderDataSource<AdvertiserUsers, AdvertiserUsersKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserUsersDataSource class.
		/// </summary>
		public AdvertiserUsersDataSource() : base(new AdvertiserUsersService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the AdvertiserUsersDataSourceView used by the AdvertiserUsersDataSource.
		/// </summary>
		protected AdvertiserUsersDataSourceView AdvertiserUsersView
		{
			get { return ( View as AdvertiserUsersDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the AdvertiserUsersDataSource control invokes to retrieve data.
		/// </summary>
		public AdvertiserUsersSelectMethod SelectMethod
		{
			get
			{
				AdvertiserUsersSelectMethod selectMethod = AdvertiserUsersSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (AdvertiserUsersSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the AdvertiserUsersDataSourceView class that is to be
		/// used by the AdvertiserUsersDataSource.
		/// </summary>
		/// <returns>An instance of the AdvertiserUsersDataSourceView class.</returns>
		protected override BaseDataSourceView<AdvertiserUsers, AdvertiserUsersKey> GetNewDataSourceView()
		{
			return new AdvertiserUsersDataSourceView(this, DefaultViewName);
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
	/// Supports the AdvertiserUsersDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class AdvertiserUsersDataSourceView : ProviderDataSourceView<AdvertiserUsers, AdvertiserUsersKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the AdvertiserUsersDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the AdvertiserUsersDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public AdvertiserUsersDataSourceView(AdvertiserUsersDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal AdvertiserUsersDataSource AdvertiserUsersOwner
		{
			get { return Owner as AdvertiserUsersDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal AdvertiserUsersSelectMethod SelectMethod
		{
			get { return AdvertiserUsersOwner.SelectMethod; }
			set { AdvertiserUsersOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal AdvertiserUsersService AdvertiserUsersProvider
		{
			get { return Provider as AdvertiserUsersService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<AdvertiserUsers> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<AdvertiserUsers> results = null;
			AdvertiserUsers item;
			count = 0;
			
			System.String _userName;
			System.Int32 _advertiserId;
			System.Int32 _advertiserUserId;
			System.Int32 _emailFormat;
			System.Int32 _lastModifiedBy;
			System.Int32 _newsletterFormat;

			switch ( SelectMethod )
			{
				case AdvertiserUsersSelectMethod.Get:
					AdvertiserUsersKey entityKey  = new AdvertiserUsersKey();
					entityKey.Load(values);
					item = AdvertiserUsersProvider.Get(entityKey);
					results = new TList<AdvertiserUsers>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case AdvertiserUsersSelectMethod.GetAll:
                    results = AdvertiserUsersProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case AdvertiserUsersSelectMethod.GetPaged:
					results = AdvertiserUsersProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case AdvertiserUsersSelectMethod.Find:
					if ( FilterParameters != null )
						results = AdvertiserUsersProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = AdvertiserUsersProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case AdvertiserUsersSelectMethod.GetByAdvertiserUserId:
					_advertiserUserId = ( values["AdvertiserUserId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AdvertiserUserId"], typeof(System.Int32)) : (int)0;
					item = AdvertiserUsersProvider.GetByAdvertiserUserId(_advertiserUserId);
					results = new TList<AdvertiserUsers>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case AdvertiserUsersSelectMethod.GetByUserNameAdvertiserId:
					_userName = ( values["UserName"] != null ) ? (System.String) EntityUtil.ChangeType(values["UserName"], typeof(System.String)) : string.Empty;
					_advertiserId = ( values["AdvertiserId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AdvertiserId"], typeof(System.Int32)) : (int)0;
					item = AdvertiserUsersProvider.GetByUserNameAdvertiserId(_userName, _advertiserId);
					results = new TList<AdvertiserUsers>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				case AdvertiserUsersSelectMethod.GetByAdvertiserId:
					_advertiserId = ( values["AdvertiserId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AdvertiserId"], typeof(System.Int32)) : (int)0;
					results = AdvertiserUsersProvider.GetByAdvertiserId(_advertiserId, this.StartIndex, this.PageSize, out count);
					break;
				case AdvertiserUsersSelectMethod.GetByEmailFormat:
					_emailFormat = ( values["EmailFormat"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["EmailFormat"], typeof(System.Int32)) : (int)0;
					results = AdvertiserUsersProvider.GetByEmailFormat(_emailFormat, this.StartIndex, this.PageSize, out count);
					break;
				case AdvertiserUsersSelectMethod.GetByLastModifiedBy:
					_lastModifiedBy = ( values["LastModifiedBy"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["LastModifiedBy"], typeof(System.Int32)) : (int)0;
					results = AdvertiserUsersProvider.GetByLastModifiedBy(_lastModifiedBy, this.StartIndex, this.PageSize, out count);
					break;
				case AdvertiserUsersSelectMethod.GetByNewsletterFormat:
					_newsletterFormat = ( values["NewsletterFormat"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["NewsletterFormat"], typeof(System.Int32)) : (int)0;
					results = AdvertiserUsersProvider.GetByNewsletterFormat(_newsletterFormat, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == AdvertiserUsersSelectMethod.Get || SelectMethod == AdvertiserUsersSelectMethod.GetByAdvertiserUserId )
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
				AdvertiserUsers entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					AdvertiserUsersProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<AdvertiserUsers> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			AdvertiserUsersProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region AdvertiserUsersDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the AdvertiserUsersDataSource class.
	/// </summary>
	public class AdvertiserUsersDataSourceDesigner : ProviderDataSourceDesigner<AdvertiserUsers, AdvertiserUsersKey>
	{
		/// <summary>
		/// Initializes a new instance of the AdvertiserUsersDataSourceDesigner class.
		/// </summary>
		public AdvertiserUsersDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AdvertiserUsersSelectMethod SelectMethod
		{
			get { return ((AdvertiserUsersDataSource) DataSource).SelectMethod; }
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
				actions.Add(new AdvertiserUsersDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region AdvertiserUsersDataSourceActionList

	/// <summary>
	/// Supports the AdvertiserUsersDataSourceDesigner class.
	/// </summary>
	internal class AdvertiserUsersDataSourceActionList : DesignerActionList
	{
		private AdvertiserUsersDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the AdvertiserUsersDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public AdvertiserUsersDataSourceActionList(AdvertiserUsersDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public AdvertiserUsersSelectMethod SelectMethod
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

	#endregion AdvertiserUsersDataSourceActionList
	
	#endregion AdvertiserUsersDataSourceDesigner
	
	#region AdvertiserUsersSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the AdvertiserUsersDataSource.SelectMethod property.
	/// </summary>
	public enum AdvertiserUsersSelectMethod
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
		/// Represents the GetByUserNameAdvertiserId method.
		/// </summary>
		GetByUserNameAdvertiserId,
		/// <summary>
		/// Represents the GetByAdvertiserUserId method.
		/// </summary>
		GetByAdvertiserUserId,
		/// <summary>
		/// Represents the GetByAdvertiserId method.
		/// </summary>
		GetByAdvertiserId,
		/// <summary>
		/// Represents the GetByEmailFormat method.
		/// </summary>
		GetByEmailFormat,
		/// <summary>
		/// Represents the GetByLastModifiedBy method.
		/// </summary>
		GetByLastModifiedBy,
		/// <summary>
		/// Represents the GetByNewsletterFormat method.
		/// </summary>
		GetByNewsletterFormat
	}
	
	#endregion AdvertiserUsersSelectMethod

	#region AdvertiserUsersFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdvertiserUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserUsersFilter : SqlFilter<AdvertiserUsersColumn>
	{
	}
	
	#endregion AdvertiserUsersFilter

	#region AdvertiserUsersExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="AdvertiserUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserUsersExpressionBuilder : SqlExpressionBuilder<AdvertiserUsersColumn>
	{
	}
	
	#endregion AdvertiserUsersExpressionBuilder	

	#region AdvertiserUsersProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;AdvertiserUsersChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="AdvertiserUsers"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class AdvertiserUsersProperty : ChildEntityProperty<AdvertiserUsersChildEntityTypes>
	{
	}
	
	#endregion AdvertiserUsersProperty
}

