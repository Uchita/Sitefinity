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
using PaymentGateway.Paypal;

using System.Configuration;

namespace JXTPortal.Website.advertiser
{
    public partial class OrderPayment : System.Web.UI.Page
    {
        #region Properties

        public string CurrencyDisplay;
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

        private InvoiceOrderService _invoiceOrderService = null;

        private InvoiceOrderService InvoiceOrderService
        {
            get
            {
                if (_invoiceOrderService == null)
                {
                    _invoiceOrderService = new InvoiceOrderService();
                }
                return _invoiceOrderService;
            }
        }

        private InvoiceService _invoiceService = null;

        private InvoiceService InvoiceService
        {
            get
            {
                if (_invoiceService == null)
                {
                    _invoiceService = new InvoiceService();
                }
                return _invoiceService;
            }
        }

        private InvoiceItemService _invoiceItemService = null;

        private InvoiceItemService InvoiceItemService
        {
            get
            {
                if (_invoiceItemService == null)
                {
                    _invoiceItemService = new InvoiceItemService();
                }
                return _invoiceItemService;
            }
        }


        private AdvertisersService _advertiserService = null;

        private AdvertisersService AdvertiserService
        {
            get
            {
                if (_advertiserService == null)
                {
                    _advertiserService = new AdvertisersService();
                }
                return _advertiserService;
            }
        }

        private AdvertiserUsersService _advertiserusersService = null;

        private AdvertiserUsersService AdvertiserUsersService
        {
            get
            {
                if (_advertiserusersService == null)
                {
                    _advertiserusersService = new AdvertiserUsersService();
                }
                return _advertiserusersService;
            }
        }

        private SitesService _sitesService = null;

        private SitesService SitesService
        {
            get
            {
                if (_sitesService == null)
                {
                    _sitesService = new SitesService();
                }
                return _sitesService;
            }
        }

        #endregion

        protected void Page_Init(object sender, EventArgs e)
        {
            // Is SSL.
            // CommonPage.IsSSL();

            CommonPage.SetBrowserPageTitle(Page, "Order Payment");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
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

            using (GlobalSettings gs = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId).FirstOrDefault())
            {
                if (gs != null)
                {
                    PortalEnums.Jobs.Currency currency = (PortalEnums.Jobs.Currency)gs.CurrencyId;
                    if (CommonFunction.GetEnumDescription(currency).Contains("**"))
                        _currencyNeedRounding = true;
                    else
                        _currencyNeedRounding = false;

                    //Load Currency
                    LoadSiteCurrencyInfo(gs);

                    ViewState["CartItem"] = SessionData.AdvertiserUser.CartItems;

                    ltPaymentError.Text = string.Empty;

                    if (!Page.IsPostBack)
                    {
                        LoadOrderTotals(gs);
                        SetCartItems();
                        LoadYear();
                    }

                    panelPromoCode.Visible = false;

                    SetFormValues();

                    if (string.IsNullOrEmpty(gs.PaypalUser) || string.IsNullOrEmpty(gs.PaypalVendor) || string.IsNullOrEmpty(gs.PaypalPartner) || string.IsNullOrEmpty(gs.PaypalProPassword))
                    {
                        divAmex.Visible = false;
                    }
                }
            }
        }

        private void SetFormValues()
        {
            btnCompleteOrder.Text = CommonFunction.GetResourceValue("LabelCompleteOrder");
            btnPrevious.Text = CommonFunction.GetResourceValue("LabelBtnPrevious");
            btnMakePayment.Text = CommonFunction.GetResourceValue("LabelMakePayment");
        }

        private void SetCartItems()
        {
            rptOrder.DataSource = ViewState["CartItem"];
            rptOrder.DataBind();
        }

        private void LoadYear()
        {
            for (int i = DateTime.Now.Year; i < DateTime.Now.Year + 20; i++)
            {
                ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }

        private void LoadSiteCurrencyInfo(GlobalSettings gs)
        {
            PortalEnums.Jobs.Currency currency = (PortalEnums.Jobs.Currency)gs.CurrencyId;
            PortalEnums.Jobs.CurrencySymbol symbol = (PortalEnums.Jobs.CurrencySymbol)gs.CurrencyId;
            ltCurrencyDisplay.Text = currency.ToString();
            CurrencyDisplay = currency.ToString();
            CurrencySymbol = CommonFunction.GetEnumDescription(symbol);

            //check if the selected currency has the special note
            if (currencyNeedRounding)
            {
                ltCurrencySpecialNote.Visible = true;
            }
        }

        private void LoadOrderTotals(GlobalSettings gs)
        {
            if (ViewState["CartItem"] != null)
            {
                decimal total = 0.00m;
                decimal gst = 0.00m;

                List<CartItem> itemlist = ViewState["CartItem"] as List<CartItem>;
                foreach (CartItem item in itemlist)
                {
                    if (currencyNeedRounding)
                        total += Convert.ToDecimal(item.Number * ((int)item.TotalAmount));
                    else
                        total += Convert.ToDecimal(item.Number * item.TotalAmount);
                }

                gst = total * gs.Gst;

                if (currencyNeedRounding)
                    gst = (int)gst;

                ltGST.Text = gs.GstLabel;

                if (currencyNeedRounding)
                {
                    ltTotal.Text = total.ToString("0");
                    ltGST.Text = gst.ToString("0");
                    ltNet.Text = (total + gst).ToString("0");
                }
                else
                {
                    ltTotal.Text = total.ToString("0.00");
                    ltGST.Text = gst.ToString("0.00");
                    ltNet.Text = (total + gst).ToString("0.00");
                }

                // Check if 0$
                if ((total + gst) > 0)
                {
                    btnExpress.Visible = true;
                    btnCompleteOrder.Visible = false;
                }
                else
                {
                    btnExpress.Visible = false;
                    btnCompleteOrder.Visible = true;
                }
            }
            else
            {
                Response.Redirect("productselect.aspx");
            }
        }

        protected void rptOrder_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton lbDelete = e.Item.FindControl("lbDelete") as LinkButton;
                Literal ltItem = e.Item.FindControl("ltItem") as Literal;
                Literal ltQuantity = e.Item.FindControl("ltQuantity") as Literal;
                Literal ltPrice = e.Item.FindControl("ltPrice") as Literal;

                CartItem cartitem = e.Item.DataItem as CartItem;

                lbDelete.Text = CommonFunction.GetResourceValue("LabelDelete");
                lbDelete.CommandName = "Delete";
                lbDelete.CommandArgument = cartitem.JobItemsTypeID.ToString();
                ltItem.Text = cartitem.ProductDescription;
                ltQuantity.Text = cartitem.Number.ToString();

                if (currencyNeedRounding)
                    ltPrice.Text = ((int)cartitem.TotalAmount * cartitem.Number).ToString();
                else
                    ltPrice.Text = (cartitem.TotalAmount * (decimal)cartitem.Number).ToString();
            }

        }

        protected void rptOrder_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            List<CartItem> itemlist = ViewState["CartItem"] as List<CartItem>;
            if (e.CommandName == "Delete")
            {
                int jobitemtypeid = Convert.ToInt32(e.CommandArgument);


                foreach (CartItem cartitem in itemlist.ToList())
                {
                    if (cartitem.JobItemsTypeID == jobitemtypeid)
                    {
                        itemlist.Remove(cartitem);
                        ViewState["CartItem"] = itemlist;
                    }
                }
            }

            //check if cart has any items, if not boot them back to product page
            if (itemlist == null || itemlist.Count() == 0)
                Response.Redirect("/advertiser/productselect.aspx");
            else
            {
                SetCartItems();
                using (GlobalSettings gs = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId).FirstOrDefault())
                {
                    LoadOrderTotals(gs);
                }
            }
        }


        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            Response.Redirect("/advertiser/productselect.aspx");
        }

        protected void btnCompleteOrder_Click(object sender, EventArgs e)
        {
            // 0$ transaction - skip and create order and redirect to order page
            DoPayment(false);
        }

        protected void btnMakePayment_Click(object sender, EventArgs e)
        {
            // Go to paypal
            DoPayment(true);
        }

        protected void DoPayment(bool blnPayment)
        {
            ////disable ALL
            //SwitchElementsStatusTo(false);

            int invoiceOrderID = 0;
            string paymentResponse = string.Empty;
            string responseCode = string.Empty;
            string banktransactionid = string.Empty;
            string maskedcreditcard = string.Empty;

            GlobalSettings GlobalSettings = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId).FirstOrDefault();

            List<CartItem> itemlist = ViewState["CartItem"] as List<CartItem>;
            PortalEnums.Jobs.Currency currency = (PortalEnums.Jobs.Currency)GlobalSettings.CurrencyId;
            bool currencyNeedRounding = CommonFunction.GetEnumDescription(currency).Contains("**");
            bool paymentSuccessful = false;

            // Secruity - check if the complete order is clicked and total cost is more then 0
            if (!blnPayment)
            {
                decimal totalCost = InvoiceOrderService.CalculateTotalForCart(itemlist, currencyNeedRounding);

                if (totalCost > 0)
                    return;
            }

            if (blnPayment)
            {
                string cardtype = rbVisa.Value;
                if (rbAmex.Checked)
                    cardtype = rbAmex.Value;
                if (rbMastercard.Checked)
                    cardtype = rbMastercard.Value;

                PaypalDirectPayment directpayment = new PaypalDirectPayment();
                bool isLive = (ConfigurationManager.AppSettings["IsPaypalLive"].ToString() == "1");


                if (string.IsNullOrEmpty(GlobalSettings.PaypalUser) || string.IsNullOrEmpty(GlobalSettings.PaypalVendor) || string.IsNullOrEmpty(GlobalSettings.PaypalPartner) || string.IsNullOrEmpty(GlobalSettings.PaypalProPassword))
                {
                    paymentSuccessful = directpayment.DoDirectPayment(isLive, GlobalSettings.PayPalUsername, GlobalSettings.PayPalPassword, GlobalSettings.PayPalSignature, Enum.GetName(typeof(PortalEnums.Jobs.Currency), GlobalSettings.CurrencyId), itemlist, currencyNeedRounding, GlobalSettings.Gst,
                                    SessionData.Site.SiteUrl, SessionData.Site.SiteName, tbCreditCardName.Text, tbCreditCardNumber.Text, Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlYear.SelectedValue), tbCVV.Text, cardtype, out responseCode, out paymentResponse, out banktransactionid);
                }
                else
                {
                    PaymentGateway.Paypal.PayflowPaymentGateway gateway = new PaymentGateway.Paypal.PayflowPaymentGateway();
                    paymentSuccessful = gateway.DoPayment(GlobalSettings.PaypalUser, GlobalSettings.PaypalVendor, GlobalSettings.PaypalPartner, GlobalSettings.PaypalProPassword, tbCreditCardNumber.Text, tbCreditCardName.Text, Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlYear.SelectedValue), tbCVV.Text, Enum.GetName(typeof(PortalEnums.Jobs.Currency), GlobalSettings.CurrencyId), itemlist, currencyNeedRounding, GlobalSettings.Gst, SessionData.Site.SiteUrl, SessionData.Site.SiteName, out responseCode, out paymentResponse);
                }


                //create an invoice order
                if (tbCreditCardNumber.Text.Length > 4)
                {
                    maskedcreditcard = string.Concat("".PadLeft(12, 'X'), tbCreditCardNumber.Text.Substring(tbCreditCardNumber.Text.Length - 4));
                }
                else
                {
                    maskedcreditcard = tbCreditCardNumber.Text;
                }
            }
            else
            {
                paymentSuccessful = true;
            }

            bool orderCreated = InvoiceOrderService.CreateInvoiceOrderForCreditCardPayment(
                                                                SessionData.AdvertiserUser.AdvertiserUserId,
                                                                currencyNeedRounding,
                                                                itemlist,
                                                                GlobalSettings.Gst,
                                                                GlobalSettings.CurrencyId,
                                                                paymentSuccessful,
                                                                responseCode,
                                                                paymentResponse,
                                                                tbCreditCardName.Text,
                                                                maskedcreditcard,
                                                                Convert.ToInt32(ddlMonth.SelectedValue),
                                                                Convert.ToInt32(ddlYear.SelectedValue),
                                                                string.Empty,
                                                                banktransactionid,
                                                                out invoiceOrderID
                                                                );

            if (paymentSuccessful)
            {
                //create invoices
                InvoiceService.CreateInvoicesForCart(invoiceOrderID, SessionData.AdvertiserUser.AdvertiserUserId, SessionData.AdvertiserUser.CartItems);

                InvoiceItemService.CreateInvoiceItemsForInvoiceOrder(invoiceOrderID);

                // Send Payment Confirmation Email

                JXTPortal.Entities.AdvertiserUsers user = AdvertiserUsersService.GetByAdvertiserUserId(SessionData.AdvertiserUser.AdvertiserUserId);
                if (user != null)
                {
                    MailService.SendPaymentConfirmationEmail(user, invoiceOrderID, GeneratePDF(invoiceOrderID, GlobalSettings.InvoiceSiteInfo, GlobalSettings.InvoiceSiteFooter, GlobalSettings.GstLabel, CurrencySymbol));
                }

                SessionData.AdvertiserUser.CartItems = itemlist;
                Response.Redirect("paymentconfirmation.aspx");
            }
            else
            {
                ltPaymentError.Text = paymentResponse;
            }

        }

        private byte[] GeneratePDF(int OrderID, string siteinfo, string footer, string taxlabel, string CurrencySymbol = "$")
        {
            string text = System.IO.File.ReadAllText(Server.MapPath("~") + "App_GlobalResources\\InvoiceDetail.txt");
            string advertisername = string.Empty;
            string siteslogo = string.Empty;
            string clientname = string.Empty;
            string clientaddress = string.Empty;
            string clientemail = string.Empty;
            string dateofinvoice = string.Empty;
            string invoicebody = string.Empty;
            string subtotal = string.Empty;
            string tax = string.Empty;
            string grandtotal = string.Empty;

            using (InvoiceOrder order = InvoiceOrderService.GetByOrderId(OrderID))
            {
                if (order != null)
                {
                    int advuserid = order.AdvertiserUserId;

                    using (JXTPortal.Entities.AdvertiserUsers advuser = AdvertiserUsersService.GetByAdvertiserUserId(advuserid))
                    {
                        if (advuser != null)
                        {
                            using (JXTPortal.Entities.Advertisers adv = AdvertiserService.GetByAdvertiserId(advuser.AdvertiserId))
                            {
                                if (adv != null && adv.SiteId == SessionData.Site.SiteId)
                                {
                                    advertisername = HttpUtility.HtmlEncode(adv.CompanyName);

                                    using (JXTPortal.Entities.Sites site = SitesService.GetBySiteId(adv.SiteId.Value))
                                    {
                                        if (string.IsNullOrWhiteSpace(site.SiteAdminLogoUrl))
                                        {
                                            if (site.SiteAdminLogo != null)
                                            {
                                                siteslogo = string.Format("<img src='http://jxt1.com.jxt1.com/admin/getadminlogo.aspx?siteid={0}' alt='{1}' />", SessionData.Site.SiteId, SessionData.Site.SiteName.Replace("'", ""));
                                            }
                                        }
                                        else
                                        {
                                            siteslogo = string.Format("<img src='http://jxt1.com.jxt1.com/media/{0}/{1}' alt='{1}' />", ConfigurationManager.AppSettings["SitesFolder"], site.SiteAdminLogoUrl);
                                        }
                                    }
                                    clientname = adv.CompanyName;
                                    clientaddress = HttpUtility.HtmlEncode(string.Format("{0} {1}", adv.StreetAddress1, adv.StreetAddress2));
                                    clientemail = adv.AccountsPayableEmail;
                                    dateofinvoice = order.CreatedDate.ToString(SessionData.Site.DateFormat);
                                    invoicebody = string.Empty;
                                    subtotal = CurrencySymbol + order.TotalAmount.ToString("0.00");
                                    tax = CurrencySymbol + order.Gst.ToString("0.00");
                                    grandtotal = CurrencySymbol + (order.TotalAmount + order.Gst).ToString("0.00");


                                    using (TList<JXTPortal.Entities.Invoice> invoices = InvoiceService.GetByOrderId(order.OrderId))
                                    {
                                        int i = 0;
                                        foreach (JXTPortal.Entities.Invoice invoice in invoices)
                                        {
                                            i++;
                                            string packname = string.Empty;
                                            string packdesc = string.Empty;

                                            if ((invoice.TotalNumberOfJobs / invoice.Quantity) == 1)
                                            {
                                                packname = invoice.Description;
                                            }
                                            else
                                            {
                                                packname = invoice.Description;
                                                using (TList<JXTPortal.Entities.JobItemsType> itemtypes = JobItemsTypeService.CustomGetBySiteID(SessionData.Site.SiteId))
                                                {
                                                    foreach (JXTPortal.Entities.JobItemsType itemtype in itemtypes)
                                                    {
                                                        if (itemtype.JobItemTypeParentId == invoice.JobItemTypeId && itemtype.TotalNumberOfJobs == 1 && itemtype.Valid)
                                                        {
                                                            packdesc = itemtype.JobItemTypeDescription;
                                                            break;
                                                        }
                                                    }
                                                }
                                            }

                                            invoicebody += string.Format(@"
                                        <tr>
                                            <td class=""no"">{0}</td>
                                            <td class=""desc""><h3>{1}</h3>
                                              {2}</td>
                                            <td class=""unit"">{3}</td>
                                            <td class=""qty"">{4}</td>
                                            <td class=""total"">{5}</td>
                                        </tr>", i, packname, packdesc, CurrencySymbol + (invoice.TotalAmount / invoice.Quantity).ToString("0.00"), invoice.Quantity.ToString(), CurrencySymbol + (invoice.TotalAmount).ToString("0.00"));
                                        }
                                    }

                                }
                                else
                                {
                                    return null;
                                }
                            }
                        }
                    }
                }
            }

            string html = string.Format(text, advertisername, OrderID, siteslogo, siteinfo, clientname, clientaddress, clientemail, dateofinvoice, invoicebody, subtotal, taxlabel, tax, grandtotal, footer);

            byte[] file = new PDFCreator().ConvertHTMLToPDF(html);

            return file;

        }

        #region Process Payment Related Methods

        //private bool ProcessCreditCardPayment(out string paymentResponse, out string banktransactionid)
        //{
        //    paymentResponse = string.Empty;
        //    banktransactionid = string.Empty;

        //    PaypalDirectPayment gateway = new PaypalDirectPayment();
        //    bool isLive = (ConfigurationManager.AppSettings["IsPaypalLive"].ToString() == "1");

        //    string cardtype = rbVisa.Value;
        //    if (rbAmex.Checked)
        //        cardtype = rbAmex.Value;
        //    if (rbMastercard.Checked)
        //        cardtype = rbMastercard.Value;
        //    GlobalSettings GlobalSettings = new GlobalSettings();
        //    GlobalSettings = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId).FirstOrDefault();

        //    string netTotal = ProcessNetTotalForCurrency((PortalEnums.Jobs.Currency)GlobalSettings.CurrencyId);

        //    gateway.DoPayment(isLive, GlobalSettings.PayPalClientId, GlobalSettings.PayPalClientSecret, cardtype, tbCreditCardNumber.Text,
        //                    Convert.ToInt32(ddlMonth.SelectedValue), Convert.ToInt32(ddlYear.SelectedValue), tbCVV.Text, SessionData.AdvertiserUser.FirstName, SessionData.AdvertiserUser.LastName,
        //                    Enum.GetName(typeof(PortalEnums.Jobs.Currency), GlobalSettings.CurrencyId), netTotal, SessionData.Site.SiteName, out paymentResponse, out banktransactionid);

        //    return (paymentResponse == "approved");
        //}

        #endregion

        protected void btnExpress_Click(object sender, EventArgs e)
        {
            using (GlobalSettings GlobalSettings = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId).FirstOrDefault())
            {
                ExpressCheckOut express = new ExpressCheckOut();
                bool isLive = (ConfigurationManager.AppSettings["IsPaypalLive"].ToString() == "1");
                string errormessage;

                PortalEnums.Jobs.Currency currency = (PortalEnums.Jobs.Currency)GlobalSettings.CurrencyId;
                bool currencyNeedRounding = CommonFunction.GetEnumDescription(currency).Contains("**");

                //string url = express.DoExpressCheckOut(isLive, "naveen-facilitator_api1.jxt.com.au", "WCBZN93GNG6UPTX6", "An5ns1Kso7MWUdW4ErQKJJJ4qi4-APpqJwyGrJmSfvZQVmUTR3vP9Bj8",
                //                Enum.GetName(typeof(PortalEnums.Jobs.Currency), GlobalSettings.CurrencyId), SessionData.AdvertiserUser.CartItems, GlobalSettings.Gst, "http://localhost:49188", out errormessage);
                List<CartItem> itemlist = ViewState["CartItem"] as List<CartItem>;

                string postbackurl = "http://";
                if (GlobalSettings.WwwRedirect)
                {
                    postbackurl += "www.";
                }
                postbackurl += SessionData.Site.SiteUrl;
                string url = express.DoExpressCheckOut(isLive, GlobalSettings.PayPalUsername, GlobalSettings.PayPalPassword, GlobalSettings.PayPalSignature,
                                Enum.GetName(typeof(PortalEnums.Jobs.Currency), GlobalSettings.CurrencyId), itemlist, currencyNeedRounding, GlobalSettings.Gst, (HttpContext.Current.Request.IsLocal) ? "http://localhost:49188" : postbackurl, SessionData.Site.SiteName, out errormessage);
                if (string.IsNullOrEmpty(errormessage))
                {
                    Response.Redirect(url);
                }
                else
                {
                    ltPaymentError.Text = errormessage;
                }
            }
        }

        #region Private Methods

        private void SwitchElementsStatusTo(bool enabled)
        {
            rbVisa.Disabled = !enabled;
            rbMastercard.Disabled = !enabled;
            rbAmex.Disabled = !enabled;
            tbCreditCardNumber.ReadOnly = !enabled;
            tbCreditCardNumber.Enabled = enabled;
            tbCreditCardName.ReadOnly = !enabled;
            tbCreditCardName.Enabled = enabled;
            ddlMonth.Enabled = enabled;
            ddlYear.Enabled = enabled;
            tbCVV.ReadOnly = !enabled;
            tbCVV.Enabled = enabled;
            btnMakePayment.Enabled = enabled;
            btnExpress.Enabled = enabled;
        }

        private string ProcessNetTotalForCurrency(PortalEnums.Jobs.Currency currency)
        {
            string netTotalAmount;
            //check currency's special ** if any (some currency paypal don't accept decimals)
            if (CommonFunction.GetEnumDescription(currency).Contains("**"))
                netTotalAmount = ((int)decimal.Parse(ltNet.Text)).ToString();
            else
                netTotalAmount = ltNet.Text;

            return netTotalAmount;
        }

        #endregion


    }
}