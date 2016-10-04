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
	/// Represents the DataRepository.EmailFormatsProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(EmailFormatsDataSourceDesigner))]
	public class EmailFormatsDataSource : ProviderDataSource<EmailFormats, EmailFormatsKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmailFormatsDataSource class.
		/// </summary>
		public EmailFormatsDataSource() : base(new EmailFormatsService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the EmailFormatsDataSourceView used by the EmailFormatsDataSource.
		/// </summary>
		protected EmailFormatsDataSourceView EmailFormatsView
		{
			get { return ( View as EmailFormatsDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the EmailFormatsDataSource control invokes to retrieve data.
		/// </summary>
		public EmailFormatsSelectMethod SelectMethod
		{
			get
			{
				EmailFormatsSelectMethod selectMethod = EmailFormatsSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (EmailFormatsSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the EmailFormatsDataSourceView class that is to be
		/// used by the EmailFormatsDataSource.
		/// </summary>
		/// <returns>An instance of the EmailFormatsDataSourceView class.</returns>
		protected override BaseDataSourceView<EmailFormats, EmailFormatsKey> GetNewDataSourceView()
		{
			return new EmailFormatsDataSourceView(this, DefaultViewName);
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
	/// Supports the EmailFormatsDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class EmailFormatsDataSourceView : ProviderDataSourceView<EmailFormats, EmailFormatsKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmailFormatsDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the EmailFormatsDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public EmailFormatsDataSourceView(EmailFormatsDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal EmailFormatsDataSource EmailFormatsOwner
		{
			get { return Owner as EmailFormatsDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal EmailFormatsSelectMethod SelectMethod
		{
			get { return EmailFormatsOwner.SelectMethod; }
			set { EmailFormatsOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal EmailFormatsService EmailFormatsProvider
		{
			get { return Provider as EmailFormatsService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<EmailFormats> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<EmailFormats> results = null;
			EmailFormats item;
			count = 0;
			
			System.Int32 _emailFormatId;

			switch ( SelectMethod )
			{
				case EmailFormatsSelectMethod.Get:
					EmailFormatsKey entityKey  = new EmailFormatsKey();
					entityKey.Load(values);
					item = EmailFormatsProvider.Get(entityKey);
					results = new TList<EmailFormats>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case EmailFormatsSelectMethod.GetAll:
                    results = EmailFormatsProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case EmailFormatsSelectMethod.GetPaged:
					results = EmailFormatsProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case EmailFormatsSelectMethod.Find:
					if ( FilterParameters != null )
						results = EmailFormatsProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = EmailFormatsProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case EmailFormatsSelectMethod.GetByEmailFormatId:
					_emailFormatId = ( values["EmailFormatId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["EmailFormatId"], typeof(System.Int32)) : (int)0;
					item = EmailFormatsProvider.GetByEmailFormatId(_emailFormatId);
					results = new TList<EmailFormats>();
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
			if ( SelectMethod == EmailFormatsSelectMethod.Get || SelectMethod == EmailFormatsSelectMethod.GetByEmailFormatId )
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
				EmailFormats entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					EmailFormatsProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<EmailFormats> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			EmailFormatsProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region EmailFormatsDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the EmailFormatsDataSource class.
	/// </summary>
	public class EmailFormatsDataSourceDesigner : ProviderDataSourceDesigner<EmailFormats, EmailFormatsKey>
	{
		/// <summary>
		/// Initializes a new instance of the EmailFormatsDataSourceDesigner class.
		/// </summary>
		public EmailFormatsDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public EmailFormatsSelectMethod SelectMethod
		{
			get { return ((EmailFormatsDataSource) DataSource).SelectMethod; }
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
				actions.Add(new EmailFormatsDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region EmailFormatsDataSourceActionList

	/// <summary>
	/// Supports the EmailFormatsDataSourceDesigner class.
	/// </summary>
	internal class EmailFormatsDataSourceActionList : DesignerActionList
	{
		private EmailFormatsDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the EmailFormatsDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public EmailFormatsDataSourceActionList(EmailFormatsDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public EmailFormatsSelectMethod SelectMethod
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

	#endregion EmailFormatsDataSourceActionList
	
	#endregion EmailFormatsDataSourceDesigner
	
	#region EmailFormatsSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the EmailFormatsDataSource.SelectMethod property.
	/// </summary>
	public enum EmailFormatsSelectMethod
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
		/// Represents the GetByEmailFormatId method.
		/// </summary>
		GetByEmailFormatId
	}
	
	#endregion EmailFormatsSelectMethod

	#region EmailFormatsFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmailFormats"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmailFormatsFilter : SqlFilter<EmailFormatsColumn>
	{
	}
	
	#endregion EmailFormatsFilter

	#region EmailFormatsExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmailFormats"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmailFormatsExpressionBuilder : SqlExpressionBuilder<EmailFormatsColumn>
	{
	}
	
	#endregion EmailFormatsExpressionBuilder	

	#region EmailFormatsProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;EmailFormatsChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="EmailFormats"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmailFormatsProperty : ChildEntityProperty<EmailFormatsChildEntityTypes>
	{
	}
	
	#endregion EmailFormatsProperty
}

