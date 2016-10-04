using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.IO;
using JXTPortal.Common;

namespace JXTPortal.Website.advertiser
{
    public partial class ProductSelect : System.Web.UI.Page
    {
        #region Properties

        //this is used for the front end Javascript
        public string CurrencySymbol = "$";

        private bool? _currencyNeedRounding;
        public bool currencyNeedRounding
        {
            get
            {
                if (_currencyNeedRounding == null)
                {
                    using (GlobalSettings gs = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId).FirstOrDefault())
                    {
                        PortalEnums.Jobs.Currency currency = (PortalEnums.Jobs.Currency)gs.CurrencyId;
                        if (CommonFunction.GetEnumDescription(currency).Contains("**"))
                            _currencyNeedRounding = true;
                        else
                            _currencyNeedRounding = false;
                    }
                }
                return _currencyNeedRounding.Value;
            }
        }

        private AdvertiserJobPricingService _advertiserJobPricingService = null;

        private AdvertiserJobPricingService AdvertiserJobPricingService
        {
            get
            {
                if (_advertiserJobPricingService == null)
                {
                    _advertiserJobPricingService = new AdvertiserJobPricingService();
                }
                return _advertiserJobPricingService;
            }
        }

        private JobItemsTypeService _jobItemsTypeService = null;

        private JobItemsTypeService JobItemsTypeService
        {
            get
            {
                if (_jobItemsTypeService == null)
                {
                    _jobItemsTypeService = new JobItemsTypeService();
                }
                return _jobItemsTypeService;
            }
        }

        private GlobalSettingsService _globalSettingsService = null;

        private GlobalSettingsService GlobalSettingsService
        {
            get
            {
                if (_globalSettingsService == null)
                {
                    _globalSettingsService = new GlobalSettingsService();
                }
                return _globalSettingsService;
            }
        }

        #endregion

        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Advertiser Product Selection");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //this is used for the front end Javascript
            CurrencySymbol = CurrencySymbolGet();

            if (SessionData.AdvertiserUser == null)
            {
                Response.Redirect("login.aspx?ReturnURL=productselect.aspx");
            }
            else
            {
                if (SessionData.AdvertiserUser.AccountType == PortalEnums.Advertiser.AccountType.Account)
                {
                    Response.Redirect("/advertiser/default.aspx");
                }
            }

            if (!Page.IsPostBack)
            {
                phNoCredit.Visible = (Request.Params["nocredit"] == "1");
                //Setup available products for purchase
                LoadProducts();

                //Set cart listing
                SetCartItems();
            }

        }


        private void LoadProducts()
        {
            Dictionary<int, Tuple<int, decimal, int, string>> JobItemCosts = new Dictionary<int, Tuple<int, decimal, int, string>>();
            List<Entities.JobItemsType> jobitemstypes = JobItemsTypeService.GetBySiteId(SessionData.Site.SiteId).Where(c => c.Valid).ToList();
            TList<AdvertiserJobPricing> advertuserjobpricings = AdvertiserJobPricingService.GetByAdvertiserId(SessionData.AdvertiserUser.AdvertiserId);

            foreach (Entities.JobItemsType jobitemstype in jobitemstypes)
            {
                AdvertiserJobPricing advertiserSpecialPrice = advertuserjobpricings
                    .Where(c => c.JobItemsTypeId == jobitemstype.JobItemTypeId
                        &&
                            (DateTime.Now >= c.StartDate && DateTime.Now <= c.ExpiryDate)
                        )
                        .FirstOrDefault();

                decimal costToDisplay = 0;
                if (advertiserSpecialPrice != null)
                    costToDisplay = advertiserSpecialPrice.TotalAmount.Value;
                else
                    costToDisplay = jobitemstype.TotalAmount.Value;

                if (currencyNeedRounding)
                    costToDisplay = (int)costToDisplay;

                ListItem item = new ListItem();

                //single products
                if (jobitemstype.TotalNumberOfJobs == 1)
                {
                    item.Text = string.Format("{0} = {2}{1}", jobitemstype.JobItemTypeDescription, costToDisplay, CurrencySymbol);
                    item.Value = jobitemstype.JobItemTypeId.ToString();
                    //data-costs attribute is added in the function UpdateDataCostsAttributesForProductDDL()
                    item.Attributes.Add("data-costs", costToDisplay.ToString());
                    //data-jobscount
                    item.Attributes.Add("data-jobscount", jobitemstype.TotalNumberOfJobs.ToString());

                    ddlProductSingle.Items.Add(item);

                }
                else //Packaged products
                {
                    item.Text = string.Format("{0} ({2}{1})", jobitemstype.JobItemTypeDescription, costToDisplay, CurrencySymbol);
                    item.Value = jobitemstype.JobItemTypeId.ToString();

                    ddlProductPackages.Items.Add(item);
                }

                //Add to dictionary
                JobItemCosts.Add(jobitemstype.JobItemTypeId, new Tuple<int, decimal, int, string>(jobitemstype.JobItemTypeParentId, costToDisplay, jobitemstype.TotalNumberOfJobs, jobitemstype.JobItemTypeDescription));
            }

            //put dictionary into session for future user
            Session["JobItemCosts"] = JobItemCosts;

            //update package dropdown contained jobs display
            if (ddlProductPackages.Items.Count > 0)
            {
                plPackageSelectPanel.Visible = true;
                UpdatePackageContainedJobsDisplay(int.Parse(ddlProductPackages.Items[0].Value));
            }

        }

        #region Events

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            //session expired
            if (SessionData.AdvertiserUser == null)
            {
                Response.Redirect("~/advertiser/login.aspx?ReturnURL=productselect.aspx");
            }
            else
            {

                int jobitemtypeid;
                bool isPackage = false;

                if (((Button)sender).CommandArgument == "Single")
                    jobitemtypeid = Convert.ToInt32(ddlProductSingle.SelectedValue);
                else
                {
                    jobitemtypeid = Convert.ToInt32(ddlProductPackages.SelectedValue);
                    isPackage = true;
                }

                Entities.JobItemsType thisJobItemsTypeItem = JobItemsTypeService.GetBySiteId(SessionData.Site.SiteId).Where(c => c.JobItemTypeId == jobitemtypeid && c.Valid).FirstOrDefault();
                AdvertiserJobPricing advertuserjobpricings = AdvertiserJobPricingService.GetByAdvertiserIdJobItemsTypeId(SessionData.AdvertiserUser.AdvertiserId, jobitemtypeid);

                if (thisJobItemsTypeItem != null)
                {
                    bool inCart = false;
                    int thisJobItemTypeID = thisJobItemsTypeItem.JobItemTypeId;
                    PortalEnums.Jobs.JobItemType thisJobItemType = (PortalEnums.Jobs.JobItemType)thisJobItemsTypeItem.JobItemTypeParentId;
                    string thisJobItemDescription = thisJobItemsTypeItem.JobItemTypeDescription;
                    decimal thisJobItemTotalAmount = advertuserjobpricings != null ? advertuserjobpricings.TotalAmount.Value : thisJobItemsTypeItem.TotalAmount.Value;
                    int thisJobItemTotalNoOfJobs = thisJobItemsTypeItem.TotalNumberOfJobs;

                    if (SessionData.AdvertiserUser.CartItems == null || SessionData.AdvertiserUser.CartItems.Count == 0)
                    {
                        SessionData.AdvertiserUser.CartItems = new List<CartItem>();
                    }
                    else
                    {
                        // Check if job item already exists
                        foreach (CartItem cartitem in SessionData.AdvertiserUser.CartItems)
                        {
                            if (cartitem.JobItemsTypeID == jobitemtypeid)
                            {
                                cartitem.Number += Convert.ToInt32(ddlNumber.SelectedValue);
                                cartitem.JobsCountInclude = thisJobItemTotalNoOfJobs * cartitem.Number;
                                inCart = true;
                                break;
                            }
                        }
                    }

                    if (!inCart)
                    {
                        CartItem newcartitem = new CartItem();
                        newcartitem.JobItemsTypeID = jobitemtypeid;
                        newcartitem.JobItemType = thisJobItemType;
                        newcartitem.ProductDescription = thisJobItemDescription;

                        //use advertiser job pricing if valid
                        if (advertuserjobpricings != null && advertuserjobpricings.StartDate <= DateTime.Now && DateTime.Now <= advertuserjobpricings.ExpiryDate)
                            newcartitem.TotalAmount = Convert.ToDecimal(advertuserjobpricings.TotalAmount);
                        else
                            newcartitem.TotalAmount = Convert.ToDecimal(thisJobItemsTypeItem.TotalAmount);

                        if (isPackage)
                            newcartitem.Number = Convert.ToInt32(1);
                        else
                            newcartitem.Number = Convert.ToInt32(ddlNumber.SelectedValue);

                        newcartitem.JobsCountInclude = thisJobItemTotalNoOfJobs * newcartitem.Number;
                        SessionData.AdvertiserUser.CartItems.Add(newcartitem);
                    }
                    SetCartItems();
                }

                ClearForm();

                //refresh
                UpdateDataCostsAttributesForProductDDL();
            }
        }


        protected void rptCart_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                CartItem cartitem = e.Item.DataItem as CartItem;
                Literal ltItemQty = e.Item.FindControl("ltItemQty") as Literal;
                Literal ltItemProduct = e.Item.FindControl("ltItemProduct") as Literal;
                Literal ltItemPrice = e.Item.FindControl("ltItemPrice") as Literal;
                LinkButton lbRemove = e.Item.FindControl("lbRemove") as LinkButton;
                lbRemove.CommandName = "Delete";
                lbRemove.CommandArgument = cartitem.JobItemsTypeID.ToString();

                ltItemQty.Text = cartitem.Number.ToString();
                ltItemProduct.Text = cartitem.ProductDescription;

                if (currencyNeedRounding)
                    ltItemPrice.Text = CurrencySymbol + (((int)cartitem.TotalAmount) * cartitem.Number);
                else
                    ltItemPrice.Text = CurrencySymbol + (cartitem.TotalAmount * cartitem.Number);
            }
        }

        protected void rptCart_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int jobitemtypeid = Convert.ToInt32(e.CommandArgument);
                foreach (CartItem cartitem in SessionData.AdvertiserUser.CartItems.ToList())
                {
                    if (cartitem.JobItemsTypeID == jobitemtypeid)
                    {
                        SessionData.AdvertiserUser.CartItems.Remove(cartitem);
                    }
                }
            }

            SetCartItems();

            //refresh
            UpdateDataCostsAttributesForProductDDL();
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            //session expired
            if (SessionData.AdvertiserUser == null)
            {
                Response.Redirect("~/advertiser/login.aspx?ReturnURL=productselect.aspx");
            }

            Response.Redirect("/advertiser/orderpayment.aspx");
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            //session expired
            if (SessionData.AdvertiserUser == null)
            {
                Response.Redirect("~/advertiser/login.aspx?ReturnURL=productselect.aspx");
            }

            Response.Redirect("/advertiser/default.aspx");
        }

        protected void ddlProductPackages_IndexChanged(object sender, EventArgs e)
        {
            //session expired
            if (SessionData.AdvertiserUser == null)
            {
                Response.Redirect("~/advertiser/login.aspx?ReturnURL=productselect.aspx");
            }

            DropDownList thisDropDown = (DropDownList)sender;
            int selectedPackageJobTypeID = int.Parse(thisDropDown.SelectedValue);

            UpdatePackageContainedJobsDisplay(selectedPackageJobTypeID);

            UpdateDataCostsAttributesForProductDDL();
        }

        #endregion


        private void UpdatePackageContainedJobsDisplay(int selectedPackageJobTypeID)
        {
            //job item costs <jobtypeid, Tuple<job parent type, price, jobs count, description>>
            Dictionary<int, Tuple<int, decimal, int, string>> JobItemCosts = (Dictionary<int, Tuple<int, decimal, int, string>>)Session["JobItemCosts"];

            if (JobItemCosts == null)
                Response.Redirect("~/advertiser/login.aspx?ReturnURL=productselect.aspx");

            int containedJobsCount = JobItemCosts[selectedPackageJobTypeID].Item3;
            PortalEnums.Jobs.JobItemType jobParentType = (PortalEnums.Jobs.JobItemType)JobItemCosts[selectedPackageJobTypeID].Item1;

            ddlProductPackagesContains.Text = String.Format("{0} {1} job credits", containedJobsCount, jobParentType.ToString());
        }

        private void SetCartItems()
        {
            rptCart.DataSource = SessionData.AdvertiserUser.CartItems;
            rptCart.DataBind();

            if (SessionData.AdvertiserUser.CartItems == null || SessionData.AdvertiserUser.CartItems.Count() == 0)
            {
                lblCartEmptyText.Visible = true;
                btnContinue.Visible = false;
            }
            else
            {
                lblCartEmptyText.Visible = false;
                btnContinue.Visible = true;
            }
        }

        private void ClearForm()
        {
            ddlProductSingle.SelectedIndex = -1;
            ddlNumber.SelectedIndex = 0;

            //UpdatePurchaseItemTotal();
        }

        private void UpdateDataCostsAttributesForProductDDL()
        {
            //job item costs <jobtypeid, Tuple<job parent type, price, jobs count, description>>
            Dictionary<int, Tuple<int, decimal, int, string>> JobItemCosts = (Dictionary<int, Tuple<int, decimal, int, string>>)Session["JobItemCosts"];

            if (JobItemCosts == null)
                Response.Redirect("~/advertiser/login.aspx?ReturnURL=productselect.aspx");

            foreach (ListItem i in ddlProductSingle.Items)
            {
                int thisListItemValue = int.Parse(i.Value);

                //data-costs
                i.Attributes.Add("data-costs", JobItemCosts[thisListItemValue].Item2.ToString());
                //data-jobscount
                i.Attributes.Add("data-jobscount", JobItemCosts[thisListItemValue].Item3.ToString());
            }

        }

        private string CurrencySymbolGet()
        {
            using (GlobalSettings gs = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId).FirstOrDefault())
            {
                if (gs != null)
                {
                    PortalEnums.Jobs.CurrencySymbol symbol = (PortalEnums.Jobs.CurrencySymbol)gs.CurrencyId;
                    return CommonFunction.GetEnumDescription(symbol);
                }
            }
            return "$";
        }


    }
}