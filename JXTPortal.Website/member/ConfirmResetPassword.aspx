<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="ConfirmResetPassword.aspx.cs" Inherits="JXTPortal.Website.member.ConfirmResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="robots" content="nofollow" />
    <script type="text/javascript" src="/scripts/strength.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtNewPassword').strength({
                strengthClass: 'strength',
                strengthMeterClass: 'strength_meter',
                strengthButtonClass: 'button_strength',
                strengthButtonText: '',
                strengthButtonTextToggle: ''
            });
        });
    </script>
    <div id="content">
        <div class="content-holder">
            <div class="form-header-group">
                <h2 class="form-header">
                    <JXTControl:ucLanguageLiteral ID="ltConfirmResetPassword" runat="server" SetLanguageCode="LabelConfirmResetPassword" />
                </h2>
            </div>
            <div class="form-all">
                <JXTControl:ucLanguageLiteral ID="ltMessage" runat="server" SetLanguageCode="LabelInvalidURL" />
                <asp:Panel ID="pnlResetPassword" runat="server">
                    <ul class="form-section">
                        <li class="form-line" id="member-fp-newpassword-field">
                            <asp:Label ID="lbNewPassword" runat="server" CssClass="form-label-left">
                                <JXTControl:ucLanguageLiteral ID="ltNewPassword" runat="server" SetLanguageCode="LabelNewPassword" />
                                </asp:Label>
                            <div class="form-input">
                                <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" CssClass="form-textbox" ClientIDMode="Static" AutoCompleteType="None" autocomplete="off"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqValNewPassword" runat="server" ControlToValidate="txtNewPassword"
                                    SetFocusOnError="true" Display="Dynamic" ErrorMessage="Required" />
                                    
                            <p id="pPasswordError" class="help-block"><asp:RegularExpressionValidator ID="revPassword" runat="server" ErrorMessage="" Display="Dynamic" ClientIDMode="Static"
                            ControlToValidate="txtNewPassword" ValidationExpression="^(?=.{8,}$)(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).*$" /><JXTControl:ucLanguageLiteral ID="ltPasswordPrompt" runat="server" SetLanguageCode="LabelPasswordPrompt" /></p>
                            </div>
                        </li>
                        <li class="form-line" id="member-fp-email-field">
                            <asp:Label ID="lbRetypePassword" runat="server" CssClass="form-label-left">
                                <JXTControl:ucLanguageLiteral ID="ltRetypePassword" runat="server" SetLanguageCode="LabelRetypePassword" />
                                </asp:Label>
                            <div class="form-input">
                                <asp:TextBox ID="txtRetypePassword" runat="server" TextMode="Password" CssClass="form-textbox" AutoCompleteType="None" autocomplete="off"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ReqValRetypePassword" runat="server" ControlToValidate="txtRetypePassword"
                                    SetFocusOnError="true" Display="Dynamic" ErrorMessage="Required" />
                                <asp:CustomValidator ID="CusValRetypePassword" runat="server" SetFocusOnError="true"
                                    Display="Dynamic" ControlToValidate="txtRetypePassword" ErrorMessage="Retype password does not match"
                                    OnServerValidate="CusValRetypePassword_ServerValidate" />
                            </div>
                        </li>
                    </ul>
                    <ul class="form-section">
                        <li class="form-line" id="member-fg-bottom-button">
                            <div class="form-input-wide">
                                <div class="form-buttons-wrapper">
                                    <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="mini-new-buttons" OnClientClick="ApplyCheck(event);"
                                        OnClick="btnReset_Click" />
                                </div>
                            </div>
                        </li>
                    </ul>
                </asp:Panel>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function ApplyCheck(event) {

            if ($("#revPassword").css("display") == "inline") {
                $("#pPasswordError").prop("class", "help-block error");
            }
            else {
                $("#pPasswordError").prop("class", "help-block");
            }

        }
    </script>
</asp:Content>
