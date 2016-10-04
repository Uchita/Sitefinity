using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using JXTPortal;
using JXTPortal.Entities;
using System.IO;
using System.Configuration;
using System.Web.Script.Serialization;
using JXTPortal.Client.Bullhorn;

namespace JXTPortal.Website.Admin.bullhorn
{
    public partial class AdvertisersMapping : System.Web.UI.Page
    {
        private IntegrationMappingsService _integrationMappingService = null;
        private IntegrationMappingsService IntegrationMappingsService
        {
            get
            {
                if (_integrationMappingService == null)
                {
                    _integrationMappingService = new IntegrationMappingsService();
                }
                return _integrationMappingService;
            }
        }

        private List<ListItem> _clientCorporationDDLItems = new List<ListItem>();
        private List<ListItem> _clientContactDDLItems = new List<ListItem>();

        private BullhornRESTAPI _BHAPI;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadForm();
            }
        }

        private string ScriptToExecute = "";

        private void LoadForm()
        {
            IntegrationsService IntegrationsService = new IntegrationsService();
            JXTPortal.Entities.Models.AdminIntegrations.Integrations Integrations = IntegrationsService.AdminIntegrationsForSiteGet(SessionData.Site.SiteId);

            if (Integrations != null && Integrations.Bullhorn != null)
            {
                if (Integrations.Bullhorn.Valid == false || Integrations.Bullhorn.EnableAdvertiserSync == false)
                {
                    ltlMessage.Text = "Currently Bullhorn Advertiser Sync is not enabled to view the mappings";

                    return;
                }

                string errorMsg = string.Empty;

                _BHAPI = new BullhornRESTAPI(SessionData.Site.SiteId);

                ClientCorporationDDLItemsGet();
                ClientContactDDLItemsGet();

            }
            else
            {
                ltlMessage.Text = "Currently Bullhorn Advertiser Sync is not enabled to view the mappings";
                return;
            }

            TList<IntegrationMappings> defaultmappings = IntegrationMappingsService.GetAll();
            defaultmappings.Filter = "GlobalMapping = True AND JXTEntity = 'Advertisers'";

            if (defaultmappings.Count > 0)
            {
                rptAdvertisersMapping.DataSource = defaultmappings;
                rptAdvertisersMapping.DataBind();
            }

            TList<IntegrationMappings> sitemappings = IntegrationMappingsService.GetBySiteId(SessionData.Site.SiteId);
            sitemappings.Filter = "GlobalMapping = False AND JXTEntity = 'Advertisers'";

            if (sitemappings.Count > 0)
            {
                foreach (IntegrationMappings sitemapping in sitemappings)
                {
                    if (sitemapping.Sync.HasValue && sitemapping.Sync.Value == 1)
                    {
                        foreach (RepeaterItem item in rptAdvertisersMapping.Items)
                        {
                            CheckBox cbSync = item.FindControl("cbSync") as CheckBox;
                            HiddenField hfAdvertiserMappingID = item.FindControl("hfAdvertiserMappingID") as HiddenField;
                            HiddenField hfDefaultAdvertiserMappingID = item.FindControl("hfDefaultAdvertiserMappingID") as HiddenField;
                            HiddenField hfJXTEntity = item.FindControl("hfJXTEntity") as HiddenField;
                            Literal ltJXTColumn = item.FindControl("ltJXTColumn") as Literal;
                            TextBox tbThirdPartyColumn = item.FindControl("tbThirdPartyColumn") as TextBox;
                            DropDownList ddlThirdPartyColumn = item.FindControl("ddlThirdPartyColumn") as DropDownList;
                            DropDownList ddlThirdPartyType = item.FindControl("ddlThirdPartyType") as DropDownList;
                            TextBox tbThirdPartySize = item.FindControl("tbThirdPartySize") as TextBox;

                            IntegrationMappings defaultmapping = item.DataItem as IntegrationMappings;
                            string column = ltJXTColumn.Text.Split(new char[] { ' ' })[0];
                            if (sitemapping.JxtEntity == hfJXTEntity.Value && sitemapping.JxtColumn == HttpUtility.HtmlDecode(column))
                            {
                                cbSync.Checked = true;
                                hfAdvertiserMappingID.Value = sitemapping.IntegrationMappingId.ToString();
                                tbThirdPartyColumn.Text = sitemapping.ThirdPartyColumn;
                                ddlThirdPartyColumn.SelectedValue = sitemapping.ThirdPartyColumn;
                                ddlThirdPartyType.SelectedValue = sitemapping.ThirdPartyType;
                                tbThirdPartySize.Text = (sitemapping.ThirdPartySize.HasValue) ? sitemapping.ThirdPartySize.Value.ToString() : string.Empty;
                                break;
                            }
                        }
                    }
                }
            }

            TList<IntegrationMappings> defaultusermappings = IntegrationMappingsService.GetAll();
            defaultusermappings.Filter = "GlobalMapping = True AND JXTEntity = 'AdvertiserUsers'";

            if (defaultusermappings.Count > 0)
            {
                rptAdvertiserUsersMapping.DataSource = defaultusermappings;
                rptAdvertiserUsersMapping.DataBind();
            }

            TList<IntegrationMappings> siteusermappings = IntegrationMappingsService.GetBySiteId(SessionData.Site.SiteId);
            siteusermappings.Filter = "GlobalMapping = False AND JXTEntity = 'AdvertiserUsers'";

            if (siteusermappings.Count > 0)
            {
                foreach (IntegrationMappings siteusermapping in siteusermappings)
                {
                    if (siteusermapping.Sync.HasValue && siteusermapping.Sync.Value == 1)
                    {
                        foreach (RepeaterItem item in rptAdvertiserUsersMapping.Items)
                        {
                            CheckBox cbSync = item.FindControl("cbSync") as CheckBox;
                            HiddenField hfAdvertiserUserMappingID = item.FindControl("hfAdvertiserUserMappingID") as HiddenField;
                            HiddenField hfDefaultAdvertiserUserMappingID = item.FindControl("hfDefaultAdvertiserUserMappingID") as HiddenField;
                            HiddenField hfJXTEntity = item.FindControl("hfJXTEntity") as HiddenField;
                            Literal ltJXTColumn = item.FindControl("ltJXTColumn") as Literal;
                            TextBox tbThirdPartyColumn = item.FindControl("tbThirdPartyColumn") as TextBox;
                            DropDownList ddlThirdPartyColumn = item.FindControl("ddlThirdPartyColumn") as DropDownList;
                            DropDownList ddlThirdPartyType = item.FindControl("ddlThirdPartyType") as DropDownList;
                            TextBox tbThirdPartySize = item.FindControl("tbThirdPartySize") as TextBox;

                            IntegrationMappings defaultmapping = item.DataItem as IntegrationMappings;
                            string column = ltJXTColumn.Text.Split(new char[] { ' ' })[0];
                            if (siteusermapping.JxtEntity == hfJXTEntity.Value && siteusermapping.JxtColumn == HttpUtility.HtmlDecode(column))
                            {
                                cbSync.Checked = true;
                                hfAdvertiserUserMappingID.Value = siteusermapping.IntegrationMappingId.ToString();
                                tbThirdPartyColumn.Text = siteusermapping.ThirdPartyColumn;
                                ddlThirdPartyColumn.SelectedValue = siteusermapping.ThirdPartyColumn;
                                ddlThirdPartyType.SelectedValue = siteusermapping.ThirdPartyType;
                                tbThirdPartySize.Text = (siteusermapping.ThirdPartySize.HasValue) ? siteusermapping.ThirdPartySize.Value.ToString() : string.Empty;
                                break;
                            }
                        }
                    }
                }
            }


            if (!string.IsNullOrWhiteSpace(ScriptToExecute))
            {
                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "TypeChangedJS", "$().ready(function() {" + ScriptToExecute + "});", true);
            }
        }

        private void ClientCorporationDDLItemsGet()
        {
            string meta1 = _BHAPI.BullhornMeta(SessionData.Site.SiteId, "ClientCorporation", new List<string> { "*" });

            JavaScriptSerializer ser = new JavaScriptSerializer();
            BullhornClientCorporation clientcorporation = ser.Deserialize<BullhornClientCorporation>(meta1);

            if (clientcorporation.fields != null)
            {
                foreach (BullhornClientCorporationFields field in clientcorporation.fields)
                {
                    ListItem thisNewListItem;
                    if (field.fields == null && field.associatedEntity == null)
                    {
                        thisNewListItem = new ListItem(field.name + " (" + field.dataType +
                            (field.maxLength == null || field.maxLength == 0 ? string.Empty : (" - " + field.maxLength))
                             + ")" + ((field.optional.HasValue && field.optional.Value == false) ? " (Required)" : string.Empty), field.name);
                        thisNewListItem.Attributes.Add("data-datatype", field.dataType);
                        if(field.maxLength != null && field.maxLength > 0 )
                            thisNewListItem.Attributes.Add("data-maxlength", field.maxLength.ToString());

                        _clientCorporationDDLItems.Add(thisNewListItem);
                    }
                    else
                    {
                        if (field.fields != null)
                        {
                            foreach (BullhornClientCorporationInnerFields innerfield in field.fields)
                            {
                                thisNewListItem = new ListItem(field.name + " - " + innerfield.name + " (" + innerfield.dataType +
                                    (innerfield.maxLength == 0 ? string.Empty : (" - " + innerfield.maxLength))
                                     + ")" + ((innerfield.optional.HasValue && innerfield.optional.Value == false) ? " (Required)" : string.Empty), //list item text
                                     field.name + " - " + innerfield.name //list item value
                                     );
                                thisNewListItem.Attributes.Add("data-datatype", innerfield.dataType);
                                if (innerfield.maxLength != null && innerfield.maxLength > 0)
                                    thisNewListItem.Attributes.Add("data-maxlength", innerfield.maxLength.ToString());

                                _clientCorporationDDLItems.Add(thisNewListItem);
                            }
                        }

                        if (field.associatedEntity != null)
                        {
                            if (field.associatedEntity.fields != null)
                            {
                                foreach (BullhornClientCorporationInnerFields innerfield in field.associatedEntity.fields)
                                {
                                    thisNewListItem = new ListItem(field.name + " - " + innerfield.name + " (" + innerfield.dataType +
                                        (innerfield.maxLength == 0 ? string.Empty : (" - " + innerfield.maxLength))
                                         + ")" + ((innerfield.optional.HasValue && innerfield.optional.Value == false) ? " (Required)" : string.Empty), //list item text
                                         field.name + " - " + innerfield.name //list item value
                                         );
                                    thisNewListItem.Attributes.Add("data-datatype", innerfield.dataType);
                                    if (innerfield.maxLength != null && innerfield.maxLength > 0)
                                        thisNewListItem.Attributes.Add("data-maxlength", innerfield.maxLength.ToString());
                                    _clientCorporationDDLItems.Add(thisNewListItem);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ClientContactDDLItemsGet()
        {
            string meta2 = _BHAPI.BullhornMeta(SessionData.Site.SiteId, "ClientContact", new List<string> { "*" });
            JavaScriptSerializer ser = new JavaScriptSerializer();
            BullhornClientCorporation clientcontact = ser.Deserialize<BullhornClientCorporation>(meta2);

            if (clientcontact.fields != null)
            {
                foreach (BullhornClientCorporationFields field in clientcontact.fields)
                {
                    ListItem thisNewListItem;
                    if (field.fields == null && field.associatedEntity == null)
                    {
                        thisNewListItem = new ListItem(field.name + " (" + field.dataType +
                            (field.maxLength == null || field.maxLength == 0 ? string.Empty : (" - " + field.maxLength))
                             + ")" + ((field.optional.HasValue && field.optional.Value == false) ? " (Required)" : string.Empty), field.name);
                        thisNewListItem.Attributes.Add("data-datatype", field.dataType);
                        if (field.maxLength != null && field.maxLength > 0)
                            thisNewListItem.Attributes.Add("data-maxlength", field.maxLength.ToString());
                        _clientContactDDLItems.Add(thisNewListItem);
                    }
                    else
                    {
                        if (field.fields != null)
                        {
                            foreach (BullhornClientCorporationInnerFields innerfield in field.fields)
                            {
                                thisNewListItem = new ListItem(field.name + " - " + innerfield.name + " (" + innerfield.dataType +
                                    (innerfield.maxLength == 0 ? string.Empty : (" - " + innerfield.maxLength))
                                     + ")" + ((innerfield.optional.HasValue && innerfield.optional.Value == false) ? " (Required)" : string.Empty), //item list text
                                     field.name + " - " + innerfield.name //item list value
                                     );
                                thisNewListItem.Attributes.Add("data-datatype", innerfield.dataType);
                                if (innerfield.maxLength != null && innerfield.maxLength > 0)
                                    thisNewListItem.Attributes.Add("data-maxlength", innerfield.maxLength.ToString());
                                _clientContactDDLItems.Add(thisNewListItem);
                            }
                        }

                        if (field.associatedEntity != null)
                        {
                            if (field.associatedEntity.fields != null)
                            {
                                foreach (BullhornClientCorporationInnerFields innerfield in field.associatedEntity.fields)
                                {
                                    thisNewListItem = new ListItem(field.name + " - " + innerfield.name + " (" + innerfield.dataType +
                                        (innerfield.maxLength == 0 ? string.Empty : (" - " + innerfield.maxLength))
                                         + ")" + ((innerfield.optional.HasValue && innerfield.optional.Value == false) ? " (Required)" : string.Empty), //item list text
                                        field.name + " - " + innerfield.name //item list value
                                     );
                                    thisNewListItem.Attributes.Add("data-datatype", innerfield.dataType);
                                    if (innerfield.maxLength != null && innerfield.maxLength > 0)
                                        thisNewListItem.Attributes.Add("data-maxlength", innerfield.maxLength.ToString());

                                    _clientContactDDLItems.Add(thisNewListItem);
                                }
                            }
                        }
                    }
                }
            }

        }

        protected void rptAdvertisersMapping_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            ltlMessage.Text = "";

            if (e.CommandName == "Update")
            {
                bool hasError = false;

                foreach (RepeaterItem item in rptAdvertisersMapping.Items)
                {
                    CheckBox cbSync = item.FindControl("cbSync") as CheckBox;
                    TextBox tbThirdPartyColumn = item.FindControl("tbThirdPartyColumn") as TextBox;
                    TextBox tbThirdPartySize = item.FindControl("tbThirdPartySize") as TextBox;
                    Literal ltThirdPartyColumnError = item.FindControl("ltThirdPartyColumnError") as Literal;
                    if (cbSync.Checked)
                    {
                        if (string.IsNullOrWhiteSpace(tbThirdPartyColumn.Text))
                        {
                            ltThirdPartyColumnError.Text = "<span style=\"color: red;\">Required</span>";
                            hasError = true;
                        }
                        else
                        {
                            ltThirdPartyColumnError.Text = string.Empty;
                        }
                    }
                }

                if (!hasError)
                {
                    foreach (RepeaterItem item in rptAdvertisersMapping.Items)
                    {
                        CheckBox cbSync = item.FindControl("cbSync") as CheckBox;
                        HiddenField hfAdvertiserMappingID = item.FindControl("hfAdvertiserMappingID") as HiddenField;
                        HiddenField hfDefaultAdvertiserMappingID = item.FindControl("hfDefaultAdvertiserMappingID") as HiddenField;
                        HiddenField hfJXTEntity = item.FindControl("hfJXTEntity") as HiddenField;
                        Literal ltJXTColumn = item.FindControl("ltJXTColumn") as Literal;
                        TextBox tbThirdPartyColumn = item.FindControl("tbThirdPartyColumn") as TextBox;
                        DropDownList ddlThirdPartyColumn = item.FindControl("ddlThirdPartyColumn") as DropDownList;
                        DropDownList ddlThirdPartyType = item.FindControl("ddlThirdPartyType") as DropDownList;
                        TextBox tbThirdPartySize = item.FindControl("tbThirdPartySize") as TextBox;

                        if (cbSync.Checked)
                        {
                            if (!string.IsNullOrWhiteSpace(hfAdvertiserMappingID.Value))
                            {
                                // Update Current Record
                                using (IntegrationMappings mapping = IntegrationMappingsService.GetByIntegrationMappingId(Convert.ToInt32(hfAdvertiserMappingID.Value)))
                                {
                                    if (mapping != null)
                                    {
                                        //mapping.ThirdPartyColumn = tbThirdPartyColumn.Text;
                                        mapping.ThirdPartyColumn = ddlThirdPartyColumn.SelectedValue;
                                        mapping.ThirdPartyType = ddlThirdPartyType.SelectedValue;
                                        mapping.ThirdPartySize = (!string.IsNullOrWhiteSpace(tbThirdPartySize.Text)) ? Convert.ToInt32(tbThirdPartySize.Text) : (int?)null;
                                        mapping.Sync = (cbSync.Checked) ? 1 : 0;
                                        mapping.LastModifiedBy = SessionData.AdminUser.AdminUserId;
                                        mapping.LastModifiedDate = DateTime.Now;

                                        IntegrationMappingsService.Update(mapping);
                                    }
                                }
                            }
                            else
                            {
                                // Add New Record
                                using (IntegrationMappings defaultmapping = IntegrationMappingsService.GetByIntegrationMappingId(Convert.ToInt32(hfDefaultAdvertiserMappingID.Value)))
                                {
                                    if (defaultmapping != null)
                                    {
                                        IntegrationMappings mapping = new IntegrationMappings();

                                        mapping.SiteId = SessionData.Site.SiteId;
                                        mapping.IntegrationMappingTypeId = defaultmapping.IntegrationMappingTypeId;
                                        mapping.JxtEntity = defaultmapping.JxtEntity;
                                        mapping.JxtColumn = defaultmapping.JxtColumn;
                                        mapping.JxtType = defaultmapping.JxtType;
                                        mapping.JxtSize = defaultmapping.JxtSize;
                                        mapping.ThirdPartyEntity = defaultmapping.ThirdPartyEntity;
                                        //mapping.ThirdPartyColumn = tbThirdPartyColumn.Text;
                                        mapping.ThirdPartyColumn = ddlThirdPartyColumn.SelectedValue;
                                        mapping.ThirdPartyType = ddlThirdPartyType.SelectedValue;
                                        mapping.ThirdPartySize = (!string.IsNullOrWhiteSpace(tbThirdPartySize.Text)) ? Convert.ToInt32(tbThirdPartySize.Text) : (int?)null;
                                        mapping.Sequence = defaultmapping.Sequence;
                                        mapping.Sync = (cbSync.Checked) ? 1 : 0;
                                        mapping.GlobalMapping = false;
                                        mapping.LastModifiedBy = SessionData.AdminUser.AdminUserId;
                                        mapping.LastModifiedDate = DateTime.Now;

                                        IntegrationMappingsService.Insert(mapping);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrWhiteSpace(hfAdvertiserMappingID.Value))
                            {
                                IntegrationMappingsService.Delete(Convert.ToInt32(hfAdvertiserMappingID.Value));
                            }
                        }
                    }

                    LoadForm();

                    ltlMessage.Text = "Advertisers Mapping updated successfully";
                }
                else
                {
                    ltlMessage.Text = "Error Occurred";
                }
            }
        }

        protected void rptAdvertisersMapping_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                CheckBox cbSync = e.Item.FindControl("cbSync") as CheckBox;
                HiddenField hfAdvertiserMappingID = e.Item.FindControl("hfAdvertiserMappingID") as HiddenField;
                HiddenField hfDefaultAdvertiserMappingID = e.Item.FindControl("hfDefaultAdvertiserMappingID") as HiddenField;
                HiddenField hfJXTEntity = e.Item.FindControl("hfJXTEntity") as HiddenField;
                Literal ltJXTColumn = e.Item.FindControl("ltJXTColumn") as Literal;
                TextBox tbThirdPartyColumn = e.Item.FindControl("tbThirdPartyColumn") as TextBox;
                DropDownList ddlThirdPartyColumn = e.Item.FindControl("ddlThirdPartyColumn") as DropDownList;
                DropDownList ddlThirdPartyType = e.Item.FindControl("ddlThirdPartyType") as DropDownList;
                TextBox tbThirdPartySize = e.Item.FindControl("tbThirdPartySize") as TextBox;

                IntegrationMappings mapping = e.Item.DataItem as IntegrationMappings;

                hfDefaultAdvertiserMappingID.Value = mapping.IntegrationMappingId.ToString();
                hfJXTEntity.Value = mapping.JxtEntity;
                ltJXTColumn.Text = HttpUtility.HtmlEncode(string.Format("{0} - {1} {2}", mapping.JxtColumn, mapping.JxtType, (mapping.JxtSize.HasValue) ? "(" + mapping.JxtSize.Value + ")" : string.Empty));
                tbThirdPartyColumn.Text = mapping.ThirdPartyColumn;
                ddlThirdPartyType.SelectedValue = mapping.ThirdPartyType;
                tbThirdPartySize.Text = (mapping.ThirdPartySize.HasValue) ? mapping.ThirdPartySize.Value.ToString() : string.Empty;
                ddlThirdPartyType.Attributes.Add("onchange", "TypeChanged('" + ddlThirdPartyType.ClientID + "', '" + tbThirdPartySize.ClientID + "')");

                foreach (ListItem itemRef in _clientCorporationDDLItems)
                {
                    ListItem thisItem = new ListItem(itemRef.Text, itemRef.Value);
                    foreach (string k in itemRef.Attributes.Keys)
                    {
                        thisItem.Attributes.Add(k, itemRef.Attributes[k]);
                    }

                    ddlThirdPartyColumn.Items.Add(thisItem);
                }

                ScriptToExecute += "TypeChanged('" + ddlThirdPartyType.ClientID + "', '" + tbThirdPartySize.ClientID + "');";
            }
        }

        protected void rptAdvertiserUsersMapping_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            ltlMessage.Text = "";

            if (e.CommandName == "Update")
            {
                bool hasError = false;

                foreach (RepeaterItem item in rptAdvertiserUsersMapping.Items)
                {
                    CheckBox cbSync = item.FindControl("cbSync") as CheckBox;
                    TextBox tbThirdPartyColumn = item.FindControl("tbThirdPartyColumn") as TextBox;
                    TextBox tbThirdPartySize = item.FindControl("tbThirdPartySize") as TextBox;
                    Literal ltThirdPartyColumnError = item.FindControl("ltThirdPartyColumnError") as Literal;
                    if (cbSync.Checked)
                    {
                        if (string.IsNullOrWhiteSpace(tbThirdPartyColumn.Text))
                        {
                            ltThirdPartyColumnError.Text = "<span style=\"color: red;\">Required</span>";
                            hasError = true;
                        }
                        else
                        {
                            ltThirdPartyColumnError.Text = string.Empty;
                        }
                    }
                }

                if (!hasError)
                {
                    foreach (RepeaterItem item in rptAdvertiserUsersMapping.Items)
                    {
                        CheckBox cbSync = item.FindControl("cbSync") as CheckBox;
                        HiddenField hfAdvertiserUserMappingID = item.FindControl("hfAdvertiserUserMappingID") as HiddenField;
                        HiddenField hfDefaultAdvertiserUserMappingID = item.FindControl("hfDefaultAdvertiserUserMappingID") as HiddenField;
                        HiddenField hfJXTEntity = item.FindControl("hfJXTEntity") as HiddenField;
                        Literal ltJXTColumn = item.FindControl("ltJXTColumn") as Literal;
                        TextBox tbThirdPartyColumn = item.FindControl("tbThirdPartyColumn") as TextBox;
                        DropDownList ddlThirdPartyColumn = item.FindControl("ddlThirdPartyColumn") as DropDownList;
                        DropDownList ddlThirdPartyType = item.FindControl("ddlThirdPartyType") as DropDownList;
                        TextBox tbThirdPartySize = item.FindControl("tbThirdPartySize") as TextBox;

                        if (cbSync.Checked)
                        {
                            if (!string.IsNullOrWhiteSpace(hfAdvertiserUserMappingID.Value))
                            {
                                // Update Current Record
                                using (IntegrationMappings mapping = IntegrationMappingsService.GetByIntegrationMappingId(Convert.ToInt32(hfAdvertiserUserMappingID.Value)))
                                {
                                    if (mapping != null)
                                    {
                                        //mapping.ThirdPartyColumn = tbThirdPartyColumn.Text;
                                        mapping.ThirdPartyColumn = ddlThirdPartyColumn.SelectedValue;
                                        mapping.ThirdPartyType = ddlThirdPartyType.SelectedValue;
                                        mapping.ThirdPartySize = (!string.IsNullOrWhiteSpace(tbThirdPartySize.Text)) ? Convert.ToInt32(tbThirdPartySize.Text) : (int?)null;
                                        mapping.Sync = (cbSync.Checked) ? 1 : 0;
                                        mapping.LastModifiedBy = SessionData.AdminUser.AdminUserId;
                                        mapping.LastModifiedDate = DateTime.Now;

                                        IntegrationMappingsService.Update(mapping);
                                    }
                                }
                            }
                            else
                            {
                                // Add New Record
                                using (IntegrationMappings defaultmapping = IntegrationMappingsService.GetByIntegrationMappingId(Convert.ToInt32(hfDefaultAdvertiserUserMappingID.Value)))
                                {
                                    if (defaultmapping != null)
                                    {
                                        IntegrationMappings mapping = new IntegrationMappings();

                                        mapping.SiteId = SessionData.Site.SiteId;
                                        mapping.IntegrationMappingTypeId = defaultmapping.IntegrationMappingTypeId;
                                        mapping.JxtEntity = defaultmapping.JxtEntity;
                                        mapping.JxtColumn = defaultmapping.JxtColumn;
                                        mapping.JxtType = defaultmapping.JxtType;
                                        mapping.JxtSize = defaultmapping.JxtSize;
                                        mapping.ThirdPartyEntity = defaultmapping.ThirdPartyEntity;
                                        //mapping.ThirdPartyColumn = tbThirdPartyColumn.Text;
                                        mapping.ThirdPartyColumn = ddlThirdPartyColumn.SelectedValue;
                                        mapping.ThirdPartyType = ddlThirdPartyType.SelectedValue;
                                        mapping.ThirdPartySize = (!string.IsNullOrWhiteSpace(tbThirdPartySize.Text)) ? Convert.ToInt32(tbThirdPartySize.Text) : (int?)null;
                                        mapping.Sequence = defaultmapping.Sequence;
                                        mapping.Sync = (cbSync.Checked) ? 1 : 0;
                                        mapping.GlobalMapping = false;
                                        mapping.LastModifiedBy = SessionData.AdminUser.AdminUserId;
                                        mapping.LastModifiedDate = DateTime.Now;

                                        IntegrationMappingsService.Insert(mapping);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrWhiteSpace(hfAdvertiserUserMappingID.Value))
                            {
                                IntegrationMappingsService.Delete(Convert.ToInt32(hfAdvertiserUserMappingID.Value));
                            }
                        }
                    }

                    LoadForm();

                    ltlMessage.Text = "Advertisers Mapping updated successfully";
                }
                else
                {
                    ltlMessage.Text = "Error Occurred";
                }
            }
        }

        protected void rptAdvertiserUsersMapping_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                CheckBox cbSync = e.Item.FindControl("cbSync") as CheckBox;
                HiddenField hfAdvertiserUserMappingID = e.Item.FindControl("hfAdvertiserUserMappingID") as HiddenField;
                HiddenField hfDefaultAdvertiserMappingID = e.Item.FindControl("hfDefaultAdvertiserUserMappingID") as HiddenField;
                HiddenField hfJXTEntity = e.Item.FindControl("hfJXTEntity") as HiddenField;
                Literal ltJXTColumn = e.Item.FindControl("ltJXTColumn") as Literal;
                TextBox tbThirdPartyColumn = e.Item.FindControl("tbThirdPartyColumn") as TextBox;
                DropDownList ddlThirdPartyType = e.Item.FindControl("ddlThirdPartyType") as DropDownList;
                TextBox tbThirdPartySize = e.Item.FindControl("tbThirdPartySize") as TextBox;
                DropDownList ddlThirdPartyColumn = e.Item.FindControl("ddlThirdPartyColumn") as DropDownList;

                IntegrationMappings mapping = e.Item.DataItem as IntegrationMappings;

                hfDefaultAdvertiserMappingID.Value = mapping.IntegrationMappingId.ToString();
                hfJXTEntity.Value = mapping.JxtEntity;
                ltJXTColumn.Text = HttpUtility.HtmlEncode(string.Format("{0} - {1} {2}", mapping.JxtColumn, mapping.JxtType, (mapping.JxtSize.HasValue) ? "(" + mapping.JxtSize.Value + ")" : string.Empty));
                tbThirdPartyColumn.Text = mapping.ThirdPartyColumn;
                ddlThirdPartyType.SelectedValue = mapping.ThirdPartyType;
                tbThirdPartySize.Text = (mapping.ThirdPartySize.HasValue) ? mapping.ThirdPartySize.Value.ToString() : string.Empty;
                ddlThirdPartyType.Attributes.Add("onchange", "TypeChanged('" + ddlThirdPartyType.ClientID + "', '" + tbThirdPartySize.ClientID + "')");

                foreach (ListItem itemRef in _clientContactDDLItems)
                {
                    ListItem thisItem = new ListItem(itemRef.Text, itemRef.Value);
                    foreach (string k in itemRef.Attributes.Keys)
                    {
                        thisItem.Attributes.Add(k, itemRef.Attributes[k]);
                    }

                    ddlThirdPartyColumn.Items.Add(thisItem);
                }
                ScriptToExecute += "TypeChanged('" + ddlThirdPartyType.ClientID + "', '" + tbThirdPartySize.ClientID + "');";
            }
        }

        internal class BullhornClientCorporationOption
        {
            public string value { get; set; }
            public string label { get; set; }
        }

        internal class BullhornClientCorporationInnerFields
        {
            public string name { get; set; }
            public string type { get; set; }
            public string dataType { get; set; }
            public int maxLength { get; set; }
            public bool confidential { get; set; }
            public bool? optional { get; set; }
            public string label { get; set; }
            public bool hideFromSearch { get; set; }
            public string optionsType { get; set; }
            public string optionsUrl { get; set; }
            public List<BullhornClientCorporationOption> options { get; set; }
        }

        internal class BullhornClientCorporationAssociatedEntity
        {
            public string entity { get; set; }
            public string entityMetaUrl { get; set; }
            public string label { get; set; }
            public List<BullhornClientCorporationInnerFields> fields { get; set; }
        }

        internal class BullhornClientCorporationFields
        {
            public string name { get; set; }
            public string type { get; set; }
            public string dataType { get; set; }
            public bool required { get; set; }
            public bool? confidential { get; set; }
            public bool? optional { get; set; }
            public string label { get; set; }
            public bool? hideFromSearch { get; set; }
            public List<BullhornClientCorporationInnerFields> fields { get; set; }
            public long? maxLength { get; set; }
            public List<BullhornClientCorporationOption> options { get; set; }
            public string optionsType { get; set; }
            public string optionsUrl { get; set; }
            public BullhornClientCorporationAssociatedEntity associatedEntity { get; set; }
        }

        internal class BullhornClientCorporation
        {
            public string entity { get; set; }
            public string entityMetaUrl { get; set; }
            public string label { get; set; }
            public List<BullhornClientCorporationFields> fields { get; set; }
        }
    }
}