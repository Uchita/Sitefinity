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
	/// Represents the DataRepository.MemberMembershipsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(MemberMembershipsDataSourceDesigner))]
	public class MemberMembershipsDataSource : ProviderDataSource<MemberMemberships, MemberMembershipsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberMembershipsDataSource class.
		/// </summary>
		public MemberMembershipsDataSource() : base(new MemberMembershipsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the MemberMembershipsDataSourceView used by the MemberMembershipsDataSource.
		/// </summary>
		protected MemberMembershipsDataSourceView MemberMembershipsView
		{
			get { return ( View as MemberMembershipsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the MemberMembershipsDataSource control invokes to retrieve data.
		/// </summary>
		public MemberMembershipsSelectMethod SelectMethod
		{
			get
			{
				MemberMembershipsSelectMethod selectMethod = MemberMembershipsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (MemberMembershipsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the MemberMembershipsDataSourceView class that is to be
		/// used by the MemberMembershipsDataSource.
		/// </summary>
		/// <returns>An instance of the MemberMembershipsDataSourceView class.</returns>
		protected override BaseDataSourceView<MemberMemberships, MemberMembershipsKey> GetNewDataSourceView()
		{
			return new MemberMembershipsDataSourceView(this, DefaultViewName);
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
	/// Supports the MemberMembershipsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class MemberMembershipsDataSourceView : ProviderDataSourceView<MemberMemberships, MemberMembershipsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberMembershipsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the MemberMembershipsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public MemberMembershipsDataSourceView(MemberMembershipsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal MemberMembershipsDataSource MemberMembershipsOwner
		{
			get { return Owner as MemberMembershipsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal MemberMembershipsSelectMethod SelectMethod
		{
			get { return MemberMembershipsOwner.SelectMethod; }
			set { MemberMembershipsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal MemberMembershipsService MemberMembershipsProvider
		{
			get { return Provider as MemberMembershipsService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<MemberMemberships> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<MemberMemberships> results = null;
			MemberMemberships item;
			count = 0;
			
			System.Int32 _memberMembershipsId;
			System.Int32 _lastModifiedBy;
			System.Int32? _siteId_nullable;

			switch ( SelectMethod )
			{
				case MemberMembershipsSelectMethod.Get:
					MemberMembershipsKey entityKey  = new MemberMembershipsKey();
					entityKey.Load(values);
					item = MemberMembershipsProvider.Get(entityKey);
					results = new TList<MemberMemberships>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case MemberMembershipsSelectMethod.GetAll:
                    results = MemberMembershipsProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case MemberMembershipsSelectMethod.GetPaged:
					results = MemberMembershipsProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case MemberMembershipsSelectMethod.Find:
					if ( FilterParameters != null )
						results = MemberMembershipsProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = MemberMembershipsProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case MemberMembershipsSelectMethod.GetByMemberMembershipsId:
					_memberMembershipsId = ( values["MemberMembershipsId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["MemberMembershipsId"], typeof(System.Int32)) : (int)0;
					item = MemberMembershipsProvider.GetByMemberMembershipsId(_memberMembershipsId);
					results = new TList<MemberMemberships>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case MemberMembershipsSelectMethod.GetByLastModifiedBy:
					_lastModifiedBy = ( values["LastModifiedBy"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["LastModifiedBy"], typeof(System.Int32)) : (int)0;
					results = MemberMembershipsProvider.GetByLastModifiedBy(_lastModifiedBy, this.StartIndex, this.PageSize, out count);
					break;
				case MemberMembershipsSelectMethod.GetBySiteId:
					_siteId_nullable = (System.Int32?) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32?));
					results = MemberMembershipsProvider.GetBySiteId(_siteId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == MemberMembershipsSelectMethod.Get || SelectMethod == MemberMembershipsSelectMethod.GetByMemberMembershipsId )
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
				MemberMemberships entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					MemberMembershipsProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<MemberMemberships> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			MemberMembershipsProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region MemberMembershipsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the MemberMembershipsDataSource class.
	/// </summary>
	public class MemberMembershipsDataSourceDesigner : ProviderDataSourceDesigner<MemberMemberships, MemberMembershipsKey>
	{
		/// <summary>
		/// Initializes a new instance of the MemberMembershipsDataSourceDesigner class.
		/// </summary>
		public MemberMembershipsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public MemberMembershipsSelectMethod SelectMethod
		{
			get { return ((MemberMembershipsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new MemberMembershipsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region MemberMembershipsDataSourceActionList

	/// <summary>
	/// Supports the MemberMembershipsDataSourceDesigner class.
	/// </summary>
	internal class MemberMembershipsDataSourceActionList : DesignerActionList
	{
		private MemberMembershipsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the MemberMembershipsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public MemberMembershipsDataSourceActionList(MemberMembershipsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public MemberMembershipsSelectMethod SelectMethod
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

	#endregion MemberMembershipsDataSourceActionList
	
	#endregion MemberMembershipsDataSourceDesigner
	
	#region MemberMembershipsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the MemberMembershipsDataSource.SelectMethod property.
	/// </summary>
	public enum MemberMembershipsSelectMethod
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
		/// Represents the GetByMemberMembershipsId method.
		/// </summary>
		GetByMemberMembershipsId,
		/// <summary>
		/// Represents the GetByLastModifiedBy method.
		/// </summary>
		GetByLastModifiedBy,
		/// <summary>
		/// Represents the GetBySiteId method.
		/// </summary>
		GetBySiteId
	}
	
	#endregion MemberMembershipsSelectMethod

	#region MemberMembershipsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberMemberships"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberMembershipsFilter : SqlFilter<MemberMembershipsColumn>
	{
	}
	
	#endregion MemberMembershipsFilter

	#region MemberMembershipsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberMemberships"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberMembershipsExpressionBuilder : SqlExpressionBuilder<MemberMembershipsColumn>
	{
	}
	
	#endregion MemberMembershipsExpressionBuilder	

	#region MemberMembershipsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;MemberMembershipsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="MemberMemberships"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberMembershipsProperty : ChildEntityProperty<MemberMembershipsChildEntityTypes>
	{
	}
	
	#endregion MemberMembershipsProperty
}

