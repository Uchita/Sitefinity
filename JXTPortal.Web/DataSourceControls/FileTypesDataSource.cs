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
	/// Represents the DataRepository.FileTypesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(FileTypesDataSourceDesigner))]
	public class FileTypesDataSource : ProviderDataSource<FileTypes, FileTypesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FileTypesDataSource class.
		/// </summary>
		public FileTypesDataSource() : base(new FileTypesService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the FileTypesDataSourceView used by the FileTypesDataSource.
		/// </summary>
		protected FileTypesDataSourceView FileTypesView
		{
			get { return ( View as FileTypesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the FileTypesDataSource control invokes to retrieve data.
		/// </summary>
		public FileTypesSelectMethod SelectMethod
		{
			get
			{
				FileTypesSelectMethod selectMethod = FileTypesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (FileTypesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the FileTypesDataSourceView class that is to be
		/// used by the FileTypesDataSource.
		/// </summary>
		/// <returns>An instance of the FileTypesDataSourceView class.</returns>
		protected override BaseDataSourceView<FileTypes, FileTypesKey> GetNewDataSourceView()
		{
			return new FileTypesDataSourceView(this, DefaultViewName);
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
	/// Supports the FileTypesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class FileTypesDataSourceView : ProviderDataSourceView<FileTypes, FileTypesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the FileTypesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the FileTypesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public FileTypesDataSourceView(FileTypesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal FileTypesDataSource FileTypesOwner
		{
			get { return Owner as FileTypesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal FileTypesSelectMethod SelectMethod
		{
			get { return FileTypesOwner.SelectMethod; }
			set { FileTypesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal FileTypesService FileTypesProvider
		{
			get { return Provider as FileTypesService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<FileTypes> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<FileTypes> results = null;
			FileTypes item;
			count = 0;
			
			System.Int32 _fileTypeId;

			switch ( SelectMethod )
			{
				case FileTypesSelectMethod.Get:
					FileTypesKey entityKey  = new FileTypesKey();
					entityKey.Load(values);
					item = FileTypesProvider.Get(entityKey);
					results = new TList<FileTypes>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case FileTypesSelectMethod.GetAll:
                    results = FileTypesProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case FileTypesSelectMethod.GetPaged:
					results = FileTypesProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case FileTypesSelectMethod.Find:
					if ( FilterParameters != null )
						results = FileTypesProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = FileTypesProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case FileTypesSelectMethod.GetByFileTypeId:
					_fileTypeId = ( values["FileTypeId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["FileTypeId"], typeof(System.Int32)) : (int)0;
					item = FileTypesProvider.GetByFileTypeId(_fileTypeId);
					results = new TList<FileTypes>();
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
			if ( SelectMethod == FileTypesSelectMethod.Get || SelectMethod == FileTypesSelectMethod.GetByFileTypeId )
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
				FileTypes entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					FileTypesProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<FileTypes> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			FileTypesProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region FileTypesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the FileTypesDataSource class.
	/// </summary>
	public class FileTypesDataSourceDesigner : ProviderDataSourceDesigner<FileTypes, FileTypesKey>
	{
		/// <summary>
		/// Initializes a new instance of the FileTypesDataSourceDesigner class.
		/// </summary>
		public FileTypesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public FileTypesSelectMethod SelectMethod
		{
			get { return ((FileTypesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new FileTypesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region FileTypesDataSourceActionList

	/// <summary>
	/// Supports the FileTypesDataSourceDesigner class.
	/// </summary>
	internal class FileTypesDataSourceActionList : DesignerActionList
	{
		private FileTypesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the FileTypesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public FileTypesDataSourceActionList(FileTypesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public FileTypesSelectMethod SelectMethod
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

	#endregion FileTypesDataSourceActionList
	
	#endregion FileTypesDataSourceDesigner
	
	#region FileTypesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the FileTypesDataSource.SelectMethod property.
	/// </summary>
	public enum FileTypesSelectMethod
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
		/// Represents the GetByFileTypeId method.
		/// </summary>
		GetByFileTypeId
	}
	
	#endregion FileTypesSelectMethod

	#region FileTypesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="FileTypes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FileTypesFilter : SqlFilter<FileTypesColumn>
	{
	}
	
	#endregion FileTypesFilter

	#region FileTypesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="FileTypes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FileTypesExpressionBuilder : SqlExpressionBuilder<FileTypesColumn>
	{
	}
	
	#endregion FileTypesExpressionBuilder	

	#region FileTypesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;FileTypesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="FileTypes"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class FileTypesProperty : ChildEntityProperty<FileTypesChildEntityTypes>
	{
	}
	
	#endregion FileTypesProperty
}

