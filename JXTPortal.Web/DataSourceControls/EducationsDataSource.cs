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
	/// Represents the DataRepository.EducationsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(EducationsDataSourceDesigner))]
	public class EducationsDataSource : ProviderDataSource<Educations, EducationsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EducationsDataSource class.
		/// </summary>
		public EducationsDataSource() : base(new EducationsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the EducationsDataSourceView used by the EducationsDataSource.
		/// </summary>
		protected EducationsDataSourceView EducationsView
		{
			get { return ( View as EducationsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the EducationsDataSource control invokes to retrieve data.
		/// </summary>
		public EducationsSelectMethod SelectMethod
		{
			get
			{
				EducationsSelectMethod selectMethod = EducationsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (EducationsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the EducationsDataSourceView class that is to be
		/// used by the EducationsDataSource.
		/// </summary>
		/// <returns>An instance of the EducationsDataSourceView class.</returns>
		protected override BaseDataSourceView<Educations, EducationsKey> GetNewDataSourceView()
		{
			return new EducationsDataSourceView(this, DefaultViewName);
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
	/// Supports the EducationsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class EducationsDataSourceView : ProviderDataSourceView<Educations, EducationsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EducationsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the EducationsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public EducationsDataSourceView(EducationsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal EducationsDataSource EducationsOwner
		{
			get { return Owner as EducationsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal EducationsSelectMethod SelectMethod
		{
			get { return EducationsOwner.SelectMethod; }
			set { EducationsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal EducationsService EducationsProvider
		{
			get { return Provider as EducationsService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Educations> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Educations> results = null;
			Educations item;
			count = 0;
			
			System.Int32 _educationId;
			System.Int32 _lastModifiedBy;
			System.Int32? _siteId_nullable;

			switch ( SelectMethod )
			{
				case EducationsSelectMethod.Get:
					EducationsKey entityKey  = new EducationsKey();
					entityKey.Load(values);
					item = EducationsProvider.Get(entityKey);
					results = new TList<Educations>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case EducationsSelectMethod.GetAll:
                    results = EducationsProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case EducationsSelectMethod.GetPaged:
					results = EducationsProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case EducationsSelectMethod.Find:
					if ( FilterParameters != null )
						results = EducationsProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = EducationsProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case EducationsSelectMethod.GetByEducationId:
					_educationId = ( values["EducationId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["EducationId"], typeof(System.Int32)) : (int)0;
					item = EducationsProvider.GetByEducationId(_educationId);
					results = new TList<Educations>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case EducationsSelectMethod.GetByLastModifiedBy:
					_lastModifiedBy = ( values["LastModifiedBy"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["LastModifiedBy"], typeof(System.Int32)) : (int)0;
					results = EducationsProvider.GetByLastModifiedBy(_lastModifiedBy, this.StartIndex, this.PageSize, out count);
					break;
				case EducationsSelectMethod.GetBySiteId:
					_siteId_nullable = (System.Int32?) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32?));
					results = EducationsProvider.GetBySiteId(_siteId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == EducationsSelectMethod.Get || SelectMethod == EducationsSelectMethod.GetByEducationId )
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
				Educations entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					EducationsProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Educations> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			EducationsProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region EducationsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the EducationsDataSource class.
	/// </summary>
	public class EducationsDataSourceDesigner : ProviderDataSourceDesigner<Educations, EducationsKey>
	{
		/// <summary>
		/// Initializes a new instance of the EducationsDataSourceDesigner class.
		/// </summary>
		public EducationsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public EducationsSelectMethod SelectMethod
		{
			get { return ((EducationsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new EducationsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region EducationsDataSourceActionList

	/// <summary>
	/// Supports the EducationsDataSourceDesigner class.
	/// </summary>
	internal class EducationsDataSourceActionList : DesignerActionList
	{
		private EducationsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the EducationsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public EducationsDataSourceActionList(EducationsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public EducationsSelectMethod SelectMethod
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

	#endregion EducationsDataSourceActionList
	
	#endregion EducationsDataSourceDesigner
	
	#region EducationsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the EducationsDataSource.SelectMethod property.
	/// </summary>
	public enum EducationsSelectMethod
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
		/// Represents the GetByEducationId method.
		/// </summary>
		GetByEducationId,
		/// <summary>
		/// Represents the GetByLastModifiedBy method.
		/// </summary>
		GetByLastModifiedBy,
		/// <summary>
		/// Represents the GetBySiteId method.
		/// </summary>
		GetBySiteId
	}
	
	#endregion EducationsSelectMethod

	#region EducationsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Educations"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EducationsFilter : SqlFilter<EducationsColumn>
	{
	}
	
	#endregion EducationsFilter

	#region EducationsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Educations"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EducationsExpressionBuilder : SqlExpressionBuilder<EducationsColumn>
	{
	}
	
	#endregion EducationsExpressionBuilder	

	#region EducationsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;EducationsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Educations"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EducationsProperty : ChildEntityProperty<EducationsChildEntityTypes>
	{
	}
	
	#endregion EducationsProperty
}

