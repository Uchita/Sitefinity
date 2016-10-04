<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="AdminUsersEdit" Title="Global - Admin Users Edit"
    CodeBehind="AdminUsersEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Admin Users - Add/Edit <a href='http://support.jxt.com.au/solution/articles/116437-create-edit-admin-content-editor-and-external-users'
        class='jxt-help-page' title='click here for help on this page' target='_blank'>help
        on this page</a>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="/scripts/strength.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtAdminUserPassword').strength({
                strengthClass: 'strength',
                strengthMeterClass: 'strength_meter',
                strengthButtonClass: 'button_strength',
                strengthButtonText: '',
                strengthButtonTextToggle: ''
            });
        });
    </script>
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" />
        </span>

        <asp:PlaceHolder ID="PasswordLockedForm" runat="server" Visible="false">
            <ul class="form-section">
                <li>
                    <p class="form-required">
                        This account is currently locked by the password security lock (5 failed login attempts
                        with the wrong credentials).
                    </p>
                </li>
                <li>
                    <p>
                        Prior to unlocking this account, ensure you have verified the user before unlocking
                        the account. Alternatively this account will be unlocked after 60 mins from the
                        locked time.</p>
                </li>
                <li class="form-line">
                    <label class="form-label-left">
                        Locked Time:</label>
                    <div class="form-input">
                        <asp:Literal ID="PasswordLockedTime" runat="server"></asp:Literal>
                    </div>
                </li>
                <li class="form-line">
                    <label class="form-label-left">
                        Unlock:<span class="form-required"></span></label>
                    <div class="form-input">
                        <asp:Button ID="btnPasswordUnlock" runat="server" Text="Unlock Password Lock" CausesValidation="false" OnClick="btnPasswordUnlock_Click" />
                    </div>
                </li>
            </ul>
            <hr />
        </asp:PlaceHolder>

        <ul class="form-section">
            <li class="form-line" id="admin-adminUsersEdit">
                <label id="Label1" class="form-label-left" runat="server">
                    Admin Role ID:</label>
                <div class="form-input">
                    <asp:DropDownList ID="ddlAdminRoleID" TabIndex="11" runat="server" class="form-dropdown"
                        NullItemText=" Please Choose ...">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rvAdminRoleID" runat="server" Display="Dynamic" ErrorMessage="Required"
                        ControlToValidate="ddlAdminRoleID" InitialValue="0" />
                </div>
            </li>
            <li class="form-line" id="admin-adminUserUsername">
                <label class="form-label-left">
                    Username:</label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="txtAdminUserUsername" CssClass="textbox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ReqVal_AdminUserUsername" runat="server" Display="Dynamic"
                        ControlToValidate="txtAdminUserUsername" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CusVal_AdminUserUserName" runat="server" ControlToValidate="txtAdminUserUsername"
                        ErrorMessage="Username already exists" SetFocusOnError="true" OnServerValidate="CusVal_AdminUserUserName_ServerValidate"></asp:CustomValidator>
                </div>
            </li>
            <li class="form-line" id="admin-adminUserPassword">
                <label class="form-label-left">
                    Password:</label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="txtAdminUserPassword" TextMode="Password" AutoCompleteType="None"
                        autocomplete="off" CssClass="textbox" ClientIDMode="Static"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ReqVal_AdminUserPassword" runat="server" Display="Dynamic"
                        ControlToValidate="txtAdminUserPassword" ErrorMessage="Required"></asp:RequiredFieldValidator>
                            <p class="help-block"><asp:RegularExpressionValidator ID="revPassword" runat="server" ErrorMessage="* "  Display="Dynamic"
                            ControlToValidate="txtAdminUserPassword" ValidationExpression="^(?=.{8,}$)(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).*$" /><JXTControl:ucLanguageLiteral ID="ltPasswordPrompt" runat="server" SetLanguageCode="LabelPasswordPrompt" /></p>
                </div>
            </li>
            <li class="form-line" id="admin-adminUserFirstName">
                <label class="form-label-left">
                    First Name:</label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="txtAdminUserFirstName" CssClass="textbox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ReqVal_AdminUserFirstName" runat="server" Display="Dynamic"
                        ControlToValidate="txtAdminUserFirstName" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </div>
            </li>
            <li class="form-line" id="admin-adminUserSurname">
                <label class="form-label-left">
                    Surname:</label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="txtAdminUserSurname" CssClass="textbox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ReqVal_AdminUserSurname" runat="server" Display="Dynamic"
                        ControlToValidate="txtAdminUserSurname" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </div>
            </li>
            <li class="form-line" id="admin-adminUserEmail">
                <label class="form-label-left">
                    Email Address:</label>
                <div class="form-input">
                    <asp:TextBox runat="server" ID="txtAdminUserEmail"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ReqVal_AdminUserEnail" runat="server" Display="Dynamic"
                        ControlToValidate="txtAdminUserEmail" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revAdminUserEmail" runat="server" ControlToValidate="txtAdminUserEmail"
                        ErrorMessage="A valid email address is required" ValidationExpression="^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$">  
                    </asp:RegularExpressionValidator>
                </div>
            </li>
            <li class="form-line" id="admin-adminUserSiteID">
                <label class="form-label-left">
                    SiteID:</label>
                <div class="form-input">
                    <div class="form-input">
                        <asp:Label runat="server" ID="lblAdminuserSiteID" />
                    </div>
                </div>
            </li>
            <li class="form-line" id="admin-adminUser-button">
                <div class="form-input-wide">
                    <div class="form-buttons-wrapper">
                        <asp:Button ID="btnSubmit" runat="server" Text="Save" OnClick="btnSubmit_Click" CssClass="jxtadminbutton" />
                    </div>
                </div>
            </li>
        </ul>
    </div>
</asp:Content>
