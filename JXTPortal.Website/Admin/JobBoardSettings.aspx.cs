using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Common;
using JXTPortal.Entities;
using System.Data;
using System.Linq;


namespace JXTPortal.Website.Admin
{
    public partial class JobBoardSettings : System.Web.UI.Page
    {
        #region Properties

        private bool siteIsJobBoard;

        private GlobalSettingsService _globalSettingsService;

        private GlobalSettingsService GlobalSettingsService
        {
            get
            {
                if (_globalSettingsService == null) _globalSettingsService = new GlobalSettingsService();
                return _globalSettingsService;
            }
        }

        private JobItemsTypeService _jobitemstypeservice;

        private JobItemsTypeService JobItemsTypeService
        {
            get
            {
                if (_jobitemstypeservice == null) _jobitemstypeservice = new JobItemsTypeService();
                return _jobitemstypeservice;
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

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            ltlMessage.Text = string.Empty;

            using (GlobalSettings GlobalSettings = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId).FirstOrDefault())
            {
                siteIsJobBoard = (PortalEnums.Admin.SiteType) GlobalSettings.SiteType == PortalEnums.Admin.SiteType.JobBoard;
                phInvoice.Visible = (PortalEnums.Admin.SiteType)GlobalSettings.SiteType == PortalEnums.Admin.SiteType.JobBoard;
                //if (GlobalSettings.SiteType != (int)PortalEnums.Admin.SiteType.JobBoard)
                //{
                //    Response.Redirect(string.Format("GlobalSettingsEdit.aspx?siteid={0}", SessionData.Site.SiteId));
                //}
                if (!Page.IsPostBack)
                {
                    //Paypal Settings Init
                    //tbPaypalClientID.Text = GlobalSettings.PayPalClientId;
                    //tbPaypalClientSecret.Text = GlobalSettings.PayPalClientSecret;
                    tbPaypalUserName.Text = GlobalSettings.PayPalUsername;
                    tbPaypalPassword.Text = GlobalSettings.PayPalPassword;
                    tbPaypalSignature.Text = GlobalSettings.PayPalSignature;

                    tbPaypalUser.Text = GlobalSettings.PaypalUser;
                    tbPaypalProPassword.Text = GlobalSettings.PaypalProPassword;
                    tbPartner.Text = GlobalSettings.PaypalPartner;
                    tbVendor.Text = GlobalSettings.PaypalVendor;

                    //Job Board Settings Init
                    tbGST.Text = GlobalSettings.Gst.ToString();
                    gstPercentDisplayInit.Text = (GlobalSettings.Gst * 100).ToString();
                    tbGSTLabel.Text = GlobalSettings.GstLabel;
                    ddlNoOfPremiumJobs.SelectedValue = GlobalSettings.NumberOfPremiumJobs.ToString();
                    cbDisplayPremiumJobs.Checked = GlobalSettings.DisplayPremiumJobsOnResults;

                    //Only Job Boards see Job Board Settings
                    if (siteIsJobBoard)
                        phJobBoardSettings.Visible = true;

                    //Must load currency before JobItemType
                    LoadCurrencyDropdown(GlobalSettings.CurrencyId);

                    LoadJobItemType();
                    LoadJobPacksForm();

                    tbInvoiceSiteInfo.Text = GlobalSettings.InvoiceSiteInfo;
                    tbInvoiceSiteFooter.Text = GlobalSettings.InvoiceSiteFooter;
                }
            }

            if (!siteIsJobBoard)
            {
                updatePanelPaypalSettings.Visible = false;
                plAddJobPackForm.Visible = false;
            }

        }

        private void LoadCurrencyDropdown(int selectedVal)
        {
            IDictionary<int, string> currencyDDs = new Dictionary<int, string>();

            foreach (KeyValuePair<int, string> pair in Common.Utils.GetEnumForDropDowns<PortalEnums.Jobs.Currency>())
            {
                PortalEnums.Jobs.Currency thisSymbol = (PortalEnums.Jobs.Currency)pair.Key;

                if (CommonFunction.GetEnumDescription(thisSymbol).Contains("**"))
                    currencyDDs.Add(pair.Key, pair.Value + "*");
                else
                    currencyDDs.Add(pair.Key, pair.Value);
            }

            ddlCurrency.DataSource = currencyDDs;
            ddlCurrency.DataTextField = "Value";
            ddlCurrency.DataValueField = "Key";
            ddlCurrency.DataBind();

            ddlCurrency.Items.FindByValue(selectedVal.ToString()).Selected = true;

            ddlCurrencySpecialNoteDisplay();

        }

        private void LoadJobItemType()
        {
            using (TList<Entities.JobItemsType> jobitemtypes = JobItemsTypeService.GetBySiteId(SessionData.Site.SiteId))
            {
                rptJobItemType.DataSource = jobitemtypes.OrderBy(c => c.Sequence);
                rptJobItemType.DataBind();
            }
        }

        private void LoadJobPacksForm()
        {
            LoadJobPacksAvailableItemType();
            LoadJobPacksCurrencyDisplay();
        }

        private void LoadJobPacksCurrencyDisplay()
        {
            using (GlobalSettings GlobalSettings = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId).FirstOrDefault())
            {
                ltlCurrencyDisp2.Text =  CurrencySymbolGet( ((PortalEnums.Jobs.Currency)GlobalSettings.CurrencyId) );
            }
        }

        private void LoadJobPacksAvailableItemType()
        {
            //ddlJobPackAddType
            using (TList<Entities.JobItemsType> globaljobitemtypes = JobItemsTypeService.GetBySiteId(SessionData.Site.SiteId))
            {
                ddlJobPackAddType.DataSource = globaljobitemtypes
                                                .Where(c => c.Valid && c.TotalNumberOfJobs == 1)
                                                .Select(c => new { JobItemTypeID = c.JobItemTypeId, JobTypeDisplayText = ((PortalEnums.Jobs.JobItemType)c.JobItemTypeParentId).ToString() });
                ddlJobPackAddType.DataBind();
            }
        }

        private void ClearJobPackForm()
        {
            ddlJobPackAddType.SelectedIndex = 0;
            tbJobPackAddName.Text = string.Empty;
            tbJobPackAddPrice.Text = string.Empty;
            tbJobPackAddQty.Text = string.Empty;
            tbJobPackAddSequence.Text = string.Empty;
            cbJobPackValid.Checked = false;
        }

        private void CalculateJobPacksDiscount(Entities.JobItemsType jobPack, List<Entities.JobItemsType> parentTypeItems)
        {
            decimal discountAmount = 0;

            Entities.JobItemsType parentItem = parentTypeItems.Where(c => c.JobItemTypeParentId == jobPack.JobItemTypeParentId).FirstOrDefault();

            if (parentItem != null)
            {
                discountAmount = (parentItem.TotalAmount.Value * jobPack.TotalNumberOfJobs) - jobPack.TotalAmount.Value;
                //assign to model
                jobPack.DiscountAmount = discountAmount;
            }
        }


        #region Events

        protected void btnEditSave_Click(object sender, EventArgs e)
        {
            using (GlobalSettings GlobalSettings = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId).FirstOrDefault())
            {
                try
                {
                    GlobalSettings.Gst = Convert.ToDecimal(tbGST.Text);
                    GlobalSettings.GstLabel = tbGSTLabel.Text;
                    GlobalSettings.NumberOfPremiumJobs = Convert.ToInt32(ddlNoOfPremiumJobs.SelectedValue);
                    //DisplayPremiumOnResults may also be updated within the foreach loop below
                    GlobalSettings.DisplayPremiumJobsOnResults = cbDisplayPremiumJobs.Checked;
                    GlobalSettings.CurrencyId = Convert.ToInt32(ddlCurrency.SelectedValue);
                    GlobalSettings.InvoiceSiteInfo = tbInvoiceSiteInfo.Text;
                    GlobalSettings.InvoiceSiteFooter = tbInvoiceSiteFooter.Text;
                    //get the list of "global" items for later use
                    List<Entities.JobItemsType> parentItems = JobItemsTypeService.GetBySiteId(SessionData.Site.SiteId).Where(c => c.TotalNumberOfJobs == 1).ToList();

                    foreach (RepeaterItem item in rptJobItemType.Items)
                    {
                        Panel plThisJobItemTypeRow = item.FindControl("plThisJobItemTypeRow") as Panel;

                        //only update if the row is visible
                        if (plThisJobItemTypeRow.Visible)
                        {
                            CheckBox cbSelect = item.FindControl("cbSelect") as CheckBox;
                            Literal ltJobItemTypeName = item.FindControl("ltJobItemTypeName") as Literal;
                            Literal ltLastModified = item.FindControl("ltLastModified") as Literal;
                            TextBox tbJobTypeNameOverride = item.FindControl("tbJobTypeNameOverride") as TextBox;
                            TextBox tbSequence = item.FindControl("tbSequence") as TextBox;
                            TextBox tbJobsCount = item.FindControl("tbJobsCount") as TextBox;
                            HiddenField hfJobItemTypeID = item.FindControl("hfJobItemTypeID") as HiddenField;
                            HiddenField hfParentTypeID = item.FindControl("hfParentTypeID") as HiddenField;
                            TextBox tbTotalAmount = item.FindControl("tbTotalAmount") as TextBox;

                            //hfJobItemTypeID has no value, find existing record if any and update, otherwise create
                            bool hasUpdatedRecord = false;

                            //1. find existing record if any and undate
                            using (Entities.JobItemsType jobitemtype = JobItemsTypeService.GetBySiteId(SessionData.Site.SiteId).Where(c => c.JobItemTypeId == Convert.ToInt32(hfJobItemTypeID.Value)).FirstOrDefault())
                            {
                                if (jobitemtype != null) //record found
                                {
                                    //Settings Restrictions:
                                    //=======================
                                    //If the site is a Recruiters, only the checkbox option is available
                                    //The "TotalAmount" textbox is available only to JobBoards 
                                    if (siteIsJobBoard)
                                    {
                                        jobitemtype.TotalAmount = string.IsNullOrEmpty(tbTotalAmount.Text) ? 0 : Convert.ToDecimal(tbTotalAmount.Text);
                                    }

                                    jobitemtype.JobItemTypeDescription = tbJobTypeNameOverride.Text;
                                    jobitemtype.TotalNumberOfJobs = int.Parse(tbJobsCount.Text);
                                    jobitemtype.Sequence = int.Parse(tbSequence.Text);

                                    if ((PortalEnums.Jobs.JobItemType)(int.Parse(hfParentTypeID.Value)) == PortalEnums.Jobs.JobItemType.Premium && jobitemtype.TotalNumberOfJobs == 1 && phPremium.Visible)
                                        jobitemtype.DaysActive = int.Parse(tbPremiumActiveDays.Text);
                                    else
                                        jobitemtype.DaysActive = 0;

                                    jobitemtype.Valid = cbSelect.Checked;
                                    jobitemtype.LastModified = DateTime.Now;
                                    jobitemtype.LastModifiedBy = SessionData.AdminUser.AdminUserId;

                                    if (jobitemtype.JobItemTypeParentId == ((int)PortalEnums.Jobs.JobItemType.Premium) && jobitemtype.TotalNumberOfJobs == 1 && phPremium.Visible)
                                    {
                                        if (cbSelect.Checked)
                                            jobitemtype.DaysActive = Convert.ToInt32(tbPremiumActiveDays.Text);
                                        else
                                        {
                                            jobitemtype.DaysActive = 0;
                                            //when the premium job type checkbox is off, we turn off display premium jobs as well
                                            GlobalSettings.DisplayPremiumJobsOnResults = false;
                                        }
                                    }

                                    CalculateJobPacksDiscount(jobitemtype, parentItems);

                                    JobItemsTypeService.Update(jobitemtype);

                                    hasUpdatedRecord = true;
                                }
                            }

                            //2. record not found, create new record
                            if (!hasUpdatedRecord)
                            {
                                using (Entities.JobItemsType jobitemtype = JobItemsTypeService.GetByJobItemTypeId(Convert.ToInt32(hfParentTypeID.Value)))
                                {
                                    jobitemtype.SiteId = SessionData.Site.SiteId;
                                    jobitemtype.Valid = cbSelect.Checked;
                                    jobitemtype.JobItemTypeParentId = Convert.ToInt32(hfParentTypeID.Value);
                                    jobitemtype.TotalNumberOfJobs = int.Parse(tbJobsCount.Text);

                                    //Settings Restrictions:
                                    //=======================
                                    //If the site is a Recruiters, only the checkbox option is available
                                    //The "TotalAmount" textbox is available only to JobBoards 
                                    jobitemtype.TotalAmount = string.IsNullOrEmpty(tbTotalAmount.Text) ? 0 : Convert.ToDecimal(tbTotalAmount.Text);

                                    jobitemtype.JobItemTypeDescription = tbJobTypeNameOverride.Text;
                                    jobitemtype.LastModified = DateTime.Now;
                                    jobitemtype.LastModifiedBy = SessionData.AdminUser.AdminUserId;

                                    //if (jobitemtype.JobItemTypeParentId == ((int)PortalEnums.Jobs.JobItemType.Premium))
                                    //{
                                    //    if (cbSelect.Checked)
                                    //        jobitemtype.DaysActive = Convert.ToInt32(tbActiveDays.Text);
                                    //    else
                                    //    {
                                    //        jobitemtype.DaysActive = 0;
                                    //        //when the premium job type checkbox is off, we turn off display premium jobs as well
                                    //        GlobalSettings.DisplayPremiumJobsOnResults = false;
                                    //    }
                                    //}

                                    CalculateJobPacksDiscount(jobitemtype, parentItems);

                                    JobItemsTypeService.Insert(jobitemtype);
                                }
                            }
                        }
                    }
                    ltlMessage.Text = "Job Board / Job Type Settings updated successfully";
                }
                catch (Exception ex)
                {
                    ltlMessage.Text = ex.Message;
                }

                GlobalSettingsService.Update(GlobalSettings);

            } //end using GlobalSettings...

            //reload data
            LoadJobItemType();
            LoadJobPacksForm();
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("globalsettingsedit.aspx");
        }

        protected void btnAddJobPack_Click(object sender, EventArgs e)
        {
            decimal discountAmt = 0;
            decimal jobPackPrice = decimal.Parse(tbJobPackAddPrice.Text);
            int jobItemTypeParentID = 0;
            int jobPackQty = int.Parse(tbJobPackAddQty.Text);

            //get the job type record for calculation purpose
            using (Entities.JobItemsType targetJobType = JobItemsTypeService.GetByJobItemTypeId(int.Parse(ddlJobPackAddType.SelectedValue)))
            {
                jobItemTypeParentID = targetJobType.JobItemTypeParentId;

                decimal pricePerItem = targetJobType.TotalAmount.Value;
                discountAmt = (pricePerItem * jobPackQty) - jobPackPrice;
            }

            Entities.JobItemsType newItem = new Entities.JobItemsType
            {
                SiteId = SessionData.Site.SiteId,
                JobItemTypeParentId = jobItemTypeParentID,
                JobItemTypeDescription = tbJobPackAddName.Text,
                LastModified = DateTime.Now,
                TotalAmount = jobPackPrice,
                DiscountAmount = discountAmt,
                TotalNumberOfJobs = jobPackQty,
                DaysActive = 0,
                Sequence = Convert.ToInt32(tbJobPackAddSequence.Text),
                Valid = cbJobPackValid.Checked
            };

            JobItemsTypeService.Insert(newItem);

            LoadJobItemType();
            ClearJobPackForm();
        }

        protected void btnPaypalSave_Click(object sender, EventArgs e)
        {
            using (GlobalSettings GlobalSettings = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId).FirstOrDefault())
            {
                try
                {
                    //GlobalSettings.PayPalClientId = null;
                    //GlobalSettings.PayPalClientSecret = null;
                    GlobalSettings.PayPalUsername = tbPaypalUserName.Text;
                    GlobalSettings.PayPalPassword = tbPaypalPassword.Text;
                    GlobalSettings.PayPalSignature = tbPaypalSignature.Text;

                    GlobalSettings.PaypalUser = tbPaypalUser.Text;
                    GlobalSettings.PaypalProPassword = tbPaypalProPassword.Text;
                    GlobalSettings.PaypalPartner = tbPartner.Text;
                    GlobalSettings.PaypalVendor = tbVendor.Text;

                    GlobalSettingsService.Update(GlobalSettings);

                    ltPaypalMessage.Text = Common.Utils.MessageDisplayWrapper("Paypal Settings updated successfully", BootstrapAlertType.Success);
                }
                catch (Exception ex)
                {
                    ltPaypalMessage.Text = ex.Message;
                }
            }
        }

        #endregion

        protected void rptJobItemType_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Entities.JobItemsType jobitemtype = e.Item.DataItem as Entities.JobItemsType;
                Literal ltlCurrencyDisp = e.Item.FindControl("ltlCurrencyDisp") as Literal;

                //job boards see all records of jobitemtypes
                //recruiters see ONLY the records with 1 jobs count
                if (!siteIsJobBoard && jobitemtype.TotalNumberOfJobs > 1)
                {
                    Panel plThisJobItemTypeRow = e.Item.FindControl("plThisJobItemTypeRow") as Panel;

                    plThisJobItemTypeRow.Visible = false;
                }
                else
                {
                    CheckBox cbSelect = e.Item.FindControl("cbSelect") as CheckBox;
                    Literal ltJobItemTypeName = e.Item.FindControl("ltJobItemTypeName") as Literal;
                    Literal ltLastModified = e.Item.FindControl("ltLastModified") as Literal;
                    TextBox tbTotalAmount = e.Item.FindControl("tbTotalAmount") as TextBox;
                    TextBox tbJobTypeNameOverride = e.Item.FindControl("tbJobTypeNameOverride") as TextBox;
                    TextBox tbJobsCount = e.Item.FindControl("tbJobsCount") as TextBox;
                    TextBox tbSequence = e.Item.FindControl("tbSequence") as TextBox;
                    HiddenField hfJobItemTypeID = e.Item.FindControl("hfJobItemTypeID") as HiddenField;
                    HiddenField hfParentTypeID = e.Item.FindControl("hfParentTypeID") as HiddenField;
                    HiddenField hfIsSingleJobType = e.Item.FindControl("hfIsSingleJobType") as HiddenField;
                    Button btnDelete = e.Item.FindControl("btnDelete") as Button;
                    RangeValidator tbJobsCountRangeValidator = e.Item.FindControl("tbJobsCountRangeValidator") as RangeValidator;

                    ltJobItemTypeName.Text = ((PortalEnums.Jobs.JobItemType)jobitemtype.JobItemTypeParentId).ToString();
                    ltLastModified.Text = jobitemtype.LastModified.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                    hfJobItemTypeID.Value = jobitemtype.JobItemTypeId.ToString();
                    hfParentTypeID.Value = jobitemtype.JobItemTypeParentId.ToString();
                    hfIsSingleJobType.Value = (jobitemtype.TotalNumberOfJobs == 1).ToString();
                    tbJobTypeNameOverride.Text = jobitemtype.JobItemTypeDescription;
                    tbJobsCount.Text = jobitemtype.TotalNumberOfJobs.ToString();
                    tbSequence.Text = jobitemtype.Sequence.ToString();

                    //set total amount
                    if (siteIsJobBoard)
                        tbTotalAmount.Text = jobitemtype.TotalAmount.ToString();
                    else
                        tbTotalAmount.Text = "0.00";

                    //Anything that has jobs count as 1, these are the "template" and has certain modify restrictions
                    if (jobitemtype.TotalNumberOfJobs == 1)
                    {
                        //btnDelete.Visible = false;
                        tbJobsCount.ReadOnly = true;
                        tbJobsCount.BorderColor = System.Drawing.Color.Transparent;
                        tbJobsCountRangeValidator.Enabled = false;
                    }
                    else
                    {
                        //btnDelete.Visible = true;
                        btnDelete.CommandArgument = jobitemtype.JobItemTypeId.ToString();
                    }

                    //disable the cb for "Normal" type 
                    if ((PortalEnums.Jobs.JobItemType)jobitemtype.JobItemTypeParentId == PortalEnums.Jobs.JobItemType.Normal
                        && jobitemtype.TotalNumberOfJobs == 1)
                    {
                        cbSelect.Checked = true;
                        cbSelect.Enabled = false;
                    }
                    else
                    {
                        //set restrictions
                        //Settings Restrictions:
                        //=======================
                        //If the site is a Recruiters, only the checkbox option is available
                        //The "TotalAmount" textbox is available only to JobBoards 

                        //any jobtypes other than "Normal"
                        if (jobitemtype.Valid)
                        {
                            cbSelect.Checked = true;
                            tbTotalAmount.Enabled = siteIsJobBoard ? true : false;
                        }
                        else
                        {
                            cbSelect.Checked = false;
                            tbTotalAmount.Enabled = false;
                        }
                    }

                }

                //display premium settings
                if ((PortalEnums.Jobs.JobItemType)jobitemtype.JobItemTypeParentId == PortalEnums.Jobs.JobItemType.Premium && jobitemtype.Valid && jobitemtype.TotalNumberOfJobs == 1)
                {
                    phPremium.Visible = true;
                    tbPremiumActiveDays.Text = jobitemtype.DaysActive.ToString();
                    //RangeVal_ActiveDays.Enabled = true;
                }

                //display the currency near the TotalAmount textbox
                ltlCurrencyDisp.Text = CurrencySymbolGet((PortalEnums.Jobs.Currency)(int.Parse(ddlCurrency.SelectedItem.Value)));

            }
        }

        protected void rptJobItemType_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int jobitemtypeID = Convert.ToInt32(e.CommandArgument);

                //remove all existing Advertiser Job Pricings first
                TList<Entities.AdvertiserJobPricing> toBeDeletedPricings = AdvertiserJobPricingService.GetByJobItemsTypeId(jobitemtypeID);
                AdvertiserJobPricingService.Delete(toBeDeletedPricings);

                //remove job items type
                JobItemsTypeService.Delete(jobitemtypeID);

                //refresh
                LoadJobItemType();
            }
        }

        protected void cbSelect_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbSelect = sender as CheckBox;

            int targetParentTypeID = 0;

            foreach (RepeaterItem item in rptJobItemType.Items)
            {
                CheckBox thisCB = (CheckBox)item.FindControl("cbSelect");
                if (thisCB == cbSelect)
                {
                    //show/hide job type settings for premium
                    HiddenField hfParentTypeID = (HiddenField)item.FindControl("hfParentTypeID");
                    TextBox tbJobsCount = (TextBox)item.FindControl("tbJobsCount");

                    if ((PortalEnums.Jobs.JobItemType)Convert.ToInt32(hfParentTypeID.Value) == PortalEnums.Jobs.JobItemType.Premium
                        && int.Parse(tbJobsCount.Text) == 1 && tbJobsCount.ReadOnly == true)
                    {
                        phPremium.Visible = cbSelect.Checked;

                        //enable/disable validation on the active days textbox
                        //if (cbSelect.Checked)
                        //    RangeVal_ActiveDays.Enabled = true;
                        //else
                        //    RangeVal_ActiveDays.Enabled = false;
                    }

                    if (siteIsJobBoard)
                    {
                        //enable/disable TotalAmount textbox
                        TextBox tbTotalAmount = (TextBox)item.FindControl("tbTotalAmount");
                        tbTotalAmount.Enabled = cbSelect.Checked;
                    }

                    //set target
                    HiddenField hfIsSingleJobType = item.FindControl("hfIsSingleJobType") as HiddenField;
                    if (hfIsSingleJobType.Value == "True")
                    {
                        targetParentTypeID = Convert.ToInt32(hfParentTypeID.Value);
                    }

                    break;
                }
            }

            if (targetParentTypeID != 0)
            {
                foreach (RepeaterItem item in rptJobItemType.Items)
                {
                    CheckBox thisCB = (CheckBox)item.FindControl("cbSelect");
                    if (thisCB != cbSelect && thisCB.Checked)
                    {
                        HiddenField hfParentTypeID = (HiddenField)item.FindControl("hfParentTypeID");
                        if (int.Parse(hfParentTypeID.Value) == targetParentTypeID)
                        {
                            thisCB.Checked = false;

                            if (siteIsJobBoard)
                            {
                                //enable/disable TotalAmount textbox
                                TextBox tbTotalAmount = (TextBox)item.FindControl("tbTotalAmount");
                                tbTotalAmount.Enabled = cbSelect.Checked;
                            }
                        }

                    }
                }
            }


        }

        protected void ddlCurrency_Changed(object sender, EventArgs e)
        {
            PortalEnums.Jobs.Currency selectedCurrency = (PortalEnums.Jobs.Currency) int.Parse(((DropDownList)sender).SelectedItem.Value);

            string currencySymbol = CurrencySymbolGet(selectedCurrency);

            //updates the currency
            foreach (RepeaterItem item in rptJobItemType.Items)
            {
                ((Literal)item.FindControl("ltlCurrencyDisp")).Text = currencySymbol;
            }

            ltlCurrencyDisp2.Text = currencySymbol;

            ddlCurrencySpecialNoteDisplay();
        }

        private void ddlCurrencySpecialNoteDisplay()
        {
            PortalEnums.Jobs.Currency selectedCurrency = (PortalEnums.Jobs.Currency)int.Parse(ddlCurrency.SelectedItem.Value);

            if (CommonFunction.GetEnumDescription(selectedCurrency).Contains("**"))
                currencyRoundingText.Visible = true;
            else
                currencyRoundingText.Visible = false;
        }


        private string CurrencySymbolGet(PortalEnums.Jobs.Currency currency)
        {
            //convert to symbol
            PortalEnums.Jobs.CurrencySymbol thisSymbol = (PortalEnums.Jobs.CurrencySymbol) ((int)currency);

            return CommonFunction.GetEnumDescription(thisSymbol);
        }


    }
}