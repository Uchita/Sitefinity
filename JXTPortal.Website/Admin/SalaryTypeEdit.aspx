<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="SalaryTypeEdit" Title="Global - Default Salary Types Edit"
    CodeBehind="SalaryTypeEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Salary Type - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" />
        </span>
        <ul class="form-section">
            <li class="form-line" id="admin-salaryTypeName">
                <label class="form-label-left">
                    Salary Type Name:<span class="form-required">*</span></label>
                <div class="form-input">
                    <asp:TextBox ID="txtSalaryTypeName" runat="server" Width="250px"></asp:TextBox>
                    <asp:Literal ID="litDisabledMsg" runat="server" Text="This Salary Type is disabled due to JXT Mapping" Visible="false"/>
                    <asp:RequiredFieldValidator ID="ReqVal_SalaryTypeName" runat="server" ControlToValidate="txtSalaryTypeName"
                        ErrorMessage="Required" Enabled="false" />
                </div>
            </li>
            <li class="form-line" id="admin-salaryTypeValid">
                <label class="form-label-left">
                    Valid:</label>
                <div class="form-input">
                    <asp:CheckBox ID="chkSalaryTypeValid" runat="server" Width="250px"></asp:CheckBox>
                </div>
            </li>
            <li class="form-line">
                <div class="form-input-wide">
                    <div class="form-buttons-wrapper">
                        <asp:Button ID="btnSubmit" runat="server" Text="Save" OnClick="btnSubmit_Click" CssClass="jxtadminbutton" />
                        <asp:Button ID="btnReturn" runat="server" Text="Return" OnClick="btnReturn_Click"
                            CssClass="jxtadminbutton" CausesValidation="false" />
                    </div>
                </div>
            </li>
        </ul>
    </div>
</asp:Content>
