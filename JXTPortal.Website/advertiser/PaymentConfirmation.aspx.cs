using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.IO;
using JXTPortal.Common;
using PaymentGateway.Paypal;

namespace JXTPortal.Website.advertiser
{
    public partial class PaymentConfirmation : System.Web.UI.Page
    {
        string CurrencySymbol = "$";

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

        private JobItemsTypeService _jobitemstypeService = null;

        private JobItemsTypeService JobItemsTypeService
        {
            get
            {
                if (_jobitemstypeService == null)
                {
                    _jobitemstypeService = new JobItemsTypeService();
                }
                return _jobitemstypeService;
            }
        }


        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Payment Confirmation");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            phMessage.Visible = false;
            ltMessage.Text = string.Empty;

            LoadCurrencySymbol();

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

            using (GlobalSettings GlobalSettings = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId).FirstOrDefault())
            {
                //set currencyNeedRounding since we have the global settings here
                PortalEnums.Jobs.Currency currency = (PortalEnums.Jobs.Currency)GlobalSettings.CurrencyId;
                if (CommonFunction.GetEnumDescription(currency).Contains("**"))
                    _currencyNeedRounding = true;
                else
                    _currencyNeedRounding = false;


                ExpressCheckOut express = new ExpressCheckOut();
                bool isLive = (ConfigurationManager.AppSettings["IsPaypalLive"].ToString() == "1");
                string errormessage;
                string responseCode;
                string banktransactionid;

                // Response from Paypal Express Checkout
                if (string.IsNullOrWhiteSpace(Request.Params["payerid"]) == false && string.IsNullOrWhiteSpace(Request.Params["token"]) == false)
                {
                    List<PayPalPayments> payments = express.PaymentConfirmation(isLive, GlobalSettings.PayPalUsername, GlobalSettings.PayPalPassword, GlobalSettings.PayPalSignature, HttpUtility.UrlEncode(Request.Params["payerid"]), HttpUtility.UrlEncode(Request.Params["token"]), out responseCode, out errormessage, out banktransactionid);
                    string paymentResponse = string.Empty;

                    if (string.IsNullOrEmpty(errormessage))
                    {
                        //get site's currency ID
                        int currencyID = 0;
                        decimal gst = 0;

                        currencyID = GlobalSettings.CurrencyId;
                        gst = GlobalSettings.Gst;

                        // Convert List<PayPalPayments> to List<CartItem>
                        List<CartItem> cartitems = new List<CartItem>();
                        CartItem cartitem = null;
                        foreach (PayPalPayments payment in payments)
                        {
                            string jobitemtypes = payment.JobItemTypes;
                            string[] splits = jobitemtypes.Split(new char[] { ',' });

                            for (int i = 0; i < payment.PayPalPaymentsDetail.Count; i++)
                            {
                                PayPalPaymentsDetail paymentdetail = payment.PayPalPaymentsDetail[i];
                                cartitem = new CartItem();
                                cartitem.ProductDescription = paymentdetail.Description;
                                cartitem.Number = paymentdetail.Quantity;
                                cartitem.JobItemsTypeID = Convert.ToInt32(splits[i]);
                                cartitem.TotalAmount = Convert.ToDecimal(paymentdetail.Amount);

                                cartitems.Add(cartitem);
                            }
                        }

                        BindCartItems(cartitems);
                        //create an invoice order
                        int invoiceOrderID = 0;
                        bool orderCreated = InvoiceOrderService.CreateInvoiceOrderForCreditCardPayment(
                                                                            SessionData.AdvertiserUser.AdvertiserUserId,
                                                                            currencyNeedRounding,
                                                                            cartitems,
                                                                            gst,
                                                                            currencyID,
                                                                            true,
                                                                            responseCode,
                                                                            paymentResponse,
                                                                            "Paypal Express Checkout",
                                                                            string.Empty,
                                                                            0,
                                                                            0,
                                                                            string.Empty,
                                                                            banktransactionid,
                                                                            out invoiceOrderID
                                                                            );
                        if (orderCreated)
                        {
                            //create invoices
                            InvoiceService.CreateInvoicesForCart(invoiceOrderID, SessionData.AdvertiserUser.AdvertiserUserId, SessionData.AdvertiserUser.CartItems);
                            InvoiceItemService.CreateInvoiceItemsForInvoiceOrder(invoiceOrderID);
                            SessionData.AdvertiserUser.CartItems = null;

                            // Send Payment Confirmation Email

                            JXTPortal.Entities.AdvertiserUsers user = AdvertiserUsersService.GetByAdvertiserUserId(SessionData.AdvertiserUser.AdvertiserUserId);
                            if (user != null)
                            {
                                MailService.SendPaymentConfirmationEmail(user, invoiceOrderID, GeneratePDF(invoiceOrderID, GlobalSettings.InvoiceSiteInfo, GlobalSettings.InvoiceSiteFooter, GlobalSettings.GstLabel, CurrencySymbol));
                            }
                        }

                        //if (paymentSuccessful)
                        //{
                        //    InvoiceItemService.CreateInvoiceItemsForInvoiceOrder(invoiceOrderID);
                        //    Response.Redirect("paymentconfirmation.aspx");
                        //}
                        //else
                        //{
                        //    ltPaymentError.Text = paymentResponse;
                        //}
                    }
                    else
                    {
                        ltMessage.Text = errormessage;
                        phMessage.Visible = true;
                    }
                }
                else
                {
                    // Retrieve orderdetail from session to table
                    if (Request.UrlReferrer != null && Request.UrlReferrer.PathAndQuery.ToLower().Contains("/advertiser/orderpayment.aspx") && SessionData.AdvertiserUser.CartItems != null)
                    {
                        BindCartItems(SessionData.AdvertiserUser.CartItems);

                        // Clean up CartItem
                        SessionData.AdvertiserUser.CartItems = null;
                    }
                    else
                    {
                        Response.Redirect("productselect.aspx");
                    }

                }
            }
        }

        private void BindCartItems(List<CartItem> cartitems)
        {
            decimal total = 0.00m;
            decimal gst = 0.00m;

            rptPyament.DataSource = cartitems;
            rptPyament.DataBind();

            foreach (CartItem item in cartitems)
            {
                if (currencyNeedRounding)
                    total += Convert.ToDecimal(item.Number * (int)item.TotalAmount);
                else
                    total += Convert.ToDecimal(item.Number * item.TotalAmount);
            }

            // Bind the Total
            Control FooterTemplate = rptPyament.Controls[rptPyament.Controls.Count - 1].Controls[0];

            Literal ltTaxLabel = FooterTemplate.FindControl("ltTaxLabel") as Literal;
            Literal ltTax = FooterTemplate.FindControl("ltTax") as Literal;
            Literal ltTotal = FooterTemplate.FindControl("ltTotal") as Literal;

            ltTaxLabel.Text = CommonFunction.GetResourceValue("LabelTax");
            using (GlobalSettings gs = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId).FirstOrDefault())
            {
                if (gs != null)
                {
                    ltTaxLabel.Text = gs.GstLabel;
                    if (currencyNeedRounding)
                        gst = (int)(total * gs.Gst);
                    else
                        gst = total * gs.Gst;
                }
            }

            if (currencyNeedRounding)
            {
                ltTax.Text = CurrencySymbol + gst.ToString("0");
                ltTotal.Text = CurrencySymbol + (total + gst).ToString("0");
            }
            else
            {
                ltTax.Text = CurrencySymbol + gst.ToString("0.00");
                ltTotal.Text = CurrencySymbol + (total + gst).ToString("0.00");
            }
            Control HeaderTemplate = rptPyament.Controls[0].Controls[0];
            Literal ltPaymentConfirmation = HeaderTemplate.FindControl("ltPaymentConfirmation") as Literal;

            ltPaymentConfirmation.Text = string.Format(CommonFunction.GetResourceValue("LabelPaymentConfirmationDescription"), "PPAL" + SessionData.Site.SiteName.Replace(" ", "").ToUpper());

            // If not a free transaction
            if ((total + gst) > 0)
                ltPaymentConfirmation.Text = ltPaymentConfirmation.Text.Replace("display:none", "");
        }

        protected void rptPyament_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                CartItem cartitem = e.Item.DataItem as CartItem;
                Literal ltProduct = e.Item.FindControl("ltProduct") as Literal;
                Literal ltPrice = e.Item.FindControl("ltPrice") as Literal;
                Literal ltQuantity = e.Item.FindControl("ltQuantity") as Literal;
                Literal ltProductTotal = e.Item.FindControl("ltProductTotal") as Literal;
                string desc = cartitem.ProductDescription; // .Split(new char[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries)[1];

                ltProduct.Text = HttpUtility.HtmlEncode(desc);
                ltQuantity.Text = cartitem.Number.ToString();

                if (currencyNeedRounding)
                {
                    ltPrice.Text = CurrencySymbol + (cartitem.TotalAmount).ToString("0"); // TODO: Add Currency
                    ltProductTotal.Text = CurrencySymbol + (cartitem.TotalAmount * cartitem.Number).ToString("0"); // cartitem.TotalAmount
                }
                else
                {
                    ltPrice.Text = CurrencySymbol + (cartitem.TotalAmount).ToString("0.00"); // TODO: Add Currency
                    ltProductTotal.Text = CurrencySymbol + (cartitem.TotalAmount * cartitem.Number).ToString("0.00"); // cartitem.TotalAmount
                }

            }

        }

        private void LoadCurrencySymbol()
        {
            using (GlobalSettings gs = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId).FirstOrDefault())
            {
                if (gs != null)
                {
                    int currencyID = gs.CurrencyId;

                    //set currency symbol
                    PortalEnums.Jobs.CurrencySymbol thisSymbol = (PortalEnums.Jobs.CurrencySymbol)currencyID;
                    CurrencySymbol = CommonFunction.GetEnumDescription(thisSymbol);
                }
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

    }
}