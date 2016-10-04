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
    /// A designer class for a strongly typed repeater <c>MembersRepeater</c>
    /// </summary>
	public class MembersRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:MembersRepeaterDesigner"/> class.
        /// </summary>
		public MembersRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is MembersRepeater))
			{ 
				throw new ArgumentException("Component is not a MembersRepeater."); 
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
			MembersRepeater z = (MembersRepeater)Component;
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
    /// A strongly typed repeater control for the <c cref="MembersRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(MembersRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:MembersRepeater runat=\"server\"></{0}:MembersRepeater>")]
	public class MembersRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:MembersRepeater"/> class.
        /// </summary>
		public MembersRepeater()
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
		[TemplateContainer(typeof(MembersItem))]
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
		[TemplateContainer(typeof(MembersItem))]
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
        [TemplateContainer(typeof(MembersItem))]
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
		[TemplateContainer(typeof(MembersItem))]
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
		[TemplateContainer(typeof(MembersItem))]
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
						JXTPortal.Entities.Members entity = o as JXTPortal.Entities.Members;
						MembersItem container = new MembersItem(entity);
	
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
	public class MembersItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private JXTPortal.Entities.Members _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:MembersItem"/> class.
        /// </summary>
		public MembersItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:MembersItem"/> class.
        /// </summary>
		public MembersItem(JXTPortal.Entities.Members entity)
			: base()
		{
			_entity = entity;
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
        /// Gets the SiteId
        /// </summary>
        /// <value>The SiteId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 SiteId
		{
			get { return _entity.SiteId; }
		}
        /// <summary>
        /// Gets the Username
        /// </summary>
        /// <value>The Username.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Username
		{
			get { return _entity.Username; }
		}
        /// <summary>
        /// Gets the Password
        /// </summary>
        /// <value>The Password.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Password
		{
			get { return _entity.Password; }
		}
        /// <summary>
        /// Gets the Title
        /// </summary>
        /// <value>The Title.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Title
		{
			get { return _entity.Title; }
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
        /// Gets the EmailAddress
        /// </summary>
        /// <value>The EmailAddress.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String EmailAddress
		{
			get { return _entity.EmailAddress; }
		}
        /// <summary>
        /// Gets the Company
        /// </summary>
        /// <value>The Company.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Company
		{
			get { return _entity.Company; }
		}
        /// <summary>
        /// Gets the Position
        /// </summary>
        /// <value>The Position.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Position
		{
			get { return _entity.Position; }
		}
        /// <summary>
        /// Gets the HomePhone
        /// </summary>
        /// <value>The HomePhone.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String HomePhone
		{
			get { return _entity.HomePhone; }
		}
        /// <summary>
        /// Gets the WorkPhone
        /// </summary>
        /// <value>The WorkPhone.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String WorkPhone
		{
			get { return _entity.WorkPhone; }
		}
        /// <summary>
        /// Gets the MobilePhone
        /// </summary>
        /// <value>The MobilePhone.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String MobilePhone
		{
			get { return _entity.MobilePhone; }
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
        /// Gets the Address1
        /// </summary>
        /// <value>The Address1.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Address1
		{
			get { return _entity.Address1; }
		}
        /// <summary>
        /// Gets the Address2
        /// </summary>
        /// <value>The Address2.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Address2
		{
			get { return _entity.Address2; }
		}
        /// <summary>
        /// Gets the LocationId
        /// </summary>
        /// <value>The LocationId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String LocationId
		{
			get { return _entity.LocationId; }
		}
        /// <summary>
        /// Gets the AreaId
        /// </summary>
        /// <value>The AreaId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String AreaId
		{
			get { return _entity.AreaId; }
		}
        /// <summary>
        /// Gets the CountryId
        /// </summary>
        /// <value>The CountryId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 CountryId
		{
			get { return _entity.CountryId; }
		}
        /// <summary>
        /// Gets the PreferredCategoryId
        /// </summary>
        /// <value>The PreferredCategoryId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PreferredCategoryId
		{
			get { return _entity.PreferredCategoryId; }
		}
        /// <summary>
        /// Gets the PreferredSubCategoryId
        /// </summary>
        /// <value>The PreferredSubCategoryId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PreferredSubCategoryId
		{
			get { return _entity.PreferredSubCategoryId; }
		}
        /// <summary>
        /// Gets the PreferredSalaryId
        /// </summary>
        /// <value>The PreferredSalaryId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? PreferredSalaryId
		{
			get { return _entity.PreferredSalaryId; }
		}
        /// <summary>
        /// Gets the Subscribed
        /// </summary>
        /// <value>The Subscribed.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean Subscribed
		{
			get { return _entity.Subscribed; }
		}
        /// <summary>
        /// Gets the MonthlyUpdate
        /// </summary>
        /// <value>The MonthlyUpdate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean MonthlyUpdate
		{
			get { return _entity.MonthlyUpdate; }
		}
        /// <summary>
        /// Gets the ReferringMemberId
        /// </summary>
        /// <value>The ReferringMemberId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? ReferringMemberId
		{
			get { return _entity.ReferringMemberId; }
		}
        /// <summary>
        /// Gets the LastModifiedDate
        /// </summary>
        /// <value>The LastModifiedDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? LastModifiedDate
		{
			get { return _entity.LastModifiedDate; }
		}
        /// <summary>
        /// Gets the Valid
        /// </summary>
        /// <value>The Valid.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean Valid
		{
			get { return _entity.Valid; }
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
        /// Gets the LastLogon
        /// </summary>
        /// <value>The LastLogon.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? LastLogon
		{
			get { return _entity.LastLogon; }
		}
        /// <summary>
        /// Gets the DateOfBirth
        /// </summary>
        /// <value>The DateOfBirth.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? DateOfBirth
		{
			get { return _entity.DateOfBirth; }
		}
        /// <summary>
        /// Gets the Gender
        /// </summary>
        /// <value>The Gender.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Gender
		{
			get { return _entity.Gender; }
		}
        /// <summary>
        /// Gets the Tags
        /// </summary>
        /// <value>The Tags.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Tags
		{
			get { return _entity.Tags; }
		}
        /// <summary>
        /// Gets the Validated
        /// </summary>
        /// <value>The Validated.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean Validated
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
        /// Gets the MemberUrlExtension
        /// </summary>
        /// <value>The MemberUrlExtension.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String MemberUrlExtension
		{
			get { return _entity.MemberUrlExtension; }
		}
        /// <summary>
        /// Gets the WebsiteUrl
        /// </summary>
        /// <value>The WebsiteUrl.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String WebsiteUrl
		{
			get { return _entity.WebsiteUrl; }
		}
        /// <summary>
        /// Gets the AvailabilityId
        /// </summary>
        /// <value>The AvailabilityId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? AvailabilityId
		{
			get { return _entity.AvailabilityId; }
		}
        /// <summary>
        /// Gets the AvailabilityFromDate
        /// </summary>
        /// <value>The AvailabilityFromDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? AvailabilityFromDate
		{
			get { return _entity.AvailabilityFromDate; }
		}
        /// <summary>
        /// Gets the MySpaceHeading
        /// </summary>
        /// <value>The MySpaceHeading.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String MySpaceHeading
		{
			get { return _entity.MySpaceHeading; }
		}
        /// <summary>
        /// Gets the MySpaceContent
        /// </summary>
        /// <value>The MySpaceContent.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String MySpaceContent
		{
			get { return _entity.MySpaceContent; }
		}
        /// <summary>
        /// Gets the UrlReferrer
        /// </summary>
        /// <value>The UrlReferrer.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String UrlReferrer
		{
			get { return _entity.UrlReferrer; }
		}
        /// <summary>
        /// Gets the RequiredPasswordChange
        /// </summary>
        /// <value>The RequiredPasswordChange.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? RequiredPasswordChange
		{
			get { return _entity.RequiredPasswordChange; }
		}
        /// <summary>
        /// Gets the PreferredJobTitle
        /// </summary>
        /// <value>The PreferredJobTitle.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PreferredJobTitle
		{
			get { return _entity.PreferredJobTitle; }
		}
        /// <summary>
        /// Gets the PreferredAvailability
        /// </summary>
        /// <value>The PreferredAvailability.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PreferredAvailability
		{
			get { return _entity.PreferredAvailability; }
		}
        /// <summary>
        /// Gets the PreferredAvailabilityType
        /// </summary>
        /// <value>The PreferredAvailabilityType.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? PreferredAvailabilityType
		{
			get { return _entity.PreferredAvailabilityType; }
		}
        /// <summary>
        /// Gets the PreferredSalaryFrom
        /// </summary>
        /// <value>The PreferredSalaryFrom.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PreferredSalaryFrom
		{
			get { return _entity.PreferredSalaryFrom; }
		}
        /// <summary>
        /// Gets the PreferredSalaryTo
        /// </summary>
        /// <value>The PreferredSalaryTo.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PreferredSalaryTo
		{
			get { return _entity.PreferredSalaryTo; }
		}
        /// <summary>
        /// Gets the CurrentSalaryFrom
        /// </summary>
        /// <value>The CurrentSalaryFrom.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CurrentSalaryFrom
		{
			get { return _entity.CurrentSalaryFrom; }
		}
        /// <summary>
        /// Gets the CurrentSalaryTo
        /// </summary>
        /// <value>The CurrentSalaryTo.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CurrentSalaryTo
		{
			get { return _entity.CurrentSalaryTo; }
		}
        /// <summary>
        /// Gets the LookingFor
        /// </summary>
        /// <value>The LookingFor.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String LookingFor
		{
			get { return _entity.LookingFor; }
		}
        /// <summary>
        /// Gets the Experience
        /// </summary>
        /// <value>The Experience.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Experience
		{
			get { return _entity.Experience; }
		}
        /// <summary>
        /// Gets the Skills
        /// </summary>
        /// <value>The Skills.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Skills
		{
			get { return _entity.Skills; }
		}
        /// <summary>
        /// Gets the Reasons
        /// </summary>
        /// <value>The Reasons.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Reasons
		{
			get { return _entity.Reasons; }
		}
        /// <summary>
        /// Gets the Comments
        /// </summary>
        /// <value>The Comments.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Comments
		{
			get { return _entity.Comments; }
		}
        /// <summary>
        /// Gets the ProfileType
        /// </summary>
        /// <value>The ProfileType.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ProfileType
		{
			get { return _entity.ProfileType; }
		}
        /// <summary>
        /// Gets the EducationId
        /// </summary>
        /// <value>The EducationId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? EducationId
		{
			get { return _entity.EducationId; }
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
        /// Gets the RegisteredDate
        /// </summary>
        /// <value>The RegisteredDate.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime RegisteredDate
		{
			get { return _entity.RegisteredDate; }
		}
        /// <summary>
        /// Gets the States
        /// </summary>
        /// <value>The States.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String States
		{
			get { return _entity.States; }
		}
        /// <summary>
        /// Gets the Suburb
        /// </summary>
        /// <value>The Suburb.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Suburb
		{
			get { return _entity.Suburb; }
		}
        /// <summary>
        /// Gets the PostCode
        /// </summary>
        /// <value>The PostCode.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PostCode
		{
			get { return _entity.PostCode; }
		}
        /// <summary>
        /// Gets the ProfilePicture
        /// </summary>
        /// <value>The ProfilePicture.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ProfilePicture
		{
			get { return _entity.ProfilePicture; }
		}
        /// <summary>
        /// Gets the ShortBio
        /// </summary>
        /// <value>The ShortBio.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ShortBio
		{
			get { return _entity.ShortBio; }
		}
        /// <summary>
        /// Gets the WorkTypeId
        /// </summary>
        /// <value>The WorkTypeId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String WorkTypeId
		{
			get { return _entity.WorkTypeId; }
		}
        /// <summary>
        /// Gets the Memberships
        /// </summary>
        /// <value>The Memberships.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String Memberships
		{
			get { return _entity.Memberships; }
		}
        /// <summary>
        /// Gets the MemberStatusId
        /// </summary>
        /// <value>The MemberStatusId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? MemberStatusId
		{
			get { return _entity.MemberStatusId; }
		}
        /// <summary>
        /// Gets the LinkedInAccessToken
        /// </summary>
        /// <value>The LinkedInAccessToken.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String LinkedInAccessToken
		{
			get { return _entity.LinkedInAccessToken; }
		}
        /// <summary>
        /// Gets the ExternalMemberId
        /// </summary>
        /// <value>The ExternalMemberId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ExternalMemberId
		{
			get { return _entity.ExternalMemberId; }
		}
        /// <summary>
        /// Gets the PassportNo
        /// </summary>
        /// <value>The PassportNo.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String PassportNo
		{
			get { return _entity.PassportNo; }
		}
        /// <summary>
        /// Gets the MailingAddress1
        /// </summary>
        /// <value>The MailingAddress1.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String MailingAddress1
		{
			get { return _entity.MailingAddress1; }
		}
        /// <summary>
        /// Gets the MailingAddress2
        /// </summary>
        /// <value>The MailingAddress2.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String MailingAddress2
		{
			get { return _entity.MailingAddress2; }
		}
        /// <summary>
        /// Gets the MailingStates
        /// </summary>
        /// <value>The MailingStates.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String MailingStates
		{
			get { return _entity.MailingStates; }
		}
        /// <summary>
        /// Gets the MailingSuburb
        /// </summary>
        /// <value>The MailingSuburb.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String MailingSuburb
		{
			get { return _entity.MailingSuburb; }
		}
        /// <summary>
        /// Gets the MailingPostCode
        /// </summary>
        /// <value>The MailingPostCode.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String MailingPostCode
		{
			get { return _entity.MailingPostCode; }
		}
        /// <summary>
        /// Gets the MailingCountryId
        /// </summary>
        /// <value>The MailingCountryId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? MailingCountryId
		{
			get { return _entity.MailingCountryId; }
		}
        /// <summary>
        /// Gets the CountryName
        /// </summary>
        /// <value>The CountryName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CountryName
		{
			get { return _entity.CountryName; }
		}
        /// <summary>
        /// Gets the MailingCountryName
        /// </summary>
        /// <value>The MailingCountryName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String MailingCountryName
		{
			get { return _entity.MailingCountryName; }
		}

        /// <summary>
        /// Gets a <see cref="T:JXTPortal.Entities.Members"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public JXTPortal.Entities.Members Entity
        {
            get { return _entity; }
        }
	}
}
