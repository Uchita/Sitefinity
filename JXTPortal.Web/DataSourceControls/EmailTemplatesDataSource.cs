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
	/// Represents the DataRepository.EmailTemplatesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(EmailTemplatesDataSourceDesigner))]
	public class EmailTemplatesDataSource : ProviderDataSource<EmailTemplates, EmailTemplatesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmailTemplatesDataSource class.
		/// </summary>
		public EmailTemplatesDataSource() : base(new EmailTemplatesService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the EmailTemplatesDataSourceView used by the EmailTemplatesDataSource.
		/// </summary>
		protected EmailTemplatesDataSourceView EmailTemplatesView
		{
			get { return ( View as EmailTemplatesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the EmailTemplatesDataSource control invokes to retrieve data.
		/// </summary>
		public EmailTemplatesSelectMethod SelectMethod
		{
			get
			{
				EmailTemplatesSelectMethod selectMethod = EmailTemplatesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (EmailTemplatesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the EmailTemplatesDataSourceView class that is to be
		/// used by the EmailTemplatesDataSource.
		/// </summary>
		/// <returns>An instance of the EmailTemplatesDataSourceView class.</returns>
		protected override BaseDataSourceView<EmailTemplates, EmailTemplatesKey> GetNewDataSourceView()
		{
			return new EmailTemplatesDataSourceView(this, DefaultViewName);
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
	/// Supports the EmailTemplatesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class EmailTemplatesDataSourceView : ProviderDataSourceView<EmailTemplates, EmailTemplatesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the EmailTemplatesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the EmailTemplatesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public EmailTemplatesDataSourceView(EmailTemplatesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal EmailTemplatesDataSource EmailTemplatesOwner
		{
			get { return Owner as EmailTemplatesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal EmailTemplatesSelectMethod SelectMethod
		{
			get { return EmailTemplatesOwner.SelectMethod; }
			set { EmailTemplatesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal EmailTemplatesService EmailTemplatesProvider
		{
			get { return Provider as EmailTemplatesService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<EmailTemplates> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<EmailTemplates> results = null;
			EmailTemplates item;
			count = 0;
			
			System.Int32 _siteId;
			System.String _emailCode;
			System.Boolean _globalTemplate;
			System.Int32? _languageId_nullable;
			System.Int32 _emailTemplateId;
			System.Int32 _lastModifiedBy;
			System.String sp276_EmailCode;

			switch ( SelectMethod )
			{
				case EmailTemplatesSelectMethod.Get:
					EmailTemplatesKey entityKey  = new EmailTemplatesKey();
					entityKey.Load(values);
					item = EmailTemplatesProvider.Get(entityKey);
					results = new TList<EmailTemplates>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case EmailTemplatesSelectMethod.GetAll:
                    results = EmailTemplatesProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case EmailTemplatesSelectMethod.GetPaged:
					results = EmailTemplatesProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case EmailTemplatesSelectMethod.Find:
					if ( FilterParameters != null )
						results = EmailTemplatesProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = EmailTemplatesProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case EmailTemplatesSelectMethod.GetByEmailTemplateId:
					_emailTemplateId = ( values["EmailTemplateId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["EmailTemplateId"], typeof(System.Int32)) : (int)0;
					item = EmailTemplatesProvider.GetByEmailTemplateId(_emailTemplateId);
					results = new TList<EmailTemplates>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				case EmailTemplatesSelectMethod.GetBySiteIdEmailCodeGlobalTemplateLanguageId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					_emailCode = ( values["EmailCode"] != null ) ? (System.String) EntityUtil.ChangeType(values["EmailCode"], typeof(System.String)) : string.Empty;
					_globalTemplate = ( values["GlobalTemplate"] != null ) ? (System.Boolean) EntityUtil.ChangeType(values["GlobalTemplate"], typeof(System.Boolean)) : false;
					_languageId_nullable = (System.Int32?) EntityUtil.ChangeType(values["LanguageId"], typeof(System.Int32?));
					item = EmailTemplatesProvider.GetBySiteIdEmailCodeGlobalTemplateLanguageId(_siteId, _emailCode, _globalTemplate, _languageId_nullable);
					results = new TList<EmailTemplates>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// FK
				case EmailTemplatesSelectMethod.GetByLastModifiedBy:
					_lastModifiedBy = ( values["LastModifiedBy"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["LastModifiedBy"], typeof(System.Int32)) : (int)0;
					results = EmailTemplatesProvider.GetByLastModifiedBy(_lastModifiedBy, this.StartIndex, this.PageSize, out count);
					break;
				case EmailTemplatesSelectMethod.GetBySiteId:
					_siteId = ( values["SiteId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32)) : (int)0;
					results = EmailTemplatesProvider.GetBySiteId(_siteId, this.StartIndex, this.PageSize, out count);
					break;
				case EmailTemplatesSelectMethod.GetByLanguageId:
					_languageId_nullable = (System.Int32?) EntityUtil.ChangeType(values["LanguageId"], typeof(System.Int32?));
					results = EmailTemplatesProvider.GetByLanguageId(_languageId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				// Custom
				case EmailTemplatesSelectMethod.CustomGetByEmailCode:
					sp276_EmailCode = (System.String) EntityUtil.ChangeType(values["EmailCode"], typeof(System.String));
					results = EmailTemplatesProvider.CustomGetByEmailCode(sp276_EmailCode, StartIndex, PageSize);
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
			if ( SelectMethod == EmailTemplatesSelectMethod.Get || SelectMethod == EmailTemplatesSelectMethod.GetByEmailTemplateId )
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
				EmailTemplates entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					EmailTemplatesProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<EmailTemplates> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			EmailTemplatesProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region EmailTemplatesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the EmailTemplatesDataSource class.
	/// </summary>
	public class EmailTemplatesDataSourceDesigner : ProviderDataSourceDesigner<EmailTemplates, EmailTemplatesKey>
	{
		/// <summary>
		/// Initializes a new instance of the EmailTemplatesDataSourceDesigner class.
		/// </summary>
		public EmailTemplatesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public EmailTemplatesSelectMethod SelectMethod
		{
			get { return ((EmailTemplatesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new EmailTemplatesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region EmailTemplatesDataSourceActionList

	/// <summary>
	/// Supports the EmailTemplatesDataSourceDesigner class.
	/// </summary>
	internal class EmailTemplatesDataSourceActionList : DesignerActionList
	{
		private EmailTemplatesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the EmailTemplatesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public EmailTemplatesDataSourceActionList(EmailTemplatesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public EmailTemplatesSelectMethod SelectMethod
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

	#endregion EmailTemplatesDataSourceActionList
	
	#endregion EmailTemplatesDataSourceDesigner
	
	#region EmailTemplatesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the EmailTemplatesDataSource.SelectMethod property.
	/// </summary>
	public enum EmailTemplatesSelectMethod
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
		/// Represents the GetBySiteIdEmailCodeGlobalTemplateLanguageId method.
		/// </summary>
		GetBySiteIdEmailCodeGlobalTemplateLanguageId,
		/// <summary>
		/// Represents the GetByEmailTemplateId method.
		/// </summary>
		GetByEmailTemplateId,
		/// <summary>
		/// Represents the GetByLastModifiedBy method.
		/// </summary>
		GetByLastModifiedBy,
		/// <summary>
		/// Represents the GetBySiteId method.
		/// </summary>
		GetBySiteId,
		/// <summary>
		/// Represents the GetByLanguageId method.
		/// </summary>
		GetByLanguageId,
		/// <summary>
		/// Represents the CustomGetByEmailCode method.
		/// </summary>
		CustomGetByEmailCode
	}
	
	#endregion EmailTemplatesSelectMethod

	#region EmailTemplatesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmailTemplates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmailTemplatesFilter : SqlFilter<EmailTemplatesColumn>
	{
	}
	
	#endregion EmailTemplatesFilter

	#region EmailTemplatesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="EmailTemplates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmailTemplatesExpressionBuilder : SqlExpressionBuilder<EmailTemplatesColumn>
	{
	}
	
	#endregion EmailTemplatesExpressionBuilder	

	#region EmailTemplatesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;EmailTemplatesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="EmailTemplates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class EmailTemplatesProperty : ChildEntityProperty<EmailTemplatesChildEntityTypes>
	{
	}
	
	#endregion EmailTemplatesProperty
}

