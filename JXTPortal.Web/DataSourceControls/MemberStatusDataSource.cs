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
	/// Represents the DataRepository.MemberStatusProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(MemberStatusDataSourceDesigner))]
	public class MemberStatusDataSource : ProviderDataSource<MemberStatus, MemberStatusKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberStatusDataSource class.
		/// </summary>
		public MemberStatusDataSource() : base(new MemberStatusService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the MemberStatusDataSourceView used by the MemberStatusDataSource.
		/// </summary>
		protected MemberStatusDataSourceView MemberStatusView
		{
			get { return ( View as MemberStatusDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the MemberStatusDataSource control invokes to retrieve data.
		/// </summary>
		public MemberStatusSelectMethod SelectMethod
		{
			get
			{
				MemberStatusSelectMethod selectMethod = MemberStatusSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (MemberStatusSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the MemberStatusDataSourceView class that is to be
		/// used by the MemberStatusDataSource.
		/// </summary>
		/// <returns>An instance of the MemberStatusDataSourceView class.</returns>
		protected override BaseDataSourceView<MemberStatus, MemberStatusKey> GetNewDataSourceView()
		{
			return new MemberStatusDataSourceView(this, DefaultViewName);
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
	/// Supports the MemberStatusDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class MemberStatusDataSourceView : ProviderDataSourceView<MemberStatus, MemberStatusKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberStatusDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the MemberStatusDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public MemberStatusDataSourceView(MemberStatusDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal MemberStatusDataSource MemberStatusOwner
		{
			get { return Owner as MemberStatusDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal MemberStatusSelectMethod SelectMethod
		{
			get { return MemberStatusOwner.SelectMethod; }
			set { MemberStatusOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal MemberStatusService MemberStatusProvider
		{
			get { return Provider as MemberStatusService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<MemberStatus> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<MemberStatus> results = null;
			MemberStatus item;
			count = 0;
			
			System.Int32 _memberStatusId;
			System.Int32 _lastModifiedBy;
			System.Int32? _siteId_nullable;

			switch ( SelectMethod )
			{
				case MemberStatusSelectMethod.Get:
					MemberStatusKey entityKey  = new MemberStatusKey();
					entityKey.Load(values);
					item = MemberStatusProvider.Get(entityKey);
					results = new TList<MemberStatus>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case MemberStatusSelectMethod.GetAll:
                    results = MemberStatusProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case MemberStatusSelectMethod.GetPaged:
					results = MemberStatusProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case MemberStatusSelectMethod.Find:
					if ( FilterParameters != null )
						results = MemberStatusProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = MemberStatusProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case MemberStatusSelectMethod.GetByMemberStatusId:
					_memberStatusId = ( values["MemberStatusId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["MemberStatusId"], typeof(System.Int32)) : (int)0;
					item = MemberStatusProvider.GetByMemberStatusId(_memberStatusId);
					results = new TList<MemberStatus>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case MemberStatusSelectMethod.GetByLastModifiedBy:
					_lastModifiedBy = ( values["LastModifiedBy"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["LastModifiedBy"], typeof(System.Int32)) : (int)0;
					results = MemberStatusProvider.GetByLastModifiedBy(_lastModifiedBy, this.StartIndex, this.PageSize, out count);
					break;
				case MemberStatusSelectMethod.GetBySiteId:
					_siteId_nullable = (System.Int32?) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32?));
					results = MemberStatusProvider.GetBySiteId(_siteId_nullable, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == MemberStatusSelectMethod.Get || SelectMethod == MemberStatusSelectMethod.GetByMemberStatusId )
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
				MemberStatus entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					MemberStatusProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<MemberStatus> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			MemberStatusProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region MemberStatusDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the MemberStatusDataSource class.
	/// </summary>
	public class MemberStatusDataSourceDesigner : ProviderDataSourceDesigner<MemberStatus, MemberStatusKey>
	{
		/// <summary>
		/// Initializes a new instance of the MemberStatusDataSourceDesigner class.
		/// </summary>
		public MemberStatusDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public MemberStatusSelectMethod SelectMethod
		{
			get { return ((MemberStatusDataSource) DataSource).SelectMethod; }
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
				actions.Add(new MemberStatusDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region MemberStatusDataSourceActionList

	/// <summary>
	/// Supports the MemberStatusDataSourceDesigner class.
	/// </summary>
	internal class MemberStatusDataSourceActionList : DesignerActionList
	{
		private MemberStatusDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the MemberStatusDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public MemberStatusDataSourceActionList(MemberStatusDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public MemberStatusSelectMethod SelectMethod
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

	#endregion MemberStatusDataSourceActionList
	
	#endregion MemberStatusDataSourceDesigner
	
	#region MemberStatusSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the MemberStatusDataSource.SelectMethod property.
	/// </summary>
	public enum MemberStatusSelectMethod
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
		/// Represents the GetByMemberStatusId method.
		/// </summary>
		GetByMemberStatusId,
		/// <summary>
		/// Represents the GetByLastModifiedBy method.
		/// </summary>
		GetByLastModifiedBy,
		/// <summary>
		/// Represents the GetBySiteId method.
		/// </summary>
		GetBySiteId
	}
	
	#endregion MemberStatusSelectMethod

	#region MemberStatusFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberStatusFilter : SqlFilter<MemberStatusColumn>
	{
	}
	
	#endregion MemberStatusFilter

	#region MemberStatusExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberStatusExpressionBuilder : SqlExpressionBuilder<MemberStatusColumn>
	{
	}
	
	#endregion MemberStatusExpressionBuilder	

	#region MemberStatusProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;MemberStatusChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="MemberStatus"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberStatusProperty : ChildEntityProperty<MemberStatusChildEntityTypes>
	{
	}
	
	#endregion MemberStatusProperty
}

