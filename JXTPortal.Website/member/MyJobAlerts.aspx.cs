using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JXTPortal.Entities;
using System.Collections;
using JXTPortal.Common;

namespace JXTPortal.Website.members
{
    public partial class MyJobAlerts : System.Web.UI.Page
    {
        
        #region Page Event handlers

        protected void Page_Init(object sender, EventArgs e)
        {
            CommonPage.SetBrowserPageTitle(Page, "Job Alert");

            if (Entities.SessionData.Member != null)
            {
                MembersService service = new MembersService();
                bool blnResult = false;

                using (Entities.Members member = service.GetByMemberId(Entities.SessionData.Member.MemberId))
                {
                    if (member.RequiredPasswordChange.HasValue && ((bool)member.RequiredPasswordChange))
                        blnResult = true;                 
                }

                if (blnResult)
                    Response.Redirect("~/member/changepassword.aspx?returnurl=" + Server.UrlEncode(Request.Url.OriginalString));
            }
            else
            {
                Response.Redirect("~/member/login.aspx?returnurl=" + Server.UrlEncode(Request.Url.OriginalString));
                return;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string msg = Request.Params["msg"];
                if (msg == "1")
                {
//                    litSuccess.Text = string.Format("<div class='form-success-message'><ul><li>{0}</li></ul></div>", CommonFunction.GetResourceValue("LabelJobAlertCreateSuccess"));
                    litSuccess.Text = Utils.MessageDisplayWrapper(CommonFunction.GetResourceValue("LabelJobAlertCreateSuccess"), BootstrapAlertType.Success);
                }
                else if (msg == "2")
                {
//                    litSuccess.Text = string.Format("<div class='form-success-message'><ul><li>{0}</li></ul></div>", CommonFunction.GetResourceValue("LabelJobAlertSaveSuccess"));
                    litSuccess.Text = Utils.MessageDisplayWrapper(CommonFunction.GetResourceValue("LabelJobAlertSaveSuccess"), BootstrapAlertType.Success);
                }
                else if (msg == "3")
                {
//                    litSuccess.Text = string.Format("<div class='form-success-message'><ul><li>{0}</li></ul></div>", CommonFunction.GetResourceValue("LabelFavouriteSearchCreateSuccess"));
                    litSuccess.Text = Utils.MessageDisplayWrapper(CommonFunction.GetResourceValue("LabelFavouriteSearchCreateSuccess"), BootstrapAlertType.Success);
                }
                else if (msg == "4")
                {
//                    litSuccess.Text = string.Format("<div class='form-success-message'><ul><li>{0}</li></ul></div>", CommonFunction.GetResourceValue("LabelFavouriteSearchSaveSuccess"));
                    litSuccess.Text = Utils.MessageDisplayWrapper(CommonFunction.GetResourceValue("LabelFavouriteSearchSaveSuccess"), BootstrapAlertType.Success);
                }

                SetFormValues();
            }
        }

        #endregion

        #region Click Event handlers

        protected void btnCreateJobAlert_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/member/createjobalert.aspx");
        }      

        #endregion

        #region Methods

        private void SetFormValues()
        {
            btnCreateJobAlert.Text = CommonFunction.GetResourceValue("ButtonCreateJobAlert");
        }

        #endregion




    }
}
