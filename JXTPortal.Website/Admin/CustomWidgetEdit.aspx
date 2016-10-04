<%@ Page Title="Custom Widget Edit" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true"
    CodeBehind="CustomWidgetEdit.aspx.cs" Inherits="JXTPortal.Website.Admin.CustomWidgetEdit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Custom Widget Edit
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" />
        </span>
        <ul class="form-section">
            <asp:HiddenField ID="hfCustomWidgetID" runat="server" />
            <li class="form-line" id="admin-adminUsersEdit">
                <label id="Label1" class="form-label-left" runat="server">
                    Unique Custom Widget Name:</label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="tbCustomWidgetName"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rvCustomWidgetName" runat="server" Display="Dynamic"
                        ErrorMessage="Required" ControlToValidate="tbCustomWidgetName" />
                </div>
            </li>
            <li class="form-line" id="admin-adminUserUsername">
                <label class="form-label-left">
                    Style Selector:</label>
                <div class="form-input">
                    <asp:DropDownList ID="ddlCSS" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rvCSS" runat="server" Display="Dynamic" ErrorMessage="Required"
                        ControlToValidate="ddlCSS" InitialValue="0" />
                </div>
            </li>
            <li class="form-line" id="admin-adminUserPassword">
                <label class="form-label-left">
                    Content:</label>
                <div class="form-input">
                    <FredCK:CKEditorControl ID="txtContent" runat="server" Width="650px" Height="400px" CustomConfig="custom_config.js"
                        Toolbar="FullToolbar" EnableViewState="false">
                    </FredCK:CKEditorControl>
                    <asp:CustomValidator ID="cvContent" runat="server" Display="Dynamic" ControlToValidate="txtContent"
                        ErrorMessage="Required" OnServerValidate="cvContent_ServerValidate"></asp:CustomValidator>
                </div>
            </li>
            <asp:PlaceHolder ID="phModified" runat="server" Visible="false">
                <li class="form-line" id="Li3">
                    <label class="form-label-left">
                        Active:</label>
                    <div class="form-input">
                        <asp:CheckBox ID="cbActive" runat="server" />
                    </div>
                </li>
                <li class="form-line" id="Li1">
                    <label class="form-label-left">
                        Modified Date:</label>
                    <div class="form-input">
                        <asp:Literal ID="ltModifiedDate" runat="server" />
                    </div>
                </li>
                <li class="form-line" id="Li2">
                    <label class="form-label-left">
                        Modified By:</label>
                    <div class="form-input">
                        <asp:Literal ID="ltModifiedBy" runat="server" />
                    </div>
                </li>
            </asp:PlaceHolder>
            <li class="form-line" id="admin-adminUser-button">
                <div class="form-input-wide">
                    <div class="form-buttons-wrapper">
                        <asp:Button ID="btnSubmit" runat="server" Text="Save" OnClick="btnSubmit_Click" CssClass="jxtadminbutton" />
                        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="jxtadminbutton" OnClick="btnBack_Click"
                            CausesValidation="False" />
                    </div>
                </div>
            </li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
