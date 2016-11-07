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
	/// Represents the DataRepository.JobTemplatesProvider object that provides
	/// data to data-bound controls in multi-tier Web application architectures.
	/// </summary>
	[Designer(typeof(JobTemplatesDataSourceDesigner))]
	public class JobTemplatesDataSource : ProviderDataSource<JobTemplates, JobTemplatesKey>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobTemplatesDataSource class.
		/// </summary>
		public JobTemplatesDataSource() : base(new JobTemplatesService())
		{
		}

		#endregion Constructors
		
		#region Properties
		
		/// <summary>
		/// Gets a reference to the JobTemplatesDataSourceView used by the JobTemplatesDataSource.
		/// </summary>
		protected JobTemplatesDataSourceView JobTemplatesView
		{
			get { return ( View as JobTemplatesDataSourceView ); }
		}
		
		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the JobTemplatesDataSource control invokes to retrieve data.
		/// </summary>
		public JobTemplatesSelectMethod SelectMethod
		{
			get
			{
				JobTemplatesSelectMethod selectMethod = JobTemplatesSelectMethod.GetAll;
				Object method = ViewState["SelectMethod"];
				if ( method != null )
				{
					selectMethod = (JobTemplatesSelectMethod) method;
				}
				return selectMethod;
			}
			set { ViewState["SelectMethod"] = value; }
		}

		#endregion Properties
		
		#region Methods

		/// <summary>
		/// Creates a new instance of the JobTemplatesDataSourceView class that is to be
		/// used by the JobTemplatesDataSource.
		/// </summary>
		/// <returns>An instance of the JobTemplatesDataSourceView class.</returns>
		protected override BaseDataSourceView<JobTemplates, JobTemplatesKey> GetNewDataSourceView()
		{
			return new JobTemplatesDataSourceView(this, DefaultViewName);
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
	/// Supports the JobTemplatesDataSource control and provides an interface for
	/// data-bound controls to perform data operations with business and data objects.
	/// </summary>
	public class JobTemplatesDataSourceView : ProviderDataSourceView<JobTemplates, JobTemplatesKey>
	{
		#region Declarations

		#endregion Declarations
		
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the JobTemplatesDataSourceView class.
		/// </summary>
		/// <param name="owner">A reference to the JobTemplatesDataSource which created this instance.</param>
		/// <param name="viewName">The name of the view.</param>
		public JobTemplatesDataSourceView(JobTemplatesDataSource owner, String viewName)
			: base(owner, viewName)
		{
		}
		
		#endregion Constructors
		
		#region Properties

		/// <summary>
		/// Gets a strongly-typed reference to the Owner property.
		/// </summary>
		internal JobTemplatesDataSource JobTemplatesOwner
		{
			get { return Owner as JobTemplatesDataSource; }
		}

		/// <summary>
		/// Gets or sets the name of the method or function that
		/// the DataSource control invokes to retrieve data.
		/// </summary>
		internal JobTemplatesSelectMethod SelectMethod
		{
			get { return JobTemplatesOwner.SelectMethod; }
			set { JobTemplatesOwner.SelectMethod = value; }
		}

		/// <summary>
		/// Gets a strongly typed reference to the Provider property.
		/// </summary>
		internal JobTemplatesService JobTemplatesProvider
		{
			get { return Provider as JobTemplatesService; }
		}

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		/// Gets a collection of Entity objects based on the value of the SelectMethod property.
		/// </summary>
		/// <param name="count">The total number of rows in the DataSource.</param>
		/// <returns>A collection of Entity objects.</returns>
		protected override IList<JobTemplates> GetSelectData(out int count)
		{
			Hashtable values = CollectionsUtil.CreateCaseInsensitiveHashtable(GetParameterValues());
			Hashtable customOutput = CollectionsUtil.CreateCaseInsensitiveHashtable();
			IList<JobTemplates> results = null;
			JobTemplates item;
			count = 0;
			
			System.Int32 _jobTemplateId;
			System.Int32 _advertiserId;
			System.Int32 _lastModifiedBy;
			System.Int32? _siteId_nullable;
			System.Int32? sp386_SiteId;
			System.Int32? sp384_JobTemplateId;
			System.Int32? sp383_AdvertiserId;
			System.Int32? sp382_SiteId;
			System.Int32? sp382_AdvertiserId;
			System.Boolean? sp380_SearchUsingOr;
			System.Int32? sp380_JobTemplateId;
			System.Int32? sp380_SiteId;
			System.String sp380_JobTemplateDescription;
			System.String sp380_JobTemplateHtml;
			System.Boolean? sp380_GlobalTemplate;
			System.Int32? sp380_LastModifiedBy;
			System.DateTime? sp380_LastModified;
			System.Byte[] sp380_JobTemplateLogo;
			System.Int32? sp380_AdvertiserId;
			System.Int32? sp385_LastModifiedBy;

			switch ( SelectMethod )
			{
				case JobTemplatesSelectMethod.Get:
					JobTemplatesKey entityKey  = new JobTemplatesKey();
					entityKey.Load(values);
					item = JobTemplatesProvider.Get(entityKey);
					results = new TList<JobTemplates>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				case JobTemplatesSelectMethod.GetAll:
                    results = JobTemplatesProvider.GetAll(StartIndex, PageSize, out count);
                    break;
				case JobTemplatesSelectMethod.GetPaged:
					results = JobTemplatesProvider.GetPaged(WhereClause, OrderBy, PageIndex, PageSize, out count);
					break;
				case JobTemplatesSelectMethod.Find:
					if ( FilterParameters != null )
						results = JobTemplatesProvider.Find(FilterParameters, OrderBy, StartIndex, PageSize, out count);
					else
						results = JobTemplatesProvider.Find(WhereClause, StartIndex, PageSize, out count);
                    break;
				// PK
				case JobTemplatesSelectMethod.GetByJobTemplateId:
					_jobTemplateId = ( values["JobTemplateId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["JobTemplateId"], typeof(System.Int32)) : (int)0;
					item = JobTemplatesProvider.GetByJobTemplateId(_jobTemplateId);
					results = new TList<JobTemplates>();
					if ( item != null ) results.Add(item);
					count = results.Count;
					break;
				// IX
				// FK
				case JobTemplatesSelectMethod.GetByAdvertiserId:
					_advertiserId = ( values["AdvertiserId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["AdvertiserId"], typeof(System.Int32)) : (int)0;
					results = JobTemplatesProvider.GetByAdvertiserId(_advertiserId, this.StartIndex, this.PageSize, out count);
					break;
				case JobTemplatesSelectMethod.GetByLastModifiedBy:
					_lastModifiedBy = ( values["LastModifiedBy"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["LastModifiedBy"], typeof(System.Int32)) : (int)0;
					results = JobTemplatesProvider.GetByLastModifiedBy(_lastModifiedBy, this.StartIndex, this.PageSize, out count);
					break;
				case JobTemplatesSelectMethod.GetBySiteId:
					_siteId_nullable = (System.Int32?) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32?));
					results = JobTemplatesProvider.GetBySiteId(_siteId_nullable, this.StartIndex, this.PageSize, out count);
					break;
				// M:M
				// Custom
				
                //case JobTemplatesSelectMethod.Get_List:
                //    results = JobTemplatesProvider.Get_List(StartIndex, PageSize);
                //    break;
				
                //case JobTemplatesSelectMethod.GetAdvertiserJobTemplates:
                //    sp382_SiteId = (System.Int32?) EntityUtil.ChangeType(values["SiteId"], typeof(System.Int32?));
                //    sp382_AdvertiserId = (System.Int32?) EntityUtil.ChangeType(values["AdvertiserId"], typeof(System.Int32?));
                //    results = JobTemplatesProvider.GetAdvertiserJobTemplates(sp382_SiteId, sp382_AdvertiserId, StartIndex, PageSize);
                //    break;
				
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
			if ( SelectMethod == JobTemplatesSelectMethod.Get || SelectMethod == JobTemplatesSelectMethod.GetByJobTemplateId )
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
				JobTemplates entity = GetCurrentEntity();
				
				if ( entity != null )
				{
					// init transaction manager
					GetTransactionManager();
					// execute deep load method
					JobTemplatesProvider.DeepLoad(GetCurrentEntity(), EnableRecursiveDeepLoad);
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
		internal override void DeepLoad(TList<JobTemplates> entityList, ProviderDataSourceDeepLoadList properties)
		{
			// init transaction manager
			GetTransactionManager();
			// execute deep load method
			JobTemplatesProvider.DeepLoad(entityList, properties.Recursive, properties.Method, properties.GetTypes());
		}

		#endregion Select Methods
	}
	
	#region JobTemplatesDataSourceDesigner

	/// <summary>
	/// Provides design-time support in a design host for the JobTemplatesDataSource class.
	/// </summary>
	public class JobTemplatesDataSourceDesigner : ProviderDataSourceDesigner<JobTemplates, JobTemplatesKey>
	{
		/// <summary>
		/// Initializes a new instance of the JobTemplatesDataSourceDesigner class.
		/// </summary>
		public JobTemplatesDataSourceDesigner()
		{
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public JobTemplatesSelectMethod SelectMethod
		{
			get { return ((JobTemplatesDataSource) DataSource).SelectMethod; }
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
				actions.Add(new JobTemplatesDataSourceActionList(this));
				actions.AddRange(base.ActionLists);
				return actions;
			}
		}
	}

	#region JobTemplatesDataSourceActionList

	/// <summary>
	/// Supports the JobTemplatesDataSourceDesigner class.
	/// </summary>
	internal class JobTemplatesDataSourceActionList : DesignerActionList
	{
		private JobTemplatesDataSourceDesigner _designer;

		/// <summary>
		/// Initializes a new instance of the JobTemplatesDataSourceActionList class.
		/// </summary>
		/// <param name="designer"></param>
		public JobTemplatesDataSourceActionList(JobTemplatesDataSourceDesigner designer) : base(designer.Component)
		{
			_designer = designer;
		}

		/// <summary>
		/// Gets or sets the SelectMethod property.
		/// </summary>
		public JobTemplatesSelectMethod SelectMethod
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

	#endregion JobTemplatesDataSourceActionList
	
	#endregion JobTemplatesDataSourceDesigner
	
	#region JobTemplatesSelectMethod
	
	/// <summary>
	/// Enumeration of method names available for the JobTemplatesDataSource.SelectMethod property.
	/// </summary>
	public enum JobTemplatesSelectMethod
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
		/// Represents the GetByJobTemplateId method.
		/// </summary>
		GetByJobTemplateId,
		/// <summary>
		/// Represents the GetByAdvertiserId method.
		/// </summary>
		GetByAdvertiserId,
		/// <summary>
		/// Represents the GetByLastModifiedBy method.
		/// </summary>
		GetByLastModifiedBy,
		/// <summary>
		/// Represents the GetBySiteId method.
		/// </summary>
		GetBySiteId,
		/// <summary>
		/// Represents the Get_List method.
		/// </summary>
		Get_List,
		/// <summary>
		/// Represents the GetAdvertiserJobTemplates method.
		/// </summary>
		GetAdvertiserJobTemplates
	}
	
	#endregion JobTemplatesSelectMethod

	#region JobTemplatesFilter
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilter&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobTemplates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobTemplatesFilter : SqlFilter<JobTemplatesColumn>
	{
	}
	
	#endregion JobTemplatesFilter

	#region JobTemplatesExpressionBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlExpressionBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="JobTemplates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobTemplatesExpressionBuilder : SqlExpressionBuilder<JobTemplatesColumn>
	{
	}
	
	#endregion JobTemplatesExpressionBuilder	

	#region JobTemplatesProperty
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ChildEntityProperty&lt;JobTemplatesChildEntityTypes&gt;"/> class
	/// that is used exclusively with a <see cref="JobTemplates"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class JobTemplatesProperty : ChildEntityProperty<JobTemplatesChildEntityTypes>
	{
	}
	
	#endregion JobTemplatesProperty
}

