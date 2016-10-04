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
	/// Represents the DataRepository.LanguagesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(LanguagesDataSourceDesigner))]
	public class LanguagesDataSource : ProviderDataSource<Languages, LanguagesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LanguagesDataSource class.
		/// </summary>
		public LanguagesDataSource() : base(new LanguagesService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the LanguagesDataSourceView used by the LanguagesDataSource.
		/// </summary>
		protected LanguagesDataSourceView LanguagesView
		{
			get { return ( View as LanguagesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the LanguagesDataSource control invokes to retrieve data.
		/// </summary>
		public LanguagesSelectMethod SelectMethod
		{
			get
			{
				LanguagesSelectMethod selectMethod = LanguagesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (LanguagesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the LanguagesDataSourceView class that is to be
		/// used by the LanguagesDataSource.
		/// </summary>
		/// <returns>An instance of the LanguagesDataSourceView class.</returns>
		protected override BaseDataSourceView<Languages, LanguagesKey> GetNewDataSourceView()
		{
			return new LanguagesDataSourceView(this, DefaultViewName);
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
	/// Supports the LanguagesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class LanguagesDataSourceView : ProviderDataSourceView<Languages, LanguagesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the LanguagesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the LanguagesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public LanguagesDataSourceView(LanguagesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal LanguagesDataSource LanguagesOwner
		{
			get { return Owner as LanguagesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal LanguagesSelectMethod SelectMethod
		{
			get { return LanguagesOwner.SelectMethod; }
			set { LanguagesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal LanguagesService LanguagesProvider
		{
			get { return Provider as LanguagesService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Languages> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Languages> results = null;
			Languages item;
			count = 0;
			
			System.Int32 _languageId;

			switch ( SelectMethod )
			{
				case LanguagesSelectMethod.Get:
					LanguagesKey entityKey  = new LanguagesKey();
					entityKey.Load(values);
					item = LanguagesProvider.Get(entityKey);
					results = new TList<Languages>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case LanguagesSelectMethod.GetAll:
                    results = LanguagesProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case LanguagesSelectMethod.GetPaged:
					results = LanguagesProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case LanguagesSelectMethod.Find:
					if ( FilterParameters != null )
						results = LanguagesProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = LanguagesProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case LanguagesSelectMethod.GetByLanguageId:
					_languageId = ( values["LanguageId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["LanguageId"], typeof(System.Int32)) : (int)0;
					item = LanguagesProvider.GetByLanguageId(_languageId);
					results = new TList<Languages>();
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
			if ( SelectMethod == LanguagesSelectMethod.Get || SelectMethod == LanguagesSelectMethod.GetByLanguageId )
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
				Languages entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					LanguagesProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Languages> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			LanguagesProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region LanguagesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the LanguagesDataSource class.
	/// </summary>
	public class LanguagesDataSourceDesigner : ProviderDataSourceDesigner<Languages, LanguagesKey>
	{
		/// <summary>
		/// Initializes a new instance of the LanguagesDataSourceDesigner class.
		/// </summary>
		public LanguagesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LanguagesSelectMethod SelectMethod
		{
			get { return ((LanguagesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new LanguagesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region LanguagesDataSourceActionList

	/// <summary>
	/// Supports the LanguagesDataSourceDesigner class.
	/// </summary>
	internal class LanguagesDataSourceActionList : DesignerActionList
	{
		private LanguagesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the LanguagesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public LanguagesDataSourceActionList(LanguagesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public LanguagesSelectMethod SelectMethod
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

	#endregion LanguagesDataSourceActionList
	
	#endregion LanguagesDataSourceDesigner
	
	#region LanguagesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the LanguagesDataSource.SelectMethod property.
	/// </summary>
	public enum LanguagesSelectMethod
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
		/// Represents the GetByLanguageId method.
		/// </summary>
		GetByLanguageId
	}
	
	#endregion LanguagesSelectMethod

	#region LanguagesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Languages"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LanguagesFilter : SqlFilter<LanguagesColumn>
	{
	}
	
	#endregion LanguagesFilter

	#region LanguagesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Languages"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LanguagesExpressionBuilder : SqlExpressionBuilder<LanguagesColumn>
	{
	}
	
	#endregion LanguagesExpressionBuilder	

	#region LanguagesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;LanguagesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Languages"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class LanguagesProperty : ChildEntityProperty<LanguagesChildEntityTypes>
	{
	}
	
	#endregion LanguagesProperty
}

