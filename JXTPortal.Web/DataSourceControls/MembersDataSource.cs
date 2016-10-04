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
	/// Represents the DataRepository.MembersProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(MembersDataSourceDesigner))]
	public class MembersDataSource : ProviderDataSource<Members, MembersKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MembersDataSource class.
		/// </summary>
		public MembersDataSource() : base(new MembersService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the MembersDataSourceView used by the MembersDataSource.
		/// </summary>
		protected MembersDataSourceView MembersView
		{
			get { return ( View as MembersDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the MembersDataSource control invokes to retrieve data.
		/// </summary>
		public MembersSelectMethod SelectMethod
		{
			get
			{
				MembersSelectMethod selectMethod = MembersSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (MembersSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the MembersDataSourceView class that is to be
		/// used by the MembersDataSource.
		/// </summary>
		/// <returns>An instance of the MembersDataSourceView class.</returns>
		protected override BaseDataSourceView<Members, MembersKey> GetNewDataSourceView()
		{
			return new MembersDataSourceView(this, DefaultViewName);
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
	/// Supports the MembersDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class MembersDataSourceView : ProviderDataSourceView<Members, MembersKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MembersDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the MembersDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public MembersDataSourceView(MembersDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal MembersDataSource MembersOwner
		{
			get { return Owner as MembersDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal MembersSelectMethod SelectMethod
		{
			get { return MembersOwner.SelectMethod; }
			set { MembersOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal MembersService MembersProvider
		{
			get { return Provider as MembersService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Members> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Members> results = null;
			Members item;
			count = 0;
			
			System.Int32 _siteId;
			System.String _emailAddress_nullable;
			System.String _username_nullable;
			System.Int32 _memberId;
			System.Int32 _countryId;
			System.Int32? _educationId_nullable;
			System.Int32 _emailFormat;

			switch ( SelectMethod )
			{
				case MembersSelectMethod.Get:
					MembersKey entityKey  = new MembersKey();
					entityKey.Load(values);
					item = MembersProvider.Get(entityKey);
					results = new TList<Members>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case MembersSelectMethod.GetAll:
                    results = MembersProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case MembersSelectMethod.GetPaged:
					results = MembersProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case MembersSelectMethod.Find:
					if ( FilterParameters != null )
						results = MembersProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = MembersProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case MembersSelectMethod.GetByMemberId:
					_memberId = ( values["MemberId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["MemberId"], typeof(System.Int32)) : (int)0;
					item = MembersProvider.GetByMemberId(_memberId);
					results = new TList<Members>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case MembersSelectMethod.GetBySiteIdEmailAddress:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					_emailAddress_nullable = (System.String) EntityUtil.ChangeType(values["EmailAddress"], typeof(System.String));
					item = MembersProvider.GetBySiteIdEmailAddress(_siteId, _emailAddress_nullable);
					results = new TList<Members>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case MembersSelectMethod.GetBySiteIdUsername:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					_username_nullable = (System.String) EntityUtil.ChangeType(values["Username"], typeof(System.String));
					item = MembersProvider.GetBySiteIdUsername(_siteId, _username_nullable);
					results = new TList<Members>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				case MembersSelectMethod.GetByCountryId:
					_countryId = ( values["CountryId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["CountryId"], typeof(System.Int32)) : (int)0;
					results = MembersProvider.GetByCountryId(_countryId, this.StartIndex, this.PageSize, out count);
					break;
				case MembersSelectMethod.GetByEducationId:
					_educationId_nullable = (System.Int32?) EntityUtil.ChangeType(values["EducationId"], typeof(System.Int32?));
					results = MembersProvider.GetByEducationId(_educationId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				case MembersSelectMethod.GetByEmailFormat:
					_emailFormat = ( values["EmailFormat"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["EmailFormat"], typeof(System.Int32)) : (int)0;
					results = MembersProvider.GetByEmailFormat(_emailFormat, this.StartIndex, this.PageSize, out count);
					break;
				case MembersSelectMethod.GetBySiteId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					results = MembersProvider.GetBySiteId(_siteId, this.StartIndex, this.PageSize, out count);
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
			if ( SelectMethod == MembersSelectMethod.Get || SelectMethod == MembersSelectMethod.GetByMemberId )
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
				Members entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					MembersProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Members> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			MembersProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region MembersDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the MembersDataSource class.
	/// </summary>
	public class MembersDataSourceDesigner : ProviderDataSourceDesigner<Members, MembersKey>
	{
		/// <summary>
		/// Initializes a new instance of the MembersDataSourceDesigner class.
		/// </summary>
		public MembersDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public MembersSelectMethod SelectMethod
		{
			get { return ((MembersDataSource) DataSource).SelectMethod; }
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
				actions.Add(new MembersDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region MembersDataSourceActionList

	/// <summary>
	/// Supports the MembersDataSourceDesigner class.
	/// </summary>
	internal class MembersDataSourceActionList : DesignerActionList
	{
		private MembersDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the MembersDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public MembersDataSourceActionList(MembersDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public MembersSelectMethod SelectMethod
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

	#endregion MembersDataSourceActionList
	
	#endregion MembersDataSourceDesigner
	
	#region MembersSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the MembersDataSource.SelectMethod property.
	/// </summary>
	public enum MembersSelectMethod
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
		/// Represents the GetBySiteIdEmailAddress method.
		/// </summary>
		GetBySiteIdEmailAddress,
		/// <summary>
		/// Represents the GetBySiteIdUsername method.
		/// </summary>
		GetBySiteIdUsername,
		/// <summary>
		/// Represents the GetByMemberId method.
		/// </summary>
		GetByMemberId,
		/// <summary>
		/// Represents the GetByCountryId method.
		/// </summary>
		GetByCountryId,
		/// <summary>
		/// Represents the GetByEducationId method.
		/// </summary>
		GetByEducationId,
		/// <summary>
		/// Represents the GetByEmailFormat method.
		/// </summary>
		GetByEmailFormat,
		/// <summary>
		/// Represents the GetBySiteId method.
		/// </summary>
		GetBySiteId
	}
	
	#endregion MembersSelectMethod

	#region MembersFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Members"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MembersFilter : SqlFilter<MembersColumn>
	{
	}
	
	#endregion MembersFilter

	#region MembersExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Members"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MembersExpressionBuilder : SqlExpressionBuilder<MembersColumn>
	{
	}
	
	#endregion MembersExpressionBuilder	

	#region MembersProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;MembersChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Members"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MembersProperty : ChildEntityProperty<MembersChildEntityTypes>
	{
	}
	
	#endregion MembersProperty
}

