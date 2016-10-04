using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JXTPortal.Website
{
    public partial class _404 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Response.Status = "404 Not Found";
            Response.StatusCode = 404;
            
            
            //CommonPage.SetBrowserPageTitle(Page, "404 - Not Found");


            /*
            // bullhorn
            Entities.Advertisers advertiser = new Entities.Advertisers();
            foreach (var item in advertiser.GetType().GetProperties())
            {
                Response.Write(string.Format("{0} - {1}<br />", item.Name, item.PropertyType));
            }

            //Response.End();
            */

            //MembersService ms = new MembersService();
            //BullhornRESTAPI.BHCloseCandidate(ms.GetByMemberId(24606), out errorMsg);

            
        }

       
    }
}