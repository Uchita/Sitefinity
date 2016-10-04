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
    /// A designer class for a strongly typed repeater <c>JobAlertsRepeater</c>
    /// </summary>
	public class JobAlertsRepeaterDesigner : System.Web.UI.Design.ControlDesigner
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:JobAlertsRepeaterDesigner"/> class.
        /// </summary>
		public JobAlertsRepeaterDesigner()
		{
		}

        /// <summary>
        /// Initializes the control designer and loads the specified component.
        /// </summary>
        /// <param name="component">The control being designed.</param>
		public override void Initialize(IComponent component)
		{
			if (!(component is JobAlertsRepeater))
			{ 
				throw new ArgumentException("Component is not a JobAlertsRepeater."); 
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
			JobAlertsRepeater z = (JobAlertsRepeater)Component;
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
    /// A strongly typed repeater control for the <c cref="JobAlertsRepeater"></c> Type.
    /// </summary>
	[Designer(typeof(JobAlertsRepeaterDesigner))]
	[ParseChildren(true)]
	[ToolboxData("<{0}:JobAlertsRepeater runat=\"server\"></{0}:JobAlertsRepeater>")]
	public class JobAlertsRepeater : CompositeDataBoundControl, System.Web.UI.INamingContainer
	{
	    /// <summary>
        /// Initializes a new instance of the <see cref="T:JobAlertsRepeater"/> class.
        /// </summary>
		public JobAlertsRepeater()
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
		[TemplateContainer(typeof(JobAlertsItem))]
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
		[TemplateContainer(typeof(JobAlertsItem))]
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
        [TemplateContainer(typeof(JobAlertsItem))]
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
		[TemplateContainer(typeof(JobAlertsItem))]
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
		[TemplateContainer(typeof(JobAlertsItem))]
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
						JXTPortal.Entities.JobAlerts entity = o as JXTPortal.Entities.JobAlerts;
						JobAlertsItem container = new JobAlertsItem(entity);
	
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
	public class JobAlertsItem : System.Web.UI.Control, System.Web.UI.INamingContainer
	{
		private JXTPortal.Entities.JobAlerts _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:JobAlertsItem"/> class.
        /// </summary>
		public JobAlertsItem()
			: base()
		{ }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:JobAlertsItem"/> class.
        /// </summary>
		public JobAlertsItem(JXTPortal.Entities.JobAlerts entity)
			: base()
		{
			_entity = entity;
		}
		
        /// <summary>
        /// Gets the JobAlertId
        /// </summary>
        /// <value>The JobAlertId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32 JobAlertId
		{
			get { return _entity.JobAlertId; }
		}
        /// <summary>
        /// Gets the JobAlertName
        /// </summary>
        /// <value>The JobAlertName.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String JobAlertName
		{
			get { return _entity.JobAlertName; }
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
        /// Gets the SearchKeywords
        /// </summary>
        /// <value>The SearchKeywords.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SearchKeywords
		{
			get { return _entity.SearchKeywords; }
		}
        /// <summary>
        /// Gets the RecurrenceType
        /// </summary>
        /// <value>The RecurrenceType.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? RecurrenceType
		{
			get { return _entity.RecurrenceType; }
		}
        /// <summary>
        /// Gets the DailyFrequency
        /// </summary>
        /// <value>The DailyFrequency.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? DailyFrequency
		{
			get { return _entity.DailyFrequency; }
		}
        /// <summary>
        /// Gets the WeeklyFrequency
        /// </summary>
        /// <value>The WeeklyFrequency.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? WeeklyFrequency
		{
			get { return _entity.WeeklyFrequency; }
		}
        /// <summary>
        /// Gets the WeeklyDayOccurence
        /// </summary>
        /// <value>The WeeklyDayOccurence.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? WeeklyDayOccurence
		{
			get { return _entity.WeeklyDayOccurence; }
		}
        /// <summary>
        /// Gets the DateLastRun
        /// </summary>
        /// <value>The DateLastRun.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? DateLastRun
		{
			get { return _entity.DateLastRun; }
		}
        /// <summary>
        /// Gets the DateNextRun
        /// </summary>
        /// <value>The DateNextRun.</value>
		[System.ComponentModel.Bindable(true)]
		public System.DateTime? DateNextRun
		{
			get { return _entity.DateNextRun; }
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
        /// Gets the AlertActive
        /// </summary>
        /// <value>The AlertActive.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? AlertActive
		{
			get { return _entity.AlertActive; }
		}
        /// <summary>
        /// Gets the EmailFormat
        /// </summary>
        /// <value>The EmailFormat.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? EmailFormat
		{
			get { return _entity.EmailFormat; }
		}
        /// <summary>
        /// Gets the CustomRecurrenceType
        /// </summary>
        /// <value>The CustomRecurrenceType.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? CustomRecurrenceType
		{
			get { return _entity.CustomRecurrenceType; }
		}
        /// <summary>
        /// Gets the LastResultCount
        /// </summary>
        /// <value>The LastResultCount.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? LastResultCount
		{
			get { return _entity.LastResultCount; }
		}
        /// <summary>
        /// Gets the PrimaryAlert
        /// </summary>
        /// <value>The PrimaryAlert.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Boolean? PrimaryAlert
		{
			get { return _entity.PrimaryAlert; }
		}
        /// <summary>
        /// Gets the UnsubscribeValidateId
        /// </summary>
        /// <value>The UnsubscribeValidateId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Guid? UnsubscribeValidateId
		{
			get { return _entity.UnsubscribeValidateId; }
		}
        /// <summary>
        /// Gets the EditValidateId
        /// </summary>
        /// <value>The EditValidateId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Guid? EditValidateId
		{
			get { return _entity.EditValidateId; }
		}
        /// <summary>
        /// Gets the ViewValidateId
        /// </summary>
        /// <value>The ViewValidateId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Guid? ViewValidateId
		{
			get { return _entity.ViewValidateId; }
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
        /// Gets the LocationId
        /// </summary>
        /// <value>The LocationId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String LocationId
		{
			get { return _entity.LocationId; }
		}
        /// <summary>
        /// Gets the AreaIds
        /// </summary>
        /// <value>The AreaIds.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String AreaIds
		{
			get { return _entity.AreaIds; }
		}
        /// <summary>
        /// Gets the ProfessionId
        /// </summary>
        /// <value>The ProfessionId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String ProfessionId
		{
			get { return _entity.ProfessionId; }
		}
        /// <summary>
        /// Gets the SearchRoleIds
        /// </summary>
        /// <value>The SearchRoleIds.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SearchRoleIds
		{
			get { return _entity.SearchRoleIds; }
		}
        /// <summary>
        /// Gets the WorkTypeIds
        /// </summary>
        /// <value>The WorkTypeIds.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String WorkTypeIds
		{
			get { return _entity.WorkTypeIds; }
		}
        /// <summary>
        /// Gets the SalaryIds
        /// </summary>
        /// <value>The SalaryIds.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String SalaryIds
		{
			get { return _entity.SalaryIds; }
		}
        /// <summary>
        /// Gets the DaysPosted
        /// </summary>
        /// <value>The DaysPosted.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? DaysPosted
		{
			get { return _entity.DaysPosted; }
		}
        /// <summary>
        /// Gets the GeneratedSql
        /// </summary>
        /// <value>The GeneratedSql.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String GeneratedSql
		{
			get { return _entity.GeneratedSql; }
		}
        /// <summary>
        /// Gets the SalaryLowerBand
        /// </summary>
        /// <value>The SalaryLowerBand.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? SalaryLowerBand
		{
			get { return _entity.SalaryLowerBand; }
		}
        /// <summary>
        /// Gets the SalaryUpperBand
        /// </summary>
        /// <value>The SalaryUpperBand.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Decimal? SalaryUpperBand
		{
			get { return _entity.SalaryUpperBand; }
		}
        /// <summary>
        /// Gets the CurrencyId
        /// </summary>
        /// <value>The CurrencyId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? CurrencyId
		{
			get { return _entity.CurrencyId; }
		}
        /// <summary>
        /// Gets the SalaryTypeId
        /// </summary>
        /// <value>The SalaryTypeId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.Int32? SalaryTypeId
		{
			get { return _entity.SalaryTypeId; }
		}
        /// <summary>
        /// Gets the CountryId
        /// </summary>
        /// <value>The CountryId.</value>
		[System.ComponentModel.Bindable(true)]
		public System.String CountryId
		{
			get { return _entity.CountryId; }
		}

        /// <summary>
        /// Gets a <see cref="T:JXTPortal.Entities.JobAlerts"></see> object
        /// </summary>
        /// <value></value>
        [System.ComponentModel.Bindable(true)]
        public JXTPortal.Entities.JobAlerts Entity
        {
            get { return _entity; }
        }
	}
}
