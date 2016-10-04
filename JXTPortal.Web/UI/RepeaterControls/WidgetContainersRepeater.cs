using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.ComponentModel;
using System.Web.UI.Design.WebControls;
using System.Web.UI.Design;
using System.Web.UI.WebControls;

namespace JXTPortal.Web.UI
{
    /// <summary>
    /// A designer class for a strongly typed repeater <c>WidgetContainersRepeater</c>
    /// </summary>
	public class WidgetContainersRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:WidgetContainersRepeaterDesigner"/> class.
        /// </summary>
		public WidgetContainersRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is WidgetContainersRepeater))
			{ 
				throw new ArgumentException("Component is not a WidgetContainersRepeater."); 
			} 
			base.Initialize(component); 
			base.SetViewFlags(ViewFlags.TemplateEditing, true); 
		}


		/// <summary>
		/// Generate HTML for the designer
		/// </summary>
		/// <returns>a string of design time HTML</returns>
		public override string GetDesignTimeHtml()
		{

			// Get the instance this designer applies to
			//
			WidgetContainersRepeater z = (WidgetContainersRepeater)Component;
			z.DataBind();

			return base.GetDesignTimeHtml();

			//return z.RenderAtDesignTime();

			//	ControlCollection c = z.Controls;
			//Totem z = (Totem) Component;
			//Totem z = (Totem) Component;
			//return ("<div style='border: 1px gray dotted; background-color: lightgray'><b>TagStat :</b> zae |  qsdds</div>");

		}
	}

    /// <summary>
    /// A strongly typed repeater control for the <c cref="WidgetContainersRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(WidgetContainersRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:WidgetContainersRepeater runat=\"server\"></{0}:WidgetContainersRepeater>")]
	public class WidgetContainersRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:WidgetContainersRepeater"/> class.
        /// </summary>
		public WidgetContainersRepeater()
		{
		}

		/// <summary>
        /// Gets a <see cref="T:System.Web.UI.ControlCollection"></see> object that represents the child controls for a specified server control in the UI hierarchy.
        /// </summary>
        /// <value></value>
        /// <returns>The collection of child controls for the specified server control.</returns>
		public override ControlCollection Controls
		{
			get
			{
				this.EnsureChildControls();
				return base.Controls;
			}
		}

		private ITemplate m_headerTemplate;
		/// <summary>
        /// Gets or sets the header template.
        /// </summary>
        /// <value>The header template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(WidgetContainersItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate HeaderTemplate
		{
			get { return m_headerTemplate; }
			set { m_headerTemplate = value; }
		}

		private ITemplate m_itemTemplate;
		/// <summary>
        /// Gets or sets the item template.
        /// </summary>
        /// <value>The item template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(WidgetContainersItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate ItemTemplate
		{
			get { return m_itemTemplate; }
			set { m_itemTemplate = value; }
		}

		private ITemplate m_seperatorTemplate;
        /// <summary>
        /// Gets or sets the Seperator Template
        /// </summary>
        [Browsable(false)]
        [TemplateContainer(typeof(WidgetContainersItem))]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        public ITemplate SeperatorTemplate
        {
            get { return m_seperatorTemplate; }
            set { m_seperatorTemplate = value; }
        }
			
		private ITemplate m_altenateItemTemplate;
        /// <summary>
        /// Gets or sets the alternating item template.
        /// </summary>
        /// <value>The alternating item template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(WidgetContainersItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate AlternatingItemTemplate
		{
			get { return m_altenateItemTemplate; }
			set { m_altenateItemTemplate = value; }
		}

		private ITemplate m_footerTemplate;
        /// <summary>
        /// Gets or sets the footer template.
        /// </summary>
        /// <value>The footer template.</value>
		[Browsable(false)]
		[TemplateContainer(typeof(WidgetContainersItem))]
		[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
		public ITemplate FooterTemplate
		{
			get { return m_footerTemplate; }
			set { m_footerTemplate = value; }
		}

//      /// <summary>
//      /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
//      /// </summary>
//		protected override void CreateChildControls()
//      {
//         if (ChildControlsCreated)
//         {
//            return;
//         }

//         Controls.Clear();

//         //Instantiate the Header template (if exists)
//         if (m_headerTemplate != null)
//         {
//            Control headerItem = new Control();
//            m_headerTemplate.InstantiateIn(headerItem);
//            Controls.Add(headerItem);
//         }

//         //Instantiate the Footer template (if exists)
//         if (m_footerTemplate != null)
//         {
//            Control footerItem = new Control();
//            m_footerTemplate.InstantiateIn(footerItem);
//            Controls.Add(footerItem);
//         }
//
//         ChildControlsCreated = true;
//      }
	
		/// <summary>
        /// Overridden and Empty so that span tags are not written
        /// </summary>
        /// <param name="writer"></param>
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            
        }

        /// <summary>
        /// Overridden and Empty so that span tags are not written
        /// </summary>
        /// <param name="writer"></param>
        public override void RenderEndTag(HtmlTextWriter writer)
        {
                
        }		
		
		/// <summary>
      	/// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
      	/// </summary>
		protected override int CreateChildControls(System.Collections.IEnumerable dataSource, bool dataBinding)
      	{
         int pos = 0;

         if (dataBinding)
         {
            //Instantiate the Header template (if exists)
            if (m_headerTemplate != null)
            {
                Control headerItem = new Control();
                m_headerTemplate.InstantiateIn(headerItem);
                Controls.Add(headerItem);
            }
			if (dataSource != null)
			{
				foreach (object o in dataSource)
				{
						JXTPortal.Entities.WidgetContainers entity = o as JXTPortal.Entities.WidgetContainers;
						WidgetContainersItem container = new WidgetContainersItem(entity);
	
						if (m_itemTemplate != null && (pos % 2) == 0)
						{
							m_itemTemplate.InstantiateIn(container);
							
							if (m_seperatorTemplate != null)
							{
								m_seperatorTemplate.InstantiateIn(container);
							}
						}
						else
						{
							if (m_altenateItemTemplate != null)
							{
								m_altenateItemTemplate.InstantiateIn(container);
								
								if (m_seperatorTemplate != null)
								{
									m_seperatorTemplate.InstantiateIn(container);
								}
								
							}
							else if (m_itemTemplate != null)
							{
								m_itemTemplate.InstantiateIn(container);
								
								if (m_seperatorTemplate != null)
								{
									m_seperatorTemplate.InstantiateIn(container);
								}
							}
							else
							{
								// no template !!!
							}
						}
						Controls.Add(container);
						
						container.DataBind();
						
						pos++;
				}
			}
            //Instantiate the Footer template (if exists)
            if (m_footerTemplate != null)
            {
                Control footerItem = new Control();
                m_footerTemplate.InstantiateIn(footerItem);
                Controls.Add(footerItem);
            }

		}
			
			return pos;
		}

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.PreRender"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> object that contains the event data.</param>
		protected override void OnPreRender(EventArgs e)
		{
			base.DataBind();
		}

		#region Design time
        /// <summary>
        /// Renders at design time.
        /// </summary>
        /// <returns>a  string of the Designed HTML</returns>
		internal string RenderAtDesignTime()
		{			
			return "Designer currently not implemented"; 
		}

		#endregion
	}

    /// <summary>
    /// A wrapper type for the entity
    /// </summary>
	[System.ComponentModel.ToolboxItem(false)]
	public class WidgetContainersItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private JXTPortal.Entities.WidgetContainers _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:WidgetContainersItem"/> class.
        /// </summary>
		public WidgetContainersItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:WidgetContainersItem"/> class.
        /// </summary>
		public WidgetContainersItem(JXTPortal.Entities.WidgetContainers entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the WidgetId
        /// </summary>
        /// <value>The WidgetId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 WidgetId
		{
			get { return _entity.WidgetId; }
		}
        /// <summary>
        /// Gets the SiteId
        /// </summary>
        /// <value>The SiteId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 SiteId
		{
			get { return _entity.SiteId; }
		}
        /// <summary>
        /// Gets the LanguageId
        /// </summary>
        /// <value>The LanguageId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 LanguageId
		{
			get { return _entity.LanguageId; }
		}
        /// <summary>
        /// Gets the WidgetName
        /// </summary>
        /// <value>The WidgetName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String WidgetName
		{
			get { return _entity.WidgetName; }
		}
        /// <summary>
        /// Gets the WidgetDomain
        /// </summary>
        /// <value>The WidgetDomain.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String WidgetDomain
		{
			get { return _entity.WidgetDomain; }
		}
        /// <summary>
        /// Gets the WidgetContainerClass
        /// </summary>
        /// <value>The WidgetContainerClass.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String WidgetContainerClass
		{
			get { return _entity.WidgetContainerClass; }
		}
        /// <summary>
        /// Gets the WidgetContainerHeaderClass
        /// </summary>
        /// <value>The WidgetContainerHeaderClass.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String WidgetContainerHeaderClass
		{
			get { return _entity.WidgetContainerHeaderClass; }
		}
        /// <summary>
        /// Gets the WidgetItemClass
        /// </summary>
        /// <value>The WidgetItemClass.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String WidgetItemClass
		{
			get { return _entity.WidgetItemClass; }
		}
        /// <summary>
        /// Gets the WidgetJobLinkCss
        /// </summary>
        /// <value>The WidgetJobLinkCss.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String WidgetJobLinkCss
		{
			get { return _entity.WidgetJobLinkCss; }
		}
        /// <summary>
        /// Gets the WidgetItemLinkImageId
        /// </summary>
        /// <value>The WidgetItemLinkImageId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? WidgetItemLinkImageId
		{
			get { return _entity.WidgetItemLinkImageId; }
		}
        /// <summary>
        /// Gets the Valid
        /// </summary>
        /// <value>The Valid.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? Valid
		{
			get { return _entity.Valid; }
		}
        /// <summary>
        /// Gets the ShowJobs
        /// </summary>
        /// <value>The ShowJobs.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? ShowJobs
		{
			get { return _entity.ShowJobs; }
		}
        /// <summary>
        /// Gets the ShowCompanies
        /// </summary>
        /// <value>The ShowCompanies.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? ShowCompanies
		{
			get { return _entity.ShowCompanies; }
		}
        /// <summary>
        /// Gets the ShowSite
        /// </summary>
        /// <value>The ShowSite.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? ShowSite
		{
			get { return _entity.ShowSite; }
		}
        /// <summary>
        /// Gets the ShowPeople
        /// </summary>
        /// <value>The ShowPeople.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? ShowPeople
		{
			get { return _entity.ShowPeople; }
		}
        /// <summary>
        /// Gets the JobHtml
        /// </summary>
        /// <value>The JobHtml.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String JobHtml
		{
			get { return _entity.JobHtml; }
		}
        /// <summary>
        /// Gets the CompanyHtml
        /// </summary>
        /// <value>The CompanyHtml.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CompanyHtml
		{
			get { return _entity.CompanyHtml; }
		}
        /// <summary>
        /// Gets the SiteHtml
        /// </summary>
        /// <value>The SiteHtml.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SiteHtml
		{
			get { return _entity.SiteHtml; }
		}
        /// <summary>
        /// Gets the PeopleHtml
        /// </summary>
        /// <value>The PeopleHtml.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PeopleHtml
		{
			get { return _entity.PeopleHtml; }
		}
        /// <summary>
        /// Gets the Javascript
        /// </summary>
        /// <value>The Javascript.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Javascript
		{
			get { return _entity.Javascript; }
		}
        /// <summary>
        /// Gets the SearchCss
        /// </summary>
        /// <value>The SearchCss.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SearchCss
		{
			get { return _entity.SearchCss; }
		}
        /// <summary>
        /// Gets the DefaultProfessionId
        /// </summary>
        /// <value>The DefaultProfessionId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? DefaultProfessionId
		{
			get { return _entity.DefaultProfessionId; }
		}
        /// <summary>
        /// Gets the DefaultCountryId
        /// </summary>
        /// <value>The DefaultCountryId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? DefaultCountryId
		{
			get { return _entity.DefaultCountryId; }
		}
        /// <summary>
        /// Gets the DefaultLocationId
        /// </summary>
        /// <value>The DefaultLocationId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? DefaultLocationId
		{
			get { return _entity.DefaultLocationId; }
		}
        /// <summary>
        /// Gets the Width
        /// </summary>
        /// <value>The Width.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? Width
		{
			get { return _entity.Width; }
		}
        /// <summary>
        /// Gets the Height
        /// </summary>
        /// <value>The Height.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? Height
		{
			get { return _entity.Height; }
		}
        /// <summary>
        /// Gets the OnAdvancedSearch
        /// </summary>
        /// <value>The OnAdvancedSearch.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? OnAdvancedSearch
		{
			get { return _entity.OnAdvancedSearch; }
		}

        /// <summary>
        /// Gets a <see cref="T:JXTPortal.Entities.WidgetContainers"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public JXTPortal.Entities.WidgetContainers Entity
        {
            get { return _entity; }
        }
	}
}
