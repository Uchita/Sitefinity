using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;

namespace JXTPortal.Website.Admin.advertiser
{
    public partial class AdvertiserCreditsSystem : System.Web.UI.Page
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
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Load advertiser account details            
                using (JXTPortal.Entities.Advertisers advertiser = AdvertisersService.GetByAdvertiserId(AdvertiserID))
                {
                    if (advertiser != null)
                        lblAdvertiserName.Text = advertiser.CompanyName;
                }

                LoadJobItemsType();
            }


        }

        #region Methods

        private void LoadJobItemsType()
        {
            TList<Entities.JobItemsType> jobitemstypes = JobItemsTypeService.GetBySiteId(SessionData.Site.SiteId);
            ddlJobItemType.DataSource = jobitemstypes;
            ddlJobItemType.DataBind();
        }

        #endregion

        #region Data Binds




        #endregion


        #region Click Events

        protected void btnEditSave_Click(object sender, EventArgs e)
        {
            try
            {
                //List<CartItem> simulateCart = new List<CartItem>
                //{

                //};

                ////create an invoice order
                //int invoiceOrderID = 0;
                //bool orderCreated = InvoiceOrderService.CreateInvoiceOrderForCreditCardPayment(
                //                                                    SessionData.AdvertiserUser.AdvertiserUserId,
                //                                                    simulateCart,
                //                                                    0,
                //                                                    currencyID,
                //                                                    paymentSuccessful,
                //                                                    new { response = paymentResponse },
                //                                                    out invoiceOrderID
                //                                                    );

                ////create invoices
                //InvoiceService.CreateInvoicesForCart(invoiceOrderID, SessionData.AdvertiserUser.AdvertiserUserId, SessionData.AdvertiserUser.CartItems);
            }
            catch (Exception ex)
            {
                ltlMessage.Text = ex.Message;
            }
        }

        protected void btnEditCancel_Click(object sender, EventArgs e)
        {
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/admin/advertisers.aspx");
        }

        #endregion

    }
}