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
	/// Represents the DataRepository.MemberFileTypesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(MemberFileTypesDataSourceDesigner))]
	public class MemberFileTypesDataSource : ProviderDataSource<MemberFileTypes, MemberFileTypesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberFileTypesDataSource class.
		/// </summary>
		public MemberFileTypesDataSource() : base(new MemberFileTypesService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the MemberFileTypesDataSourceView used by the MemberFileTypesDataSource.
		/// </summary>
		protected MemberFileTypesDataSourceView MemberFileTypesView
		{
			get { return ( View as MemberFileTypesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the MemberFileTypesDataSource control invokes to retrieve data.
		/// </summary>
		public MemberFileTypesSelectMethod SelectMethod
		{
			get
			{
				MemberFileTypesSelectMethod selectMethod = MemberFileTypesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (MemberFileTypesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the MemberFileTypesDataSourceView class that is to be
		/// used by the MemberFileTypesDataSource.
		/// </summary>
		/// <returns>An instance of the MemberFileTypesDataSourceView class.</returns>
		protected override BaseDataSourceView<MemberFileTypes, MemberFileTypesKey> GetNewDataSourceView()
		{
			return new MemberFileTypesDataSourceView(this, DefaultViewName);
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
	/// Supports the MemberFileTypesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class MemberFileTypesDataSourceView : ProviderDataSourceView<MemberFileTypes, MemberFileTypesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberFileTypesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the MemberFileTypesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public MemberFileTypesDataSourceView(MemberFileTypesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal MemberFileTypesDataSource MemberFileTypesOwner
		{
			get { return Owner as MemberFileTypesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal MemberFileTypesSelectMethod SelectMethod
		{
			get { return MemberFileTypesOwner.SelectMethod; }
			set { MemberFileTypesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal MemberFileTypesService MemberFileTypesProvider
		{
			get { return Provider as MemberFileTypesService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<MemberFileTypes> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<MemberFileTypes> results = null;
			MemberFileTypes item;
			count = 0;
			
			System.Int32 _memberFileTypeId;

			switch ( SelectMethod )
			{
				case MemberFileTypesSelectMethod.Get:
					MemberFileTypesKey entityKey  = new MemberFileTypesKey();
					entityKey.Load(values);
					item = MemberFileTypesProvider.Get(entityKey);
					results = new TList<MemberFileTypes>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case MemberFileTypesSelectMethod.GetAll:
                    results = MemberFileTypesProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case MemberFileTypesSelectMethod.GetPaged:
					results = MemberFileTypesProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case MemberFileTypesSelectMethod.Find:
					if ( FilterParameters != null )
						results = MemberFileTypesProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = MemberFileTypesProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case MemberFileTypesSelectMethod.GetByMemberFileTypeId:
					_memberFileTypeId = ( values["MemberFileTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["MemberFileTypeId"], typeof(System.Int32)) : (int)0;
					item = MemberFileTypesProvider.GetByMemberFileTypeId(_memberFileTypeId);
					results = new TList<MemberFileTypes>();
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
			if ( SelectMethod == MemberFileTypesSelectMethod.Get || SelectMethod == MemberFileTypesSelectMethod.GetByMemberFileTypeId )
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
				MemberFileTypes entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					MemberFileTypesProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<MemberFileTypes> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			MemberFileTypesProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region MemberFileTypesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the MemberFileTypesDataSource class.
	/// </summary>
	public class MemberFileTypesDataSourceDesigner : ProviderDataSourceDesigner<MemberFileTypes, MemberFileTypesKey>
	{
		/// <summary>
		/// Initializes a new instance of the MemberFileTypesDataSourceDesigner class.
		/// </summary>
		public MemberFileTypesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public MemberFileTypesSelectMethod SelectMethod
		{
			get { return ((MemberFileTypesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new MemberFileTypesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region MemberFileTypesDataSourceActionList

	/// <summary>
	/// Supports the MemberFileTypesDataSourceDesigner class.
	/// </summary>
	internal class MemberFileTypesDataSourceActionList : DesignerActionList
	{
		private MemberFileTypesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the MemberFileTypesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public MemberFileTypesDataSourceActionList(MemberFileTypesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public MemberFileTypesSelectMethod SelectMethod
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

	#endregion MemberFileTypesDataSourceActionList
	
	#endregion MemberFileTypesDataSourceDesigner
	
	#region MemberFileTypesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the MemberFileTypesDataSource.SelectMethod property.
	/// </summary>
	public enum MemberFileTypesSelectMethod
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
		/// Represents the GetByMemberFileTypeId method.
		/// </summary>
		GetByMemberFileTypeId
	}
	
	#endregion MemberFileTypesSelectMethod

	#region MemberFileTypesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberFileTypes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberFileTypesFilter : SqlFilter<MemberFileTypesColumn>
	{
	}
	
	#endregion MemberFileTypesFilter

	#region MemberFileTypesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberFileTypes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberFileTypesExpressionBuilder : SqlExpressionBuilder<MemberFileTypesColumn>
	{
	}
	
	#endregion MemberFileTypesExpressionBuilder	

	#region MemberFileTypesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;MemberFileTypesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="MemberFileTypes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberFileTypesProperty : ChildEntityProperty<MemberFileTypesChildEntityTypes>
	{
	}
	
	#endregion MemberFileTypesProperty
}

