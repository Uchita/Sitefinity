using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Reflection;
using System.ComponentModel;

using JXTPortal.Entities;
using JXTPortal.Common;
using JXTPortal;
using JXTPortal.Website;

public partial class InvoiceDetail : System.Web.UI.Page
{
    int _orderid = 0;
    string CurrencySymbol = "$";


    #region Properties
    protected int OrderID
    {
        get
        {

            int.TryParse(Request.Params["orderid"], out _orderid);
            return _orderid;
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

    private AdvertiserUsersService _advertiserUsersService = null;

    private AdvertiserUsersService AdvertiserUsersService
    {
        get
        {
            if (_advertiserUsersService == null)
            {
                _advertiserUsersService = new AdvertiserUsersService();
            }
            return _advertiserUsersService;
        }
    }

    private AdvertisersService _advertisersService = null;

    private AdvertisersService AdvertisersService
    {
        get
        {
            if (_advertisersService == null)
            {
                _advertisersService = new AdvertisersService();
            }
            return _advertisersService;
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

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (SessionData.AdminUser != null && (SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.Administrator
                || SessionData.AdminUser.AdminRoleId == (int)PortalEnums.Admin.AdminRole.ContentEditor))
        {
            using (GlobalSettings gs = GlobalSettingsService.GetBySiteId(SessionData.Site.SiteId).FirstOrDefault())
            {
                if (gs != null)
                {
                    if (gs.SiteType == (int)PortalEnums.Admin.SiteType.Recruiter)
                    {
                        Response.Redirect("/admin/default.aspx");
                    }
                }
            }
            LoadCurrencySymbol();
            LoadInvoice();
        }
        else
        {
            Response.Redirect("~/admin/invoice.aspx");
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
                ltTaxLabel.Text = gs.GstLabel;

                // Info & Footer
                ltInvoiceSiteInfo.Text = gs.InvoiceSiteInfo; // TODO: Change to new field
                ltInvoiceSiteFooter.Text = gs.InvoiceSiteFooter; // TODO: Change to new field
            }
        }
    }

    private void LoadInvoice()
    {
        if (OrderID > 0)
        {
            using (InvoiceOrder order = InvoiceOrderService.GetByOrderId(OrderID))
            {
                if (order != null)
                {
                    // Security Check

                    int advuserid = order.AdvertiserUserId;

                    using (JXTPortal.Entities.AdvertiserUsers advuser = AdvertiserUsersService.GetByAdvertiserUserId(advuserid))
                    {
                        if (advuser != null)
                        {
                            using (JXTPortal.Entities.Advertisers adv = AdvertisersService.GetByAdvertiserId(advuser.AdvertiserId))
                            {
                                if (adv != null && adv.SiteId == SessionData.Site.SiteId)
                                {

                                    ltAdvertiserLogoUrl.Text = string.Format("<img src='http://jxt1.com.jxt1.com/admin/getadminlogo.aspx?siteid={0}' alt='{1}' />", SessionData.Site.SiteId, SessionData.Site.SiteName.Replace("'", ""));
                                    
                                    ltClientName.Text = adv.CompanyName;
                                    ltClientAddress.Text = string.Format("{0} {1}", adv.StreetAddress1, adv.StreetAddress2);
                                    ltClientEmail.Text = adv.AccountsPayableEmail;
                                    ltDateOfInvoice.Text = order.CreatedDate.ToString(SessionData.Site.DateFormat + " hh:mm:ss tt");
                                }
                                else
                                {
                                    Response.Redirect("/admin/invoice.aspx");
                                }
                            }
                        }
                        else
                        {
                            Response.Redirect("/admin/invoice.aspx");
                        }

                        using (JXTPortal.Entities.Advertisers adv = AdvertisersService.GetByAdvertiserId(advuser.AdvertiserId))
                        {
                            if (adv != null)
                            {
                                if (adv.SiteId != SessionData.Site.SiteId)
                                {
                                    Response.Redirect("/admin/invoice.aspx");
                                }

                            }
                            else
                            {
                                Response.Redirect("/admin/invoice.aspx");
                            }
                        }
                    }
                }
                else
                {
                    Response.Redirect("/admin/invoice.aspx");
                }

                ltAdvertiserNameHeader.Text = string.Empty;
                //ltCompanyName.Text = SessionData.Site.SiteName;
                //ltCompanyAddress.Text = "Level 2, 50 York Street, 2000";
                //ltCompanyPhone.Text = "02 9955 7170";
                //ltCompanyEmail.Text = "<a href=\"mailto:sales@jxt.com.au\">sales@jxt.com.au</a>";


                using (TList<JXTPortal.Entities.Invoice> invoices = InvoiceService.GetByOrderId(order.OrderId))
                {
                    rptInvoice.DataSource = invoices;
                    rptInvoice.DataBind();
                }

                ltSubTotal.Text = CurrencySymbol + order.TotalAmount.ToString("0.00");
                ltTax.Text = CurrencySymbol + order.Gst.ToString("0.00");
                ltGrandTotal.Text = CurrencySymbol + (order.TotalAmount + order.Gst).ToString("0.00");
            }
        }
        else
        {
            Response.Redirect("/admin/invoice.aspx");
        }
    }

    protected void rptInvoice_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal ltPackName = e.Item.FindControl("ltPackName") as Literal;
            Literal ltPackDescription = e.Item.FindControl("ltPackDescription") as Literal;
            Literal ltUnitPrice = e.Item.FindControl("ltUnitPrice") as Literal;
            Literal ltQuantity = e.Item.FindControl("ltQuantity") as Literal;
            Literal ltTotal = e.Item.FindControl("ltTotal") as Literal;

            JXTPortal.Entities.Invoice invoice = e.Item.DataItem as JXTPortal.Entities.Invoice;
            if ((invoice.TotalNumberOfJobs / invoice.Quantity) == 1)
            {
                ltPackName.Text = invoice.Description;
            }
            else
            {
                ltPackName.Text = invoice.Description;
                string itemdesc = string.Empty;

                using (TList<JXTPortal.Entities.JobItemsType> itemtypes = JobItemsTypeService.CustomGetBySiteID(SessionData.Site.SiteId))
                {
                    foreach (JXTPortal.Entities.JobItemsType itemtype in itemtypes)
                    {
                        if (itemtype.JobItemTypeParentId == invoice.JobItemTypeId && itemtype.TotalNumberOfJobs == 1 && itemtype.Valid)
                        {
                            itemdesc = itemtype.JobItemTypeDescription;
                            break;
                        }
                    }
                }

                ltPackDescription.Text = itemdesc;
            }
            ltUnitPrice.Text = CurrencySymbol + (invoice.TotalAmount / invoice.Quantity).ToString("0.00");
            ltQuantity.Text = invoice.Quantity.ToString();
            ltTotal.Text = CurrencySymbol + (invoice.TotalAmount).ToString("0.00");
        }
    }
}