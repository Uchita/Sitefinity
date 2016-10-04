<%@ Page Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="CreateJobAlert.aspx.cs" Inherits="JXTPortal.Website.members.CreateJobAlert" %>

<%@ Register Src="~/usercontrols/job/ucJobAlert.ascx" TagName="ucJobAlert" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/scripts/strength.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="/scripts/uni-form.jquery.js"></script>
    <script type="text/javascript">
        $(function () {

            // init Uni-Form
            $('div.uniForm').jxt_uniform();

            // specific for this page
            $(".browse a").click(function (e) {
                e.preventDefault();
                $("#formStyle").attr("href", $(this).attr('rel'));
                return false;
            });
        });

        $(document).ready(function () {
            $('#tbPassword').strength({
                strengthClass: 'strength',
                strengthMeterClass: 'strength_meter',
                strengthButtonClass: 'button_strength',
                strengthButtonText: '',
                strengthButtonTextToggle: ''
            });
        });
    </script>
    <div id="content">
        <div class="uniForm">
            <fieldset class="inlineLabels">
                <JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage" runat="server" SetSystemPageCode="SystemPage_MemberCreateJobAlert" />
                <asp:Literal ID="ltlMessage" runat="server" />
                <asp:Panel ID="pnlJobAlert" runat="server" DefaultButton="btnSave">
                    <asp:Panel ID="pnlLogin" runat="server">
                        <div class="ctrlHolder">
                            <asp:Label ID="lbFirstName" runat="server" AssociatedControlID="tbFirstName" CssClass="form-label-left">
                                <JXTControl:ucLanguageLiteral ID="ltFirstName" runat="server" SetLanguageCode="LabelFirstName" />
                                <span class="form-required">*</span></asp:Label>
                            <asp:TextBox ID="tbFirstName" runat="server" size="50" class="textInput"></asp:TextBox>
                        </div>
                        <div class="ctrlHolder">
                            <asp:Label ID="lbSurname" runat="server" CssClass="form-label-left" AssociatedControlID="tbSurname">
                                <JXTControl:ucLanguageLiteral ID="ltSurname" runat="server" SetLanguageCode="LabelSurname" />
                                <span class="form-required">*</span></asp:Label>
                            <asp:TextBox ID="tbSurname" runat="server" size="50" class="textInput"></asp:TextBox>
                        </div>
                        <div class="ctrlHolder">
                            <asp:Label ID="lbEmail" runat="server" CssClass="form-label-left" AssociatedControlID="tbEmail">
                                <JXTControl:ucLanguageLiteral ID="ltEmail" runat="server" SetLanguageCode="LabelEmail" />
                                <span class="form-required">*</span></asp:Label>
                            <asp:TextBox ID="tbEmail" runat="server" size="60" class="textInput"></asp:TextBox>
                        </div>
                        <div class="ctrlHolder">
                            <asp:Label ID="lbPassword" runat="server" AssociatedControlID="tbPassword" CssClass="form-label-left">
                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelPassword" />
                                <span class="form-required">*</span></asp:Label>
                            <asp:TextBox ID="tbPassword" runat="server" class="textInput" TextMode="Password"
                                autocomplete="off" ClientIDMode="Static"></asp:TextBox>
                        </div>
                    </asp:Panel>
                    <h3>
                        <JXTControl:ucLanguageLiteral ID="ltMemberCreateAlertHeader" runat="server" SetLanguageCode="LabelJobAlertDetail" />
                    </h3>
                    <div class="ctrlHolder">
                        <asp:Label ID="lbNameOfTheFeed" runat="server" CssClass="form-label-left" AssociatedControlID="txtNameOfTheFeed">
                            <JXTControl:ucLanguageLiteral ID="ltMemberCreateAlertNameFeed" runat="server" SetLanguageCode="LabelNameOfFeed" />
                            <span class="form-required">*</span> </asp:Label>
                        <asp:TextBox ID="txtNameOfTheFeed" runat="server" CssClass="form-textbox2" />
                    </div>
                    <asp:Panel ID="pnlSendEmailAlerts" runat="server">
                        <div class="ctrlHolder">
                            <p class="label">
                                &nbsp;</p>
                            <ul class="blockLabels">
                                <li class="mini-main-alert">
                                    <asp:CheckBox ID="chkSendEmailAlerts" runat="server" />
                                    <JXTControl:ucLanguageLiteral ID="ltMemberCreateAlertMainAlert" runat="server" SetLanguageCode="LabelSendEmailAlerts" />
                                </li>
                            </ul>
                        </div>
                    </asp:Panel>
                    <uc1:ucJobAlert ID="ucJobAlert1" runat="server" />
                    <div class="buttonHolder">
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="mini-new-buttons" OnClick="btnSave_Click" />
                        <asp:Button ID="btnDelete" runat="server" Text="Delete Alert" CssClass="mini-new-buttons"
                            OnClick="btnDelete_Click" Visible="false" />
                        <%--<asp:Button ID="btnSendJobAlert" runat="server" Text="Send a Job Alert now" CssClass="mini-new-buttons"
                            OnClick="btnSendJobAlert_Click" Visible="false" />--%>
                    </div>
                    <JXTControl:ucPrivacySettings ID="ucPrivacySettings" runat="server" />
                </asp:Panel>
            </fieldset>
        </div>
    </div>
</asp:Content>
<%--<li>
                                <asp:CheckBox ID="chkTermsAndConditions" runat="server" />
                                <span class="mini-terms-link">
                                    <JXTControl:ucLanguageLiteral ID="ltMemberCreateAlertAcceptTermCon" runat="server"
                                        SetLanguageCode="LabelAcceptTermCondition" />
                                    .</span><span class="form-required">*</span></li>
                            <li class="mini-receive-emails">
                                <asp:CheckBox ID="chkReceiveEmails" runat="server" />
                                <JXTControl:ucLanguageLiteral ID="ltMemberCreateAlertMailAlerts" runat="server" SetLanguageCode="LabelRequestAlertEmail" />
                            </li>--%>