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
	/// Represents the DataRepository.FoldersProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(FoldersDataSourceDesigner))]
	public class FoldersDataSource : ProviderDataSource<Folders, FoldersKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FoldersDataSource class.
		/// </summary>
		public FoldersDataSource() : base(new FoldersService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the FoldersDataSourceView used by the FoldersDataSource.
		/// </summary>
		protected FoldersDataSourceView FoldersView
		{
			get { return ( View as FoldersDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the FoldersDataSource control invokes to retrieve data.
		/// </summary>
		public FoldersSelectMethod SelectMethod
		{
			get
			{
				FoldersSelectMethod selectMethod = FoldersSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (FoldersSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the FoldersDataSourceView class that is to be
		/// used by the FoldersDataSource.
		/// </summary>
		/// <returns>An instance of the FoldersDataSourceView class.</returns>
		protected override BaseDataSourceView<Folders, FoldersKey> GetNewDataSourceView()
		{
			return new FoldersDataSourceView(this, DefaultViewName);
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
	/// Supports the FoldersDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class FoldersDataSourceView : ProviderDataSourceView<Folders, FoldersKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FoldersDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the FoldersDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public FoldersDataSourceView(FoldersDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal FoldersDataSource FoldersOwner
		{
			get { return Owner as FoldersDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal FoldersSelectMethod SelectMethod
		{
			get { return FoldersOwner.SelectMethod; }
			set { FoldersOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal FoldersService FoldersProvider
		{
			get { return Provider as FoldersService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Folders> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Folders> results = null;
			Folders item;
			count = 0;
			
			System.Int32 _siteId;
			System.Int32 _folderId;
			System.Int32 _parentFolderId;
			System.Int32? sp233_SiteId;
			System.Int32? sp232_FolderId;
			System.Boolean? sp230_SearchUsingOr;
			System.Int32? sp230_FolderId;
			System.Int32? sp230_ParentFolderId;
			System.Int32? sp230_SiteId;
			System.String sp230_FolderName;
			System.Int32? sp234_SiteId;
			System.Int32? sp234_FolderId;
			System.Int32? sp234_ParentFolderId;

			switch ( SelectMethod )
			{
				case FoldersSelectMethod.Get:
					FoldersKey entityKey  = new FoldersKey();
					entityKey.Load(values);
					item = FoldersProvider.Get(entityKey);
					results = new TList<Folders>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case FoldersSelectMethod.GetAll:
                    results = FoldersProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case FoldersSelectMethod.GetPaged:
					results = FoldersProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case FoldersSelectMethod.Find:
					if ( FilterParameters != null )
						results = FoldersProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = FoldersProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case FoldersSelectMethod.GetByFolderId:
					_folderId = ( values["FolderId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["FolderId"], typeof(System.Int32)) : (int)0;
					item = FoldersProvider.GetByFolderId(_folderId);
					results = new TList<Folders>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case FoldersSelectMethod.GetBySiteIdFolderIdParentFolderId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					_folderId = ( values["FolderId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["FolderId"], typeof(System.Int32)) : (int)0;
					_parentFolderId = ( values["ParentFolderId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ParentFolderId"], typeof(System.Int32)) : (int)0;
					item = FoldersProvider.GetBySiteIdFolderIdParentFolderId(_siteId, _folderId, _parentFolderId);
					results = new TList<Folders>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				case FoldersSelectMethod.GetBySiteId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					results = FoldersProvider.GetBySiteId(_siteId, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				// Custom
				case FoldersSelectMethod.Get_List:
					results = FoldersProvider.Get_List(StartIndex, PageSize);
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
			if ( SelectMethod == FoldersSelectMethod.Get || SelectMethod == FoldersSelectMethod.GetByFolderId )
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
				Folders entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					FoldersProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Folders> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			FoldersProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region FoldersDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the FoldersDataSource class.
	/// </summary>
	public class FoldersDataSourceDesigner : ProviderDataSourceDesigner<Folders, FoldersKey>
	{
		/// <summary>
		/// Initializes a new instance of the FoldersDataSourceDesigner class.
		/// </summary>
		public FoldersDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public FoldersSelectMethod SelectMethod
		{
			get { return ((FoldersDataSource) DataSource).SelectMethod; }
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
				actions.Add(new FoldersDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region FoldersDataSourceActionList

	/// <summary>
	/// Supports the FoldersDataSourceDesigner class.
	/// </summary>
	internal class FoldersDataSourceActionList : DesignerActionList
	{
		private FoldersDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the FoldersDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public FoldersDataSourceActionList(FoldersDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public FoldersSelectMethod SelectMethod
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

	#endregion FoldersDataSourceActionList
	
	#endregion FoldersDataSourceDesigner
	
	#region FoldersSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the FoldersDataSource.SelectMethod property.
	/// </summary>
	public enum FoldersSelectMethod
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
		/// Represents the GetBySiteIdFolderIdParentFolderId method.
		/// </summary>
		GetBySiteIdFolderIdParentFolderId,
		/// <summary>
		/// Represents the GetByFolderId method.
		/// </summary>
		GetByFolderId,
		/// <summary>
		/// Represents the GetBySiteId method.
		/// </summary>
		GetBySiteId,
		/// <summary>
		/// Represents the Get_List method.
		/// </summary>
		Get_List
	}
	
	#endregion FoldersSelectMethod

	#region FoldersFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Folders"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FoldersFilter : SqlFilter<FoldersColumn>
	{
	}
	
	#endregion FoldersFilter

	#region FoldersExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Folders"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FoldersExpressionBuilder : SqlExpressionBuilder<FoldersColumn>
	{
	}
	
	#endregion FoldersExpressionBuilder	

	#region FoldersProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;FoldersChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Folders"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FoldersProperty : ChildEntityProperty<FoldersChildEntityTypes>
	{
	}
	
	#endregion FoldersProperty
}

