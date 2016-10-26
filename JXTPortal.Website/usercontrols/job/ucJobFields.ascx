<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucJobFields.ascx.cs"
    Inherits="JXTPortal.Website.Admin.UserControls.JobFields" %>
<%@ Register Src="../common/ucLanguageLiteral.ascx" TagName="ucLanguageLiteral" TagPrefix="JXTControl" %>
<%@ Register Src="~/usercontrols/job/ucJobFieldsMultiLingual.ascx" TagName="JobFieldsMultiLingual"
    TagPrefix="uc1" %>
<%@ Register TagPrefix="uc1" Namespace="JXTPortal.Website.usercontrols.common" Assembly="JXTPortal.WebSite" %>
<asp:HiddenField ID="hfFileCheck" runat="server" Value="" ClientIDMode="Static" />
<asp:HiddenField ID="hfFileError" runat="server" Value="" ClientIDMode="Static" />
<div id="content-container">
    <div class="container">
        <div id="content">
            <JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage" runat="server" SetSystemPageCode="SystemPage_AdvertiserJobCreate" />
            <div class="form-all">
                <ul class="form-section">
                    <li>
                        <div class="form-header-group">
                            <h2 class="form-header">
                                <JXTControl:ucLanguageLiteral ID="ltPostAJob" runat="server" SetLanguageCode="LabelPostAJob" />
                                <!-- Post a Job -->
                            </h2>
                        </div>
                    </li>
                </ul>
                <hr /> 
                <span class="form-message">
                    <asp:Literal ID="ltlMessage" runat="server" />
                    <asp:CustomValidator ID="CusValJobProfessionRole" runat="server" Display="Dynamic"
                        OnServerValidate="CusValJobProfessionRole_ServerValidate" SetFocusOnError="true" />
                </span>
                <ul class="form-section">
                    <asp:PlaceHolder ID="pnlAdvertiser" runat="server">
                        <li class="form-line" id="jobs-advertiser-field">
                            <asp:Label ID="lbAdvertiser" runat="server" AssociatedControlID="ddlAdvertiser">
                                <JXTControl:ucLanguageLiteral ID="ltAdvertiser" runat="server" SetLanguageCode="LabelAdvertiser" />
                                :<span class="form-required">*</span></asp:Label>
                            <div>
                                <asp:DropDownList runat="server" ID="ddlAdvertiser" DataTextField="CompanyName" DataValueField="AdvertiserID"
                                    CssClass="form-multiple-column" Enabled="false" />
                                <asp:RequiredFieldValidator ID="ReqVal_Advertiser" runat="server" ControlToValidate="ddlAdvertiser"
                                    SetFocusOnError="true" Display="Dynamic" InitialValue="0" />
                            </div>
                        </li>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="pnlAdvertiserUser" runat="server">
                        <li class="form-line" id="jobs-advertiseruser-field">
                            <asp:Label ID="lbAdvertiserUser" runat="server" AssociatedControlID="lblusername">
                                <JXTControl:ucLanguageLiteral ID="ltAdvertiserUser" runat="server" SetLanguageCode="LabelAssignedJobTo" />
                                :<span class="form-required">*</span></asp:Label>
                            <div>
                                <asp:Label ID="lblusername" runat="server" />
                            </div>
                        </li>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="pnlCompanyName" runat="server" Visible="false">
                        <li class="form-line" id="jobs-companyname-field">
                            <asp:Label ID="lbCompanyName" runat="server" AssociatedControlID="txtCompanyName">
                                <JXTControl:ucLanguageLiteral ID="ltCompanyName" runat="server" SetLanguageCode="LabelCompanyName" />
                                :</asp:Label>
                            <div>
                                <asp:TextBox ID="txtCompanyName" runat="server" Enabled="false" />
                            </div>
                        </li>
                    </asp:PlaceHolder>
                    <li class="form-line" id="jobs-jobitemtype-field">
                        <asp:Label ID="lbJobItemType" runat="server" AssociatedControlID="ddlJobItemType">
                            <JXTControl:ucLanguageLiteral ID="ltJobItemType" runat="server" SetLanguageCode="LabelJobItemType" />
                            <!-- Job Item Type -->
                            <span class="form-required">*</span></asp:Label>
                        <div>
                            <asp:DropDownList ID="ddlJobItemType" runat="server" CssClass="form-multiple-column"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlJobItemType_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:PlaceHolder ID="phNoJobCredit" runat="server" Visible="false"><span style="color: red;
                                display: inline;">
                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral6" runat="server" SetLanguageCode="LabelNoJobCredit" />
                            </span></asp:PlaceHolder>
                        </div>
                        <asp:PlaceHolder ID="phInfo" runat="server" Visible="false">
                            <p class="help-block premiumNotice">
                                <JXTControl:ucLanguageLiteral ID="ltPremiumJobsNote" runat="server" SetLanguageCode="LabelPremiumJobsNote" />
                            </p>
                        </asp:PlaceHolder>
                    </li>
                    <asp:PlaceHolder ID="phJobStartDate" runat="server" Visible="false">
                        <li class="form-line" id="Li3">
                            <asp:Label ID="lbJobStartDate" runat="server" AssociatedControlID="tbStartDate">
                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral7" runat="server" SetLanguageCode="LabelJobStartDate" />
                                :<span class="form-required">*</span></asp:Label>
                            <div>
                                <asp:TextBox runat="server" ID="tbStartDate" MaxLength="10"></asp:TextBox>
                                <asp:ImageButton ID="ibStartDate" runat="server" SkinID="CalendarImageButton" CausesValidation="False"
                                    ImageUrl="/images/minical.gif" />
                                <ajaxToolkit:CalendarExtender ID="cal_tbStartDate" runat="server" Format="dd/MM/yyyy"
                                    TargetControlID="tbStartDate" PopupButtonID="ibStartDate">
                                </ajaxToolkit:CalendarExtender>
                                <asp:RequiredFieldValidator ID="rqStartDate" runat="server" ControlToValidate="tbStartDate"
                                    SetFocusOnError="true" Display="Dynamic" />

                                <asp:CustomValidator ID="cvStartDate" runat="server" ControlToValidate="tbStartDate" OnServerValidate="cvStartDate_ServerValidate" />
                            </div>
                        </li>
                    </asp:PlaceHolder>
                    <li class="form-line" id="jobs-jobname-field">
                        <asp:Label ID="lbRefNo" runat="server" AssociatedControlID="txtRefNo">
                            <JXTControl:ucLanguageLiteral ID="ltRefNo" runat="server" SetLanguageCode="LabelRefNo" />
                            <!-- Reference Number -->
                        </asp:Label>
                        <div>
                            <asp:TextBox ID="txtRefNo" runat="server" autocomplete="off" />
                        </div>
                    </li>
                    <script type="text/javascript">
                        $(document).ready(function () {
                            $('ul.new-lang-tabs li').click(function () {
                                var tab_id = $(this).attr('data-tab');

                                $('ul.new-lang-tabs li').removeClass('current');
                                $('.tab-content').removeClass('current');

                                $(this).addClass('current');
                                $("#" + tab_id).addClass('current');
                            });

                            $('.customQuestionTypeSelect').change(function () {
                                if ($(this).val() == 2) {
                                    $('.customQuestionOptions').show();
                                } else {
                                    $('.customQuestionOptions').hide();
                                }
                            });

                            $('ul.new-lang-tabs li').first().click();
                        });


                        $('.addQuestionBtn').click(function () {
                            var quesLabel = $('.questionLabelForm').val();
                            var quesOptions = $('#languageSelector').val();

                            $('.screenQuestionsTable').last('tr').prepend('<tr class="NewQuestion"><td><span class="questionLabelTable">' + quesLabel + '</span></td><td><span class="questionOptionsTable">' + questionOptionsForm + '</span></td><td><a class="editQuestionBtn">Edit</a> | <a class="DeleteQuestionBtn">Delete</a></td>');
                            // $('.versionTemplateHolder').hide();
                            // $('#languageTableVersions').after('<p class="msg done">Your version has been successfully saved</p>');
                            // $('#languageSelector').val('0');
                            // setTimeout(fade_out, 3000);
                        });
                    </script>
                    <asp:PlaceHolder ID="phSelectLanguage" runat="server" Visible="false">
                        <li class="form-line">
                            <asp:Label ID="lbLanguage" runat="server" AssociatedControlID="ltLanguageList">
                                <JXTControl:ucLanguageLiteral ID="ltSelectLanguage" runat="server" SetLanguageCode="LabelSelectLanguage" />
                                <!-- Select Language-->
                                <span class="form-required">*</span></asp:Label>
                            <ul class="new-lang-tabs">
                                <asp:Literal ID="ltLanguageList" runat="server" />
                                <!-- <li class="tab-link current" data-tab="english-tab">English</li>
					<li class="tab-link" data-tab="chinese-tab">Chinese</li>
					<li class="tab-link" data-tab="french-tab">French</li>
					<li class="tab-link" data-tab="spanish-tab">Spanish</li> -->
                            </ul>
                        </li>
                    </asp:PlaceHolder>
                    <!-- Repeater of User Control Begins -->
                    <asp:Repeater ID="rptLanguagesPanel" runat="server" OnItemDataBound="rptLanguagesPanel_ItemDataBound">
                        <ItemTemplate>
                            <uc1:JobFieldsMultiLingual ID="ucJobFieldsMultiLingual" runat="server" />
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Literal ID="ltMultiLingualScript" runat="server" />
                    <li class="form-line" id="jobs-jobname-field">
                        <asp:Label ID="lbFriendlyUrl" runat="server" AssociatedControlID="txtFriendlyUrl">
                            <JXTControl:ucLanguageLiteral ID="ltJobFriendlyName" runat="server" SetLanguageCode="LabelJobFriendlyName" />
                            <!-- Job Friendly Name -->
                            <span class="form-required">*</span></asp:Label>
                        <div>
                            <div class="input-group">
                                <asp:TextBox ID="txtFriendlyUrl" runat="server" CssClass="form-control" autocomplete="off"
                                    placeholder="click to generate ..." />
                                <span class="input-group-btn">
                                    <button class="btn btn-default" type="button" onclick="checkFriendlyUrlChanged();">
                                        <JXTControl:ucLanguageLiteral ID="ltGenerate" runat="server" SetLanguageCode="LabelGenerate" />
                                    </button>
                                </span>
                                <asp:RequiredFieldValidator ID="ReqVal_FriendlyUrl" runat="server" ControlToValidate="txtFriendlyUrl"
                                    SetFocusOnError="true" Display="Dynamic" />
                            </div>
                            <!-- /input-group -->
                        </div>
                    </li>
                    <li class="form-line" id="Li1">
                        <asp:Label ID="lbEnterCommaSeparated" runat="server" AssociatedControlID="txtTags">
                            <JXTControl:ucLanguageLiteral ID="ltTags" runat="server" SetLanguageCode="LabelTags" />
                            <!-- Tags -->
                        </asp:Label>
                        <div>
                            <asp:TextBox ID="txtTags" runat="server" autocomplete="off" />
                        </div>
                        <p class="help-block">
                            <JXTControl:ucLanguageLiteral ID="ltEnterCommaSeparated" runat="server" SetLanguageCode="LabelEnterCommaSeparated" />
                            <!-- Please enter comma seperated "," -->
                        </p>
                    </li>
                    <h3>
                        <JXTControl:ucLanguageLiteral ID="ltLocationDetails" runat="server" SetLanguageCode="LabelLocationDetails" />
                        <!-- Location details -->
                    </h3>
                    <li class="form-line" id="jobs-jobname-field">
                        <asp:Label ID="lbAddress" runat="server" AssociatedControlID="txtAddress">
                            <JXTControl:ucLanguageLiteral ID="ltStreetAddress" runat="server" SetLanguageCode="LabelStreetAddress" />
                            <!-- Street Address -->
                        </asp:Label>
                        <div>
                            <asp:TextBox ID="txtAddress" runat="server" autocomplete="off" ClientIDMode="Static" />
                            <asp:HiddenField ID="hfAddressLat" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="hfAddressLng" runat="server" ClientIDMode="Static" />
                            <div id="map" style="width: 500px; height: 500px">
                            </div>
                        </div>
                        <p class="help-block">
                            <JXTControl:ucLanguageLiteral ID="ltSubmitStreetAddress" runat="server" SetLanguageCode="LabelSubmitStreetAddress" />
                            <!-- Please submit street address to enable map and radius searching -->
                        </p>
                    </li>
                    <li class="form-line" id="jobs-location-area">
                        <asp:Label ID="lbLocation" runat="server" AssociatedControlID="ddlLocation">
                            <JXTControl:ucLanguageLiteral ID="ltLocationAndArea" runat="server" SetLanguageCode="LabelLocationAndArea" />
                            <!-- Location / Area-->
                            <span class="form-required">*</span></asp:Label>
                        <asp:UpdatePanel ID="updatePanel" runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-md-6 halfBlock">
                                        <uc1:DropDownListX ID="ddlLocation" runat="server" AutoPostBack="true" CssClass="form-control"
                                            OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged" />
                                        <%--<select class="form-control">
                                <option selected="selected" value="0">Please Choose ...</option>
                                <optgroup label="AUSTRALIA">
                                    <option value="1">Sydney</option>
                                    <option value="2">Melbourne</option>
                                </optgroup>
                            </select>--%>
                                    </div>
                                    <div class="col-md-6 halfBlock">
                                        <asp:DropDownList ID="ddlArea" runat="server" CssClass="form-control" />
                                        <asp:RequiredFieldValidator ID="ReqVal_JobArea" runat="server" ControlToValidate="ddlArea"
                                            InitialValue="0" SetFocusOnError="true" Display="Dynamic" />
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </li>
                    <li class="form-line" id="jobs-publictransport-field">
                        <asp:Label ID="lbPublicTransport" runat="server" AssociatedControlID="txtPublicTransport">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldPublicTransport" runat="server" SetLanguageCode="LabelPublicTransport" />
                            :</asp:Label>
                        <div>
                            <asp:TextBox ID="txtPublicTransport" runat="server" />
                        </div>
                    </li>
                    <li class="form-line" id="jobs-showlocationdetails-field">
                        <asp:Label ID="lbShowLocation" runat="server" AssociatedControlID="chkShowLocationDetails">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldShowLocationDetail" runat="server" SetLanguageCode="LabelShowLocationDetail" />
                            :</asp:Label>
                        <div>
                            <asp:CheckBox ID="chkShowLocationDetails" runat="server" />
                        </div>
                    </li>
                    <h3>
                        <JXTControl:ucLanguageLiteral ID="ltSalaryDetails" runat="server" SetLanguageCode="LabelSalaryDetails" />
                        <!--Salary details-->
                    </h3>
                    <li class="form-line" id="jobs-jobitemtype-field">
                        <asp:Label ID="lbSalaryType" runat="server" AssociatedControlID="ddlSalary">
                            <JXTControl:ucLanguageLiteral ID="ltSalaryType" runat="server" SetLanguageCode="LabelSalaryType" />
                            <!--Salary type-->
                            <span class="form-required">*</span></asp:Label>
                        <div>
                            <div class="row">
                                <div class="col-md-6">
                                    <asp:DropDownList runat="server" ID="ddlSalary" DataTextField="SalaryTypeName" DataValueField="SalaryTypeID"
                                        ClientIDMode="Static" CssClass="form-multiple-column" />
                                    <asp:RequiredFieldValidator ID="ReqVal_Salary" runat="server" InitialValue="0" ControlToValidate="ddlSalary"
                                        SetFocusOnError="true" Display="Dynamic" />
                                </div>
                            </div>
                        </div>
                    </li>
                    <li class="form-line" id="jobs-salary-range">
                        <asp:Label ID="lbFromTo" runat="server" AssociatedControlID="txtSalaryLowerBand">
                            <JXTControl:ucLanguageLiteral ID="ltFromTo" runat="server" SetLanguageCode="LabelFromTo" />
                            <!-- From/To -->
                            <span class="form-required">*</span></asp:Label>
                        <div>
                            <div class="row">
                                <div class="col-md-6 halfBlock">
                                    <div>
                                        <asp:Literal ID="ltlLowerCurrency" runat="server" /><asp:TextBox ID="txtSalaryLowerBand"
                                            runat="server" size="10" ClientIDMode="Static" autocomplete="off" placeholder="From Salary"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6 halfBlock">
                                    <div>
                                        <asp:Literal ID="ltlUpperCurrency" runat="server" /><asp:TextBox ID="txtSalaryUpperBand"
                                            runat="server" size="10" ClientIDMode="Static" placeholder="To Salary"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </li>
                    <li class="form-line checkbox-holder">
                        <asp:Label ID="lbShowSalaryRange" runat="server" AssociatedControlID="chkShowSalaryRange">
                            <input id="chkShowSalaryRange" runat="server" type="checkbox" clientidmode="Static" />
                            <JXTControl:ucLanguageLiteral ID="ltDisplaySalary" runat="server" SetLanguageCode="LabelDisplaySalary" />
                            <!-- Display salary -->
                        </asp:Label>
                    </li>
                    <li class="form-line" id="jobs-salarytext-field">
                        <asp:Label ID="lbSalaryText" runat="server" AssociatedControlID="txtSalaryText">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldSalaryText" runat="server" SetLanguageCode="LabelSalaryText" />
                            :</asp:Label>
                        <div>
                            <asp:TextBox ID="txtSalaryText" runat="server" ClientIDMode="Static" />
                        </div>
                    </li>
                    <li class="form-line" id="jobs-showsalarydetails-field">
                        <asp:Label ID="lbShowSalaryDetails" runat="server" AssociatedControlID="chkShowSalaryDetails">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldShowSalaryDetail" runat="server" SetLanguageCode="LabelShowSalaryDetail" />
                            :</asp:Label>
                        <div>
                            <asp:CheckBox ID="chkShowSalaryDetails" runat="server" ClientIDMode="Static" />
                        </div>
                    </li>
                    <h3>
                        <JXTControl:ucLanguageLiteral ID="ltProfessionRoleDetails" runat="server" SetLanguageCode="LabelProfessionRoleDetails" />
                        <!-- Profession/Role Details -->
                    </h3>
                    <asp:UpdatePanel ID="updatePanel1" runat="server">
                        <ContentTemplate>
                            <li class="form-line" id="jobs-profession-roles">
                                <asp:Label ID="lbProfession" runat="server" AssociatedControlID="ddlProfession1">
                                    <JXTControl:ucLanguageLiteral ID="ltProfessionRole" runat="server" SetLanguageCode="LabelProfessionRole" />
                                    <!-- Profession / Role-->
                                    <span class="form-required">*</span></asp:Label>
                                <div class="row">
                                    <div class="col-md-6 halfBlock">
                                        <asp:DropDownList ID="ddlProfession1" runat="server" AutoPostBack="true" CssClass="form-control"
                                            OnSelectedIndexChanged="ddlProfession1_SelectedIndexChanged" />
                                    </div>
                                    <div class="col-md-6 halfBlock">
                                        <asp:DropDownList ID="ddlRole1" runat="server" CssClass="form-control" />
                                        <asp:RequiredFieldValidator ID="ReqVal_Role1" runat="server" ControlToValidate="ddlRole1"
                                            InitialValue="0" SetFocusOnError="true" Display="Dynamic" />
                                    </div>
                                </div>
                                <asp:PlaceHolder ID="plClassifications" runat="server">
                                    <div class="row">
                                        <div class="col-md-6 halfBlock">
                                            <asp:DropDownList ID="ddlProfession2" runat="server" AutoPostBack="true" CssClass="form-control"
                                                OnSelectedIndexChanged="ddlProfession2_SelectedIndexChanged" />
                                        </div>
                                        <div class="col-md-6 halfBlock">
                                            <asp:DropDownList ID="ddlRole2" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6 halfBlock">
                                            <asp:DropDownList ID="ddlProfession3" runat="server" AutoPostBack="true" CssClass="form-control"
                                                OnSelectedIndexChanged="ddlProfession3_SelectedIndexChanged" />
                                        </div>
                                        <div class="col-md-6 halfBlock">
                                            <asp:DropDownList ID="ddlRole3" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                </asp:PlaceHolder>
                            </li>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <h3>
                        <JXTControl:ucLanguageLiteral ID="ltJobWorkType" runat="server" SetLanguageCode="LabelJobWorktype" />
                        <!-- Job Worktype -->
                    </h3>
                    <li class="form-line" id="jobs-jobitemtype-field">
                        <asp:Label ID="lbWorkType" runat="server" AssociatedControlID="ddlWorkType">
                            <JXTControl:ucLanguageLiteral ID="ltWorktype" runat="server" SetLanguageCode="LabelWorktype" />
                            <!-- Worktype-->
                            <span class="form-required">*</span></asp:label>
                            <div>
                                <asp:DropDownList runat="server" ID="ddlWorkType" DataTextField="SiteWorkTypeName"
                                    DataValueField="WorkTypeID" CssClass="form-multiple-column" />
                                <asp:RequiredFieldValidator ID="ReqVal_WorkType" runat="server" InitialValue="0"
                                    ControlToValidate="ddlWorkType" SetFocusOnError="true" Display="Dynamic" />
                            </div>
                    </li>
                    <h3>
                        <JXTControl:ucLanguageLiteral ID="ltJobApplicationDetails" runat="server" SetLanguageCode="LabelJobApplicationDetails" />
                        <!-- Job Application Details -->
                    </h3>
                    <li class="form-line" id="jobs-jobname-field">
                        <asp:Label ID="lbApplicationEmail" runat="server" AssociatedControlID="txtApplicationEmailAddress">
                            <JXTControl:ucLanguageLiteral ID="ltApplicationEmail" runat="server" SetLanguageCode="LabelApplicationEmail" />
                            <!-- Application email -->
                            <span class="form-required">*</span></asp:Label>
                            <div>
                                <asp:TextBox ID="txtApplicationEmailAddress" runat="server" />
                                <asp:RequiredFieldValidator ID="ReqVal_ApplicationEmailAddress" runat="server" ControlToValidate="txtApplicationEmailAddress"
                                    SetFocusOnError="true" Display="Dynamic" />
                                <asp:RegularExpressionValidator ID="revEmailAddress" runat="server" ControlToValidate="txtApplicationEmailAddress"
                                    SetFocusOnError="true" Display="Dynamic" ErrorMessage="Invalid email address"
                                    ValidationExpression="^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$">  
                                </asp:RegularExpressionValidator>
                            </div>
                            <p class="help-block">
                                <JXTControl:ucLanguageLiteral ID="ltAllApplicationsSendEmail" runat="server" SetLanguageCode="LabelAllApplicationsSendEmail" />
                                <!-- All applications for job will be sent to this email address -->
                            </p>
                    </li>
                    <asp:UpdatePanel ID="updatePanelapplicationmethod" runat="server">
                        <ContentTemplate>
                            <li class="form-line" id="jobs-applicationmethod-field">
                                <asp:Label ID="lbApplicationMethod" runat="server" AssociatedControlID="ddlApplicationMethod">
                                    <JXTControl:ucLanguageLiteral ID="ltApplicationMethod" runat="server" SetLanguageCode="LabelApplicationMethod" />
                                    <!-- Application method-->
                                    <span class="form-required">*</span></asp:Label>
                                <div>
                                    <asp:DropDownList runat="server" ID="ddlApplicationMethod" CssClass="form-control"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlApplicationMethod_SelectedIndexChanged" />
                                </div>
                            </li>
                            <li class="form-line" id="jobs-applicationurl-field">
                                <asp:Label ID="lbApplicationURL" runat="server" AssociatedControlID="txtApplicationURL">
                                    <JXTControl:ucLanguageLiteral ID="ltApplicationURL" runat="server" SetLanguageCode="LabelApplicationURL" />
                                    <!-- Application URL-->
                                </asp:Label>
                                <div>
                                    <asp:TextBox ID="txtApplicationURL" runat="server" CssClass="form-control" Enabled="false"
                                        placeholder="http://" />
                                    <asp:CustomValidator ID="ctmApplicationMethod" runat="server" Display="Dynamic" OnServerValidate="ctmApplicationMethod_ServerValidate"
                                        SetFocusOnError="true" />
                                </div>
                            </li>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <h3>
                        <JXTControl:ucLanguageLiteral ID="ltJobContactDetails" runat="server" SetLanguageCode="LabelJobContactDetails" />
                        <!--Job Contact Details-->
                    </h3>
                    <li class="form-line" id="jobs-jobname-field">
                        <asp:Label ID="lbFullName" runat="server" AssociatedControlID="txtJobContactName">
                            <JXTControl:ucLanguageLiteral ID="ltFullName" runat="server" SetLanguageCode="LabelFullName" />
                            <!--Full name-->
                        </asp:Label>
                        <div>
                            <asp:TextBox ID="txtJobContactName" runat="server" AutoCompleteType="None" />
                        </div>
                    </li>
                    <li class="form-line" id="jobs-jobname-field">
                        <asp:Label ID="lbEmail" runat="server" AssociatedControlID="txtContactDetails">
                            <JXTControl:ucLanguageLiteral ID="ltEmail" runat="server" SetLanguageCode="LabelEmail" />
                            <span class="form-required">*</span></asp:Label>
                        <div>
                            <asp:TextBox ID="txtContactDetails" runat="server" autocomplete="off" />
                            <asp:RequiredFieldValidator ID="ReqVal_ContactDetails" runat="server" InitialValue=""
                                ControlToValidate="txtContactDetails" SetFocusOnError="true" Display="Dynamic" />
                        </div>
                    </li>
                    <li class="form-line" id="jobs-jobname-field">
                        <asp:Label ID="lbPhone" runat="server" AssociatedControlID="txtJobContactPhone">
                            <JXTControl:ucLanguageLiteral ID="ltPhone" runat="server" SetLanguageCode="LabelPhone" />
                        </asp:Label>
                        <div>
                            <asp:TextBox ID="txtJobContactPhone" runat="server" autocomplete="off" />
                        </div>
                    </li>
                    <h3>
                        <JXTControl:ucLanguageLiteral ID="ltJobTemplateSettings" runat="server" SetLanguageCode="LabelJobTemplateSettings" />
                        <!-- Job Template Settings -->
                    </h3>
                    <li class="form-line" id="jobs-jobitemtype-field">
                        <asp:Label ID="lbAdvertiserJobTemplateLogo" runat="server" AssociatedControlID="ddlAdvertiserJobTemplateLogo">
                            <JXTControl:ucLanguageLiteral ID="ltJobTemplateLogo" runat="server" SetLanguageCode="LabelJobTemplateLogo" />
                            <!-- Job Template logo -->
                        </asp:Label>
                        <div>
                            <asp:DropDownList runat="server" ID="ddlAdvertiserJobTemplateLogo" DataTextField="JobLogoName"
                                DataValueField="AdvertiserJobTemplateLogoID" CssClass="form-multiple-column" />
                        </div>
                        <asp:LinkButton ID="btnNewJobLogo" runat="server" Text="Upload New Logo" CausesValidation="false"
                            CssClass="btn btn-default mini-new-buttons" OnClientClick="NewLogoClicked(); return false;" />
                        <br />
                        <br />
                    </li>
                    <li id="liNewJobLogoTitle" style="display: none;">
                        <asp:Label ID="lbJobLogoName" runat="server" AssociatedControlID="tbJobLogoName">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral5" runat="server" SetLanguageCode="LabelAdvertiserJobTemplateLogoName" />
                            :<span class="form-required">*</span></asp:Label>
                        <div>
                            <asp:TextBox runat="server" ID="tbJobLogoName" DataTextField="JobLogoName" DataValueField="AdvertiserJobTemplateLogoID" />
                            <asp:RequiredFieldValidator ID="rfvAdvJobTemplateLogoName" runat="server" ControlToValidate="tbJobLogoName"
                                SetFocusOnError="true" Display="Dynamic" Enabled="false"></asp:RequiredFieldValidator>
                            <asp:CustomValidator ID="cvalFileName" runat="server" OnServerValidate="cvalFileName_ServerValidate"
                                SetFocusOnError="true" Display="Dynamic"></asp:CustomValidator>
                        </div>
                    </li>
                    <li class="form-line" id="liNewJobLogoFileTitle" style="display: none;">
                        <asp:Label ID="lbUploadFile" runat="server" AssociatedControlID="docInput">
                            <JXTControl:ucLanguageLiteral ID="ltUploadFile" runat="server" SetLanguageCode="LabelUploadFile" />
                            <!-- Upload file -->
                            </asp:Label>
                            <div>
                                <asp:FileUpload ID="docInput" runat="server" />&nbsp;
                                <asp:RequiredFieldValidator ID="rfvAdvJobTemplateLogoImage" runat="server" ControlToValidate="docInput"
                                    SetFocusOnError="true" Display="Dynamic" Enabled="false"></asp:RequiredFieldValidator>
                                <asp:CustomValidator ID="cvalFile" runat="server" OnServerValidate="cvalFile_ServerValidate"
                                    SetFocusOnError="true" Display="Dynamic"></asp:CustomValidator>
                                <asp:LinkButton ID="LinkButton1" runat="server" Text="Cancel" CausesValidation="false"
                                    OnClientClick="CancelNewLogoClicked(); return false;" />
                            </div>
                            <br />
                            <br />
                    </li>
                    <li class="form-line" id="jobs-jobtemplateid-field">
                        <asp:Label ID="lbJobTemplate" runat="server" AssociatedControlID="ddlJobTemplateID">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelSelectJobTemplate" />
                            <!-- Select Job Template-->
                            <span class="form-required">*</span></asp:Label>
                        <div>
                            <asp:DropDownList runat="server" ID="ddlJobTemplateID" DataTextField="JobTemplateDescription"
                                DataValueField="JobTemplateID" CssClass="form-multiple-column" />
                            <asp:RequiredFieldValidator ID="ReqValJobTemplate" runat="server" ControlToValidate="ddlJobTemplateID"
                                SetFocusOnError="true" Display="Dynamic" />
                            <br />
                            <asp:Image ID="imgAdvJobTemplate" runat="server" />
                        </div>
                    </li>
                    <asp:PlaceHolder ID="pnlJobItem" runat="server">
                        <li>
                            <div class="form-header-group">
                                <h2 class="form-header">
                                    <JXTControl:ucLanguageLiteral ID="ltJobFieldHeaderJobItems" runat="server" SetLanguageCode="LabelJobItem" />
                                </h2>
                            </div>
                        </li>
                        <li class="form-line" id="jobs-jobitemprice-field">
                            <asp:Label ID="lbJobItemPrice" runat="server" AssociatedControlID="txtJobItemPrice">
                                <JXTControl:ucLanguageLiteral ID="ltJobFieldJobItemPrice" runat="server" SetLanguageCode="LabelJobItemPrice" />
                                :<span class="form-required">*</span></asp:Label>
                            <div>
                                <asp:TextBox ID="txtJobItemPrice" runat="server" />
                                <asp:RequiredFieldValidator ID="ReqVal_JobItemPrice" runat="server" ControlToValidate="txtJobItemPrice"
                                    SetFocusOnError="true" Display="Dynamic" />
                                <asp:RangeValidator ID="RangeVal_JobItemPrice" runat="server" MinimumValue="1" MaximumValue="9999"
                                    Type="Double" ControlToValidate="txtJobItemPrice" SetFocusOnError="true" Display="Dynamic" />
                            </div>
                        </li>
                    </asp:PlaceHolder>
                    <h3>
                        <JXTControl:ucLanguageLiteral ID="ltJobAdvertisementOption" runat="server" SetLanguageCode="LabelJobAdvertisementOption" />
                        <!--Job Advertisement Option-->
                    </h3>
                    <li class="form-line" id="jobs-qualificationsrecognised-field">
                        <asp:Label ID="lbQualificationsRecognised" runat="server" AssociatedControlID="chkQualificationsRecognised">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldQualificationsRecognised" runat="server"
                                SetLanguageCode="LabelQualificationsRecognised" />
                            :</asp:Label>
                        <div>
                            <asp:CheckBox ID="chkQualificationsRecognised" runat="server" />
                        </div>
                    </li>
                    <li class="form-line" id="jobs-residentonly-field">
                        <asp:Label ID="lbResidentOnly" runat="server" AssociatedControlID="chkResidentOnly">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldResidentOnly" runat="server" SetLanguageCode="LabelResidentOnly" />
                            :</asp:Label>
                        <div>
                            <asp:CheckBox ID="chkResidentOnly" runat="server" />
                        </div>
                    </li>
                    <asp:PlaceHolder ID="phLastmodifiedByAdmin" runat="server">
                        <li class="form-line" id="jobs-lastmodifiedbyadminuserid-field">
                            <asp:Label ID="lbLastModifiedByAdminUser" runat="server" AssociatedControlID="lblLastModifiedByAdminUserId">
                                <JXTControl:ucLanguageLiteral ID="ltJobFieldLastModifiedByAdminUser" runat="server"
                                    SetLanguageCode="LabelLastModifiedByAdminUser" />
                                :</asp:Label>
                            <div>
                                <asp:Label ID="lblLastModifiedByAdminUserId" runat="server" />
                            </div>
                        </li>
                    </asp:PlaceHolder>
                    <li class="form-line" id="jobs-expiried-field">
                        <asp:Label ID="lbExpired" runat="server" AssociatedControlID="chkJobExpired">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldExpired" runat="server" SetLanguageCode="LabelExpired" />
                            :</asp:Label>
                        <div>
                            <asp:CheckBox ID="chkJobExpired" runat="server" />
                        </div>
                    </li>
                    <asp:PlaceHolder ID="phStatusAction" runat="server">
                        <li class="form-line" id="jobs-status-field">
                            <asp:Label ID="lbStatus" runat="server" AssociatedControlID="ddlStatus">
                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral2" runat="server" SetLanguageCode="LabelStatus" />
                                :</asp:Label>
                            <div>
                                <asp:DropDownList ID="ddlStatus" runat="server" />
                            </div>
                        </li>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="phPostedDates" runat="server">
                        <li class="form-line" id="jobs-dateposted-field">
                            <hr />
                            <asp:Label ID="lbDatePosted" runat="server" AssociatedControlID="lblDatePosted">
                                <JXTControl:ucLanguageLiteral ID="ltJobFieldDatePosted" runat="server" SetLanguageCode="LabelDatePosted" />
                                :</asp:Label>
                            <div>
                                <asp:Label ID="lblDatePosted" runat="server" />
                            </div>
                        </li>
                        <li class="form-line" id="jobs-expirydate-field">
                            <asp:Label ID="lbExpiryDate" runat="server" AssociatedControlID="lblExpiryDate">
                                <JXTControl:ucLanguageLiteral ID="ltJobFieldExpiryDate" runat="server" SetLanguageCode="LabelExpiryDate" />
                                :</asp:Label>
                            <div>
                                <asp:Label ID="lblExpiryDate" runat="server" />
                            </div>
                        </li>
                        <li class="form-line" id="jobs-lastmodified-field">
                            <asp:Label ID="lbLastModified" runat="server" AssociatedControlID="lblLastModified">
                                <JXTControl:ucLanguageLiteral ID="ltJobFieldLastModified" runat="server" SetLanguageCode="LabelLastModified" />
                                :</asp:Label>
                            <div>
                                <asp:Label ID="lblLastModified" runat="server" />
                            </div>
                        </li>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="phPostedBy" runat="server">
                        <li class="form-line" id="jobs-postedby">
                            <asp:Label ID="lbPostedByAdvertiserUser" runat="server" AssociatedControlID="lblPostedByAdvertiserUser">
                                <JXTControl:ucLanguageLiteral ID="ltJobFieldpostedBy" runat="server" SetLanguageCode="lblPostedByAdvertiserUser" />
                                :</asp:Label>
                            <div>
                                <asp:Label ID="lblPostedByAdvertiserUser" runat="server" />
                            </div>
                        </li>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="phlastmodifiedByAdvuserID" runat="server">
                        <li class="form-line" id="jobs-lastmodifiedbyadvertiseruserid-field">
                            <asp:label id="lbLastModifiedByAdvertiserUser" runat="server" associatedcontrolid="lblLastModifiedByAdvertiserUserId">
                                <JXTControl:ucLanguageLiteral ID="ltJobFieldLastModifiedByAdvertiserUser" runat="server"
                                    SetLanguageCode="LabelLastModifiedByAdvertiserUser" />
                                :</asp:label>
                            <div>
                                <asp:Label ID="lblLastModifiedByAdvertiserUserId" runat="server" />
                            </div>
                        </li>
                    </asp:PlaceHolder>
                    <li class="form-line" id="reg-bottom-button">
                        <hr />
                        <div class="form-input-wide">
                            <div class="form-buttons-wrapper">
                                <asp:Button ID="CancelButton" runat="server" CausesValidation="False" Text="Cancel"
                                    CssClass="mini-new-buttons" OnClick="CancelButton_Click" />
                                <asp:Button ID="InsertButton" runat="server" CausesValidation="True" Text="Save Job"
                                    CssClass="mini-new-buttons" OnClick="InsertButton_Click" OnClientClick="MultiLingualCheck()" />
                                <asp:Button ID="UpdateButton" runat="server" CausesValidation="True" Text="Update"
                                    CssClass="mini-new-buttons" OnClick="UpdateButton_Click" OnClientClick="MultiLingualCheck()" />
                                <asp:Button ID="DraftButton" runat="server" CausesValidation="True" Text="Save as draft"
                                    CssClass="mini-new-buttons" OnClick="DraftButton_Click" OnClientClick="MultiLingualCheck()" />
                            </div>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</div>
<%
        if (string.IsNullOrEmpty(MapKey))
        {
%>
<script type="text/javascript" src="//maps.google.com/maps/api/js?sensor=false&v=3.exp&signed_in=true&libraries=places"></script>
<%
        }
        else
        {
%>
<script type="text/javascript" src="//maps.google.com/maps/api/js?key=<%=MapKey %>&sensor=false&v=3.exp&signed_in=true&libraries=places"></script>
<%
        }
%>

<script type='text/javascript'>

    //Google Map Variable
    var gMap, gMapMarker;
    var geocoder = new google.maps.Geocoder();

    var FriendlyUrlValue = $('#<%= txtFriendlyUrl.ClientID %>').val().toLowerCase();

     function NewLogoClicked() {
        $('#hfFileCheck').val("1");
        var validator = document.getElementById("<%=rfvAdvJobTemplateLogoName.ClientID %>");
        ValidatorEnable(validator, true);
        validator = document.getElementById("<%=cvalFileName.ClientID %>");
        ValidatorEnable(validator, true);
        validator = document.getElementById("<%=rfvAdvJobTemplateLogoImage.ClientID %>");
        ValidatorEnable(validator, true);
        validator = document.getElementById("<%=cvalFile.ClientID %>");
        ValidatorEnable(validator, true);

        $('#jobs-advertiserjobtemplatelogoid-field').hide();
        $('#liNewJobLogoTitle').show();
        $('#liNewJobLogoFileTitle').show();

        $("#<%=rfvAdvJobTemplateLogoName.ClientID %>").hide();
        $("#<%=cvalFileName.ClientID %>").hide();
        $("#<%=rfvAdvJobTemplateLogoImage.ClientID %>").hide();
        $("#<%=cvalFile.ClientID %>").hide();

        if ($('#hfFileError').val() != "") {
            $('#' + $('#hfFileError').val()).show();
        }


    } 

    function CancelNewLogoClicked() {
        $('#hfFileCheck').val("");
        var validator = document.getElementById("<%=rfvAdvJobTemplateLogoName.ClientID %>");
        ValidatorEnable(validator, false);
        validator = document.getElementById("<%=cvalFileName.ClientID %>");
        ValidatorEnable(validator, false);
        validator = document.getElementById("<%=rfvAdvJobTemplateLogoImage.ClientID %>");
        ValidatorEnable(validator, false);
        validator = document.getElementById("<%=cvalFile.ClientID %>");
        ValidatorEnable(validator, false);

        $('#jobs-advertiserjobtemplatelogoid-field').show();
        $('#liNewJobLogoTitle').hide();
        $('#liNewJobLogoFileTitle').hide();

        $("#<%=rfvAdvJobTemplateLogoName.ClientID %>").hide();
        $("#<%=cvalFileName.ClientID %>").hide();
        $("#<%=rfvAdvJobTemplateLogoImage.ClientID %>").hide();
        $("#<%=cvalFile.ClientID %>").hide();


    }

    function checkFriendlyUrlChanged() {
        if ($("#<%= txtFriendlyUrl.ClientID %>").attr("disabled")) {
            return;
        }
        else {
            var currentValue = $('#<%= txtFriendlyUrl.ClientID %>').val().toLowerCase();

            FriendlyUrlValue = currentValue;
            FriendlyUrlValue = $('#<%=DefaultLangJobNameID %>').val().toLowerCase();

            FriendlyUrlValue = FriendlyUrlValue.replace("+", "plus").replace("?", "").replace("&", "and").replace("'", "-").replace(/  +/g, "-").replace(/[\W]/gi, "-").replace(/[-]+/gi, "-");

            if (FriendlyUrlValue.substring(FriendlyUrlValue.length - 1, FriendlyUrlValue.length) == '-')
                FriendlyUrlValue = FriendlyUrlValue.substring(0, FriendlyUrlValue.length - 1);

            $("#<%= txtFriendlyUrl.ClientID %>").val(FriendlyUrlValue);
        }
    }

    function initializeGoogleMap() {
        var options = {
            zoom: 1,
            center: new google.maps.LatLng(-25.2743980,133.7751360),
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        gMap = new google.maps.Map(document.getElementById('map'), options);
    }

    function RemoveGMapMarker()
    {
        if( gMapMarker != null )
        {
            gMapMarker.setMap(null);
            gMapMarker = null;
        }
    }

    function UpdateMapPin()
    {
        RemoveGMapMarker();

        if( $("#hfAddressLat").val().length == 0 || $("#hfAddressLng").val().length == 0 )
        {
            gMap.setCenter(new google.maps.LatLng(-25.2743980,133.7751360));
            gMap.setZoom(1);
        }
        else
        {
            var targetPin = new google.maps.LatLng($("#hfAddressLat").val(), $("#hfAddressLng").val());
            //put marker to map
            gMapMarker = new google.maps.Marker({
                position: new google.maps.LatLng($("#hfAddressLat").val(), $("#hfAddressLng").val()),
                map: gMap,
                draggable: true
            });
            gMap.setCenter(targetPin);
            gMap.setZoom(15);

            // Add drag end event listener  
            google.maps.event.addListener(gMapMarker, 'dragend', function() {
                GeocodePositionForMarker(gMapMarker.getPosition());
            });

        }
    }

    function GeocodePositionForMarker(pos) {
        geocoder.geocode({
            latLng: pos
        }, function(responses) {
            if (responses && responses.length > 0) {
                $("#txtAddress").val(responses[0].formatted_address);
                
                $("#hfAddressLat").val(responses[0].geometry.location.lat());
                $("#hfAddressLng").val(responses[0].geometry.location.lng());

            } else {
                $("#txtAddress").val("");
                $("#hfAddressLat").val("");
                $("#hfAddressLng").val("");
            }
        });
    }

    $(document).ready(function () {

         if ($('#hfFileError').val() != "") {
            NewLogoClicked();
            $('html, body').animate({
                scrollTop: $("#<%= tbJobLogoName.ClientID %>").offset().top
            }, 0);
        }

        $("#<%= ddlJobTemplateID.ClientID %>").change(function () {
            var id = $("#<%= ddlJobTemplateID.ClientID %>").val();
            if (id != "0" && id != "") {
                $("#<%= imgAdvJobTemplate.ClientID %>").attr("src", '/getfile.aspx?jobtemplateid=' + id);

                $("#<%= imgAdvJobTemplate.ClientID %>").attr("style", "display:block");
            }
            else {
                $("#<%= imgAdvJobTemplate.ClientID %>").attr("src", '');
                $("#<%= imgAdvJobTemplate.ClientID %>").attr("style", "display:none");
            }
        }); 


        // Decimal value valiation
        $('#txtSalaryLowerBand, #txtSalaryUpperBand').keyup(function () {
            this.value = this.value.replace(/[^0-9\.]/g, '');
        });

        // ** Job Alert - Salary
        $('#txtSalaryLowerBand').prop('disabled', (($('#ddlSalary').val() == 0 || $('#ddlSalary').val() == 3)? true : false));
        $('#txtSalaryUpperBand').prop('disabled', (($('#ddlSalary').val() == 0 || $('#ddlSalary').val() == 3) ? true : false));


        SalaryChange();
        $('#ddlSalary').change(function () {

            SalaryChange();
            $("#txtSalaryLowerBand").focus();
        });

        // Create the autocomplete object, restricting the search to geographical location types.
        var placeSearch, autocomplete;
        autocomplete = new google.maps.places.Autocomplete((document.getElementById('txtAddress')), { types: ['geocode'] });

        // When the user selects an address from the dropdown,
        // populate the address fields in the form.
        google.maps.event.addListener(autocomplete, 'place_changed', function () {
            var place = autocomplete.getPlace();

            var lat, lng;

            if( place.geometry == null ) //location not found
            {
                lat = "";
                lng = "";
            }
            else
            {
                lat = place.geometry.location.lat();
                lng = place.geometry.location.lng();
            }
            
            $("#hfAddressLat").val(lat);
            $("#hfAddressLng").val(lng);

            //update map pin
            UpdateMapPin();            
        });

        $("#txtAddress").on("keydown", function (e) {

            if (e.keyCode == 13) {
                return false;
            }

            $("#hfAddressLat").val("");
            $("#hfAddressLng").val("");
        });

        //init google map
        initializeGoogleMap();


        <% if (HasAddressInputValue)
        { 

            if( HasLatLngInputValues )
            {
            %>
                UpdateMapPin();
            <%
            }
            else
            {
        %>
                //init: Get address geocode if needed
                geocoder.geocode({ "address": $("#txtAddress").val() }, function (results, status) {
                    if (status == google.maps.GeocoderStatus.OK) {

                        var centerPoint_lat = results[0].geometry.location.lat(),
                            centerPoint_lng = results[0].geometry.location.lng();

                        $("#hfAddressLat").val(centerPoint_lat);
                        $("#hfAddressLng").val(centerPoint_lng);

                        UpdateMapPin();
                    } 
                });
        <% 
            }
        } 
        %>
    });

    function SalaryChange() {

        $('#txtSalaryLowerBand').prop('disabled', (($('#ddlSalary').val() == 0 || $('#ddlSalary').val() == 3) ? true : false));
        $('#txtSalaryUpperBand').prop('disabled', (($('#ddlSalary').val() == 0 || $('#ddlSalary').val() == 3) ? true : false));

        if ($('#ddlSalary').val() == 3) {
            $('#chkShowSalaryRange').prop('checked', false);
            $('#chkShowSalaryRange').prop('disabled', true);
            // $('#txtSalaryText').val('');
            // $('#txtSalaryText').prop('disabled', true);
            $('#chkShowSalaryDetails').prop('checked', false);
            $('#chkShowSalaryDetails').prop('disabled', true);


        }
        else {
            $('#chkShowSalaryRange').prop('disabled', false);
            // $('#txtSalaryText').prop('disabled', false);
            $('#chkShowSalaryDetails').prop('disabled', false);
        }

    }

    function JobItemTypeChanged() {
        if ($('#ddlJobItemType').val() == '3') {
            $('#jobs-profession-role-2').hide();
            $('#jobs-profession-role-3').hide();
        }
        else {
            $('#jobs-profession-role-2').show();
            $('#jobs-profession-role-3').show();
        }
    }    
</script>
