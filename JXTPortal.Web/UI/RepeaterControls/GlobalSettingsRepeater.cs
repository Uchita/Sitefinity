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
    /// A designer class for a strongly typed repeater <c>GlobalSettingsRepeater</c>
    /// </summary>
	public class GlobalSettingsRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:GlobalSettingsRepeaterDesigner"/> class.
        /// </summary>
		public GlobalSettingsRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is GlobalSettingsRepeater))
			{ 
				throw new ArgumentException("Component is not a GlobalSettingsRepeater."); 
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
			GlobalSettingsRepeater z = (GlobalSettingsRepeater)Component;
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
    /// A strongly typed repeater control for the <c cref="GlobalSettingsRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(GlobalSettingsRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:GlobalSettingsRepeater runat=\"server\"></{0}:GlobalSettingsRepeater>")]
	public class GlobalSettingsRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:GlobalSettingsRepeater"/> class.
        /// </summary>
		public GlobalSettingsRepeater()
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
		[TemplateContainer(typeof(GlobalSettingsItem))]
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
		[TemplateContainer(typeof(GlobalSettingsItem))]
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
        [TemplateContainer(typeof(GlobalSettingsItem))]
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
		[TemplateContainer(typeof(GlobalSettingsItem))]
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
		[TemplateContainer(typeof(GlobalSettingsItem))]
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
						JXTPortal.Entities.GlobalSettings entity = o as JXTPortal.Entities.GlobalSettings;
						GlobalSettingsItem container = new GlobalSettingsItem(entity);
	
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
	public class GlobalSettingsItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private JXTPortal.Entities.GlobalSettings _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:GlobalSettingsItem"/> class.
        /// </summary>
		public GlobalSettingsItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:GlobalSettingsItem"/> class.
        /// </summary>
		public GlobalSettingsItem(JXTPortal.Entities.GlobalSettings entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the GlobalSettingId
        /// </summary>
        /// <value>The GlobalSettingId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 GlobalSettingId
		{
			get { return _entity.GlobalSettingId; }
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
        /// Gets the DefaultLanguageId
        /// </summary>
        /// <value>The DefaultLanguageId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 DefaultLanguageId
		{
			get { return _entity.DefaultLanguageId; }
		}
        /// <summary>
        /// Gets the DefaultDynamicPageId
        /// </summary>
        /// <value>The DefaultDynamicPageId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? DefaultDynamicPageId
		{
			get { return _entity.DefaultDynamicPageId; }
		}
        /// <summary>
        /// Gets the PublicJobsSearch
        /// </summary>
        /// <value>The PublicJobsSearch.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean PublicJobsSearch
		{
			get { return _entity.PublicJobsSearch; }
		}
        /// <summary>
        /// Gets the PublicMembersSearch
        /// </summary>
        /// <value>The PublicMembersSearch.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean PublicMembersSearch
		{
			get { return _entity.PublicMembersSearch; }
		}
        /// <summary>
        /// Gets the PublicCompaniesSearch
        /// </summary>
        /// <value>The PublicCompaniesSearch.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean PublicCompaniesSearch
		{
			get { return _entity.PublicCompaniesSearch; }
		}
        /// <summary>
        /// Gets the PublicSponsoredAdverts
        /// </summary>
        /// <value>The PublicSponsoredAdverts.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean PublicSponsoredAdverts
		{
			get { return _entity.PublicSponsoredAdverts; }
		}
        /// <summary>
        /// Gets the PrivateJobs
        /// </summary>
        /// <value>The PrivateJobs.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean PrivateJobs
		{
			get { return _entity.PrivateJobs; }
		}
        /// <summary>
        /// Gets the PrivateMembers
        /// </summary>
        /// <value>The PrivateMembers.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean PrivateMembers
		{
			get { return _entity.PrivateMembers; }
		}
        /// <summary>
        /// Gets the PrivateCompanies
        /// </summary>
        /// <value>The PrivateCompanies.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean PrivateCompanies
		{
			get { return _entity.PrivateCompanies; }
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
        /// Gets the PageTitlePrefix
        /// </summary>
        /// <value>The PageTitlePrefix.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PageTitlePrefix
		{
			get { return _entity.PageTitlePrefix; }
		}
        /// <summary>
        /// Gets the PageTitleSuffix
        /// </summary>
        /// <value>The PageTitleSuffix.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PageTitleSuffix
		{
			get { return _entity.PageTitleSuffix; }
		}
        /// <summary>
        /// Gets the DefaultTitle
        /// </summary>
        /// <value>The DefaultTitle.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String DefaultTitle
		{
			get { return _entity.DefaultTitle; }
		}
        /// <summary>
        /// Gets the HomeTitle
        /// </summary>
        /// <value>The HomeTitle.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String HomeTitle
		{
			get { return _entity.HomeTitle; }
		}
        /// <summary>
        /// Gets the DefaultDescription
        /// </summary>
        /// <value>The DefaultDescription.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String DefaultDescription
		{
			get { return _entity.DefaultDescription; }
		}
        /// <summary>
        /// Gets the HomeDescription
        /// </summary>
        /// <value>The HomeDescription.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String HomeDescription
		{
			get { return _entity.HomeDescription; }
		}
        /// <summary>
        /// Gets the DefaultKeywords
        /// </summary>
        /// <value>The DefaultKeywords.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String DefaultKeywords
		{
			get { return _entity.DefaultKeywords; }
		}
        /// <summary>
        /// Gets the HomeKeywords
        /// </summary>
        /// <value>The HomeKeywords.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String HomeKeywords
		{
			get { return _entity.HomeKeywords; }
		}
        /// <summary>
        /// Gets the ShowFaceBookButton
        /// </summary>
        /// <value>The ShowFaceBookButton.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean ShowFaceBookButton
		{
			get { return _entity.ShowFaceBookButton; }
		}
        /// <summary>
        /// Gets the UseAdvertiserFilter
        /// </summary>
        /// <value>The UseAdvertiserFilter.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 UseAdvertiserFilter
		{
			get { return _entity.UseAdvertiserFilter; }
		}
        /// <summary>
        /// Gets the MerchantId
        /// </summary>
        /// <value>The MerchantId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? MerchantId
		{
			get { return _entity.MerchantId; }
		}
        /// <summary>
        /// Gets the ShowTwitterButton
        /// </summary>
        /// <value>The ShowTwitterButton.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean ShowTwitterButton
		{
			get { return _entity.ShowTwitterButton; }
		}
        /// <summary>
        /// Gets the ShowJobAlertButton
        /// </summary>
        /// <value>The ShowJobAlertButton.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean ShowJobAlertButton
		{
			get { return _entity.ShowJobAlertButton; }
		}
        /// <summary>
        /// Gets the ShowLinkedInButton
        /// </summary>
        /// <value>The ShowLinkedInButton.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean ShowLinkedInButton
		{
			get { return _entity.ShowLinkedInButton; }
		}
        /// <summary>
        /// Gets the SiteFavIconId
        /// </summary>
        /// <value>The SiteFavIconId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? SiteFavIconId
		{
			get { return _entity.SiteFavIconId; }
		}
        /// <summary>
        /// Gets the SiteDocType
        /// </summary>
        /// <value>The SiteDocType.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SiteDocType
		{
			get { return _entity.SiteDocType; }
		}
        /// <summary>
        /// Gets the CurrencySymbol
        /// </summary>
        /// <value>The CurrencySymbol.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CurrencySymbol
		{
			get { return _entity.CurrencySymbol; }
		}
        /// <summary>
        /// Gets the FtpFolderLocation
        /// </summary>
        /// <value>The FtpFolderLocation.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String FtpFolderLocation
		{
			get { return _entity.FtpFolderLocation; }
		}
        /// <summary>
        /// Gets the MetaTags
        /// </summary>
        /// <value>The MetaTags.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String MetaTags
		{
			get { return _entity.MetaTags; }
		}
        /// <summary>
        /// Gets the SystemMetaTags
        /// </summary>
        /// <value>The SystemMetaTags.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SystemMetaTags
		{
			get { return _entity.SystemMetaTags; }
		}
        /// <summary>
        /// Gets the MemberRegistrationNotification
        /// </summary>
        /// <value>The MemberRegistrationNotification.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String MemberRegistrationNotification
		{
			get { return _entity.MemberRegistrationNotification; }
		}
        /// <summary>
        /// Gets the LinkedInApi
        /// </summary>
        /// <value>The LinkedInApi.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String LinkedInApi
		{
			get { return _entity.LinkedInApi; }
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
        /// Gets the LinkedInCompanyId
        /// </summary>
        /// <value>The LinkedInCompanyId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? LinkedInCompanyId
		{
			get { return _entity.LinkedInCompanyId; }
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
        /// Gets the PrivacySettings
        /// </summary>
        /// <value>The PrivacySettings.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PrivacySettings
		{
			get { return _entity.PrivacySettings; }
		}
        /// <summary>
        /// Gets the AllowAdvertiser
        /// </summary>
        /// <value>The AllowAdvertiser.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean AllowAdvertiser
		{
			get { return _entity.AllowAdvertiser; }
		}
        /// <summary>
        /// Gets the LinkedInApiSecret
        /// </summary>
        /// <value>The LinkedInApiSecret.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String LinkedInApiSecret
		{
			get { return _entity.LinkedInApiSecret; }
		}
        /// <summary>
        /// Gets the GoogleClientId
        /// </summary>
        /// <value>The GoogleClientId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String GoogleClientId
		{
			get { return _entity.GoogleClientId; }
		}
        /// <summary>
        /// Gets the GoogleClientSecret
        /// </summary>
        /// <value>The GoogleClientSecret.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String GoogleClientSecret
		{
			get { return _entity.GoogleClientSecret; }
		}
        /// <summary>
        /// Gets the FacebookAppId
        /// </summary>
        /// <value>The FacebookAppId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String FacebookAppId
		{
			get { return _entity.FacebookAppId; }
		}
        /// <summary>
        /// Gets the FacebookAppSecret
        /// </summary>
        /// <value>The FacebookAppSecret.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String FacebookAppSecret
		{
			get { return _entity.FacebookAppSecret; }
		}
        /// <summary>
        /// Gets the LinkedInButtonSize
        /// </summary>
        /// <value>The LinkedInButtonSize.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? LinkedInButtonSize
		{
			get { return _entity.LinkedInButtonSize; }
		}
        /// <summary>
        /// Gets the WwwRedirect
        /// </summary>
        /// <value>The WwwRedirect.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean WwwRedirect
		{
			get { return _entity.WwwRedirect; }
		}

        /// <summary>
        /// Gets a <see cref="T:JXTPortal.Entities.GlobalSettings"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public JXTPortal.Entities.GlobalSettings Entity
        {
            get { return _entity; }
        }
	}
}
