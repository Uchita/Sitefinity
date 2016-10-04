﻿using System;
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
    /// A designer class for a strongly typed repeater <c>AdvertiserUsersRepeater</c>
    /// </summary>
	public class AdvertiserUsersRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:AdvertiserUsersRepeaterDesigner"/> class.
        /// </summary>
		public AdvertiserUsersRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is AdvertiserUsersRepeater))
			{ 
				throw new ArgumentException("Component is not a AdvertiserUsersRepeater."); 
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
			AdvertiserUsersRepeater z = (AdvertiserUsersRepeater)Component;
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
    /// A strongly typed repeater control for the <c cref="AdvertiserUsersRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(AdvertiserUsersRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:AdvertiserUsersRepeater runat=\"server\"></{0}:AdvertiserUsersRepeater>")]
	public class AdvertiserUsersRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:AdvertiserUsersRepeater"/> class.
        /// </summary>
		public AdvertiserUsersRepeater()
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
		[TemplateContainer(typeof(AdvertiserUsersItem))]
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
		[TemplateContainer(typeof(AdvertiserUsersItem))]
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
        [TemplateContainer(typeof(AdvertiserUsersItem))]
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
		[TemplateContainer(typeof(AdvertiserUsersItem))]
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
		[TemplateContainer(typeof(AdvertiserUsersItem))]
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
						JXTPortal.Entities.AdvertiserUsers entity = o as JXTPortal.Entities.AdvertiserUsers;
						AdvertiserUsersItem container = new AdvertiserUsersItem(entity);
	
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
	public class AdvertiserUsersItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private JXTPortal.Entities.AdvertiserUsers _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AdvertiserUsersItem"/> class.
        /// </summary>
		public AdvertiserUsersItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AdvertiserUsersItem"/> class.
        /// </summary>
		public AdvertiserUsersItem(JXTPortal.Entities.AdvertiserUsers entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the AdvertiserUserId
        /// </summary>
        /// <value>The AdvertiserUserId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 AdvertiserUserId
		{
			get { return _entity.AdvertiserUserId; }
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
        /// Gets the PrimaryAccount
        /// </summary>
        /// <value>The PrimaryAccount.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean PrimaryAccount
		{
			get { return _entity.PrimaryAccount; }
		}
        /// <summary>
        /// Gets the UserName
        /// </summary>
        /// <value>The UserName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String UserName
		{
			get { return _entity.UserName; }
		}
        /// <summary>
        /// Gets the UserPassword
        /// </summary>
        /// <value>The UserPassword.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String UserPassword
		{
			get { return _entity.UserPassword; }
		}
        /// <summary>
        /// Gets the FirstName
        /// </summary>
        /// <value>The FirstName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String FirstName
		{
			get { return _entity.FirstName; }
		}
        /// <summary>
        /// Gets the Surname
        /// </summary>
        /// <value>The Surname.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Surname
		{
			get { return _entity.Surname; }
		}
        /// <summary>
        /// Gets the Email
        /// </summary>
        /// <value>The Email.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Email
		{
			get { return _entity.Email; }
		}
        /// <summary>
        /// Gets the ApplicationEmailAddress
        /// </summary>
        /// <value>The ApplicationEmailAddress.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ApplicationEmailAddress
		{
			get { return _entity.ApplicationEmailAddress; }
		}
        /// <summary>
        /// Gets the Phone
        /// </summary>
        /// <value>The Phone.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Phone
		{
			get { return _entity.Phone; }
		}
        /// <summary>
        /// Gets the Fax
        /// </summary>
        /// <value>The Fax.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Fax
		{
			get { return _entity.Fax; }
		}
        /// <summary>
        /// Gets the AccountStatus
        /// </summary>
        /// <value>The AccountStatus.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? AccountStatus
		{
			get { return _entity.AccountStatus; }
		}
        /// <summary>
        /// Gets the Newsletter
        /// </summary>
        /// <value>The Newsletter.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean Newsletter
		{
			get { return _entity.Newsletter; }
		}
        /// <summary>
        /// Gets the NewsletterFormat
        /// </summary>
        /// <value>The NewsletterFormat.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 NewsletterFormat
		{
			get { return _entity.NewsletterFormat; }
		}
        /// <summary>
        /// Gets the EmailFormat
        /// </summary>
        /// <value>The EmailFormat.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 EmailFormat
		{
			get { return _entity.EmailFormat; }
		}
        /// <summary>
        /// Gets the Validated
        /// </summary>
        /// <value>The Validated.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? Validated
		{
			get { return _entity.Validated; }
		}
        /// <summary>
        /// Gets the ValidateGuid
        /// </summary>
        /// <value>The ValidateGuid.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Guid? ValidateGuid
		{
			get { return _entity.ValidateGuid; }
		}
        /// <summary>
        /// Gets the Description
        /// </summary>
        /// <value>The Description.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Description
		{
			get { return _entity.Description; }
		}
        /// <summary>
        /// Gets the LastLoginDate
        /// </summary>
        /// <value>The LastLoginDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? LastLoginDate
		{
			get { return _entity.LastLoginDate; }
		}
        /// <summary>
        /// Gets the LastModified
        /// </summary>
        /// <value>The LastModified.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? LastModified
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
        /// Gets a <see cref="T:JXTPortal.Entities.AdvertiserUsers"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public JXTPortal.Entities.AdvertiserUsers Entity
        {
            get { return _entity; }
        }
	}
}
