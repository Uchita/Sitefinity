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
	/// Represents the DataRepository.MemberPositionsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(MemberPositionsDataSourceDesigner))]
	public class MemberPositionsDataSource : ProviderDataSource<MemberPositions, MemberPositionsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberPositionsDataSource class.
		/// </summary>
		public MemberPositionsDataSource() : base(new MemberPositionsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the MemberPositionsDataSourceView used by the MemberPositionsDataSource.
		/// </summary>
		protected MemberPositionsDataSourceView MemberPositionsView
		{
			get { return ( View as MemberPositionsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the MemberPositionsDataSource control invokes to retrieve data.
		/// </summary>
		public MemberPositionsSelectMethod SelectMethod
		{
			get
			{
				MemberPositionsSelectMethod selectMethod = MemberPositionsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (MemberPositionsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the MemberPositionsDataSourceView class that is to be
		/// used by the MemberPositionsDataSource.
		/// </summary>
		/// <returns>An instance of the MemberPositionsDataSourceView class.</returns>
		protected override BaseDataSourceView<MemberPositions, MemberPositionsKey> GetNewDataSourceView()
		{
			return new MemberPositionsDataSourceView(this, DefaultViewName);
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
	/// Supports the MemberPositionsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class MemberPositionsDataSourceView : ProviderDataSourceView<MemberPositions, MemberPositionsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberPositionsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the MemberPositionsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public MemberPositionsDataSourceView(MemberPositionsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal MemberPositionsDataSource MemberPositionsOwner
		{
			get { return Owner as MemberPositionsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal MemberPositionsSelectMethod SelectMethod
		{
			get { return MemberPositionsOwner.SelectMethod; }
			set { MemberPositionsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal MemberPositionsService MemberPositionsProvider
		{
			get { return Provider as MemberPositionsService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<MemberPositions> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<MemberPositions> results = null;
			MemberPositions item;
			count = 0;
			
			System.Int32 _memberPositionId;
			System.Int32 _memberId;

			switch ( SelectMethod )
			{
				case MemberPositionsSelectMethod.Get:
					MemberPositionsKey entityKey  = new MemberPositionsKey();
					entityKey.Load(values);
					item = MemberPositionsProvider.Get(entityKey);
					results = new TList<MemberPositions>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case MemberPositionsSelectMethod.GetAll:
                    results = MemberPositionsProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case MemberPositionsSelectMethod.GetPaged:
					results = MemberPositionsProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case MemberPositionsSelectMethod.Find:
					if ( FilterParameters != null )
						results = MemberPositionsProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = MemberPositionsProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case MemberPositionsSelectMethod.GetByMemberPositionId:
					_memberPositionId = ( values["MemberPositionId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["MemberPositionId"], typeof(System.Int32)) : (int)0;
					item = MemberPositionsProvider.GetByMemberPositionId(_memberPositionId);
					results = new TList<MemberPositions>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case MemberPositionsSelectMethod.GetByMemberId:
					_memberId = ( values["MemberId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["MemberId"], typeof(System.Int32)) : (int)0;
					results = MemberPositionsProvider.GetByMemberId(_memberId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == MemberPositionsSelectMethod.Get || SelectMethod == MemberPositionsSelectMethod.GetByMemberPositionId )
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
				MemberPositions entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					MemberPositionsProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<MemberPositions> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			MemberPositionsProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region MemberPositionsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the MemberPositionsDataSource class.
	/// </summary>
	public class MemberPositionsDataSourceDesigner : ProviderDataSourceDesigner<MemberPositions, MemberPositionsKey>
	{
		/// <summary>
		/// Initializes a new instance of the MemberPositionsDataSourceDesigner class.
		/// </summary>
		public MemberPositionsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public MemberPositionsSelectMethod SelectMethod
		{
			get { return ((MemberPositionsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new MemberPositionsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region MemberPositionsDataSourceActionList

	/// <summary>
	/// Supports the MemberPositionsDataSourceDesigner class.
	/// </summary>
	internal class MemberPositionsDataSourceActionList : DesignerActionList
	{
		private MemberPositionsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the MemberPositionsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public MemberPositionsDataSourceActionList(MemberPositionsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public MemberPositionsSelectMethod SelectMethod
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

	#endregion MemberPositionsDataSourceActionList
	
	#endregion MemberPositionsDataSourceDesigner
	
	#region MemberPositionsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the MemberPositionsDataSource.SelectMethod property.
	/// </summary>
	public enum MemberPositionsSelectMethod
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
		/// Represents the GetByMemberPositionId method.
		/// </summary>
		GetByMemberPositionId,
		/// <summary>
		/// Represents the GetByMemberId method.
		/// </summary>
		GetByMemberId
	}
	
	#endregion MemberPositionsSelectMethod

	#region MemberPositionsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberPositions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberPositionsFilter : SqlFilter<MemberPositionsColumn>
	{
	}
	
	#endregion MemberPositionsFilter

	#region MemberPositionsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberPositions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberPositionsExpressionBuilder : SqlExpressionBuilder<MemberPositionsColumn>
	{
	}
	
	#endregion MemberPositionsExpressionBuilder	

	#region MemberPositionsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;MemberPositionsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="MemberPositions"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberPositionsProperty : ChildEntityProperty<MemberPositionsChildEntityTypes>
	{
	}
	
	#endregion MemberPositionsProperty
}

