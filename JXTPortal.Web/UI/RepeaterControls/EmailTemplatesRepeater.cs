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
    /// A designer class for a strongly typed repeater <c>EmailTemplatesRepeater</c>
    /// </summary>
	public class EmailTemplatesRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:EmailTemplatesRepeaterDesigner"/> class.
        /// </summary>
		public EmailTemplatesRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is EmailTemplatesRepeater))
			{ 
				throw new ArgumentException("Component is not a EmailTemplatesRepeater."); 
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
			EmailTemplatesRepeater z = (EmailTemplatesRepeater)Component;
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
    /// A strongly typed repeater control for the <c cref="EmailTemplatesRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(EmailTemplatesRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:EmailTemplatesRepeater runat=\"server\"></{0}:EmailTemplatesRepeater>")]
	public class EmailTemplatesRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:EmailTemplatesRepeater"/> class.
        /// </summary>
		public EmailTemplatesRepeater()
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
		[TemplateContainer(typeof(EmailTemplatesItem))]
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
		[TemplateContainer(typeof(EmailTemplatesItem))]
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
        [TemplateContainer(typeof(EmailTemplatesItem))]
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
		[TemplateContainer(typeof(EmailTemplatesItem))]
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
		[TemplateContainer(typeof(EmailTemplatesItem))]
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
						JXTPortal.Entities.EmailTemplates entity = o as JXTPortal.Entities.EmailTemplates;
						EmailTemplatesItem container = new EmailTemplatesItem(entity);
	
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
	public class EmailTemplatesItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private JXTPortal.Entities.EmailTemplates _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:EmailTemplatesItem"/> class.
        /// </summary>
		public EmailTemplatesItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:EmailTemplatesItem"/> class.
        /// </summary>
		public EmailTemplatesItem(JXTPortal.Entities.EmailTemplates entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the EmailTemplateId
        /// </summary>
        /// <value>The EmailTemplateId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 EmailTemplateId
		{
			get { return _entity.EmailTemplateId; }
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
        /// Gets the EmailTemplateParentId
        /// </summary>
        /// <value>The EmailTemplateParentId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 EmailTemplateParentId
		{
			get { return _entity.EmailTemplateParentId; }
		}
        /// <summary>
        /// Gets the EmailCode
        /// </summary>
        /// <value>The EmailCode.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String EmailCode
		{
			get { return _entity.EmailCode; }
		}
        /// <summary>
        /// Gets the EmailDescription
        /// </summary>
        /// <value>The EmailDescription.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String EmailDescription
		{
			get { return _entity.EmailDescription; }
		}
        /// <summary>
        /// Gets the EmailSubject
        /// </summary>
        /// <value>The EmailSubject.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String EmailSubject
		{
			get { return _entity.EmailSubject; }
		}
        /// <summary>
        /// Gets the EmailBodyText
        /// </summary>
        /// <value>The EmailBodyText.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String EmailBodyText
		{
			get { return _entity.EmailBodyText; }
		}
        /// <summary>
        /// Gets the EmailBodyHtml
        /// </summary>
        /// <value>The EmailBodyHtml.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String EmailBodyHtml
		{
			get { return _entity.EmailBodyHtml; }
		}
        /// <summary>
        /// Gets the EmailFields
        /// </summary>
        /// <value>The EmailFields.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String EmailFields
		{
			get { return _entity.EmailFields; }
		}
        /// <summary>
        /// Gets the EmailAddressName
        /// </summary>
        /// <value>The EmailAddressName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String EmailAddressName
		{
			get { return _entity.EmailAddressName; }
		}
        /// <summary>
        /// Gets the EmailAddressFrom
        /// </summary>
        /// <value>The EmailAddressFrom.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String EmailAddressFrom
		{
			get { return _entity.EmailAddressFrom; }
		}
        /// <summary>
        /// Gets the EmailAddressCc
        /// </summary>
        /// <value>The EmailAddressCc.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String EmailAddressCc
		{
			get { return _entity.EmailAddressCc; }
		}
        /// <summary>
        /// Gets the EmailAddressBcc
        /// </summary>
        /// <value>The EmailAddressBcc.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String EmailAddressBcc
		{
			get { return _entity.EmailAddressBcc; }
		}
        /// <summary>
        /// Gets the GlobalTemplate
        /// </summary>
        /// <value>The GlobalTemplate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean GlobalTemplate
		{
			get { return _entity.GlobalTemplate; }
		}
        /// <summary>
        /// Gets the LastModifiedBy
        /// </summary>
        /// <value>The LastModifiedBy.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 LastModifiedBy
		{
			get { return _entity.LastModifiedBy; }
		}
        /// <summary>
        /// Gets the LastModified
        /// </summary>
        /// <value>The LastModified.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime LastModified
		{
			get { return _entity.LastModified; }
		}

        /// <summary>
        /// Gets a <see cref="T:JXTPortal.Entities.EmailTemplates"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public JXTPortal.Entities.EmailTemplates Entity
        {
            get { return _entity; }
        }
	}
}
