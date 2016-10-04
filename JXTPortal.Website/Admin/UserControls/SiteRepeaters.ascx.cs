using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.Data;
using System.Collections;

namespace JXTPortal.Website.Admin.UserControls
{
    public partial class SiteRepeaters : System.Web.UI.UserControl
    {
        #region "Event Handlers"

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rptSitesObject_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                Label lblHeader = (Label)e.Item.FindControl("lblHeader");
                lblHeader.Text = HeaderName;
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                CheckBox chkID = (CheckBox)e.Item.FindControl("chkID");
                CheckBox chkOriginalID = (CheckBox)e.Item.FindControl("chkOriginalID");
                HiddenField hfID = (HiddenField)e.Item.FindControl("hfID");

                Label lblName = (Label)e.Item.FindControl("lblName");

                PropertyInfo piTextField = e.Item.DataItem.GetType().GetProperty(DataTextField);
                string textValue = (string)(piTextField.GetValue(e.Item.DataItem, null));

                PropertyInfo piValueField = e.Item.DataItem.GetType().GetProperty(DataValueField);
                int value = (int)(piValueField.GetValue(e.Item.DataItem, null));

                lblName.Text = textValue;
                chkID.Checked = LoadSelected(value);
                chkOriginalID.Checked = chkID.Checked;
                hfID.Value = value.ToString();

            }
        }

        #endregion

        #region "Methods"

        private bool LoadSelected(int Id)
        {
            bool selected = false;

            if (SiteDataSource != null)
            {
                foreach (object obj in (IList)SiteDataSource)
                {
                    PropertyInfo piTextField = obj.GetType().GetProperty(SiteDataValueField);
                    int value = (int)(piTextField.GetValue(obj, null));

                    if (value == Id)
                    {
                        selected = true;
                        break;
                    }
                }

            }

            return selected;
        }

        public void Bind()
        {
            if (DataSource != null)
            {
                rptSitesObject.DataSource = DataSource;
                rptSitesObject.DataBind();
            }
        }

        private List<int> GetSelectedValue()
        {
            List<int> selectedInteger = new List<int>();

            foreach (RepeaterItem e in rptSitesObject.Items)
            {
                if (e.ItemType == ListItemType.Item || e.ItemType == ListItemType.AlternatingItem)
                {
                    CheckBox chkID = (CheckBox)e.FindControl("chkID");

                    HiddenField hfID = (HiddenField)e.FindControl("hfID");

                    if (chkID.Checked)
                        selectedInteger.Add(Convert.ToInt32(hfID.Value));
                }
            }

            return selectedInteger;
        }

        private List<int> GetSelectedValueChanged()
        {
            List<int> selectedInteger = new List<int>();

            foreach (RepeaterItem e in rptSitesObject.Items)
            {
                if (e.ItemType == ListItemType.Item || e.ItemType == ListItemType.AlternatingItem)
                {
                    CheckBox chkID = (CheckBox)e.FindControl("chkID");
                    CheckBox chkOriginalID = (CheckBox)e.FindControl("chkOriginalID");

                    HiddenField hfID = (HiddenField)e.FindControl("hfID");

                    if (chkID.Checked != chkOriginalID.Checked)
                        selectedInteger.Add(Convert.ToInt32(hfID.Value));
                }
            }

            return selectedInteger;
        }

        #endregion

        #region "Properties"

        public object DataSource { get; set; }

        public object SiteDataSource { get; set; }

        public List<int> SelectedValues
        {
            get { return GetSelectedValue(); }
        }

        public string HeaderName { get; set; }

        public string DisplayName { get; set; }

        public string DataValueField { get; set; }

        public string DataTextField { get; set; }

        public string SiteDataValueField { get; set; }

        #endregion
    }
}