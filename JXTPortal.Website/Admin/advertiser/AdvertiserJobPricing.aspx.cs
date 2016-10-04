using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using JXTPortal;
using JXTPortal.Entities;
namespace JXTPortal.Website.Admin
{
    public partial class AdvertiserJobPricing : System.Web.UI.Page
    {
        #region Properties
        private int _advertiserid = 0;
        protected int AdvertiserID
        {
            get
            {
                if ((Request.QueryString["AdvertiserID"] != null))
                {
                    if (int.TryParse((Request.QueryString["AdvertiserID"].Trim()), out _advertiserid))
                    {
                        _advertiserid = Convert.ToInt32(Request.QueryString["AdvertiserID"]);
                    }
                    return _advertiserid;
                }

                return _advertiserid;
            }
        }

        private AdvertiserJobPricingService _advertiserjobpricingservice;
        AdvertiserJobPricingService AdvertiserJobPricingService
        {
            get
            {
                if (_advertiserjobpricingservice == null)
                {
                    _advertiserjobpricingservice = new AdvertiserJobPricingService();
                }
                return _advertiserjobpricingservice;
            }
        }

        private JobItemsTypeService _jobitemstpyeservice;
        JobItemsTypeService JobItemsTypeService
        {
            get
            {
                if (_jobitemstpyeservice == null)
                {
                    _jobitemstpyeservice = new JobItemsTypeService();
                }
                return _jobitemstpyeservice;
            }
        }

        private AdvertisersService _advertisersservice;
        private AdvertisersService AdvertisersService
        {
            get
            {
                if (_advertisersservice == null)
                {
                    _advertisersservice = new AdvertisersService();
                }
                return _advertisersservice;
            }
        }

        private static List<Tuple<int, string, bool>> jobTypeDescriptions;

        #endregion

        #region Page Event handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            using (JXTPortal.Entities.Advertisers advertiser = AdvertisersService.GetByAdvertiserId(AdvertiserID))
            {
                //advertiserID reference check before we do anything
                if (advertiser == null || (!SessionData.AdminUser.isAdminUser && advertiser.SiteId != SessionData.Site.SiteId))
                    Response.Redirect("/admin/advertisers.aspx");

                if (!Page.IsPostBack)
                {
                    //Load advertiser account details    
                    lblAdvertiserName.Text = advertiser.CompanyName;

                    LoadJobItemsType();

                    //get reference list for job type description displays
                    jobTypeDescriptions = JobItemsTypeService.GetBySiteId(SessionData.Site.SiteId)
                                                                    .Select(c => new Tuple<int, string, bool>(c.JobItemTypeId, c.JobItemTypeDescription, c.Valid))
                                                                    .ToList();

                    //load data into form if we are editing
                    string reqQuery = Request.QueryString["JobItemsTypeID"];
                    if (reqQuery != null)
                    {
                        int reqQueryJobItemTypeID = 0;
                        if (int.TryParse(reqQuery, out reqQueryJobItemTypeID))
                        {
                            LoadForm(reqQueryJobItemTypeID);

                            btnEditSave.Text = "Update";
                            ddlJobItemType.Enabled = false;
                            btnEditCancel.Visible = true;
                        }
                    }

                }


                cal_tbStartDate.Format = SessionData.Site.DateFormat;
                cal_tbExpiryDate.Format = SessionData.Site.DateFormat;
                //Load listing table
                LoadTable();
            }
        }

        #endregion

        #region Events

        protected void rptAdminAdvertiserJobPricing_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltAdminAdvertiserJobPricingType = e.Item.FindControl("ltAdminAdvertiserJobPricingType") as Literal;
                Literal ltAdminAdvertiserJobPricingStartDate = e.Item.FindControl("ltAdminAdvertiserJobPricingStartDate") as Literal;
                Literal ltAdminAdvertiserJobPricingExpirtyDate = e.Item.FindControl("ltAdminAdvertiserJobPricingExpirtyDate") as Literal;
                Literal ltAdminAdvertiserJobPricingTotal = e.Item.FindControl("ltAdminAdvertiserJobPricingTotal") as Literal;
                Literal ltAdminAdvertiserJobPricingLastModified = e.Item.FindControl("ltAdminAdvertiserJobPricingLastModified") as Literal;
                Literal ltAdminAdvertiserJobPricingStatus = e.Item.FindControl("ltAdminAdvertiserJobPricingStatus") as Literal;
                PlaceHolder plEditLink = e.Item.FindControl("plEditLink") as PlaceHolder;

                Entities.AdvertiserJobPricing advertiserJobPricing = (Entities.AdvertiserJobPricing)e.Item.DataItem;

                string jobPricingDescription = advertiserJobPricing.JobItemsTypeId.ToString();
                string jobPricingStatus = string.Empty;

                Tuple<int, string, bool> jobTypeItemDetails = jobTypeDescriptions.Where(c => c.Item1 == advertiserJobPricing.JobItemsTypeId).FirstOrDefault();
                if (jobTypeItemDetails != null)
                {
                    jobPricingDescription = jobTypeItemDetails.Item2;
                    
                    //LOGIC
                    //==============
                    // If the jobitemtype is VALID, this advertiser job pricing is changed to EXPIRED if the dates are < current date
                    // If this job type has been changed to NOT ACTIVE in Job Board Settings, this item is displayed as DISABLED

                    if (jobTypeItemDetails.Item3)
                    {
                        if (advertiserJobPricing.ExpiryDate < DateTime.Now)
                            jobPricingStatus = "Expired";
                        else
                            jobPricingStatus = "Valid";
                    }
                    else
                        jobPricingStatus = "Disabled";
                                        
                    plEditLink.Visible = jobTypeItemDetails.Item3; //show link only if the job type is valid
                }

                ltAdminAdvertiserJobPricingType.Text = jobPricingDescription;
                ltAdminAdvertiserJobPricingStartDate.Text = advertiserJobPricing.StartDate.HasValue ? advertiserJobPricing.StartDate.Value.ToString(SessionData.Site.DateFormat) : string.Empty;
                ltAdminAdvertiserJobPricingExpirtyDate.Text = advertiserJobPricing.ExpiryDate.HasValue ? advertiserJobPricing.ExpiryDate.Value.ToString(SessionData.Site.DateFormat) : string.Empty;
                ltAdminAdvertiserJobPricingTotal.Text = advertiserJobPricing.TotalAmount.ToString();
                ltAdminAdvertiserJobPricingLastModified.Text = advertiserJobPricing.LastModified.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                ltAdminAdvertiserJobPricingStatus.Text = jobPricingStatus;
            }
        }

        protected void rptAdminAdvertiserJobPricing_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int jobItemType = Convert.ToInt32(e.CommandArgument);
                AdvertiserJobPricingService.Delete(new AdvertiserJobPricingKey { AdvertiserId = AdvertiserID, JobItemsTypeId = jobItemType });

                LoadTable();
            }
        }

        #endregion

        #region Click Events

        protected void btnEditSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    using (JXTPortal.Entities.Advertisers advertiser = AdvertisersService.GetByAdvertiserId(AdvertiserID))
                    {
                        //advertiserID reference check
                        if (advertiser == null || (!SessionData.AdminUser.isAdminUser && advertiser.SiteId != SessionData.Site.SiteId))
                            Response.Redirect("/admin/advertisers.aspx");
                    }


                    //clear form error
                    ltlMessage.Text = string.Empty;

                    string formError = FormInputValidations();
                    if (!string.IsNullOrEmpty(formError))
                    {
                        ltlMessage.Text = formError;
                        return;
                    }

                    //gets the current pricing 
                    Entities.AdvertiserJobPricing thisPricing = AdvertiserJobPricingService.GetByAdvertiserIdJobItemsTypeId(AdvertiserID, Convert.ToInt32(ddlJobItemType.SelectedValue));
                    bool hasExistingRecord = true;

                    //if pricing does not exists in db, create a new one, otherwise update
                    if (thisPricing == null)
                    {
                        hasExistingRecord = false;

                        thisPricing = new Entities.AdvertiserJobPricing
                        {
                            AdvertiserId = AdvertiserID,
                            JobItemsTypeId = Convert.ToInt32(ddlJobItemType.SelectedValue)
                        };
                    }

                    thisPricing.TotalAmount = Convert.ToDecimal(tbTotalAmount.Text);
                    thisPricing.StartDate = (string.IsNullOrWhiteSpace(tbStartDate.Text)) ? (DateTime?)null : DateTime.ParseExact(tbStartDate.Text, SessionData.Site.DateFormat, null);
                    thisPricing.ExpiryDate = (string.IsNullOrWhiteSpace(tbExpiryDate.Text)) ? (DateTime?)null : DateTime.ParseExact(tbExpiryDate.Text, SessionData.Site.DateFormat, null);
                    thisPricing.LastModified = DateTime.Now;
                    thisPricing.LastModifiedBy = SessionData.AdminUser.AdminUserId;

                    if (hasExistingRecord)
                    {
                        AdvertiserJobPricingService.Update(thisPricing);
                    }
                    else
                    {
                        AdvertiserJobPricingService.Insert(thisPricing);
                    }

                    //refresh table display
                    LoadTable();

                    ClearForm();

                }
                catch (Exception ex)
                {
                    ltlMessage.Text = ex.Message;
                }
            }
        }

        protected void btnEditCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/admin/advertisers.aspx");
        }

        #endregion

        #region Methods

        private void LoadJobItemsType()
        {
            List<Entities.JobItemsType> jobitemstypes = JobItemsTypeService.GetBySiteId(SessionData.Site.SiteId).Where(c => c.Valid).ToList();

            foreach (Entities.JobItemsType itemType in jobitemstypes)
            {
                ListItem item = new ListItem();

                item.Text = string.Format("{0} (${1})", itemType.JobItemTypeDescription, itemType.TotalAmount);
                item.Value = itemType.JobItemTypeId.ToString();

                ddlJobItemType.Items.Add(item);
            }   
        
        }

        private void LoadTable()
        {
            AdvertiserJobPricingService service = new AdvertiserJobPricingService();
            List<Entities.AdvertiserJobPricing> jobPricings = service.GetByAdvertiserId(AdvertiserID).ToList();

            if (jobPricings != null && jobPricings.Count() > 0)
            {
                rptAdminAdvertiserJobPricing.DataSource = jobPricings;
                rptAdminAdvertiserJobPricing.DataBind();
            }

        }

        private void LoadForm(int jobItemTypeID)
        {
            AdvertiserJobPricingService service = new AdvertiserJobPricingService();
            tbStartDate.Text = string.Empty;
            tbExpiryDate.Text = string.Empty;
            tbTotalAmount.Text = string.Empty;

            //AdvertiserID here has been verified from the caller which is Page_Load()
            DataSet ds = service.CustomGetByAdvertiserIDJobItemsTypeID(AdvertiserID, Convert.ToInt32(jobItemTypeID));
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlJobItemType.Items.FindByValue(jobItemTypeID.ToString()).Selected = true;

                DataRow dr = ds.Tables[0].Rows[0];
                if (dr["StartDate"] != DBNull.Value)
                {
                    tbStartDate.Text = Convert.ToDateTime(dr["StartDate"]).ToString(SessionData.Site.DateFormat);
                }

                if (dr["ExpiryDate"] != DBNull.Value)
                {
                    tbExpiryDate.Text = Convert.ToDateTime(dr["ExpiryDate"]).ToString(SessionData.Site.DateFormat);
                }

                if (dr["TotalAmount"] != DBNull.Value)
                {
                    tbTotalAmount.Text = Convert.ToDecimal(dr["TotalAmount"]).ToString();
                }
            }
        }

        private void ClearForm()
        {
            ddlJobItemType.SelectedIndex = -1;
            tbStartDate.Text = string.Empty;
            tbExpiryDate.Text = string.Empty;
            tbTotalAmount.Text = string.Empty;

            btnEditSave.Text = "Create";

            ddlJobItemType.Enabled = true;
            btnEditCancel.Visible = false;

        }

        private string FormInputValidations()
        {
            if (string.IsNullOrEmpty(tbStartDate.Text))
                return "You must specify the start date.";

            if (string.IsNullOrEmpty(tbExpiryDate.Text))
                return "You must specify the expiry date.";

            if (string.IsNullOrEmpty(tbTotalAmount.Text))
                return "You must specify the total amount.";

            //date check
            if (Convert.ToDateTime(tbExpiryDate.Text) < DateTime.ParseExact(tbStartDate.Text, SessionData.Site.DateFormat, null))
                return "Invalid start and expiry date.";

            return null;
        }

        #endregion

        protected void cvStartDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrWhiteSpace(tbStartDate.Text))
            {
                DateTime dt;

                if (DateTime.TryParseExact(tbStartDate.Text, SessionData.Site.DateFormat, null, System.Globalization.DateTimeStyles.None, out dt))
                {
                    if (dt < System.Data.SqlTypes.SqlDateTime.MinValue.Value || dt > new DateTime(DateTime.Now.Year + 100, 12, 31))
                    {
                        cvStartDate.ErrorMessage = "Date out of range.";

                        args.IsValid = false;
                    }
                }
                else
                {
                    cvStartDate.ErrorMessage = "Invalid Date.";

                    args.IsValid = false;
                }
            }
        }

        protected void cvExpiryDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrWhiteSpace(tbExpiryDate.Text))
            {
                DateTime dt;

                if (DateTime.TryParseExact(tbExpiryDate.Text, SessionData.Site.DateFormat, null, System.Globalization.DateTimeStyles.None, out dt))
                {
                    if (dt < System.Data.SqlTypes.SqlDateTime.MinValue.Value || dt > new DateTime(DateTime.Now.Year + 100, 12, 31))
                    {
                        cvExpiryDate.ErrorMessage = "Date out of range.";

                        args.IsValid = false;
                    }
                }
                else
                {
                    cvExpiryDate.ErrorMessage = "Invalid Date.";

                    args.IsValid = false;
                }
            }
        }
    }


}