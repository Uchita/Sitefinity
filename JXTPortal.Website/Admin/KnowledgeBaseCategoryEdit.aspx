<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="KnowledgeBaseCategoryEdit" Title="Global - Knowledgebase Category Edit"
    CodeBehind="KnowledgeBaseCategoryEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Knowledge Base Category Edit <a href='http://support.jxt.com.au/solution/articles/116437-create-edit-admin-content-editor-and-external-users'
        class='jxt-help-page' title='click here for help on this page' target='_blank'>help
        on this page</a>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" />
        </span>
        <ul class="form-section">
            <li class="form-line">
                <label id="Label1" class="form-label-left" runat="server">
                    Knowledgebase Category Name:</label>
                <div class="form-input">
                    <asp:TextBox ID="txtCategoryName" runat="server" />
                    <asp:RequiredFieldValidator ID="rvCategoryName" runat="server" Display="Dynamic"
                        ErrorMessage="Required" ControlToValidate="txtCategoryName" InitialValue="0" />
                </div>
            </li>
            <li class="form-line">
                <label class="form-label-left">
                    Category:</label>
                <div class="form-input">
                    <asp:DropDownList runat="server" ID="ddlCategory" CssClass="checkbox">
                    </asp:DropDownList>
                </div>
            </li>
            <li class="form-line">
                <label class="form-label-left">
                    Valid:</label>
                <div class="form-input">
                    <asp:CheckBox runat="server" ID="chkBoxValid" CssClass="checkbox"></asp:CheckBox>
                </div>
            </li>
            <li class="form-line">
                <label class="form-label-left">
                    Sequence:</label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="txtSequence"></asp:TextBox>
                    <asp:CompareValidator ID="cvSequence" runat="server" ControlToValidate="txtSequence"
                        Type="Integer" Operator="DataTypeCheck" ErrorMessage="Enter Valid Number" />
                </div>
            </li>
            <li class="form-line" id="admin-adminUser-button">
                <div class="form-input-wide">
                    <div class="form-buttons-wrapper">
                        <asp:Button ID="btnSubmit" runat="server" Text="Save" OnClick="btnSubmit_Click" CssClass="jxtadminbutton" /> 
                        <asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                                Text="Cancel" OnClick="CancelButton_Click" CssClass="jxtadminbutton" />
                    </div>
                </div>
            </li>
        </ul>
    </div>
</asp:Content>
