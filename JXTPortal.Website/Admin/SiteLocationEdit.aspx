<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="SiteLocationEdit" Title="SiteLocation Edit"
    CodeBehind="SiteLocationEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Site Location - Add/Edit
    <a href='http://support.jxt.com.au/solution/articles/116444-site-locations' class='jxt-help-page' title='click here for help on this page'  target='_blank'>help on this page</a>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
        <asp:MultiView ID="MultiViewSiteProfession" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewSiteProfession" runat="server">
                <ul class="form-section">
                    <li class="form-line" id="sl-defaultlocation-field">
                        <label class="form-label-left">
                            <strong>Default Location</strong></label>
                        <div class="form-input">
                        </div>
                    </li>
                    <li class="form-line" id="sl-defaultlocationname-field">
                        <label class="form-label-left">
                            Location Name:</label>
                        <div class="form-input">
                            <asp:Label ID="lbLocationName" runat="server" />
                        </div>
                    </li>
                    <li class="form-line" id="sl-sitelocation-field">
                        <label class="form-label-left">
                            <strong>Site Location</strong></label>
                        <div class="form-input">
                        </div>
                    </li>
                    <li class="form-line" id="sl-sitelocationname-field">
                        <label class="form-label-left">
                            Location Name:</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataLocationName" runat="server" Width="250" />
                            <asp:RequiredFieldValidator ID="ReqVal_LocationName" runat="server" ErrorMessage="Required"
                                ControlToValidate="dataLocationName" />
                        </div>
                    </li>
                    <li class="form-line" id="sl-sitelocationfriendlyurl-field">
                        <label class="form-label-left">
                            Friendly Url:</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataFriendlyUrl" runat="server" Width="250" />
                            <asp:RequiredFieldValidator ID="ReqVal_dataFriendlyUrl" runat="server" ErrorMessage="Required"
                                ControlToValidate="dataFriendlyUrl" />
                        </div>
                    </li>
                    <li class="form-line">
                        <div class="form-input-wide">
                            <div class="form-buttons-wrapper">
                                <asp:Button ID="btnEditSave" runat="server" Text="Update" OnClick="btnEditSave_Click"
                                    CssClass="jxtadminbutton" />
                                <asp:Button ID="btnReturn" runat="server" Text="Return" OnClick="btnReturn_Click"
                                    CssClass="jxtadminbutton" CausesValidation="false" />
                            </div>
                        </div>
                    </li>
                </ul>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
