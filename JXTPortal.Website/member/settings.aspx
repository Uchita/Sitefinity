<%@ Page Language="C#" MasterPageFile="~/MasterPages/CustomMain.Master" AutoEventWireup="true"
    CodeBehind="settings.aspx.cs" Inherits="JXTPortal.Website.members.Settings" %>
<%@ Register Src="~/usercontrols/member/ucMemberEdit.ascx" TagName="ucMemberEdit" TagPrefix="uc2" %>
<%@ Register src="/usercontrols/navigation/ucMemberAccountNavigation.ascx" tagname="ucMemberAccountNavigation" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="robots" content="nofollow" />

    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/newdash/lib/bootstrap.min.css" />
    <%--<link rel="stylesheet" href="//images.jxt.net.au/COMMON/newdash/newDash.css" />--%>
    <script type="text/javascript">
        $(function () {

            $('#ckAddMailingAddress').change(function () {
                if ($(this).is(":checked")) {
                    $("#divMailingAddress").show();
                    $("#divMailingSuburb").show();
                    $("#divMailingPostcode").show();
                    $("#divMailingState").show();
                    $("#divMailingCountry").show();
                }
                else {
                    $("#divMailingAddress").hide();
                    $("#divMailingSuburb").hide();
                    $("#divMailingPostcode").hide();
                    $("#divMailingState").hide();
                    $("#divMailingCountry").hide();
                }
            });
        });
    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="endOfHead" runat="server">
    <link rel="stylesheet" href="/styles/member/settings.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    <div id="content-container">
    <div id="content">
        <div class="content-holder">
            <uc1:ucMemberAccountNavigation ID="ucMemberAccountNavigation1" runat="server" />
            <%--<JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage1" runat="server" SetSystemPageCode="SystemPage_MemberDefaultWelcome" />--%>
            
            <div class="">
                <div class="row form-header-group">
                  <div class="col-sm-8">
                    <h1 class="form-header"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelSettings" /></h1>
                  </div>
                  <div class="col-sm-4"><br />
                    <asp:Button ID="btnCloseAccount" runat="server" Text="Close Account" OnClick="btnCloseAccount_Click" CssClass="mini-new-buttons btn btn-danger pull-right btn-sm btn-primary" />                    
                  </div>
                </div>

                <asp:Literal ID="ltlMessage" runat="server" />

                <div class="form-all">
                  <!-- Username -->
                  <div class="row">
                    <div class="col-sm-6 col-xs-12 form-line" id="ucmemberedit-username-field">
                      <asp:Label ID="lbUsername" runat="server" CssClass="form-label-left" AssociatedControlID="txtUsername">
                        <JXTControl:ucLanguageLiteral ID="ucUsername" runat="server" SetLanguageCode="LabelUsername" />
                      </asp:Label>
                      <div class="form-input">
                       <asp:TextBox ID="txtUsername" runat="server" CssClass="form-textbox2 form-control" ReadOnly="true" />                        
                      </div>
                    </div>
                  </div>  
                  
                  <!-- Email Detail -->
                  <div class="row">
                    <div class="col-sm-6 col-xs-12 form-line" id="ucmemberedit-email-field">
                      <asp:Label ID="lbEmailAddress" runat="server" CssClass="form-label-left" AssociatedControlID="txtEmailAddress">
                        <JXTControl:ucLanguageLiteral ID="ucEmailAddress" runat="server" SetLanguageCode="LabelEmail" />
                    </asp:Label>

                      <div class="form-input">
                        <asp:TextBox ID="txtEmailAddress" runat="server" CssClass="form-textbox2 form-control" Enabled="false" ReadOnly="true" />                        
                      </div>
                    </div>
                    <div class="col-sm-6 col-xs-12 form-line" id="ucmemberedit-secondaryemail-field">
                      <asp:Label ID="lbSecondaryEmail" runat="server" CssClass="form-label-left" AssociatedControlID="txtSecondaryEmailAddress">
                        <JXTControl:ucLanguageLiteral ID="UcSecondaryEmail" runat="server" SetLanguageCode="LabelSecondaryEmail" />
                    </asp:Label>

                      <div class="form-input">
                        <asp:TextBox ID="txtSecondaryEmailAddress" runat="server" CssClass="form-textbox2 form-control" />
                        <asp:RegularExpressionValidator ID="revSecondaryEmailAddress" runat="server" ControlToValidate="txtSecondaryEmailAddress"
                             ValidationExpression="^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$"
                            SetFocusOnError="true" Display="Dynamic"> 
                        </asp:RegularExpressionValidator>
                        </div>
                    </div>
                  </div>
                  
                  <!-- Email Format -->
                  <div class="row">  
                    <div class="col-sm-6 col-xs-12 form-line" id="ucmemberedit-email-format-section">
                      <asp:Label ID="lbEmailFormat" runat="server" CssClass="form-label-left" AssociatedControlID="radlEmailFormat">
                        <JXTControl:ucLanguageLiteral ID="ucEmailFormat" runat="server" SetLanguageCode="LabelEmailFormat" />
                    </asp:Label>
                      <div class="form-input">
                        <div class="btn-group  btn-radio-group">
                            <asp:RadioButtonList ID="radlEmailFormat"  RepeatDirection="Horizontal" RepeatLayout="Flow" 
                                runat="server" class="form-radio">
                                <asp:ListItem Value="1" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                      </div>
                    </div>

                    <asp:PlaceHolder ID="phLanguage" runat="server" Visible="false">
                    <div class="col-sm-6 col-xs-12 form-line" id="ucmemberedit-language">
                        <asp:Label ID="lbLanguage" runat="server" CssClass="form-label-left" AssociatedControlID="ddlLanguage">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral11" runat="server" SetLanguageCode="LabelPreferredEmailLanguage" />
                        </asp:Label>
                        <div class="form-input">
                            <span class="custom-select"><asp:DropDownList ID="ddlLanguage" TabIndex="9" runat="server" class="form-dropdown form-control">
                            </asp:DropDownList></span>
                        </div>
                    </div>
                </asp:PlaceHolder>

                  </div>
                  
                  <!-- Password Detail -->
                  <div class="row">  

                    <h3 class="form-header col-xs-12"><JXTControl:ucLanguageLiteral ID="lblMemberHeaderChangePassword" runat="server" SetLanguageCode="LabelChangePwd" /></h3>

                    <div class="col-sm-4 col-xs-12 form-line" id="ucMember-currentpassword-field">
                    <asp:Label ID="lbCurrentPassword" runat="server" CssClass="form-label-left" AssociatedControlID="txtMemberCurrentPassword">
                    <JXTControl:ucLanguageLiteral ID="litucMemberCurrentPassword" runat="server" SetLanguageCode="LabelCurrentPassword" />
                    </asp:Label>
                      <div class="form-input">
                          <asp:TextBox ID="txtMemberCurrentPassword" runat="server" CssClass="form-textbox2"
                            TextMode="Password" autocomplete="off"></asp:TextBox><%--<asp:RequiredFieldValidator
                                ID="ReqVal_CurrentPassword" runat="server" ErrorMessage="Required" ControlToValidate="txtMemberCurrentPassword"
                                 SetFocusOnError="true" Display="Dynamic" />--%>
                                <asp:CustomValidator ID="CusVal_CurrentPassword" runat="server" ErrorMessage="Incorrect current password"
                            OnServerValidate="CusVal_CurrentPassword_ServerValidate" 
                            SetFocusOnError="true" Display="Dynamic" />
                      </div>
                    </div>
                    <div class="col-sm-4 col-xs-12 form-line" id="ucMember-newpassword-field">
                      <asp:Label ID="lbNewPassword" runat="server" CssClass="form-label-left" AssociatedControlID="txtMemberNewPassword">
                    <JXTControl:ucLanguageLiteral ID="litucMemberNewPassword" runat="server" SetLanguageCode="LabelNewPassword" />
                    </asp:Label>
                        <div class="form-input">
                            <asp:TextBox ID="txtMemberNewPassword" runat="server" TextMode="Password" CssClass="form-textbox2"
                        autocomplete="off" ClientIDMode="Static"></asp:TextBox><%--<asp:RequiredFieldValidator
                            ID="ReqVal_NewPassword" runat="server" ErrorMessage="Required" ControlToValidate="txtMemberNewPassword"
                             SetFocusOnError="true" Display="Dynamic" />--%>
                            <asp:RegularExpressionValidator ID="revPassword" runat="server" ErrorMessage="* " 
                            Display="Dynamic"  ControlToValidate="txtMemberNewPassword"
                            ValidationExpression="^(?=.{8,}$)(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).*$" />
                            
                        </div>
                    </div>
                    <div class="col-sm-4 col-xs-12 form-line" id="ucMember-confirmnewpassword-field">
                      <asp:Label ID="lbConfirmNewPassword" runat="server" CssClass="form-label-left" AssociatedControlID="txtMemberConfirmNewPassword">
                    <JXTControl:ucLanguageLiteral ID="litucMemberConfirmNewPassword" runat="server" SetLanguageCode="LabelConfirmNewPassword" />
                    </asp:Label>
                      <div class="form-input">
                          <asp:TextBox ID="txtMemberConfirmNewPassword" runat="server" TextMode="Password"
                                CssClass="form-textbox2" autocomplete="off"></asp:TextBox><%--<asp:RequiredFieldValidator
                                    ID="ReqVal_ConfirmNewPassword" runat="server" ErrorMessage="Required" ControlToValidate="txtMemberConfirmNewPassword"
                                     SetFocusOnError="true" Display="Dynamic" />--%>
                            <asp:CustomValidator ID="CusVal_ConfirmNewPassword" runat="server" ErrorMessage="Confirm password does not match"
                                OnServerValidate="CusVal_ConfirmNewPassword_ServerValidate" 
                                SetFocusOnError="true" Display="Dynamic" />
                      </div>
                    </div>
                    
                  <div class="col-xs-12">
                      <p class="help-block"><JXTControl:ucLanguageLiteral ID="ltPasswordPrompt" runat="server" SetLanguageCode="LabelPasswordPrompt" /></p>
                    </div>
                  </div>

                  <!-- Update buttton  -->
                  <div class="form-line" id="ucmemberedit-bottom-button">
                    <div class="form-input-wide">
                        <div class="form-buttons-wrapper">
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="mini-new-buttons" OnClick="btnSave_Click" />
                        </div>
                    </div>
                  </div>
                </div>
                <!-- //form-all -->

              </div>

        </div>
    </div>
    </div>

    <!--[if lt IE 9]>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/html5shiv.js" type="text/javascript"></script>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/respond.min.js" type="text/javascript"></script>
    <![endif]-->
    <script src='//images.jxt.net.au/COMMON/newdash/lib/bootstrap.min.js'></script>
    <%--<script src='//images.jxt.net.au/COMMON/newdash/newDash.js'></script>--%>
    <script>    
        $('.dropdown-toggle').dropdown();
    </script>
</asp:Content>
