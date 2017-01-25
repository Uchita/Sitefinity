<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CustomMain.Master"
    AutoEventWireup="true" CodeBehind="ApplyJob.aspx.cs" Inherits="JXTPortal.Website.NewApplyPage" %>

<%@ Register Src="~/usercontrols/member/ucMemberSocialLogin.ascx" TagName="ucMemberSocialLogin"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="https://www.dropbox.com/static/api/2/dropins.js"
        id="dropboxjs" data-app-key="<%=DropboxKey %>"></script>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.4/css/bootstrap.min.css">
    <link href="//netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.css" rel="stylesheet">
    <!-- Latest compiled and minified JavaScript -->
    <% if (this.Page.Master.FindControl("ltlMetaContent") != null && !(((Literal)this.Page.Master.FindControl("ltlMetaContent")).Text.Contains("bootstrap.min.js")))
       { %>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/bootstrap.min.js"></script>
    <% } %>
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/css/apply.css" />
    <link rel="stylesheet" href="./styles/ScreeningQuestions/style.css" />
    <script src="/scripts/JXTApplyFormScript.js"></script>
    <script type="text/javascript" src="/scripts/strength.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hfOAuthError" runat="server" ClientIDMode="Static" />
    <script type="text/javascript">
        var params = {}, queryString = location.hash.substring(1), regex = /([^&=]+)=([^&]*)/g, m;
        while (m = regex.exec(queryString)) {
            params[decodeURIComponent(m[1])] = decodeURIComponent(m[2]);
        }

        if (params["error"]) {
            if (document.getElementById("hfOAuthError")) {
                document.getElementById("hfOAuthError").value = params["error"];
            }

            document.getElementById("aspnetForm").submit();
        }

        $(document).ready(function () {
            $('#tbNewPassword').strength({
                strengthClass: 'strength',
                strengthMeterClass: 'strength_meter',
                strengthButtonClass: 'button_strength',
                strengthButtonText: '',
                strengthButtonTextToggle: ''
            });
        });

        function OnIndeedCompleted() {
            location.href = "/page/job-apply-success";
        }
    </script>
    <!-- Referrer - <asp:Literal ID="ltReferrer" runat="server" /> -->
    <div id="content-container" class="boardy-apply-content">
        <div id="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-sm-6">
                        <a href="/advancedsearch.aspx?search=1&retainsearch=1" class="backToResults"><span
                            class="glyphicon glyphicon-chevron-left"></span>
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LinkButtonBackToResult" />
                        </a>
                    </div>
                </div>
                <h1>
                    <JXTControl:ucLanguageLiteral ID="ltResumeRestriction" runat="server" SetLanguageCode="LabelApplyForPosition" />
                    <span class="position-title">"<asp:Literal ID="ltJobName" runat="server" />"</span></h1>
                <asp:PlaceHolder ID="phLoginPanel" runat="server">
                    <div class="well clearfix boardy-apply-options">
                        <div class="col-sm-5 col-xs-12">
                            <h3>
                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral2" runat="server" SetLanguageCode="LabelLogin" />
                            </h3>
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label for="tbUserName" class="col-sm-3 control-label">
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral3" runat="server" SetLanguageCode="LabelUsername" />
                                        &nbsp;<span class="required">*</span></label>
                                    <div class="col-sm-9 input-group">
                                        <span class="input-group-addon" id="defaultLoginEmail"><span class="glyphicon glyphicon-envelope">
                                        </span></span>
                                        <asp:TextBox ID="tbUserName" runat="server" CssClass="form-control" placeholder="Username"
                                            ClientIDMode="Static" />
                                    </div>
                                    <asp:PlaceHolder ID="phLoginError" runat="server" Visible="true">
                                        <div id="divLoginError" class="col-sm-8 col-sm-offset-3 input-group">
                                            <p class="help-block">
                                                <span class="error">
                                                    <%=AccessDenied %></span></p>
                                        </div>
                                    </asp:PlaceHolder>
                                    <div id="divUsernameError" class="col-sm-8 col-sm-offset-3 input-group" style="display: none;">
                                        <p class="help-block">
                                            <span class="error">
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral4" runat="server" SetLanguageCode="LabelUsernameRequired" />
                                            </span>
                                        </p>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="tbPassword" class="col-sm-3 control-label">
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral26" runat="server" SetLanguageCode="LabelPassword"
                                            autocomplete="off" />
                                        &nbsp;<span class="required">*</span></label>
                                    <div class="col-sm-9 input-group">
                                        <span class="input-group-addon" id="defaultLoginPassword"><span class="glyphicon glyphicon-lock">
                                        </span></span>
                                        <asp:TextBox ID="tbPassword" runat="server" TextMode="Password" CssClass="form-control"
                                            placeholder="Password" ClientIDMode="Static" />
                                    </div>
                                    <div id="divPasswordError" class="col-sm-8 col-sm-offset-3 input-group" style="display: none;">
                                        <p class="help-block">
                                            <span class="error">
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral5" runat="server" SetLanguageCode="labellPasswordRequired" />
                                            </span>
                                        </p>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-offset-3 col-sm-4">
                                        <div class="checkbox">
                                            <label>
                                                <input id="cbRememberMe" type="checkbox" runat="server" />
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral6" runat="server" SetLanguageCode="LabelRememberMe" />
                                            </label>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                                    </div>
                                    <div class="col-sm-5 col-xs-12">
                                        <a href="/member/forgetpassword.aspx" class="BoardyforgetPassword">
                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral7" runat="server" SetLanguageCode="LabelForgotPassword" />
                                        </a>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-offset-3 col-sm-9">
                                        <asp:Button ID="btnSignIn" runat="server" CssClass="mini-new-buttons" UseSubmitBehavior="true"
                                            Text="Sign in" OnClick="btnSignIn_Click" OnClientClick="SignInClicked(event);" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-2 hidden-xs">
                            <span class="line-break"></span>
                        </div>
                        <div class="col-sm-5 col-xs-12">
                            <div class="visible-xs">
                                <hr />
                            </div>
                            <div id="socialLoginWrapper">
                                <uc1:ucMemberSocialLogin ID="ucMemberSocialLogin1" runat="server" />
                                <%--                                <div class="boardyLoginWithSocial">
                                    <h3>
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral8" runat="server" SetLanguageCode="LabelLoginWithSocialMedia" />
                                    </h3>
                                    <asp:LinkButton ID="lbSignInFacebook" runat="server" OnClick="lbSignInFacebook_Click"
                                        Visible="false">
                        <img src="//images.jxt.net.au/COMMON/images/apply/sign-in-facebook.png" alt="sign in facebook"
                            class="img-responsive" /></asp:LinkButton>
                                    <asp:LinkButton ID="lbSignInLinkedIn" runat="server" OnClick="lbSignInLinkedIn_Click"
                                        Visible="false"><img
                                src="//images.jxt.net.au/COMMON/images/apply/sign-in-linkedin.png" alt="sign in linkedin"
                                class="img-responsive" /></asp:LinkButton>
                                    <asp:LinkButton ID="lbSignInGoogle" runat="server" OnClick="lbSignInGoogle_Click"
                                        Visible="false"><img src="//images.jxt.net.au/COMMON/images/apply/sign-in-google.png"
                                    alt="sign in google" class="img-responsive" /></asp:LinkButton>
                                    <div class="clearfix">
                                    </div>
                                </div>--%>
                            </div>
                            <p class="boardyNotRegistered">
                                <span class=""></span>
                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral9" runat="server" SetLanguageCode="LabelNotRegisteredQuickly" />
                                <a href="#" class="regtrigger">
                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral10" runat="server" SetLanguageCode="LabelRegisterAndApply" />
                                </a>
                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral25" runat="server" SetLanguageCode="LabelBelow" />
                            </p>
                        </div>
                    </div>
                </asp:PlaceHolder>
                <asp:PlaceHolder ID="phSocialLoggedIn" runat="server" Visible="false">
                    <hr />
                    <h2>
                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral27" runat="server" SetLanguageCode="LabelWelcome" />
                        <%--<span class="candidateFirstName">--%>
                        &nbsp;<asp:Literal ID="ltFirstName" runat="server" />
                        <%--</span>--%>
                    </h2>
                </asp:PlaceHolder>
                <div id="divForm" role="form">
                    <asp:PlaceHolder ID="phApplyWith" runat="server">
                        <section class="boardyApplyWith" id="applywith">

                <h3><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral11" runat="server" SetLanguageCode="LabelApplyWith" /></h3>
                <div class="row">
                    <div class="buttonHolder">
                    <asp:PlaceHolder ID="phApplyWithIndeed" runat="server" Visible="false">
                    <div class="col-sm-3"><div class="thumbnail">
                        <span class="indeed-apply-widget"
                         data-indeed-apply-apiToken="<%=IndeedAPIToken %>"
                         data-indeed-apply-jobId="<%=JobID %>"
                         data-indeed-apply-jobLocation="<%=JobLocation %>"
                         data-indeed-apply-jobCompanyName="<%=CompanyName %>"
                         data-indeed-apply-jobTitle="<%=JobTitle %>"
                         data-indeed-apply-jobUrl="<%=JobURL %>"
                         data-indeed-apply-postUrl="<%=PostURL %>"
                         data-indeed-apply-onapplied="OnIndeedCompleted"
                         ></span>
                        <script>                            (function (d, s, id) {
                                var js, iajs = d.getElementsByTagName(s)[0];
                                if (d.getElementById(id)) { return; }
                                js = d.createElement(s); js.id = id; js.async = true;
                                js.src = "https://apply.indeed.com/indeedapply/static/scripts/app/bootstrap.js";
                                iajs.parentNode.insertBefore(js, iajs);
                            } (document, 'script', 'indeed-apply-js'));
                        </script>
                    </div></div>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="phApplyWithLinkedIn" runat="server" Visible="false">
                    <div class="col-sm-3"><div class="thumbnail">
                        <asp:ImageButton ID="ibApplyWithLinkedIn" runat="server" ImageUrl="//images.jxt.net.au/COMMON/images/apply/applyLinkedIn2.svg" alt="Apply with Linkedin"
                                    class="img-responsive" OnClick="ibApplyWithLinkedIn_Click" />
                    </div></div>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="phApplyWithSeek" runat="server" Visible="false">
                    <div class="col-sm-3"><div class="thumbnail">
                    <asp:LinkButton id="hlApplyWithSeek" runat="server" CssClass="seek-apply-btn" OnClick="hlApplyWithSeek_Click" />
                    </div></div>
                    </asp:PlaceHolder>
                    </div>
                </div>
            </section>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="phSuccess" runat="server" Visible="false">
                        <div class="alert alert-success">
                            <p>
                                <asp:Literal ID="litSuccessMessage" runat="server" /></p>
                        </div>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="phError" runat="server" Visible="true">
                        <div class="alert alert-danger">
                            <p>
                                <asp:Literal ID="litErrorMessage" runat="server" /></p>
                        </div>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="phBoardyLoggedIn" runat="server" Visible="false">
                        <h3>
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral23" runat="server" SetLanguageCode="LabelWelcomeBack" />
                            <%--<span class="candidateFirstName">--%>
                            &nbsp;<asp:Literal ID="ltBoardyFirstName" runat="server" />
                            <%--</span>--%>
                        </h3>
                    </asp:PlaceHolder>
                    <div class="justapply-wrapper">
                        <asp:PlaceHolder ID="phJustApplyTop" runat="server">
                            <div class="form-group boardy-apply-titles first">
                                <h3 id="registerSec">
                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral13" runat="server" SetLanguageCode="LabelJustApply" />
                                </h3>
                                <br />
                            </div>
                        </asp:PlaceHolder>
                        <asp:PlaceHolder ID="phJustApplyTopSection" runat="server">
                            <section class="boardy-apply-register form-horizontal">
                        </asp:PlaceHolder>
                        <asp:PlaceHolder ID="phJustApplyTopLeft" runat="server">
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="row">
                        </asp:PlaceHolder>
                        <asp:PlaceHolder ID="phJustApplyLeft" runat="server">
                            <div class="form-group">
                                <label for="tbFirstName" class="col-md-3 col-sm-4 control-label">
                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral14" runat="server" SetLanguageCode="LabelFirstName" />
                                    &nbsp;<span class="required">*</span></label>
                                <div class="col-md-9 col-sm-8 input-group">
                                    <span class="input-group-addon" id="basic-addon1"><span class="glyphicon glyphicon-user">
                                    </span></span>
                                    <asp:TextBox ID="tbFirstName" runat="server" ClientIDMode="Static" placeholder="Enter your first name"
                                        CssClass="form-control" />
                                </div>
                                <div id="divFirstNameRequired" runat="server" clientidmode="Static" style="display: none"
                                    class="col-sm-8 col-sm-offset-3 input-group">
                                    <p class="help-block">
                                        <span class="error">First name is required</span></p>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="tbLastName" class="col-md-3 col-sm-4 control-label">
                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral15" runat="server" SetLanguageCode="LabelLastName" />
                                    &nbsp;<span class="required">*</span></label>
                                <div class="col-md-9 col-sm-8 input-group">
                                    <span class="input-group-addon" id="basic-addon2"><span class="glyphicon glyphicon-user">
                                    </span></span>
                                    <asp:TextBox ID="tbLastName" runat="server" ClientIDMode="Static" placeholder="Enter your last name"
                                        CssClass="form-control" />
                                </div>
                                <div id="divLastNameRequired" runat="server" clientidmode="Static" style="display: none"
                                    class="col-sm-8 col-sm-offset-3 input-group">
                                    <p class="help-block">
                                        <span class="error">Last name is required</span></p>
                                </div>
                            </div>
                            <div id="divPhone" runat="server" class="form-group">
                                <label for="tbPhone" class="col-md-3 col-sm-4 control-label">
                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral16" runat="server" SetLanguageCode="LabelPhone" />
                                </label>
                                <div class="col-md-9 col-sm-8 input-group">
                                    <span class="input-group-addon" id="basic-addon3"><span class="glyphicon glyphicon-phone-alt">
                                    </span></span>
                                    <asp:TextBox ID="tbPhone" runat="server" ClientIDMode="Static" placeholder="Enter phone number"
                                        CssClass="form-control" />
                                </div>
                                <div id="divPhoneIncorrectFormat" runat="server" clientidmode="Static" style="display: none"
                                    class="col-sm-8 col-sm-offset-3 input-group">
                                    <p class="help-block">
                                        <span class="error">Phone is incorrect format</span></p>
                                </div>
                            </div>
                        </asp:PlaceHolder>
                        <asp:PlaceHolder ID="pnlPeopleBankLeft" runat="server" Visible="False">
                            <div class="form-group">
                                <label for="tbLandLine" class="col-md-3 col-sm-4 control-label">
                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral20" runat="server" SetLanguageCode="LabelLandLine" />
                                    :&nbsp;<span class="required">*</span></label>
                                <div class="col-md-9 col-sm-8 input-group">
                                    <span class="input-group-addon" id="Span1"><span class="glyphicon glyphicon-phone-alt">
                                    </span></span>
                                    <asp:TextBox ID="tbLandLine" runat="server" ClientIDMode="Static" placeholder="Landline Number"
                                        CssClass="form-control" />
                                </div>
                                <div id="divLandLineError" runat="server" clientidmode="Static" style="display: none"
                                    class="col-sm-8 col-sm-offset-3 input-group">
                                    <p class="help-block">
                                        <span class="error">Landline is required</span></p>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="ddlState" class="col-md-3 col-sm-4 control-label">
                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral21" runat="server" SetLanguageCode="LabelStateResideIn" />
                                    :&nbsp;<span class="required">*</span></label>
                                <div class="col-md-9 col-sm-8 input-group">
                                    <asp:DropDownList ID="ddlState" runat="server" ClientIDMode="Static" CssClass="form-control">
                                        <asp:ListItem Text="Please Select" Value=""></asp:ListItem>
                                        <asp:ListItem Text="ACT" Value="ACT"></asp:ListItem>
                                        <asp:ListItem Text="NSW" Value="NSW"></asp:ListItem>
                                        <asp:ListItem Text="NT" Value="NT"></asp:ListItem>
                                        <asp:ListItem Text="QLD" Value="QLD"></asp:ListItem>
                                        <asp:ListItem Text="SA" Value="SA"></asp:ListItem>
                                        <asp:ListItem Text="TAS" Value="TAS"></asp:ListItem>
                                        <asp:ListItem Text="VIC" Value="VIC"></asp:ListItem>
                                        <asp:ListItem Text="WA" Value="WA"></asp:ListItem>
                                        <asp:ListItem Text="I'm Overseas" Value="Overseas"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div id="divStateError" runat="server" clientidmode="Static" style="display: none"
                                    class="col-sm-8 col-sm-offset-3 input-group">
                                    <p class="help-block">
                                        <span class="error">State is required</span></p>
                                </div>
                            </div>
                        </asp:PlaceHolder>
                        <asp:PlaceHolder ID="pnlSafeSearchLeft" runat="server" Visible="False">
                            <div class="form-group">
                                <label for="tbAddress" class="col-md-3 col-sm-4 control-label">
                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral28" runat="server" SetLanguageCode="LabelAddress" />
                                    :&nbsp;<span class="required">*</span></label>
                                <div class="col-md-9 col-sm-8 input-group">
                                    <span class="input-group-addon" id="Span2"><span class="glyphicon glyphicon-envelope">
                                    </span></span>
                                    <asp:TextBox ID="tbAddress" runat="server" ClientIDMode="Static" placeholder="Address"
                                        CssClass="form-control" MaxLength="100" />
                                </div>
                                <div id="divSSAddressError" runat="server" clientidmode="Static" style="display: none"
                                    class="col-sm-8 col-sm-offset-3 input-group">
                                    <p class="help-block">
                                        <span class="error">Address is required</span></p>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="tbCountry" class="col-md-3 col-sm-4 control-label">
                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral41" runat="server" SetLanguageCode="LabelCountry" />
                                    :&nbsp;<span class="required">*</span></label>
                                <div class="col-md-9 col-sm-8 input-group">
                                    <span class="input-group-addon" id="Span4"><span class="glyphicon glyphicon-envelope">
                                    </span></span>
                                    <asp:TextBox ID="tbCountry" runat="server" ClientIDMode="Static" placeholder="Country"
                                        CssClass="form-control" MaxLength="100" />
                                </div>
                                <div id="divSSCountryError" runat="server" clientidmode="Static" style="display: none"
                                    class="col-sm-8 col-sm-offset-3 input-group">
                                    <p class="help-block">
                                        <span class="error">Country is required</span></p>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="tbPostcode" class="col-md-3 col-sm-4 control-label">
                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral42" runat="server" SetLanguageCode="LabelPostcode" />
                                    :&nbsp;<span class="required">*</span></label>
                                <div class="col-md-9 col-sm-8 input-group">
                                    <span class="input-group-addon" id="Span5"><span class="glyphicon glyphicon-envelope">
                                    </span></span>
                                    <asp:TextBox ID="tbPostcode" runat="server" ClientIDMode="Static" placeholder="Postcode"
                                        CssClass="form-control" MaxLength="100" />
                                </div>
                                <div id="divSSPostcodeError" runat="server" clientidmode="Static" style="display: none"
                                    class="col-sm-8 col-sm-offset-3 input-group">
                                    <p class="help-block">
                                        <span class="error">Postcode is required</span></p>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="tbContactNumber" class="col-md-3 col-sm-4 control-label">
                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral37" runat="server" SetLanguageCode="LabelContactNumber" />
                                    :&nbsp;<span class="required">*</span></label>
                                <div class="col-md-9 col-sm-8 input-group">
                                    <span class="input-group-addon" id="Span3"><span class="glyphicon glyphicon-phone-alt">
                                    </span></span>
                                    <asp:TextBox ID="tbContactNumber" runat="server" ClientIDMode="Static" placeholder="Contact Number"
                                        CssClass="form-control" MaxLength="100" />
                                </div>
                                <div id="divSSContactNumberError" runat="server" clientidmode="Static" style="display: none"
                                    class="col-sm-8 col-sm-offset-3 input-group">
                                    <p class="help-block">
                                        <span class="error">Contact Number is required</span></p>
                                </div>
                            </div>
                        </asp:PlaceHolder>
                        <asp:PlaceHolder ID="phJustApplyBottomLeft" runat="server">
                    </div>
                </div>
                </asp:PlaceHolder>
                <asp:PlaceHolder ID="phJustApplyTopRight" runat="server">
                    <div class="col-sm-6">
                        <div class="row">
                </asp:PlaceHolder>
                <asp:PlaceHolder ID="phJustApplyRight" runat="server">
                    <div class="form-group">
                        <label for="tbEmail" class="col-md-3 col-sm-4 control-label">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral17" runat="server" SetLanguageCode="LabelEmail" />
                            &nbsp;<span class="required">*</span></label>
                        <div class="col-md-9 col-sm-8 input-group">
                            <span class="input-group-addon" id="basic-addon4"><span class="glyphicon glyphicon-envelope">
                            </span></span>
                            <asp:TextBox ID="tbEmail" runat="server" TextMode="Email" ClientIDMode="Static" placeholder="Email"
                                CssClass="form-control" />
                        </div>
                        <div id="divEmailRequired" runat="server" clientidmode="Static" style="display: none"
                            class="col-sm-8 col-sm-offset-3 input-group">
                            <p class="help-block">
                                <span id="spEmailError" runat="server" class="error">Email is required</span></p>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="tbConfirmEmail" class="col-md-3 col-sm-4 control-label">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral18" runat="server" SetLanguageCode="LabelConfirmEmailPage" />
                            &nbsp;<span class="required">*</span></label>
                        <div class="col-md-9 col-sm-8 input-group">
                            <span class="input-group-addon" id="basic-addon5"><span class="glyphicon glyphicon-envelope">
                            </span></span>
                            <asp:TextBox ID="tbConfirmEmail" runat="server" TextMode="Email" ClientIDMode="Static"
                                placeholder="Confirm Email" CssClass="form-control" />
                        </div>
                        <div id="divConfirmEmailRequired" runat="server" clientidmode="Static" style="display: none"
                            class="col-sm-8 col-sm-offset-3 input-group">
                            <p class="help-block">
                                <span id="spConfEmailError" runat="server" class="error">Confirm Email is required</span></p>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="tbNewPassword" class="col-md-3 col-sm-4 control-label">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral19" runat="server" SetLanguageCode="LabelPassword" />
                            &nbsp;<span class="required">*</span></label>
                        <div class="col-md-9 col-sm-8 input-group">
                            <span class="input-group-addon"><span class="glyphicon glyphicon-lock"></span></span>
                            <asp:TextBox ID="tbNewPassword" runat="server" TextMode="Password" ClientIDMode="Static"
                                placeholder="Password" CssClass="form-control" autocomplete="off" />
                        </div>
                        <div id="divPasswordRequired" runat="server" clientidmode="Static" style="display: none"
                            class="col-sm-8 col-sm-offset-3 input-group">
                            <p class="help-block">
                                <span class="error">Password is required</span></p>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-9 col-sm-8 col-md-offset-3 col-sm-offset-4 input-group">
                            <p id="pPasswordError" class="help-block">
                                <asp:RegularExpressionValidator ID="revPassword" runat="server" ErrorMessage="" Display="Dynamic"
                                    ClientIDMode="Static" ControlToValidate="tbNewPassword" ValidationExpression="^(?=.{8,}$)(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).*$" /><JXTControl:ucLanguageLiteral
                                        ID="ltPasswordPrompt" runat="server" SetLanguageCode="LabelPasswordPrompt" />
                            </p>
                        </div>
                    </div>
                </asp:PlaceHolder>
                <asp:PlaceHolder ID="pnlPeopleBankRight" runat="server" Visible="False">
                    <div class="form-group">
                        <label for="ddlResidencyStatus" class="col-md-3 col-sm-4 control-label">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral22" runat="server" SetLanguageCode="LabelResidency" />
                            :&nbsp;<span class="required">*</span></label>
                        <div class="col-md-9 col-sm-8 input-group">
                            <asp:DropDownList ID="ddlResidencyStatus" runat="server" ClientIDMode="Static" CssClass="form-control">
                                <asp:ListItem Text="Please Select" Value="" />
                                <asp:ListItem Text="Australian Citizen" Value="Australian Citizen"></asp:ListItem>
                                <asp:ListItem Text="Australian Permanent Resident" Value="Australian Permanent Resident"></asp:ListItem>
                                <asp:ListItem Text="NZ Citizen" Value="NZ Citizen"></asp:ListItem>
                                <asp:ListItem Text="International Applicant" Value="International Applicant"></asp:ListItem>
                                <asp:ListItem Text="International Applicant with Work Visa" Value="International Applicant with Work Visa"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="divResidencyStatusError" runat="server" clientidmode="Static" style="display: none"
                            class="col-sm-8 col-sm-offset-3 input-group">
                            <p class="help-block">
                                <span class="error">Residency Status is required</span></p>
                        </div>
                    </div>
                </asp:PlaceHolder>
                <asp:PlaceHolder ID="pnlSafeSearchRight" runat="server" Visible="False">
                    <div class="form-group">
                        <label for="ddlWillingToRelocate" class="col-md-3 col-sm-4 control-label">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral38" runat="server" SetLanguageCode="LabelWillingToRelocate" />
                            :&nbsp;<span class="required">*</span></label>
                        <div class="col-md-9 col-sm-8 input-group">
                            <asp:DropDownList ID="ddlWillingToRelocate" runat="server" ClientIDMode="Static"
                                CssClass="form-control">
                                <asp:ListItem Text="Please Select" Value=""></asp:ListItem>
                                <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="divSSWillingToRelocateError" runat="server" clientidmode="Static" style="display: none"
                            class="col-sm-8 col-sm-offset-3 input-group">
                            <p class="help-block">
                                <span class="error">Willing To Relocate is required</span></p>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="ddlPreferredEmployment" class="col-md-3 col-sm-4 control-label">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral39" runat="server" SetLanguageCode="LabelPreferredEmployment" />
                            :&nbsp;<span class="required">*</span></label>
                        <div class="col-md-9 col-sm-8 input-group">
                            <asp:DropDownList ID="ddlPreferredEmployment" runat="server" ClientIDMode="Static"
                                CssClass="form-control">
                                <asp:ListItem Text="Please Select" Value=""></asp:ListItem>
                                <asp:ListItem Text="Permanent" Value="Permanent"></asp:ListItem>
                                <asp:ListItem Text="Contract" Value="Contract"></asp:ListItem>
                                <asp:ListItem Text="Permanent or Contract" Value="Permanent or Conatract"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="divSSPreferredEmploymentError" runat="server" clientidmode="Static" style="display: none"
                            class="col-sm-8 col-sm-offset-3 input-group">
                            <p class="help-block">
                                <span class="error">Preferred Employment is required</span></p>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="ddlSalary" class="col-md-3 col-sm-4 control-label">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral40" runat="server" SetLanguageCode="LabelSalary" />
                            :&nbsp;<span class="required">*</span></label>
                        <div class="col-md-9 col-sm-8 input-group">
                            <asp:DropDownList ID="ddlSalary" runat="server" ClientIDMode="Static" CssClass="form-control">
                                <asp:ListItem Text="Please Select" Value=""></asp:ListItem>
                                <asp:ListItem Value="60000">$60,000</asp:ListItem>
                                <asp:ListItem Value="70000">$70,000</asp:ListItem>
                                <asp:ListItem Value="80000">$80,000</asp:ListItem>
                                <asp:ListItem Value="90000">$90,000</asp:ListItem>
                                <asp:ListItem Value="100000">$100,000</asp:ListItem>
                                <asp:ListItem Value="110000">$110,000</asp:ListItem>
                                <asp:ListItem Value="120000">$120,000</asp:ListItem>
                                <asp:ListItem Value="130000">$130,000</asp:ListItem>
                                <asp:ListItem Value="140000">$140,000</asp:ListItem>
                                <asp:ListItem Value="150000">$150,000</asp:ListItem>
                                <asp:ListItem Value="160000">$160,000</asp:ListItem>
                                <asp:ListItem Value="170000">$170,000</asp:ListItem>
                                <asp:ListItem Value="180000">$180,000</asp:ListItem>
                                <asp:ListItem Value="190000">$190,000</asp:ListItem>
                                <asp:ListItem Value="200000">$200,000</asp:ListItem>
                                <asp:ListItem Value="210000">$210,000</asp:ListItem>
                                <asp:ListItem Value="220000">$220,000</asp:ListItem>
                                <asp:ListItem Value="230000">$230,000</asp:ListItem>
                                <asp:ListItem Value="240000">$240,000</asp:ListItem>
                                <asp:ListItem Value="250000">$250,000</asp:ListItem>
                                <asp:ListItem Value="260000">$260,000</asp:ListItem>
                                <asp:ListItem Value="270000">$270,000</asp:ListItem>
                                <asp:ListItem Value="280000">$280,000</asp:ListItem>
                                <asp:ListItem Value="290000">$290,000</asp:ListItem>
                                <asp:ListItem Value="300000">$300,000</asp:ListItem>
                                <asp:ListItem Value="300000+">$300,000+</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="divSSSalaryError" runat="server" clientidmode="Static" style="display: none"
                            class="col-sm-8 col-sm-offset-3 input-group">
                            <p class="help-block">
                                <span class="error">Salary is required</span></p>
                        </div>
                    </div>
                </asp:PlaceHolder>
                <asp:PlaceHolder ID="phJustApplyBottomRight" runat="server">
            </div>
        </div>
    </div>
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="phJustApplyBottomSection" runat="server"></section> </asp:PlaceHolder>
    <asp:PlaceHolder ID="phJustApplyBottom" runat="server"></asp:PlaceHolder>
    <div class="row">
        <div class="col-sm-6">
            <section class="boardy-resume-options">

                    <div class="form-group boardy-apply-titles">
                        <h3><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral24" runat="server" SetLanguageCode="LabelResume" /></h3>
                        <p id="pResumeRequired" runat="server" clientidmode="Static" visible="false" class="help-block"><span class="error" id="spResumeError" runat="server">Resume is required. Please choose a valid method</span></p>
                    </div>

                    <div class="btn-group">

                        <div class="radio" id="cvUploadResume">
                            <label>
                                <input id="rbUploadResume" runat="server" type="radio" name="cvRadios" value="resume2" clientidmode="Static" checked>
                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral34" runat="server" SetLanguageCode="LabelUploadAResume" />
                            </label>
                        </div>

                        <div class="radio" id="cvUseExiting" runat="server" visible="false">
                            <label>
                                <input id="rbExistingResume" runat="server"  type="radio" name="cvRadios" value="resume3" clientidmode="Static">
                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral35" runat="server" SetLanguageCode="LabelUseExistingResumeFile" />
                                
                            </label>
                        </div>

                        <div class="radio" id="cvUseProfile" runat="server" visible="false">
                            <label>
                                <input id="rbUseMyProfile" runat="server"  type="radio" name="cvRadios" value="resume4" clientidmode="Static">
                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral36" runat="server" SetLanguageCode="LabelUseMyProfile" />
                                
                            </label>
                        </div>

                    </div>

                </section>
            <section class="boardy-select-profile-resume" runat="server" clientidmode="Static"
                id="secUploadResume">

                    <!-- File Button -->
                    <div class="form-group">
                        <asp:DropDownList ID="ddlResume" runat="server" class="form-control" DataValueField="MemberFileID" DataTextField="MemberFileName">
                        </asp:DropDownList>
                    </div>
                </section>
            <section class="boardy-upload-resume" runat="server" clientidmode="Static" id="secExistingResume">

                    <!-- File Button -->
                    <div class="form-group">
                        <label class="control-label"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral29" runat="server" SetLanguageCode="LabelUploadResume" /></label>

                        <div class="controls">
                            <asp:FileUpload ID="fileUploadResume" runat="server" CssClass="input-file" ClientIDMode="Static" onchange="RemoveResumeFile();" />
                        </div>
                    </div>

                    <div class="form-group">

                        <asp:PlaceHolder ID="phResumeDropbox" runat="server" Visible="false">
                        <a id="lnkResumeDropBox" href="javascript:void(0);" class="dropbox" title="Upload via Dropbox"><img src="//images.jxt.net.au/COMMON/images/apply/uploadViaDropbox.png" alt="Upload via Dropbox" class="img-responsive"/></a>
                        </asp:PlaceHolder>
                        <asp:PlaceHolder ID="phResumeGoogleDrive" runat="server" Visible="false">
                        <a href="javascript:void(0);" class="google-drive" title="Upload via Google Drive" onclick="SetSelectedType('resume'); onApiLoad();"><img src="//images.jxt.net.au/COMMON/images/apply/uploadViaGoogleDrive.png" alt="Upload via Google Drive" class="img-responsive"/></a>
                        </asp:PlaceHolder>
                    </div>

                    <div id="divResumeFile" class="form-group externalFiles" runat="server" clientidmode="Static" style="display: none;">
                        <div class="alert alert-warning alert-dismissible" role="alert">
                            <button type="button" class="close" onclick="RemoveResumeFile();"><span aria-hidden="true">&times;</span></button>
                            <span id="spdivResumeFileName"><asp:Literal ID="ltSeekFileName" runat="server" /></span>
                        </div>
                    </div>

                    <asp:HiddenField ID="hfDropBoxResumeFileName" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hfDropBoxResumeFileURL" runat="server" ClientIDMode="Static" />

                    <asp:HiddenField ID="hfGoogleResumeFileId" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hfGoogleResumeFileName" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hfGoogleResumeToken" runat="server" ClientIDMode="Static" />

                    <asp:HiddenField ID="hfSeekResumeURL" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hfSeekApplicationID" runat="server" ClientIDMode="Static" />

                    <script type="text/javascript">
                        if (document.getElementById("lnkResumeDropBox")) {
                            if (Dropbox.isBrowserSupported()) {
                                document.getElementById("lnkResumeDropBox").onclick = function () {
                                    Dropbox.choose({
                                        linkType: "direct",
                                        success: function (files) {
                                            clearFileInput('fileUploadResume');
                                            $("#hfGoogleResumeFileId").val("");
                                            $("#hfGoogleResumeFileName").val("");
                                            $("#hfGoogleResumeToken").val("");

                                            $('#hfDropBoxResumeFileName').val(files[0].name);
                                            $('#hfDropBoxResumeFileURL').val(files[0].link);

                                            $('#divResumeFile').show();
                                            $('#spdivResumeFileName').text(files[0].name);
                                            $('#pResumeRequired').hide();
                                        },
                                        extensions: ['.txt', '.doc', '.docx', '.xls', '.xlsx', '.pdf', '.rtf']
                                    });
                                };
                            }
                        }
                    </script>
                </section>
        </div>
        <div class="col-sm-6">
            <section class="boardy-coverletter-options">
                    <!-- Multiple Radios -->
                    <div class="form-group boardy-apply-titles">
                        <h3><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral43" runat="server" SetLanguageCode="LabelCoverLetter" /></h3>
                        <p id="divCoverLetterFormatNotValid" runat="server" clientidmode="Static" visible="false" class="help-block"><span class="error" id="spCoverLetterError" runat="server">The file format uploaded is not valid.</span></p>
                    </div>

                    <div class="btn-group">

                        <div class="radio" id="clUploadCoverletter">
                            <label>
                                <input id="rbUploadCoverLetter" runat="server" type="radio" name="clRadio" value="coverletter1" clientidmode="Static" checked>
                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral30" runat="server" SetLanguageCode="LabelUploadACoverLetter" />
                            </label>
                        </div>

                        <div class="radio" id="clWriteOwn">
                            <label>
                                <input id="rbWriteOneNow" runat="server"  type="radio" name="clRadio" value="coverletter2" clientidmode="Static" />
                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral31" runat="server" SetLanguageCode="ButtonWriteOneNow" />
                            </label>
                        </div>

                        <div class="radio" id="clUseExisting" runat="server" visible="false">
                            <label>
                                <input id="rbExistingCoverLetter" runat="server"  type="radio" name="clRadio" value="coverletter3" clientidmode="Static">
                                Use existing cover letter file
                            </label>
                        </div>
                    </div>

                </section>
            <section class="boardy-upload-coverletter">
                <!-- File Button -->
                <div class="form-group">
                    <label class="control-label" for="fileUploadCV"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral32" runat="server" SetLanguageCode="LabelUploadCoverLetter" /></label>

                    <div class="controls">
                        <asp:FileUpload ID="fileUploadCV" runat="server" CssClass="input-file" ClientIDMode="Static" onchange="RemoveCoverLetterFile();" />
                    </div>
                </div>
                <div class="form-group">

                    <asp:PlaceHolder ID="phCLDropbox" runat="server" Visible="false">
                        <a id="lnkCLDropBox" href="javascript:void(0);" class="dropbox" title="Upload via Dropbox"><img src="//images.jxt.net.au/COMMON/images/apply/uploadViaDropbox.png" alt="Upload via Dropbox" class="img-responsive"/></a>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="phCLGoogleDrive" runat="server" Visible="false">
                        <a href="javascript:void(0);" class="google-drive" title="Upload via Google Drive" onclick="SetSelectedType('coverletter'); onApiLoad();"><img src="//images.jxt.net.au/COMMON/images/apply/uploadViaGoogleDrive.png" alt="Upload via Google Drive" class="img-responsive"/></a>
                    </asp:PlaceHolder>
                </div>

                <div id="divCoverLetterFile" class="form-group externalFiles" style="display: none;">
                    <div class="alert alert-warning alert-dismissible" role="alert">
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close" onclick="RemoveCoverLetterFile();"><span aria-hidden="true">&times;</span></button>
                        <span id="spdivCoverLetterFileName"></span>
                    </div>
                </div>

            </section>
            <section class="boardy-select-profile-coverletter">
                <!-- File Button -->
                <div class="form-group">
                    <asp:DropDownList ID="ddlCoverLetter" runat="server" CssClass="form-control" DataValueField="MemberFileID" DataTextField="MemberFileName">
                    </asp:DropDownList>
                </div>

            </section>
            <section class="boardy-write-coverletter">
                <!-- Textarea -->
                <div class="form-group">

                    <div class="controls">
                        <asp:TextBox ID="txtCoverLetterText" runat="server" CssClass="form-control" placeholder="Write my own coverletter" TextMode="MultiLine" />
                    </div>
                </div>

                <asp:HiddenField ID="hfDropBoxCLFileName" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hfDropBoxCLFileURL" runat="server" ClientIDMode="Static" />

                <asp:HiddenField ID="hfGoogleCLFileId" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hfGoogleCLFileName" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hfGoogleCLToken" runat="server" ClientIDMode="Static" />

                <asp:HiddenField ID="hfGoogleSelectedType" runat="server" ClientIDMode="Static" />

                <script type="text/javascript">
                    if (document.getElementById("lnkCLDropBox")) {
                        if (Dropbox.isBrowserSupported()) {
                            document.getElementById("lnkCLDropBox").onclick = function () {
                                Dropbox.choose({
                                    linkType: "direct",
                                    success: function (files) {
                                        clearFileInput('fileUploadCV');
                                        $("#hfGoogleCLFileId").val("");
                                        $("#hfGoogleCLFileName").val("");
                                        $("#hfGoogleCLToken").val("");

                                        $('#hfDropBoxCLFileName').val(files[0].name);
                                        $('#hfDropBoxCLFileURL').val(files[0].link);

                                        $('#divCoverLetterFile').show();
                                        $('#spdivCoverLetterFileName').text(files[0].name);
                                        $('#divCoverLetterFormatNotValid').hide();
                                    },
                                    extensions: ['.txt', '.doc', '.docx', '.pdf', '.rtf']
                                });
                            };
                        }
                    }
                </script>
            </section>
        </div>
    </div>
    <asp:PlaceHolder ID="phScreeningQuestions" runat="server">
        <section class="boardy-screen-questions boardy-apply-register" style="display: block;">
        <div class="row">
            <div class="col-sm-12">
                <div class="row">
                    <h3><JXTControl:ucLanguageLiteral ID="ltScreeningQuestions" runat="server" SetLanguageCode="LabelScreeningQuestions" /></h3>
                    <ul class="SQstTemp">
                        <asp:Repeater ID="rptScreeningQuestions" runat="server" OnItemDataBound="rptScreeningQuestions_ItemDataBound">
                            <ItemTemplate>
                                <li>
                                    <span class="screen-qsts">
								        <strong><asp:HiddenField ID="hfScreeningQuestionId" runat="server" /><asp:Literal ID="ltQuestion" runat="server" /></strong>
                                        <asp:Literal ID="ltOptions" runat="server" />
                                    </span>
                                    <asp:PlaceHolder ID="phError" runat="server" Visible="false">
                                        <span class="help-block">
                                                <span class="error"><JXTControl:ucLanguageLiteral ID="ltError" runat="server" /></span>
                                        </span>
                                    </asp:PlaceHolder>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>
        </section>
    </asp:PlaceHolder>
    <section class="boardy-captcha-alert-terms">

        <!-- Multiple Checkboxes -->
        <div class="form-group">
            <JXTControl:ucPrivacySettings ID="ucPrivacySettings" runat="server" />
        </div>
        <div class="checkbox">
            <label>
                <input id="cbSubscribeJobAlert" runat="server" type="checkbox" value="" />
                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral33" runat="server" SetLanguageCode="LabelSubscribeToJobAlert" />
            </label>
        </div>

    </section>
    </div>
    <hr />
    <!-- Button (Double) -->
    <div class="form-group">
        <div class="controls">
            <asp:Button runat="server" ID="apply" CssClass="mini-new-buttons" UseSubmitBehavior="true"
                Text="Apply" OnClick="apply_Click" OnClientClick="ApplyCheck(event);" ClientIDMode="Static">
            </asp:Button>
            <asp:Button runat="server" ID="cancel" CssClass="mini-new-buttons" UseSubmitBehavior="true"
                Text="Back to Job" OnClick="cancel_Click" ClientIDMode="Static"></asp:Button>
        </div>
    </div>
    </div> </div> </div> </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#divForm input').keydown(function (event) {
                if (event.keyCode == 13) {
                    $('#apply').click();

                    event.preventDefault();
                    return false;
                }
            });
        });
    </script>
    <script type="text/javascript">

        // The Browser API key obtained from the Google Developers Console.
        var developerKey = '<%=GoogleDeveloperKey %>';

        // The Client ID obtained from the Google Developers Console. Replace with your own Client ID.
        var clientId = '<%=GoogleClientID %>';
        // Scope to use to access user's photos.
        var scope = ['https://www.googleapis.com/auth/drive'];

        var pickerApiLoaded = false;
        var oauthToken;

        // Use the API Loader script to load google.picker and gapi.auth.
        function onApiLoad() {
            gapi.load('auth', { 'callback': onAuthApiLoad });
            gapi.load('picker', { 'callback': onPickerApiLoad() });
        }

        function onAuthApiLoad() {
            window.gapi.auth.authorize(
            {
                'client_id': clientId,
                'scope': scope,
                'immediate': false
            },
            handleAuthResult);
        }

        function onPickerApiLoad() {
            pickerApiLoaded = true;
            createPicker();
        }

        function handleAuthResult(authResult) {
            if (authResult && !authResult.error) {
                oauthToken = authResult.access_token;
                if ($("#hfGoogleSelectedType").val() == "coverletter") {
                    $('#hfGoogleCLToken').val(oauthToken);
                }
                else {
                    $('#hfGoogleResumeToken').val(oauthToken);
                }
                createPicker();
            }
        }

        // Create and render a Picker object for picking user Photos.
        var created = false;
        var picker;
        function createPicker() {
            if (pickerApiLoaded && oauthToken) {
                if (!created) {
                    picker = new google.picker.PickerBuilder().
                  addView(new google.picker.DocsView(google.picker.ViewId.DOCUMENTS).setOwnedByMe(true)).
                  addView(new google.picker.DocsView(google.picker.ViewId.SPREADSHEETS).setOwnedByMe(true)).
                  setOAuthToken(oauthToken).
                  setDeveloperKey(developerKey).
                  setCallback(pickerCallback).
                  build();
                    created = true;
                }
                picker.setVisible(true);
            }
        }

        // A simple callback implementation.
        function pickerCallback(data) {
            var id = '', filename = '';
            if (data[google.picker.Response.ACTION] == google.picker.Action.PICKED) {
                var doc = data[google.picker.Response.DOCUMENTS][0];
                id = doc[google.picker.Document.ID];
                filename = doc[google.picker.Document.NAME];

                if ($("#hfGoogleSelectedType").val() == "coverletter") {
                    $('#divCoverLetterFile').show();
                    $('#spdivCoverLetterFileName').text(filename);
                }
                else {
                    $('#divResumeFile').show();
                    $('#spdivResumeFileName').text(filename);
                }
            }

            if ($("#hfGoogleSelectedType").val() == "coverletter") {
                clearFileInput('fileUploadCV');
                $("#hfDropBoxCLFileName").val("");
                $("#hfDropBoxCLFileURL").val("");
                $('#hfGoogleCLFileId').val(id);
                $('#hfGoogleCLFileName').val(filename);
                $('#divCoverLetterFormatNotValid').hide();
            }
            else {
                clearFileInput('fileUploadResume');
                $("#hfSeekResumeURL").val("");
                $("#hfDropBoxResumeFileName").val("");
                $("#hfDropBoxResumeFileURL").val("");
                $('#hfGoogleResumeFileId').val(id);
                $('#hfGoogleResumeFileName').val(filename);
                $('#pResumeRequired').hide();
            }
        }

        function clearFileInput(input) {
            $("#" + input).val("");
        }

    </script>
    <script type="text/javascript" src="https://apis.google.com/js/api.js"></script>
    <script type="text/javascript">
        function RemoveCoverLetterFile() {
            $("#hfDropBoxCLFileName").val("");
            $("#hfDropBoxCLFileURL").val("");
            $("#hfGoogleCLFileId").val("");
            $("#hfGoogleCLFileName").val("");
            $("#hfGoogleCLToken").val("");

            $("#divCoverLetterFile").hide();
            $("#spdivCoverLetterFileName").text("");
            $('#divCoverLetterFormatNotValid').hide();
        }

        function RemoveResumeFile() {
            $("#hfDropBoxResumeFileName").val("");
            $("#hfDropBoxResumeFileURL").val("");
            $("#hfGoogleResumeFileId").val("");
            $("#hfGoogleResumeFileName").val("");
            $("#hfGoogleResumeToken").val("");
            $("#hfSeekResumeURL").val("");

            $("#divResumeFile").hide();
            $("#spdivResumeFileName").text("");
            $('#pResumeRequired').hide();
        }

        function SetSelectedType(type) {
            $('#hfGoogleSelectedType').val(type);
        }

        function SignInClicked(event) {

            var hasError = false;

            if ($("#tbUserName").val() == "") {
                hasError = true;
                $("#divUsernameError").show();
            }
            else {
                $("#divUsernameError").hide();
            }

            if ($("#tbPassword").val() == "") {
                hasError = true;
                $("#divPasswordError").show();
            }
            else {
                $("#divPasswordError").hide();
            }

            if (hasError) {
                event.preventDefault();
            }
        }

        function ApplyCheck(event) {
            var hasError = false;

            if ($("#tbFirstName").val() == "") {
                $("#divFirstNameRequired").show();
                $("#divFirstNameRequired span").html("<%=FirstNameError %>");
                if (!hasError) {
                    $("#tbFirstName").focus();
                }

                hasError = true;
            }
            else {
                $("#divFirstNameRequired").hide();
            }

            if ($("#tbLastName").val() == "") {

                $("#divLastNameRequired").show();
                $("#divLastNameRequired span").html("<%=LastNameError %>");
                if (!hasError) {
                    $("#tbLastName").focus();
                }
                hasError = true;
            }
            else {
                $("#divLastNameRequired").hide();
            }

            if ($("#tbEmail").val() == "") {

                $("#divEmailRequired").show();
                $("#divEmailRequired span").html("<%=EmailError %>");
                if (!hasError) {
                    $("#tbEmail").focus();
                }
                hasError = true;
            }
            else {
                $("#divEmailRequired").hide();
            }

            if ($("#tbConfirmEmail").val() == "") {

                $("#divConfirmEmailRequired").show();
                $("#divConfirmEmailRequired span").html("<%=ConfirmEmailError %>");
                if (!hasError) {
                    $("#tbConfirmEmail").focus();
                }
                hasError = true;
            }
            else {
                if ($("#tbEmail").val() != "") {
                    if ($("#tbEmail").val() != $("#tbConfirmEmail").val()) {
                        $("#divConfirmEmailRequired").show();
                        $("#divConfirmEmailRequired span").html("<%=ConfirmEmailNotMatch %>");
                        if (!hasError) {
                            $("#tbConfirmEmail").focus();
                        }
                        hasError = true;
                    }
                    else {
                        $("#divConfirmEmailRequired").hide();
                    }
                }

            }

            if ($("#tbNewPassword").val() == "") {

                $("#divPasswordRequired").show();
                $("#divPasswordRequired span").html("<%=NewPasswordError %>");
                if (!hasError) {
                    $("#tbNewPassword").focus();
                }
                hasError = true;
            }
            else {
                $("#divPasswordRequired").hide();
            }

            if ($("#tbLandLine").val() == "") {

                $("#divLandLineError").show();
                $("#divLandLineError span").html("<%=LandLineError %>");
                if (!hasError) {
                    $("#tbLandLine").focus();
                }
                hasError = true;
            }
            else {
                $("#divLandLineError").hide();
            }

            if ($("#ddlState").val() == "") {

                $("#divStateError").show();
                $("#divStateError span").html("<%=StateError %>");
                if (!hasError) {
                    $("#ddlState").focus();
                }
                hasError = true;
            }
            else {
                $("#divStateError").hide();
            }

            if ($("#ddlResidencyStatus").val() == "") {

                $("#divResidencyStatusError").show();
                $("#divResidencyStatusError span").html("<%=ResidencyStatusError %>");
                if (!hasError) {
                    $("#ddlResidencyStatus").focus();
                }
                hasError = true;
            }
            else {
                $("#divStateError").hide();
            }

            if ($("#tbAddress").val() == "") {

                $("#divSSAddressError").show();
                $("#divSSAddressError span").html("<%=AddressError %>");
                if (!hasError) {
                    $("#tbAddress").focus();
                }
                hasError = true;
            }
            else {
                $("#divSSAddressError").hide();
            }

            if ($("#tbContactNumber").val() == "") {

                $("#divSSContactNumberError").show();
                $("#divSSContactNumberError span").html("<%=ContactNumberError %>");
                if (!hasError) {
                    $("#tbContactNumber").focus();
                }
                hasError = true;
            }
            else {
                $("#divSSContactNumberError").hide();
            }

            if ($("#tbCountry").val() == "") {

                $("#divSSCountryError").show();
                $("#divSSCountryError span").html("<%=CountryError %>");
                if (!hasError) {
                    $("#tbCountry").focus();
                }
                hasError = true;
            }
            else {
                $("#divSSCountryError").hide();
            }

            if ($("#tbPostcode").val() == "") {

                $("#divSSPostcodeError").show();
                $("#divSSPostcodeError span").html("<%=PostcodeError %>");
                if (!hasError) {
                    $("#tbPostcode").focus();
                }
                hasError = true;
            }
            else {
                $("#divSSPostcodeError").hide();
            }

            if ($("#ddlWillingToRelocate").val() == "") {

                $("#divSSWillingToRelocateError").show();
                $("#divSSWillingToRelocateError span").html("<%=WillingToRelocateError %>");
                if (!hasError) {
                    $("#divSSWillingToRelocateError").focus();
                }
                hasError = true;
            }
            else {
                $("#divSSPreferredEmploymentError").hide();
            }

            if ($("#ddlPreferredEmployment").val() == "") {

                $("#divSSPreferredEmploymentError").show();
                $("#divSSPreferredEmploymentError span").html("<%=PreferredEmploymentError %>");
                if (!hasError) {
                    $("#ddlPreferredEmployment").focus();
                }
                hasError = true;
            }
            else {
                $("#divSSPreferredEmploymentError").hide();
            }

            if ($("#ddlSalary").val() == "") {

                $("#divSSSalaryError").show();
                $("#divSSSalaryError span").html("<%=SalaryErrror %>");
                if (!hasError) {
                    $("#ddlSalary").focus();
                }
                hasError = true;
            }
            else {
                $("#divSSSalaryError").hide();
            }

            if ($("#revPassword").css("display") == "inline") {
                $("#pPasswordError").prop("class", "help-block error");
            }
            else {
                $("#pPasswordError").prop("class", "help-block");
            }

            if (hasError) {
                event.preventDefault();
            }

        }
    </script>
</asp:Content>
