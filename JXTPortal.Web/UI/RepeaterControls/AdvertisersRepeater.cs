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
    /// A designer class for a strongly typed repeater <c>AdvertisersRepeater</c>
    /// </summary>
	public class AdvertisersRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:AdvertisersRepeaterDesigner"/> class.
        /// </summary>
		public AdvertisersRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is AdvertisersRepeater))
			{ 
				throw new ArgumentException("Component is not a AdvertisersRepeater."); 
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
			AdvertisersRepeater z = (AdvertisersRepeater)Component;
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
    /// A strongly typed repeater control for the <c cref="AdvertisersRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(AdvertisersRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:AdvertisersRepeater runat=\"server\"></{0}:AdvertisersRepeater>")]
	public class AdvertisersRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:AdvertisersRepeater"/> class.
        /// </summary>
		public AdvertisersRepeater()
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
		[TemplateContainer(typeof(AdvertisersItem))]
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
		[TemplateContainer(typeof(AdvertisersItem))]
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
        [TemplateContainer(typeof(AdvertisersItem))]
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
		[TemplateContainer(typeof(AdvertisersItem))]
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
		[TemplateContainer(typeof(AdvertisersItem))]
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
						JXTPortal.Entities.Advertisers entity = o as JXTPortal.Entities.Advertisers;
						AdvertisersItem container = new AdvertisersItem(entity);
	
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
	public class AdvertisersItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private JXTPortal.Entities.Advertisers _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AdvertisersItem"/> class.
        /// </summary>
		public AdvertisersItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AdvertisersItem"/> class.
        /// </summary>
		public AdvertisersItem(JXTPortal.Entities.Advertisers entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the AdvertiserId
        /// </summary>
        /// <value>The AdvertiserId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 AdvertiserId
		{
			get { return _entity.AdvertiserId; }
		}
        /// <summary>
        /// Gets the SiteId
        /// </summary>
        /// <value>The SiteId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? SiteId
		{
			get { return _entity.SiteId; }
		}
        /// <summary>
        /// Gets the AdvertiserAccountTypeId
        /// </summary>
        /// <value>The AdvertiserAccountTypeId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 AdvertiserAccountTypeId
		{
			get { return _entity.AdvertiserAccountTypeId; }
		}
        /// <summary>
        /// Gets the AdvertiserBusinessTypeId
        /// </summary>
        /// <value>The AdvertiserBusinessTypeId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 AdvertiserBusinessTypeId
		{
			get { return _entity.AdvertiserBusinessTypeId; }
		}
        /// <summary>
        /// Gets the AdvertiserAccountStatusId
        /// </summary>
        /// <value>The AdvertiserAccountStatusId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 AdvertiserAccountStatusId
		{
			get { return _entity.AdvertiserAccountStatusId; }
		}
        /// <summary>
        /// Gets the CompanyName
        /// </summary>
        /// <value>The CompanyName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CompanyName
		{
			get { return _entity.CompanyName; }
		}
        /// <summary>
        /// Gets the BusinessNumber
        /// </summary>
        /// <value>The BusinessNumber.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String BusinessNumber
		{
			get { return _entity.BusinessNumber; }
		}
        /// <summary>
        /// Gets the StreetAddress1
        /// </summary>
        /// <value>The StreetAddress1.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String StreetAddress1
		{
			get { return _entity.StreetAddress1; }
		}
        /// <summary>
        /// Gets the StreetAddress2
        /// </summary>
        /// <value>The StreetAddress2.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String StreetAddress2
		{
			get { return _entity.StreetAddress2; }
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
        /// Gets the LastModifiedBy
        /// </summary>
        /// <value>The LastModifiedBy.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 LastModifiedBy
		{
			get { return _entity.LastModifiedBy; }
		}
        /// <summary>
        /// Gets the PostalAddress1
        /// </summary>
        /// <value>The PostalAddress1.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PostalAddress1
		{
			get { return _entity.PostalAddress1; }
		}
        /// <summary>
        /// Gets the PostalAddress2
        /// </summary>
        /// <value>The PostalAddress2.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PostalAddress2
		{
			get { return _entity.PostalAddress2; }
		}
        /// <summary>
        /// Gets the WebAddress
        /// </summary>
        /// <value>The WebAddress.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String WebAddress
		{
			get { return _entity.WebAddress; }
		}
        /// <summary>
        /// Gets the NoOfEmployees
        /// </summary>
        /// <value>The NoOfEmployees.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String NoOfEmployees
		{
			get { return _entity.NoOfEmployees; }
		}
        /// <summary>
        /// Gets the FirstApprovedDate
        /// </summary>
        /// <value>The FirstApprovedDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? FirstApprovedDate
		{
			get { return _entity.FirstApprovedDate; }
		}
        /// <summary>
        /// Gets the Profile
        /// </summary>
        /// <value>The Profile.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Profile
		{
			get { return _entity.Profile; }
		}
        /// <summary>
        /// Gets the CharityNumber
        /// </summary>
        /// <value>The CharityNumber.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CharityNumber
		{
			get { return _entity.CharityNumber; }
		}
        /// <summary>
        /// Gets the SearchField
        /// </summary>
        /// <value>The SearchField.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SearchField
		{
			get { return _entity.SearchField; }
		}
        /// <summary>
        /// Gets the FreeTrialStartDate
        /// </summary>
        /// <value>The FreeTrialStartDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? FreeTrialStartDate
		{
			get { return _entity.FreeTrialStartDate; }
		}
        /// <summary>
        /// Gets the FreeTrialEndDate
        /// </summary>
        /// <value>The FreeTrialEndDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? FreeTrialEndDate
		{
			get { return _entity.FreeTrialEndDate; }
		}
        /// <summary>
        /// Gets the AccountsPayableEmail
        /// </summary>
        /// <value>The AccountsPayableEmail.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String AccountsPayableEmail
		{
			get { return _entity.AccountsPayableEmail; }
		}
        /// <summary>
        /// Gets the RequireLogonForExternalApplication
        /// </summary>
        /// <value>The RequireLogonForExternalApplication.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean RequireLogonForExternalApplication
		{
			get { return _entity.RequireLogonForExternalApplication; }
		}
        /// <summary>
        /// Gets the AdvertiserLogo
        /// </summary>
        /// <value>The AdvertiserLogo.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Byte[] AdvertiserLogo
		{
			get { return _entity.AdvertiserLogo; }
		}
        /// <summary>
        /// Gets the LinkedInLogo
        /// </summary>
        /// <value>The LinkedInLogo.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String LinkedInLogo
		{
			get { return _entity.LinkedInLogo; }
		}
        /// <summary>
        /// Gets the LinkedInEmail
        /// </summary>
        /// <value>The LinkedInEmail.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String LinkedInEmail
		{
			get { return _entity.LinkedInEmail; }
		}

        /// <summary>
        /// Gets a <see cref="T:JXTPortal.Entities.Advertisers"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public JXTPortal.Entities.Advertisers Entity
        {
            get { return _entity; }
        }
	}
}
