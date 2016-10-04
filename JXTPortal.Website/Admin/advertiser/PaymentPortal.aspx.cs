using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JXTPortal.Website.Admin.advertiser
{
    public partial class PaymentPortal : System.Web.UI.Page
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
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            hlAdvertiserJobPricing.NavigateUrl = "~/admin/advertiser/advertiserjobpricing.aspx?advertiserid=" + AdvertiserID.ToString();

            //hlAdvertiserCredits.NavigateUrl = "~/admin/advertiser/advertisercredits.aspx?advertiserid=" + AdvertiserID.ToString();
        }
    }
}