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
	/// Represents the DataRepository.MemberFilesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(MemberFilesDataSourceDesigner))]
	public class MemberFilesDataSource : ProviderDataSource<MemberFiles, MemberFilesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberFilesDataSource class.
		/// </summary>
		public MemberFilesDataSource() : base(new MemberFilesService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the MemberFilesDataSourceView used by the MemberFilesDataSource.
		/// </summary>
		protected MemberFilesDataSourceView MemberFilesView
		{
			get { return ( View as MemberFilesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the MemberFilesDataSource control invokes to retrieve data.
		/// </summary>
		public MemberFilesSelectMethod SelectMethod
		{
			get
			{
				MemberFilesSelectMethod selectMethod = MemberFilesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (MemberFilesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the MemberFilesDataSourceView class that is to be
		/// used by the MemberFilesDataSource.
		/// </summary>
		/// <returns>An instance of the MemberFilesDataSourceView class.</returns>
		protected override BaseDataSourceView<MemberFiles, MemberFilesKey> GetNewDataSourceView()
		{
			return new MemberFilesDataSourceView(this, DefaultViewName);
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
	/// Supports the MemberFilesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class MemberFilesDataSourceView : ProviderDataSourceView<MemberFiles, MemberFilesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the MemberFilesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the MemberFilesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public MemberFilesDataSourceView(MemberFilesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal MemberFilesDataSource MemberFilesOwner
		{
			get { return Owner as MemberFilesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal MemberFilesSelectMethod SelectMethod
		{
			get { return MemberFilesOwner.SelectMethod; }
			set { MemberFilesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal MemberFilesService MemberFilesProvider
		{
			get { return Provider as MemberFilesService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<MemberFiles> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<MemberFiles> results = null;
			MemberFiles item;
			count = 0;
			
			System.Int32 _memberId;
			System.String _memberFileName;
			System.Int32 _memberFileId;
			System.Int32 _memberFileTypeId;
			System.Int32? sp406_MemberFileId;
			System.Int32? sp408_MemberId;
			System.Boolean? sp404_SearchUsingOr;
			System.Int32? sp404_MemberFileId;
			System.Int32? sp404_MemberId;
			System.Int32? sp404_MemberFileTypeId;
			System.String sp404_MemberFileName;
			System.String sp404_MemberFileSystemName;
			System.Byte[] sp404_MemberFileContent;
			System.String sp404_MemberFileTitle;
			System.DateTime? sp404_LastModifiedDate;
			System.Int32? sp404_DocumentTypeId;
			System.Int32? sp409_MemberId;
			System.String sp409_MemberFileName;
			System.Int32? sp407_MemberFileTypeId;

			switch ( SelectMethod )
			{
				case MemberFilesSelectMethod.Get:
					MemberFilesKey entityKey  = new MemberFilesKey();
					entityKey.Load(values);
					item = MemberFilesProvider.Get(entityKey);
					results = new TList<MemberFiles>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case MemberFilesSelectMethod.GetAll:
                    results = MemberFilesProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case MemberFilesSelectMethod.GetPaged:
					results = MemberFilesProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case MemberFilesSelectMethod.Find:
					if ( FilterParameters != null )
						results = MemberFilesProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = MemberFilesProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case MemberFilesSelectMethod.GetByMemberFileId:
					_memberFileId = ( values["MemberFileId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["MemberFileId"], typeof(System.Int32)) : (int)0;
					item = MemberFilesProvider.GetByMemberFileId(_memberFileId);
					results = new TList<MemberFiles>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case MemberFilesSelectMethod.GetByMemberIdMemberFileName:
					_memberId = ( values["MemberId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["MemberId"], typeof(System.Int32)) : (int)0;
					_memberFileName = ( values["MemberFileName"] != null ) ? (System.String) EntityUtil.ChangeType(values["MemberFileName"], typeof(System.String)) : string.Empty;
					item = MemberFilesProvider.GetByMemberIdMemberFileName(_memberId, _memberFileName);
					results = new TList<MemberFiles>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				case MemberFilesSelectMethod.GetByMemberId:
					_memberId = ( values["MemberId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["MemberId"], typeof(System.Int32)) : (int)0;
					results = MemberFilesProvider.GetByMemberId(_memberId, this.StartIndex, this.PageSize, out count);
					break;
				case MemberFilesSelectMethod.GetByMemberFileTypeId:
					_memberFileTypeId = ( values["MemberFileTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["MemberFileTypeId"], typeof(System.Int32)) : (int)0;
					results = MemberFilesProvider.GetByMemberFileTypeId(_memberFileTypeId, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				// Custom
				case MemberFilesSelectMethod.Get_List:
					results = MemberFilesProvider.Get_List(StartIndex, PageSize);
					break;
				
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
			if ( SelectMethod == MemberFilesSelectMethod.Get || SelectMethod == MemberFilesSelectMethod.GetByMemberFileId )
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
				MemberFiles entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					MemberFilesProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<MemberFiles> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			MemberFilesProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region MemberFilesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the MemberFilesDataSource class.
	/// </summary>
	public class MemberFilesDataSourceDesigner : ProviderDataSourceDesigner<MemberFiles, MemberFilesKey>
	{
		/// <summary>
		/// Initializes a new instance of the MemberFilesDataSourceDesigner class.
		/// </summary>
		public MemberFilesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public MemberFilesSelectMethod SelectMethod
		{
			get { return ((MemberFilesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new MemberFilesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region MemberFilesDataSourceActionList

	/// <summary>
	/// Supports the MemberFilesDataSourceDesigner class.
	/// </summary>
	internal class MemberFilesDataSourceActionList : DesignerActionList
	{
		private MemberFilesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the MemberFilesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public MemberFilesDataSourceActionList(MemberFilesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public MemberFilesSelectMethod SelectMethod
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

	#endregion MemberFilesDataSourceActionList
	
	#endregion MemberFilesDataSourceDesigner
	
	#region MemberFilesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the MemberFilesDataSource.SelectMethod property.
	/// </summary>
	public enum MemberFilesSelectMethod
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
		/// Represents the GetByMemberIdMemberFileName method.
		/// </summary>
		GetByMemberIdMemberFileName,
		/// <summary>
		/// Represents the GetByMemberFileId method.
		/// </summary>
		GetByMemberFileId,
		/// <summary>
		/// Represents the GetByMemberId method.
		/// </summary>
		GetByMemberId,
		/// <summary>
		/// Represents the GetByMemberFileTypeId method.
		/// </summary>
		GetByMemberFileTypeId,
		/// <summary>
		/// Represents the Get_List method.
		/// </summary>
		Get_List
	}
	
	#endregion MemberFilesSelectMethod

	#region MemberFilesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberFiles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberFilesFilter : SqlFilter<MemberFilesColumn>
	{
	}
	
	#endregion MemberFilesFilter

	#region MemberFilesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="MemberFiles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberFilesExpressionBuilder : SqlExpressionBuilder<MemberFilesColumn>
	{
	}
	
	#endregion MemberFilesExpressionBuilder	

	#region MemberFilesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;MemberFilesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="MemberFiles"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class MemberFilesProperty : ChildEntityProperty<MemberFilesChildEntityTypes>
	{
	}
	
	#endregion MemberFilesProperty
}

