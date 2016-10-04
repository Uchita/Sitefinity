<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true"
    ValidateRequest="false" CodeBehind="CopySystemPage.aspx.cs" Inherits="JXTPortal.Website.Admin.CopySystemPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Copy System Page</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-all">
        <asp:MultiView ID="FormView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewAdvertiser" runat="server">
                <span class="form-message">
                    <asp:Literal ID="ltlMessage" runat="server" /></span>
                <ul class="form-section">
                    <li class="form-line" id="adv-accountsettings-field">
                        <label class="form-label-left">
                            System Page:
                        </label>
                        <div class="form-input">
                            <asp:DropDownList ID="ddlSystemPage" runat="server" DataTextField="PageName" DataValueField="PageName"
                                OnSelectedIndexChanged="ddlSystemPage_SelectedIndexChanged" AutoPostBack="True" />
                            <asp:RequiredFieldValidator ID="rfvSystemPage" runat="server" Display="Dynamic" ControlToValidate="ddlSystemPage"
                                InitialValue="0" ErrorMessage="Required" ValidationGroup="Copy" />
                        </div>
                    </li>
                    <li class="form-line" id="Li1">
                        <label class="form-label-left">
                            Site:
                        </label>
                        <div class="form-input">
                            <asp:DropDownList ID="ddlSite" runat="server" DataTextField="SiteName" DataValueField="SiteID" />
                        </div>
                    </li>
                </ul>
                <asp:Panel ID="pnlSystemPage" runat="server" Visible="false">
                    <ul class="form-section">
                        <li class="form-line" id="Li2">
                            <label class="form-label-left">
                                Content:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="tbContent" runat="server" ReadOnly="true" TextMode="MultiLine" Rows="15"
                                    Width="350" />
                            </div>
                        </li>
                    </ul>
                </asp:Panel>
                <ul class="form-section">
                    <li class="form-line" id="reg-bottom-button">
                        <div class="form-input-wide">
                            <div class="form-buttons-wrapper">
                                <asp:Button ID="CopyButton" runat="server" CausesValidation="True" CommandName="Insert"
                                    Text="Copy" CssClass="form-submit-button" OnClick="CopyButton_Click" ValidationGroup="Copy" />
                            </div>
                        </div>
                    </li>
                </ul>
                <asp:Panel ID="pnlMissingSystemPage" runat="server" Visible="false">
                    <hr />
                    <br />
                    <asp:CustomValidator ID="cvSystemPages" runat="server" Display="Dynamic" ErrorMessage="Please select a System Page"
                        OnServerValidate="cvSystemPages_ServerValidate" ValidationGroup="Replicate">
                    </asp:CustomValidator>
                    <br />
                    <asp:Repeater ID="rptSystemPages" runat="server" OnItemDataBound="rptSystemPages_ItemDataBound">
                        <ItemTemplate>
                            <br />
                            <asp:CheckBox ID="chkSystemPage" runat="server" />
                            <asp:Literal ID="ltlSystemPage" runat="server" />
                        </ItemTemplate>
                    </asp:Repeater>
                    <ul class="form-section">
                        <li class="form-line" id="Li3">
                            <div class="form-input-wide">
                                <div class="form-buttons-wrapper">
                                    <asp:Button ID="CopyButton2" runat="server" CausesValidation="True" CommandName="Insert"
                                        Text="Copy From Master Site" CssClass="form-submit-button" OnClick="CopyButton2_Click"
                                        ValidationGroup="Replicate" />
                                </div>
                            </div>
                        </li>
                    </ul>
                </asp:Panel>
            </asp:View>
        </asp:MultiView>
        <br />
        <br />
    </div>
</asp:Content>
