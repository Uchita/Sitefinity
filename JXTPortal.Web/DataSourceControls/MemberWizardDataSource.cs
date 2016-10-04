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
	/// Represents the DataRepository.MemberWizardProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(MemberWizardDataSourceDesigner))]
	public class MemberWizardDataSource : ProviderDataSource<MemberWizard, MemberWizardKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberWizardDataSource class.
		/// </summary>
		public MemberWizardDataSource() : base(new MemberWizardService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the MemberWizardDataSourceView used by the MemberWizardDataSource.
		/// </summary>
		protected MemberWizardDataSourceView MemberWizardView
		{
			get { return ( View as MemberWizardDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the MemberWizardDataSource control invokes to retrieve data.
		/// </summary>
		public MemberWizardSelectMethod SelectMethod
		{
			get
			{
				MemberWizardSelectMethod selectMethod = MemberWizardSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (MemberWizardSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the MemberWizardDataSourceView class that is to be
		/// used by the MemberWizardDataSource.
		/// </summary>
		/// <returns>An instance of the MemberWizardDataSourceView class.</returns>
		protected override BaseDataSourceView<MemberWizard, MemberWizardKey> GetNewDataSourceView()
		{
			return new MemberWizardDataSourceView(this, DefaultViewName);
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
	/// Supports the MemberWizardDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class MemberWizardDataSourceView : ProviderDataSourceView<MemberWizard, MemberWizardKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberWizardDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the MemberWizardDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public MemberWizardDataSourceView(MemberWizardDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal MemberWizardDataSource MemberWizardOwner
		{
			get { return Owner as MemberWizardDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal MemberWizardSelectMethod SelectMethod
		{
			get { return MemberWizardOwner.SelectMethod; }
			set { MemberWizardOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal MemberWizardService MemberWizardProvider
		{
			get { return Provider as MemberWizardService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<MemberWizard> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<MemberWizard> results = null;
			MemberWizard item;
			count = 0;
			
			System.Int32 _memberWizardId;
			System.Int32 _lastModifiedBy;
			System.Int32? _siteId_nullable;

			switch ( SelectMethod )
			{
				case MemberWizardSelectMethod.Get:
					MemberWizardKey entityKey  = new MemberWizardKey();
					entityKey.Load(values);
					item = MemberWizardProvider.Get(entityKey);
					results = new TList<MemberWizard>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case MemberWizardSelectMethod.GetAll:
                    results = MemberWizardProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case MemberWizardSelectMethod.GetPaged:
					results = MemberWizardProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case MemberWizardSelectMethod.Find:
					if ( FilterParameters != null )
						results = MemberWizardProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = MemberWizardProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case MemberWizardSelectMethod.GetByMemberWizardId:
					_memberWizardId = ( values["MemberWizardId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["MemberWizardId"], typeof(System.Int32)) : (int)0;
					item = MemberWizardProvider.GetByMemberWizardId(_memberWizardId);
					results = new TList<MemberWizard>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case MemberWizardSelectMethod.GetByLastModifiedBy:
					_lastModifiedBy = ( values["LastModifiedBy"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["LastModifiedBy"], typeof(System.Int32)) : (int)0;
					results = MemberWizardProvider.GetByLastModifiedBy(_lastModifiedBy, this.StartIndex, this.PageSize, out count);
					break;
				case MemberWizardSelectMethod.GetBySiteId:
					_siteId_nullable = (System.Int32?) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32?));
					results = MemberWizardProvider.GetBySiteId(_siteId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == MemberWizardSelectMethod.Get || SelectMethod == MemberWizardSelectMethod.GetByMemberWizardId )
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
				MemberWizard entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					MemberWizardProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<MemberWizard> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			MemberWizardProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region MemberWizardDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the MemberWizardDataSource class.
	/// </summary>
	public class MemberWizardDataSourceDesigner : ProviderDataSourceDesigner<MemberWizard, MemberWizardKey>
	{
		/// <summary>
		/// Initializes a new instance of the MemberWizardDataSourceDesigner class.
		/// </summary>
		public MemberWizardDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public MemberWizardSelectMethod SelectMethod
		{
			get { return ((MemberWizardDataSource) DataSource).SelectMethod; }
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
				actions.Add(new MemberWizardDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region MemberWizardDataSourceActionList

	/// <summary>
	/// Supports the MemberWizardDataSourceDesigner class.
	/// </summary>
	internal class MemberWizardDataSourceActionList : DesignerActionList
	{
		private MemberWizardDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the MemberWizardDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public MemberWizardDataSourceActionList(MemberWizardDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public MemberWizardSelectMethod SelectMethod
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

	#endregion MemberWizardDataSourceActionList
	
	#endregion MemberWizardDataSourceDesigner
	
	#region MemberWizardSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the MemberWizardDataSource.SelectMethod property.
	/// </summary>
	public enum MemberWizardSelectMethod
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
		/// Represents the GetByMemberWizardId method.
		/// </summary>
		GetByMemberWizardId,
		/// <summary>
		/// Represents the GetByLastModifiedBy method.
		/// </summary>
		GetByLastModifiedBy,
		/// <summary>
		/// Represents the GetBySiteId method.
		/// </summary>
		GetBySiteId
	}
	
	#endregion MemberWizardSelectMethod

	#region MemberWizardFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberWizard"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberWizardFilter : SqlFilter<MemberWizardColumn>
	{
	}
	
	#endregion MemberWizardFilter

	#region MemberWizardExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberWizard"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberWizardExpressionBuilder : SqlExpressionBuilder<MemberWizardColumn>
	{
	}
	
	#endregion MemberWizardExpressionBuilder	

	#region MemberWizardProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;MemberWizardChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="MemberWizard"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberWizardProperty : ChildEntityProperty<MemberWizardChildEntityTypes>
	{
	}
	
	#endregion MemberWizardProperty
}

