<%@ Page Language="C#" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"
    Inherits="DynamicPageWebPartTemplatesEdit" Title="Web Container Edit" CodeBehind="DynamicPageWebPartTemplatesEdit.aspx.cs" %>

<%@ Register Src="~/Admin/UserControls/DynamicPageWebPartTemplatesLink.ascx" TagName="DynamicPageWebPartTemplatesLink"
    TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Site Web Parts Template - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
        <ul class="form-section">
            <li class="form-line" id="reg-username-field">
                <label class="form-label-left">
                    Template Name:<span class="form-required">*</span>
                </label>
                <div class="form-input">
                    <asp:TextBox ID="txtWebPartTemplateName" runat="server" /><asp:RequiredFieldValidator
                        ID="ReqVal_WebPartTemplateName" runat="server" Display="Dynamic" ControlToValidate="txtWebPartTemplateName"
                        ErrorMessage="Required"></asp:RequiredFieldValidator>
                </div>
            </li>
            <li class="form-line">
                <label class="form-label-left">
                    Last Modified:
                </label>
                <div class="form-input">
                    <asp:Literal ID="ltlLastModified" runat="server" Text="" />
                </div>
            </li>
            <li class="form-line">
                <label class="form-label-left">
                    Last Modified By:
                </label>
                <div class="form-input">
                    <asp:Literal ID="ltlLastModifiedBy" runat="server" Text="" />
                </div>
            </li>
            <li class="form-line" id="reg-bottom-button">
                <div class="form-input-wide">
                    <div class="form-buttons-wrapper">
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="jxtadminbutton" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                            CausesValidation="false" CssClass="jxtadminbutton" />
                    </div>
                </div>
            </li>
        </ul>
        <h4>
            Web Parts Linked to:</h4>
        <uc1:DynamicPageWebPartTemplatesLink ID="DynamicPageWebPartTemplatesLink1" runat="server" />
    </div>
</asp:Content>
