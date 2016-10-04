<%@ Page Language="C#" MasterPageFile="~/MasterPages/CustomMain.Master" AutoEventWireup="true"
    CodeBehind="ConfirmDelete.aspx.cs" Inherits="JXTPortal.Website.members.ConfirmDelete" %>

<%@ Register Src="/usercontrols/navigation/ucMemberAccountNavigation.ascx" TagName="ucMemberAccountNavigation"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="robots" content="nofollow" />
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/newdash/lib/bootstrap.min.css" />
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/newdash/newDash.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="page-title">
	    <div class="container">
		    <div class="row">
			    <div class="col-md-12 inner-title text-center"><!-- --><h1><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral2" runat="server" SetLanguageCode="LabelCloseMyAccount" /></h1></div>
		    </div>
	    </div>
    </section>
    <div id="content-container">
        <div id="content">
            <div class="content-holder">
                <div class="login-main-holder">
                    <div class="form-all">
                        <p>
                            In order to close your account, please verify your current password. Please note
                            once you have confirmed closure, all data associated to your account will be removed
                            from our records. You will also be logged out of your current session.</p>
                        <ul class="form-section">
                            <li class="form-required" id="memberlogin-errorMessage">
                                <asp:Literal ID="ltErrorMessage" runat="server" />
                            </li>
                            <li class="form-line">
                                <label class="form-label-left">
                                    <JXTControl:ucLanguageLiteral ID="ltCurrentPassword" runat="server" SetLanguageCode="LabelCurrentPassword" />
                                    <span class="form-required">*</span>
                                </label>
                                <div class="form-input">
                                    <asp:TextBox ID="txtCurrentPassword" runat="server" TextMode="Password" CssClass="form-textbox" autocomplete="off" />
                                    <asp:RequiredFieldValidator ID="rfvCurrentPassword" runat="server" ControlToValidate="txtCurrentPassword"
                                        SetFocusOnError="true" Display="Dynamic" ValidationGroup="Confirm"></asp:RequiredFieldValidator>
                                </div>
                            </li>
                            <li class="form-line">
                                <label class="form-label-left">
                                    <JXTControl:ucLanguageLiteral ID="ltConfirmPassword" runat="server" SetLanguageCode="LabelConfirmPassword" />
                                    <span class="form-required">*</span>
                                </label>
                                <div class="form-input">
                                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-textbox"
                                        AutoCompleteType="None" autocomplete="off" />
                                    <asp:CompareValidator ID="comvPassword" runat="server" ControlToValidate="txtConfirmPassword"
                                        ControlToCompare="txtCurrentPassword" SetFocusOnError="true" Display="Dynamic" ValidationGroup="Confirm"></asp:CompareValidator>
                                </div>
                            </li>
                            <li class="memberlogin-links">
                                <div class="jxt-form-text">
                                    * By submitting this form, you agree to our <a href="#" class="candidateTermsDeletion"
                                        target="_blank">Terms &amp; Conditions</a>.
                                </div>
                            </li>
                        </ul>
                    </div>
                    <div class="member-submitbottom">
                        <asp:Button ID="btnConfirm" runat="server" Text="Confirm Closure" CssClass="mini-new-buttons" OnClick="btnConfirm_Click"/>
                        <asp:Button ID="Button1" runat="server" Text="Back To Profile" CssClass="mini-new-buttons"
                            OnClick="btnBack_Click"  />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--[if lt IE 9]>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/html5shiv.js" type="text/javascript"></script>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/respond.min.js" type="text/javascript"></script>
    <![endif]-->
    <script src='//images.jxt.net.au/COMMON/newdash/lib/bootstrap.min.js'></script>
    <script src='//images.jxt.net.au/COMMON/newdash/newDash.js'></script>
</asp:Content>
