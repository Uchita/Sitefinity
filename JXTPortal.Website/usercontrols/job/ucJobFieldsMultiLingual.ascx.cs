using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JXTPortal.Web.UI;
using JXTPortal.Entities;
using JXTPortal;
using AjaxControlToolkit;
using JXTPortal.Website;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using JXTPortal.Entities.Models;

namespace JXTPortal.Website.usercontrols.job
{
    public partial class ucJobFieldsMultiLingual : System.Web.UI.UserControl
    {
        public string LanguageID { get; set; }
        public string LanguageText { get; set; }

        public string JobName
        {
            get
            {
                return txtJobName.Text;
            }
            set { txtJobName.Text = value; }
        }
        public string BulletPoint1
        {
            get
            {
                return txtBulletPoint1.Text;
            }
            set { txtBulletPoint1.Text = value; }
        }
        public string BulletPoint2
        {
            get
            {
                return txtBulletPoint2.Text;
            }
            set { txtBulletPoint2.Text = value; }
        }
        public string BulletPoint3
        {
            get
            {
                return txtBulletPoint3.Text;
            }
            set { txtBulletPoint3.Text = value; }
        }
        public string ShortDescription
        {
            get
            {
                return txtDescription.Text;
            }
            set { txtDescription.Text = value; }
        }
        public string FullDescription
        {
            get
            {
                return txtFullDescription.Text;
            }
            set { txtFullDescription.Text = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ltDivLang.Text = string.Format("<div class=\"tab-content current\" id=\"{0}-tab\">", LanguageID);

            if (LanguageID != SessionData.Site.DefaultLanguageId.ToString())
            {
                phEnableLanguage.Visible = true;
                ltEnableLanguage.Text = CommonFunction.GetResourceValue("LabelEnable") + " " + LanguageText + " " + CommonFunction.GetResourceValue("LabelVersion");
            }

            if (!Page.IsPostBack)
            {
                hfLanguageID.Value = LanguageID.ToString();

                SetFormValue();
            }
        }

        private void SetFormValue()
        {
            ReqVal_JobName.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            ReqVal_Description.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
            rvjobFieldFullDescription.ErrorMessage = CommonFunction.GetResourceValue("LabelRequiredField1");
        }
    }

}