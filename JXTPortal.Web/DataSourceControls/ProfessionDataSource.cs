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
	/// Represents the DataRepository.ProfessionProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(ProfessionDataSourceDesigner))]
	public class ProfessionDataSource : ProviderDataSource<Profession, ProfessionKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProfessionDataSource class.
		/// </summary>
		public ProfessionDataSource() : base(new ProfessionService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the ProfessionDataSourceView used by the ProfessionDataSource.
		/// </summary>
		protected ProfessionDataSourceView ProfessionView
		{
			get { return ( View as ProfessionDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the ProfessionDataSource control invokes to retrieve data.
		/// </summary>
		public ProfessionSelectMethod SelectMethod
		{
			get
			{
				ProfessionSelectMethod selectMethod = ProfessionSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (ProfessionSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the ProfessionDataSourceView class that is to be
		/// used by the ProfessionDataSource.
		/// </summary>
		/// <returns>An instance of the ProfessionDataSourceView class.</returns>
		protected override BaseDataSourceView<Profession, ProfessionKey> GetNewDataSourceView()
		{
			return new ProfessionDataSourceView(this, DefaultViewName);
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
	/// Supports the ProfessionDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class ProfessionDataSourceView : ProviderDataSourceView<Profession, ProfessionKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ProfessionDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the ProfessionDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public ProfessionDataSourceView(ProfessionDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal ProfessionDataSource ProfessionOwner
		{
			get { return Owner as ProfessionDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal ProfessionSelectMethod SelectMethod
		{
			get { return ProfessionOwner.SelectMethod; }
			set { ProfessionOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal ProfessionService ProfessionProvider
		{
			get { return Provider as ProfessionService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Profession> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Profession> results = null;
			Profession item;
			count = 0;
			
			System.Int32 _professionId;
			System.Int32? _referredSiteId_nullable;

			switch ( SelectMethod )
			{
				case ProfessionSelectMethod.Get:
					ProfessionKey entityKey  = new ProfessionKey();
					entityKey.Load(values);
					item = ProfessionProvider.Get(entityKey);
					results = new TList<Profession>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case ProfessionSelectMethod.GetAll:
                    results = ProfessionProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case ProfessionSelectMethod.GetPaged:
					results = ProfessionProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case ProfessionSelectMethod.Find:
					if ( FilterParameters != null )
						results = ProfessionProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = ProfessionProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case ProfessionSelectMethod.GetByProfessionId:
					_professionId = ( values["ProfessionId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["ProfessionId"], typeof(System.Int32)) : (int)0;
					item = ProfessionProvider.GetByProfessionId(_professionId);
					results = new TList<Profession>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case ProfessionSelectMethod.GetByReferredSiteId:
					_referredSiteId_nullable = (System.Int32?) EntityUtil.ChangeType(values["ReferredSiteId"], typeof(System.Int32?));
					results = ProfessionProvider.GetByReferredSiteId(_referredSiteId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == ProfessionSelectMethod.Get || SelectMethod == ProfessionSelectMethod.GetByProfessionId )
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
				Profession entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					ProfessionProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Profession> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			ProfessionProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region ProfessionDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the ProfessionDataSource class.
	/// </summary>
	public class ProfessionDataSourceDesigner : ProviderDataSourceDesigner<Profession, ProfessionKey>
	{
		/// <summary>
		/// Initializes a new instance of the ProfessionDataSourceDesigner class.
		/// </summary>
		public ProfessionDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProfessionSelectMethod SelectMethod
		{
			get { return ((ProfessionDataSource) DataSource).SelectMethod; }
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
				actions.Add(new ProfessionDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region ProfessionDataSourceActionList

	/// <summary>
	/// Supports the ProfessionDataSourceDesigner class.
	/// </summary>
	internal class ProfessionDataSourceActionList : DesignerActionList
	{
		private ProfessionDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the ProfessionDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public ProfessionDataSourceActionList(ProfessionDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public ProfessionSelectMethod SelectMethod
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

	#endregion ProfessionDataSourceActionList
	
	#endregion ProfessionDataSourceDesigner
	
	#region ProfessionSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the ProfessionDataSource.SelectMethod property.
	/// </summary>
	public enum ProfessionSelectMethod
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
		/// Represents the GetByProfessionId method.
		/// </summary>
		GetByProfessionId,
		/// <summary>
		/// Represents the GetByReferredSiteId method.
		/// </summary>
		GetByReferredSiteId
	}
	
	#endregion ProfessionSelectMethod

	#region ProfessionFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Profession"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProfessionFilter : SqlFilter<ProfessionColumn>
	{
	}
	
	#endregion ProfessionFilter

	#region ProfessionExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Profession"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProfessionExpressionBuilder : SqlExpressionBuilder<ProfessionColumn>
	{
	}
	
	#endregion ProfessionExpressionBuilder	

	#region ProfessionProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;ProfessionChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Profession"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ProfessionProperty : ChildEntityProperty<ProfessionChildEntityTypes>
	{
	}
	
	#endregion ProfessionProperty
}

