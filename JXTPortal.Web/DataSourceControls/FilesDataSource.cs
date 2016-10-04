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
	/// Represents the DataRepository.FilesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(FilesDataSourceDesigner))]
	public class FilesDataSource : ProviderDataSource<Files, FilesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FilesDataSource class.
		/// </summary>
		public FilesDataSource() : base(new FilesService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the FilesDataSourceView used by the FilesDataSource.
		/// </summary>
		protected FilesDataSourceView FilesView
		{
			get { return ( View as FilesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the FilesDataSource control invokes to retrieve data.
		/// </summary>
		public FilesSelectMethod SelectMethod
		{
			get
			{
				FilesSelectMethod selectMethod = FilesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (FilesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the FilesDataSourceView class that is to be
		/// used by the FilesDataSource.
		/// </summary>
		/// <returns>An instance of the FilesDataSourceView class.</returns>
		protected override BaseDataSourceView<Files, FilesKey> GetNewDataSourceView()
		{
			return new FilesDataSourceView(this, DefaultViewName);
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
	/// Supports the FilesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class FilesDataSourceView : ProviderDataSourceView<Files, FilesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FilesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the FilesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public FilesDataSourceView(FilesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal FilesDataSource FilesOwner
		{
			get { return Owner as FilesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal FilesSelectMethod SelectMethod
		{
			get { return FilesOwner.SelectMethod; }
			set { FilesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal FilesService FilesProvider
		{
			get { return Provider as FilesService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<Files> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<Files> results = null;
			Files item;
			count = 0;
			
			System.Int32 _folderId;
			System.Int32 _siteId;
			System.String _fileName;
			System.Int32 _fileId;
			System.Int32 _lastModifiedBy;
			System.Int32 _fileTypeId;
			System.Int32? sp205_FolderId;
			System.Int32? sp205_SiteId;
			System.String sp205_FileName;
			System.Int32? sp202_FileId;
			System.Int32? sp207_SiteId;
			System.Int32? sp208_SiteId;
			System.String sp208_PageName;
			System.Int32? sp208_FileTypeId;
			System.Int32? sp204_FolderId;
			System.Boolean? sp200_SearchUsingOr;
			System.Int32? sp200_FileId;
			System.Int32? sp200_SiteId;
			System.Int32? sp200_FolderId;
			System.String sp200_FileName;
			System.String sp200_FileSystemName;
			System.Int32? sp200_FileTypeId;
			System.DateTime? sp200_LastModified;
			System.Int32? sp200_LastModifiedBy;
			System.Int32? sp200_SourceId;
			System.Int32? sp206_LastModifiedBy;
			System.Int32? sp203_FileTypeId;

			switch ( SelectMethod )
			{
				case FilesSelectMethod.Get:
					FilesKey entityKey  = new FilesKey();
					entityKey.Load(values);
					item = FilesProvider.Get(entityKey);
					results = new TList<Files>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case FilesSelectMethod.GetAll:
                    results = FilesProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case FilesSelectMethod.GetPaged:
					results = FilesProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case FilesSelectMethod.Find:
					if ( FilterParameters != null )
						results = FilesProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = FilesProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case FilesSelectMethod.GetByFileId:
					_fileId = ( values["FileId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["FileId"], typeof(System.Int32)) : (int)0;
					item = FilesProvider.GetByFileId(_fileId);
					results = new TList<Files>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case FilesSelectMethod.GetByFolderIdSiteIdFileName:
					_folderId = ( values["FolderId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["FolderId"], typeof(System.Int32)) : (int)0;
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					_fileName = ( values["FileName"] != null ) ? (System.String) EntityUtil.ChangeType(values["FileName"], typeof(System.String)) : string.Empty;
					item = FilesProvider.GetByFolderIdSiteIdFileName(_folderId, _siteId, _fileName);
					results = new TList<Files>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				case FilesSelectMethod.GetByLastModifiedBy:
					_lastModifiedBy = ( values["LastModifiedBy"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["LastModifiedBy"], typeof(System.Int32)) : (int)0;
					results = FilesProvider.GetByLastModifiedBy(_lastModifiedBy, this.StartIndex, this.PageSize, out count);
					break;
				case FilesSelectMethod.GetByFileTypeId:
					_fileTypeId = ( values["FileTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["FileTypeId"], typeof(System.Int32)) : (int)0;
					results = FilesProvider.GetByFileTypeId(_fileTypeId, this.StartIndex, this.PageSize, out count);
					break;
				case FilesSelectMethod.GetByFolderId:
					_folderId = ( values["FolderId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["FolderId"], typeof(System.Int32)) : (int)0;
					results = FilesProvider.GetByFolderId(_folderId, this.StartIndex, this.PageSize, out count);
					break;
				case FilesSelectMethod.GetBySiteId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					results = FilesProvider.GetBySiteId(_siteId, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				// Custom
				
				case FilesSelectMethod.Get_List:
					results = FilesProvider.Get_List(StartIndex, PageSize);
					break;
				case FilesSelectMethod.GetBySiteIDPageNameFileTypeID:
					sp208_SiteId = (System.Int32?) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32?));
					sp208_PageName = (System.String) EntityUtil.ChangeType(values["PageName"], typeof(System.String));
					sp208_FileTypeId = (System.Int32?) EntityUtil.ChangeType(values["FileTypeId"], typeof(System.Int32?));
					results = FilesProvider.GetBySiteIDPageNameFileTypeID(sp208_SiteId, sp208_PageName, sp208_FileTypeId, StartIndex, PageSize);
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
			if ( SelectMethod == FilesSelectMethod.Get || SelectMethod == FilesSelectMethod.GetByFileId )
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
				Files entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					FilesProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<Files> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			FilesProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region FilesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the FilesDataSource class.
	/// </summary>
	public class FilesDataSourceDesigner : ProviderDataSourceDesigner<Files, FilesKey>
	{
		/// <summary>
		/// Initializes a new instance of the FilesDataSourceDesigner class.
		/// </summary>
		public FilesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public FilesSelectMethod SelectMethod
		{
			get { return ((FilesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new FilesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region FilesDataSourceActionList

	/// <summary>
	/// Supports the FilesDataSourceDesigner class.
	/// </summary>
	internal class FilesDataSourceActionList : DesignerActionList
	{
		private FilesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the FilesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public FilesDataSourceActionList(FilesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public FilesSelectMethod SelectMethod
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

	#endregion FilesDataSourceActionList
	
	#endregion FilesDataSourceDesigner
	
	#region FilesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the FilesDataSource.SelectMethod property.
	/// </summary>
	public enum FilesSelectMethod
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
		/// Represents the GetByFolderIdSiteIdFileName method.
		/// </summary>
		GetByFolderIdSiteIdFileName,
		/// <summary>
		/// Represents the GetByFileId method.
		/// </summary>
		GetByFileId,
		/// <summary>
		/// Represents the GetByLastModifiedBy method.
		/// </summary>
		GetByLastModifiedBy,
		/// <summary>
		/// Represents the GetByFileTypeId method.
		/// </summary>
		GetByFileTypeId,
		/// <summary>
		/// Represents the GetByFolderId method.
		/// </summary>
		GetByFolderId,
		/// <summary>
		/// Represents the GetBySiteId method.
		/// </summary>
		GetBySiteId,
		/// <summary>
		/// Represents the Get_List method.
		/// </summary>
		Get_List,
		/// <summary>
		/// Represents the GetBySiteIDPageNameFileTypeID method.
		/// </summary>
		GetBySiteIDPageNameFileTypeID
	}
	
	#endregion FilesSelectMethod

	#region FilesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Files"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FilesFilter : SqlFilter<FilesColumn>
	{
	}
	
	#endregion FilesFilter

	#region FilesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Files"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FilesExpressionBuilder : SqlExpressionBuilder<FilesColumn>
	{
	}
	
	#endregion FilesExpressionBuilder	

	#region FilesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;FilesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="Files"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FilesProperty : ChildEntityProperty<FilesChildEntityTypes>
	{
	}
	
	#endregion FilesProperty
}

