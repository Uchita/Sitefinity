<%@ Page Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="ChangePwd.aspx.cs" Inherits="JXTPortal.Website.advertiser.ChangePwd"
    Title="Advertiser Change Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div id="content">
    <div class="content-holder">
            <div class="form-all">
                <!--DO NOT REMOVE - THIS IS GLOBAL CONTAINER-->
                <ul class="form-section">
                    <li class="form-input-wide" id="changepasword-title">
                        <div class="form-header-group">
                            <h2 class="form-header">
                                <asp:Label ID="lbChangePwd" runat="server" Text="Change Password"></asp:Label></h2>
                        </div>
                    </li>
                    <li class="form-line" id="cp-currentpassword-field">
                        <asp:Label ID="lbCurrentPassword" runat="server" CssClass="form-label-left">Current Password:<span class="form-required">*</span></asp:Label>
                        <div class="form-input">
                            <asp:TextBox ID="tbCurrentPassword" runat="server" CssClass="form-textbox validate[required]"
                                TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqVal_CurrentPassword" runat="server" ErrorMessage="Required"
                                ControlToValidate="tbCurrentPassword" />
                            <asp:CustomValidator ID="CusVal_CurrentPassword" runat="server" 
                                ErrorMessage="Incorrect current password" 
                                onservervalidate="CusVal_CurrentPassword_ServerValidate" />
                        </div>
                    </li>
                    <li class="form-line" id="cp-newpassword-field">
                        <asp:Label ID="lbNewPassword" runat="server" CssClass="form-label-left">New Password:<span class="form-required">*</span></asp:Label>
                        <div class="form-input">
                            <asp:TextBox ID="tbNewPassword" runat="server" TextMode="Password" CssClass="form-textbox validate[required]"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqVal_NewPassword" runat="server" ErrorMessage="Required"
                                ControlToValidate="tbNewPassword" />
                        </div>
                    </li>
                    <li class="form-line" id="cp-confirmnewpassword-field">
                        <asp:Label ID="lbConfirmNewPassword" runat="server" CssClass="form-label-left">Confirm New Password:<span class="form-required">*</span></asp:Label>
                        <div class="form-input">
                            <asp:TextBox ID="tbConfirmNewPassword" runat="server" TextMode="Password" CssClass="form-textbox validate[required]"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ReqVal_ConfirmNewPassword" runat="server" ErrorMessage="Required"
                                ControlToValidate="tbConfirmNewPassword" />
                            <asp:CustomValidator ID="CusVal_ConfirmNewPassword" runat="server" 
                                ErrorMessage="Confirm password doesn not match" 
                                onservervalidate="CusVal_ConfirmNewPassword_ServerValidate" />
                        </div>
                    </li>
                    <li class="form-line" id="cp-bottom-button">
                        <div class="form-input-wide">
                            <div class="form-buttons-wrapper">
                                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="mini-new-buttons" OnClick="btnBack_Click" />
                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="mini-new-buttons" OnClick="btnSave_Click" />
                            </div>
                        </div>
                    </li>
                </ul>
            </div>
    </div>
</div>
</asp:Content>
