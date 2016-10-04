<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="DynamicPageWebPartTemplatesLinkEdit" Title="Web Containers - Link Container with Web Parts"
    CodeBehind="DynamicPageWebPartTemplatesLinkEdit.aspx.cs" %>

<%@ Register Src="~/Admin/UserControls/DynamicPageWebPartTemplatesLink.ascx" TagName="DynamicPageWebPartTemplatesLink"
    TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Dynamic Page Web Part Templates Link - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" EnableViewState="false" /></span>
        <ul class="form-section">
            <li class="form-line" id="Li1">
                <label class="form-label-left">
                    Site Web Parts:
                </label>
                <div class="form-input">
                    <asp:DropDownList ID="ddlSiteWebParts" runat="server" CssClass="form-dropdown">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="ReqVal_lstBoxSiteWebParts" runat="server" Display="Dynamic"
                        ControlToValidate="ddlSiteWebParts" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </div>
            </li>
            <li class="form-line" id="reg-business-type">
                <label class="form-label-left">
                    Web Part Template:
                </label>
                <div class="form-input">
                    <asp:DropDownList ID="ddlWebPartTemplate" runat="server" CssClass="form-dropdown"
                        AutoPostBack="true" />
                    <asp:RequiredFieldValidator ID="ReqVal_ddlWebPartTemplate" runat="server" Display="Dynamic"
                        ControlToValidate="ddlWebPartTemplate" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </div>
            </li>
            <li class="form-line" id="reg-username-field">
                <label class="form-label-left">
                    Sequence:<span class="form-required">*</span>
                </label>
                <div class="form-input">
                    <asp:TextBox ID="txtSequence" runat="server" CssClass="form-textbox validate[Numeric]"
                        Columns="5" />
                    <asp:RequiredFieldValidator ID="ReqVal_txtSequence" runat="server" Display="Dynamic"
                        ControlToValidate="txtSequence" ErrorMessage="Required" />
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Please enter the valid sequence"
                        ControlToValidate="txtSequence" MinimumValue="0" MaximumValue="99999" Display="Dynamic"></asp:RangeValidator>
                </div>
            </li>
            <li class="form-line" id="reg-bottom-button">
                <div class="form-input-wide">
                    <div class="form-buttons-wrapper">
                        <asp:Button ID="btnSave" runat="server" Text="Save Web Part" OnClick="btnSave_Click"
                            CssClass="jxtadminbutton" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                            CausesValidation="false" CssClass="jxtadminbutton" />
                    </div>
                </div>
            </li>
        </ul>
        <h4>
            Web Parts Linked to:</h4>
        <uc1:DynamicPageWebPartTemplatesLink ID="DynamicPageWebPartTemplatesLink1" runat="server"
            Visible="false" />
    </div>
</asp:Content>
