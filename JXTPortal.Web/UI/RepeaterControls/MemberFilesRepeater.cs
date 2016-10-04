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
    /// A designer class for a strongly typed repeater <c>MemberFilesRepeater</c>
    /// </summary>
	public class MemberFilesRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:MemberFilesRepeaterDesigner"/> class.
        /// </summary>
		public MemberFilesRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is MemberFilesRepeater))
			{ 
				throw new ArgumentException("Component is not a MemberFilesRepeater."); 
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
			MemberFilesRepeater z = (MemberFilesRepeater)Component;
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
    /// A strongly typed repeater control for the <c cref="MemberFilesRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(MemberFilesRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:MemberFilesRepeater runat=\"server\"></{0}:MemberFilesRepeater>")]
	public class MemberFilesRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:MemberFilesRepeater"/> class.
        /// </summary>
		public MemberFilesRepeater()
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
		[TemplateContainer(typeof(MemberFilesItem))]
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
		[TemplateContainer(typeof(MemberFilesItem))]
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
        [TemplateContainer(typeof(MemberFilesItem))]
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
		[TemplateContainer(typeof(MemberFilesItem))]
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
		[TemplateContainer(typeof(MemberFilesItem))]
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
						JXTPortal.Entities.MemberFiles entity = o as JXTPortal.Entities.MemberFiles;
						MemberFilesItem container = new MemberFilesItem(entity);
	
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
	public class MemberFilesItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private JXTPortal.Entities.MemberFiles _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:MemberFilesItem"/> class.
        /// </summary>
		public MemberFilesItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:MemberFilesItem"/> class.
        /// </summary>
		public MemberFilesItem(JXTPortal.Entities.MemberFiles entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the MemberFileId
        /// </summary>
        /// <value>The MemberFileId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 MemberFileId
		{
			get { return _entity.MemberFileId; }
		}
        /// <summary>
        /// Gets the MemberId
        /// </summary>
        /// <value>The MemberId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 MemberId
		{
			get { return _entity.MemberId; }
		}
        /// <summary>
        /// Gets the MemberFileTypeId
        /// </summary>
        /// <value>The MemberFileTypeId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 MemberFileTypeId
		{
			get { return _entity.MemberFileTypeId; }
		}
        /// <summary>
        /// Gets the MemberFileName
        /// </summary>
        /// <value>The MemberFileName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String MemberFileName
		{
			get { return _entity.MemberFileName; }
		}
        /// <summary>
        /// Gets the MemberFileSearchExtension
        /// </summary>
        /// <value>The MemberFileSearchExtension.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String MemberFileSearchExtension
		{
			get { return _entity.MemberFileSearchExtension; }
		}
        /// <summary>
        /// Gets the MemberFileContent
        /// </summary>
        /// <value>The MemberFileContent.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Byte[] MemberFileContent
		{
			get { return _entity.MemberFileContent; }
		}
        /// <summary>
        /// Gets the MemberFileTitle
        /// </summary>
        /// <value>The MemberFileTitle.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String MemberFileTitle
		{
			get { return _entity.MemberFileTitle; }
		}
        /// <summary>
        /// Gets the LastModifiedDate
        /// </summary>
        /// <value>The LastModifiedDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime LastModifiedDate
		{
			get { return _entity.LastModifiedDate; }
		}
        /// <summary>
        /// Gets the DocumentTypeId
        /// </summary>
        /// <value>The DocumentTypeId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? DocumentTypeId
		{
			get { return _entity.DocumentTypeId; }
		}

        /// <summary>
        /// Gets a <see cref="T:JXTPortal.Entities.MemberFiles"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public JXTPortal.Entities.MemberFiles Entity
        {
            get { return _entity; }
        }
	}
}
