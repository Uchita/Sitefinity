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
	/// Represents the DataRepository.MemberQualificationProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(MemberQualificationDataSourceDesigner))]
	public class MemberQualificationDataSource : ProviderDataSource<MemberQualification, MemberQualificationKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberQualificationDataSource class.
		/// </summary>
		public MemberQualificationDataSource() : base(new MemberQualificationService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the MemberQualificationDataSourceView used by the MemberQualificationDataSource.
		/// </summary>
		protected MemberQualificationDataSourceView MemberQualificationView
		{
			get { return ( View as MemberQualificationDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the MemberQualificationDataSource control invokes to retrieve data.
		/// </summary>
		public MemberQualificationSelectMethod SelectMethod
		{
			get
			{
				MemberQualificationSelectMethod selectMethod = MemberQualificationSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (MemberQualificationSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the MemberQualificationDataSourceView class that is to be
		/// used by the MemberQualificationDataSource.
		/// </summary>
		/// <returns>An instance of the MemberQualificationDataSourceView class.</returns>
		protected override BaseDataSourceView<MemberQualification, MemberQualificationKey> GetNewDataSourceView()
		{
			return new MemberQualificationDataSourceView(this, DefaultViewName);
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
	/// Supports the MemberQualificationDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class MemberQualificationDataSourceView : ProviderDataSourceView<MemberQualification, MemberQualificationKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberQualificationDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the MemberQualificationDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public MemberQualificationDataSourceView(MemberQualificationDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal MemberQualificationDataSource MemberQualificationOwner
		{
			get { return Owner as MemberQualificationDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal MemberQualificationSelectMethod SelectMethod
		{
			get { return MemberQualificationOwner.SelectMethod; }
			set { MemberQualificationOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal MemberQualificationService MemberQualificationProvider
		{
			get { return Provider as MemberQualificationService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<MemberQualification> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<MemberQualification> results = null;
			MemberQualification item;
			count = 0;
			
			System.Int32 _memberQualificationId;
			System.Int32 _memberId;

			switch ( SelectMethod )
			{
				case MemberQualificationSelectMethod.Get:
					MemberQualificationKey entityKey  = new MemberQualificationKey();
					entityKey.Load(values);
					item = MemberQualificationProvider.Get(entityKey);
					results = new TList<MemberQualification>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case MemberQualificationSelectMethod.GetAll:
                    results = MemberQualificationProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case MemberQualificationSelectMethod.GetPaged:
					results = MemberQualificationProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case MemberQualificationSelectMethod.Find:
					if ( FilterParameters != null )
						results = MemberQualificationProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = MemberQualificationProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case MemberQualificationSelectMethod.GetByMemberQualificationId:
					_memberQualificationId = ( values["MemberQualificationId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["MemberQualificationId"], typeof(System.Int32)) : (int)0;
					item = MemberQualificationProvider.GetByMemberQualificationId(_memberQualificationId);
					results = new TList<MemberQualification>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case MemberQualificationSelectMethod.GetByMemberId:
					_memberId = ( values["MemberId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["MemberId"], typeof(System.Int32)) : (int)0;
					results = MemberQualificationProvider.GetByMemberId(_memberId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == MemberQualificationSelectMethod.Get || SelectMethod == MemberQualificationSelectMethod.GetByMemberQualificationId )
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
				MemberQualification entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					MemberQualificationProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<MemberQualification> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			MemberQualificationProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region MemberQualificationDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the MemberQualificationDataSource class.
	/// </summary>
	public class MemberQualificationDataSourceDesigner : ProviderDataSourceDesigner<MemberQualification, MemberQualificationKey>
	{
		/// <summary>
		/// Initializes a new instance of the MemberQualificationDataSourceDesigner class.
		/// </summary>
		public MemberQualificationDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public MemberQualificationSelectMethod SelectMethod
		{
			get { return ((MemberQualificationDataSource) DataSource).SelectMethod; }
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
				actions.Add(new MemberQualificationDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region MemberQualificationDataSourceActionList

	/// <summary>
	/// Supports the MemberQualificationDataSourceDesigner class.
	/// </summary>
	internal class MemberQualificationDataSourceActionList : DesignerActionList
	{
		private MemberQualificationDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the MemberQualificationDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public MemberQualificationDataSourceActionList(MemberQualificationDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public MemberQualificationSelectMethod SelectMethod
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

	#endregion MemberQualificationDataSourceActionList
	
	#endregion MemberQualificationDataSourceDesigner
	
	#region MemberQualificationSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the MemberQualificationDataSource.SelectMethod property.
	/// </summary>
	public enum MemberQualificationSelectMethod
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
		/// Represents the GetByMemberQualificationId method.
		/// </summary>
		GetByMemberQualificationId,
		/// <summary>
		/// Represents the GetByMemberId method.
		/// </summary>
		GetByMemberId
	}
	
	#endregion MemberQualificationSelectMethod

	#region MemberQualificationFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberQualification"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberQualificationFilter : SqlFilter<MemberQualificationColumn>
	{
	}
	
	#endregion MemberQualificationFilter

	#region MemberQualificationExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberQualification"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberQualificationExpressionBuilder : SqlExpressionBuilder<MemberQualificationColumn>
	{
	}
	
	#endregion MemberQualificationExpressionBuilder	

	#region MemberQualificationProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;MemberQualificationChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="MemberQualification"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberQualificationProperty : ChildEntityProperty<MemberQualificationChildEntityTypes>
	{
	}
	
	#endregion MemberQualificationProperty
}

