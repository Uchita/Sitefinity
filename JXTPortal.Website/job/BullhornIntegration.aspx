<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BullhornIntegration.aspx.cs"
    Inherits="JXTPortal.Website.job.BullhornIntegration" %>

<%@ Register Src="/usercontrols/common/ucLanguageLiteral.ascx" TagName="ucLanguageLiteral"
    TagPrefix="JXTControl" %>
<%@ Register TagPrefix="uc1" Namespace="JXTPortal.Website.usercontrols.common" Assembly="JXTPortal.WebSite" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">
    <link rel="stylesheet" href="/styles/bootstrap-datepicker.min.css" />
    <!-- Latest compiled and minified JavaScript -->
    <script type="text/javascript" src="/admin/js/jquery.js"></script>
    <script type="text/javascript" src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
    <script src="/scripts/bootstrap-datepicker/js/bootstrap-datepicker.js" type="text/javascript"></script>
    <asp:Literal runat="server" ID="ltGoogleMapJSHeader"></asp:Literal>
</head>
<body id="topper">
    <input type="text" id="tempInput" style="opacity: 0;" />
    <div class="col-xs-6">
        <asp:PlaceHolder ID="plEndFormMessage" runat="server" Visible="false">
            <div id="submitMessages" class="alert alert-success">
                <asp:Literal ID="ltFormMessage" runat="server" Visible="false"></asp:Literal>
                <asp:Literal ID="ltJobLiveMessage" runat="server" Visible="false">This job is currently LIVE on the job board.</asp:Literal>
            </div>
        </asp:PlaceHolder>
    </div>
    <div class="clearfix">
    </div>
    <div class="col-xs-6">
        <asp:PlaceHolder runat="server" ID="phInvalidAccountTypeMessage" Visible="false">
            <p>
                <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
            </p>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="ExpiredArchivedDisplay" Visible="false">
            <h4>
                This job is now expired</h4>
            <div class="form-group" id="Div1">
                <label class="form-label-left">
                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral3" runat="server" SetLanguageCode="LabelJobName" />
                    :</label>
                <div class="form-input">
                    <asp:Literal ID="expiredTitle" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="form-group" id="Div2">
                <label class="form-label-left">
                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral8" runat="server" SetLanguageCode="LabelFullDescription" />
                    :</label>
                <div class="form-input">
                    <asp:Literal ID="expiredDescription" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="form-group" id="Div3">
                <label class="form-label-left">
                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral9" runat="server" SetLanguageCode="LabelDatePosted" />
                    :</label>
                <div class="form-input">
                    <asp:Literal ID="expiredDatePosted" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="form-group" id="Div4">
                <label class="form-label-left">
                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral10" runat="server" SetLanguageCode="LabelExpired" />
                    :</label>
                <div class="form-input">
                    <asp:Literal ID="expiredDateExpired" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="form-group" id="Div7">
                <label class="form-label-left">
                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral13" runat="server" SetLanguageCode="LabelExpired" />
                    :</label>
                <div class="form-input">
                    <asp:Literal ID="expiredChkBoxExpired" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="form-group" id="Div5">
                <label class="form-label-left">
                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral11" runat="server" SetLanguageCode="LabelLastModified" />
                    :</label>
                <div class="form-input">
                    <asp:Literal ID="expiredLastModified" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="form-group" id="Div6">
                <label class="form-label-left">
                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral12" runat="server" SetLanguageCode="lblPostedByAdvertiserUser" />
                    :</label>
                <div class="form-input">
                    <asp:Literal ID="expiredPostedBy" runat="server"></asp:Literal>
                </div>
            </div>
        </asp:PlaceHolder>
        <form id="formJobFields" runat="server" visible="false">
        <asp:HiddenField ID="hfFileCheck" runat="server" Value="" ClientIDMode="Static" />
        <asp:HiddenField ID="hfFileError" runat="server" Value="" ClientIDMode="Static" />
        <asp:ScriptManager ID="scriptManager" runat="server" />
        <div class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" />
            <asp:CustomValidator ID="CusValJobProfessionRole" runat="server" Display="Dynamic"
                OnServerValidate="CusValJobProfessionRole_ServerValidate" SetFocusOnError="true" />
        </div>
        <div class="form-header-group">
            <h3 class="form-header">
                <JXTControl:ucLanguageLiteral ID="ltJobFieldHeaderJobDescription" runat="server"
                    SetLanguageCode="LabelJobDescription" />
            </h3>
        </div>
        <asp:Panel ID="pnlAdvertiser" runat="server">
            <div class="form-group" id="jobs-advertiser-field">
                <label class="form-label-left">
                    <JXTControl:ucLanguageLiteral ID="ltAdvertiser" runat="server" SetLanguageCode="LabelAdvertiser" />
                    :<span class="form-required">*</span></label>
                <div class="form-input">
                    <asp:Literal ID="advertiserNameDisplay" runat="server"></asp:Literal>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlAdvertiserUser" runat="server">
            <div class="form-group" id="jobs-advertiseruser-field">
                <label class="form-label-left">
                    <%--<JXTControl:ucLanguageLiteral ID="ltAdvertiserUser" runat="server" SetLanguageCode="LabelAssignedJobTo" />--%>
                    Advertiser Company:<span class="form-required">*</span></label>
                <div class="form-input">
                    <asp:Label ID="lblusername" runat="server" />
                </div>
            </div>
        </asp:Panel>
        <div class="form-line" id="jobs-companyname-field">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ltCompanyName" runat="server" SetLanguageCode="LabelCompanyName" />
                :</label>
            <div class="form-input">
                <asp:TextBox ID="txtCompanyName" runat="server" class="form-control" />
            </div>
        </div>
        <div>
            <asp:UpdatePanel ID="upJobItemType" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="form-group" id="jobs-jobitemtype-field">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral4" runat="server" SetLanguageCode="LabelJobItemType" />
                            :<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:DropDownList runat="server" ID="ddlJobItemType" CssClass="form-multiple-column form-control"
                                ClientIDMode="Static" AutoPostBack="True" OnSelectedIndexChanged="ddlJobItemType_SelectedIndexChanged" />
                            <asp:PlaceHolder ID="phNoJobCredit" runat="server" Visible="false"><span id="ctl00_ContentPlaceHolder1_ucJobFields_ReqVal_JobName"
                                style="color: red; display: inline;">
                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral6" runat="server" SetLanguageCode="LabelNoJobCredit" />
                            </span></asp:PlaceHolder>
                        </div>
                        <asp:PlaceHolder ID="phInfo" runat="server" Visible="false"><small class="help-block">
                            Please note: Premium jobs will be displayed at the top of the specified classification
                            when searched.</small> </asp:PlaceHolder>
                    </div>
                    <asp:PlaceHolder ID="phJobStartDate" runat="server" Visible="false">
                        <div class="form-group" id="Li3">
                            <label class="form-label-left">
                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral7" runat="server" SetLanguageCode="LabelJobStartDate" />
                                :<span class="form-required">*</span></label>
                            <div class="form-input">
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
                        </div>
                    </asp:PlaceHolder>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="form-line" id="jobs-jobname-field">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ltJobFieldJobName" runat="server" SetLanguageCode="LabelJobName" />
                :<span class="form-required">*</span></label>
            <div class="form-input">
                <asp:TextBox ID="txtJobName" runat="server" class="form-control" />
                <asp:RequiredFieldValidator ID="ReqVal_JobName" runat="server" ControlToValidate="txtJobName"
                    SetFocusOnError="true" Display="Dynamic" />
            </div>
        </div>
        <div class="form-line" id="Li1">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ltJobFriendlyName" runat="server" SetLanguageCode="LabelJobFriendlyName" />
                :<span class="form-required">*</span></label>
            <div class="form-input">
                <asp:TextBox ID="txtFriendlyUrl" runat="server" class="form-control" />&nbsp;<a href="javascript:void(0);"
                    onclick="checkFriendlyUrlChanged()"><JXTControl:ucLanguageLiteral ID="ltGenerate"
                        runat="server" SetLanguageCode="LabelGenerate" />
                </a>
                <asp:RequiredFieldValidator ID="ReqVal_FriendlyUrl" runat="server" ControlToValidate="txtFriendlyUrl"
                    SetFocusOnError="true" Display="Dynamic" />
            </div>
        </div>
        <div class="form-line" id="jobs-refno-field">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ltJobFieldReferenceNumber" runat="server" SetLanguageCode="LabelReferenceNumber" />
                :</label>
            <div class="form-input">
                <asp:TextBox ID="txtRefNo" runat="server" class="form-control" />
            </div>
        </div>
        <div class="form-line" id="Div8">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ltExpirtyDate" runat="server" SetLanguageCode="LabelExpiryDate" />
                (<%=DateFormat %>):</label>
            <div class="form-input">
                <asp:TextBox ID="tbExpiryDate" runat="server" class="form-control" ClientIDMode="Static" />
            </div>
            <asp:CustomValidator ID="cvExpiryDate" runat="server" OnServerValidate="cvalExpiryDate_ServerValidate"
                ControlToValidate="tbExpiryDate" SetFocusOnError="true" Display="Dynamic"></asp:CustomValidator>
            <asp:RequiredFieldValidator ID="ReqVal_ExpiryDate" runat="server" ControlToValidate="tbExpiryDate"
                SetFocusOnError="true" Display="Dynamic" />
        </div>
        <div class="form-line" id="jobs-bulletpoint1-field">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ltJobFieldBulletPoint1" runat="server" SetLanguageCode="LabelBulletPoint1" />
                :</label>
            <div class="form-input">
                <asp:TextBox ID="txtBulletPoint1" runat="server" class="form-control" MaxLength="160" />
                <asp:CustomValidator ID="CusValBulletPoint1" runat="server" ControlToValidate="txtBulletPoint1"
                    SetFocusOnError="true" Display="Dynamic" OnServerValidate="CusValBulletPoint1_ServerValidate" />
            </div>
        </div>
        <div class="form-line" id="jobs-bulletpoint2-field">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ltJobFieldBulletPoint2" runat="server" SetLanguageCode="LabelBulletPoint2" />
                :</label>
            <div class="form-input">
                <asp:TextBox ID="txtBulletPoint2" runat="server" class="form-control" MaxLength="160" />
                <asp:CustomValidator ID="CusValBulletPoint2" runat="server" ControlToValidate="txtBulletPoint2"
                    SetFocusOnError="true" Display="Dynamic" OnServerValidate="CusValBulletPoint2_ServerValidate" />
            </div>
        </div>
        <div class="form-line" id="jobs-bulletpoint3-field">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ltJobFieldBulletPoint3" runat="server" SetLanguageCode="LabelBulletPoint3" />
                :</label>
            <div class="form-input">
                <asp:TextBox ID="txtBulletPoint3" runat="server" class="form-control" MaxLength="160" />
                <asp:CustomValidator ID="CusValBulletPoint3" runat="server" ControlToValidate="txtBulletPoint3"
                    SetFocusOnError="true" Display="Dynamic" OnServerValidate="CusValBulletPoint3_ServerValidate" />
            </div>
        </div>
        <div class="form-group" id="jobs-worktype-field">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ltJobFieldWorkType" runat="server" SetLanguageCode="LabelWorkType" />
                :<span class="form-required">*</span></label>
            <div class="form-input">
                <asp:DropDownList runat="server" ID="ddlWorkType" DataTextField="SiteWorkTypeName"
                    DataValueField="WorkTypeID" CssClass="form-multiple-column form-control" />
                <asp:RequiredFieldValidator ID="ReqVal_WorkType" runat="server" InitialValue="0"
                    ControlToValidate="ddlWorkType" SetFocusOnError="true" Display="Dynamic" />
            </div>
        </div>
        <div class="form-line" id="jobs-description-field">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ltJobFieldShortDescription" runat="server" SetLanguageCode="LabelShortDescription" />
                :<span class="form-required">*</span></label>
            <div class="form-input">
                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" class="form-textarea form-control"
                    Rows="3" />
                <asp:RequiredFieldValidator ID="ReqVal_Description" runat="server" ControlToValidate="txtDescription"
                    SetFocusOnError="true" Display="Dynamic" />
            </div>
        </div>
        <div class="form-line" id="jobs-fuldescription-field">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ltJobFieldFullDescription" runat="server" SetLanguageCode="LabelFullDescription" />
                :<span class="form-required">*</span></label>
            <div class="form-input">
                <FredCK:CKEditorControl ID="txtFullDescription" runat="server" Width="650px" Height="400px"
                    CustomConfig="custom_config.js" Toolbar="SmallToolbar" EnableViewState="false">
                </FredCK:CKEditorControl>
                <asp:RequiredFieldValidator ID="rvjobFieldFullDescription" runat="server" SetFocusOnError="true"
                    Display="Dynamic" ControlToValidate="txtFullDescription" />
            </div>
        </div>
        <div class="form-line" id="jobs-tags-field">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ltJobFieldTags" runat="server" SetLanguageCode="LabelTags" />
                :</label>
            <div class="form-input">
                <asp:TextBox ID="txtTags" runat="server" class="form-control" />
            </div>
        </div>
        <div class="form-header-group">
            <h3 class="form-header">
                <JXTControl:ucLanguageLiteral ID="ltJobFieldJobLocation" runat="server" SetLanguageCode="LabelJobLocation" />
            </h3>
        </div>
        <div class="form-group" id="jobs-location-area">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ltJobFieldLocationArea" runat="server" SetLanguageCode="LabelLocationArea" />
                :<span class="form-required">*</span></label>
            <div class="form-input">
                <asp:UpdatePanel ID="updatePanel" runat="server">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    <uc1:DropDownListX ID="ddlLocation" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlLocation_SelectedIndexChanged"
                                        CssClass="form-control" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlArea" runat="server" CssClass="form-control" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="ReqVal_JobArea" runat="server" ControlToValidate="ddlArea"
                                        InitialValue="0" SetFocusOnError="true" Display="Dynamic" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="form-line" id="jobs-address-field">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ltJobFieldAddress" runat="server" SetLanguageCode="LabelAddress" />
                :</label>
            <div class="form-input">
                <asp:TextBox ID="txtAddress" runat="server" class="form-control col-xs-12" ClientIDMode="Static"
                    placeholder="" />
                <asp:HiddenField ID="hfAddressLat" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hfAddressLng" runat="server" ClientIDMode="Static" />
                <div id="map" style="width: 500px; height: 500px">
                </div>
            </div>
        </div>
        <div class="form-line" id="jobs-publictransport-field">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ltJobFieldPublicTransport" runat="server" SetLanguageCode="LabelPublicTransport" />
                :</label>
            <div class="form-input">
                <asp:TextBox ID="txtPublicTransport" runat="server" class="form-control" />
            </div>
        </div>
        <div class="form-line" id="jobs-showlocationdetails-field">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ltJobFieldShowLocationDetail" runat="server" SetLanguageCode="LabelShowLocationDetail" />
                :</label>
            <div class="form-input">
                <asp:CheckBox ID="chkShowLocationDetails" runat="server" />
            </div>
        </div>
        <div class="form-header-group">
            <h3 class="form-header">
                <JXTControl:ucLanguageLiteral ID="ltJobFieldJobSalaryDetail" runat="server" SetLanguageCode="LabelJobSalaryDetail" />
            </h3>
        </div>
        <div class="form-group" id="jobs-salary-field">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelSalary" />
                :<span class="form-required">*</span></label>
            <div class="form-input">
                <asp:DropDownList runat="server" ID="ddlSalary" DataTextField="SalaryTypeName" DataValueField="SalaryTypeID"
                    ClientIDMode="Static" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="ReqVal_Salary" runat="server" InitialValue="0" ControlToValidate="ddlSalary"
                    SetFocusOnError="true" Display="Dynamic" />
            </div>
        </div>
        <div class="form-group" id="jobs-salaryfromto-field">
            <label class="form-label-left">
            </label>
            <div class="form-input">
                <%--<asp:DropDownList ID="ddlSalaryFrom" runat="server" CssClass="form-multiple-column"
                    AutoPostBack="true" OnSelectedIndexChanged="ddlSalaryFrom_SelectedIndexChanged">
                </asp:DropDownList>--%>
                <table>
                    <tr>
                        <td>
                            <span class="divSalaryCurrency">
                                <asp:Literal ID="ltlLowerCurrency" runat="server" /></span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSalaryLowerBand" runat="server" size="10" CssClass="numbersOnly form-control"
                                ClientIDMode="Static"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;
                            <JXTControl:ucLanguageLiteral ID="litTo" runat="server" SetLanguageCode="LabelTo" />
                            &nbsp;
                        </td>
                        <td>
                            <span class="divSalaryCurrency">
                                <asp:Literal ID="ltlUpperCurrency" runat="server" /></span>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSalaryUpperBand" runat="server" size="10" CssClass="numbersOnly form-control"
                                ClientIDMode="Static"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <%--<asp:DropDownList ID="ddlSalaryTo" runat="server" CssClass="form-multiple-column">
                </asp:DropDownList>--%>
            </div>
        </div>
        <div class="form-group" id="Li2">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral2" runat="server" SetLanguageCode="LabelShowSalaryRange" />
                :</label>
            <div class="form-input">
                <asp:CheckBox ID="chkShowSalaryRange" runat="server" ClientIDMode="Static" />
            </div>
        </div>
        <div class="form-group" id="jobs-salarytext-field">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ltJobFieldSalaryText" runat="server" SetLanguageCode="LabelSalaryText" />
                :</label>
            <div class="form-input">
                <asp:TextBox ID="txtSalaryText" runat="server" class="form-control" ClientIDMode="Static" />
            </div>
        </div>
        <div class="form-group" id="jobs-showsalarydetails-field">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ltJobFieldShowSalaryDetail" runat="server" SetLanguageCode="LabelShowSalaryDetail" />
                :</label>
            <div class="form-input">
                <asp:CheckBox ID="chkShowSalaryDetails" runat="server" ClientIDMode="Static" />
            </div>
        </div>
        <asp:UpdatePanel ID="updatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <div class="form-header-group">
                        <h3 class="form-header">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldJobClassificationDetail" runat="server"
                                SetLanguageCode="LabelJobClassificationDetail" />
                        </h3>
                    </div>
                </div>
                <div class="form-group" id="jobs-profession-role-1">
                    <label class="form-label-left">
                        <JXTControl:ucLanguageLiteral ID="ltJobFieldJobProfession1" runat="server" SetLanguageCode="LabelProfession" />
                        1:<span class="form-required">*</span></label>
                    <div class="form-input">
                        <table>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlProfession1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProfession1_SelectedIndexChanged"
                                        CssClass="form-control" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlRole1" runat="server" CssClass="form-control" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:RequiredFieldValidator ID="ReqVal_Prof1" runat="server" ControlToValidate="ddlProfession1"
                                        InitialValue="0" SetFocusOnError="true" Display="Dynamic" />
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="ReqVal_Role1" runat="server" ControlToValidate="ddlRole1"
                                        InitialValue="0" SetFocusOnError="true" Display="Dynamic" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <asp:PlaceHolder ID="plClassifications" runat="server">
                    <div class="form-group" id="jobs-profession-role-2">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldJobProfession2" runat="server" SetLanguageCode="LabelProfession" />
                            2:</label>
                        <div class="form-input">
                            <table>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlProfession2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProfession2_SelectedIndexChanged"
                                            CssClass="form-control" />
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlRole2" runat="server" CssClass="form-control" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="form-group" id="jobs-profession-role-3">
                        <label class="form-label-left">
                            <JXTControl:ucLanguageLiteral ID="ltJobFieldJobProfession3" runat="server" SetLanguageCode="LabelProfession" />
                            3:</label>
                        <div class="form-input">
                            <table>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlProfession3" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProfession3_SelectedIndexChanged"
                                            CssClass="form-control" />
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlRole3" runat="server" CssClass="form-control" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </asp:PlaceHolder>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div>
            <div class="form-header-group">
                <h3 class="form-header">
                    <JXTControl:ucLanguageLiteral ID="ltJobFieldJobApplicationDetail" runat="server"
                        SetLanguageCode="LabelJobApplicationDetail" />
                </h3>
            </div>
        </div>
        <div class="form-group" id="jobs-applicationemailaddress-field">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ltJobFieldApplicationEmailAddress" runat="server"
                    SetLanguageCode="LabelApplicationEmailAddress" />
                :<span class="form-required">*</span></label>
            <div class="form-input">
                <asp:TextBox ID="txtApplicationEmailAddress" runat="server" class="form-control form-control" />
                <asp:RequiredFieldValidator ID="ReqVal_ApplicationEmailAddress" runat="server" ControlToValidate="txtApplicationEmailAddress"
                    SetFocusOnError="true" Display="Dynamic" />
                <asp:RegularExpressionValidator ID="revEmailAddress" runat="server" ControlToValidate="txtApplicationEmailAddress"
                    SetFocusOnError="true" Display="Dynamic" ErrorMessage="Invalid email address">  
                </asp:RegularExpressionValidator>
            </div>
        </div>
        <asp:UpdatePanel ID="updatePanel2" runat="server">
            <ContentTemplate>
                <div class="form-group" id="jobs-applicationmethod-field">
                    <label class="form-label-left">
                        <JXTControl:ucLanguageLiteral ID="ltJobFieldApplicationMethod" runat="server" SetLanguageCode="LabelApplicationMethod" />
                        :</label>
                    <div class="form-input">
                        <asp:DropDownList runat="server" ID="ddlApplicationMethod" class="form-dropdown form-control"
                            AutoPostBack="true" OnSelectedIndexChanged="ddlApplicationMethod_SelectedIndexChanged" />
                    </div>
                </div>
                <div class="form-group" id="jobs-applicationurl-field">
                    <label class="form-label-left">
                        <JXTControl:ucLanguageLiteral ID="ltJobFieldApplicationURL" runat="server" SetLanguageCode="LabelApplicationURL" />
                        :</label>
                    <div class="form-input">
                        <asp:TextBox ID="txtApplicationURL" runat="server" class="form-control" Enabled="false" />
                        <asp:CustomValidator ID="ctmApplicationMethod" runat="server" Display="Dynamic" OnServerValidate="ctmApplicationMethod_ServerValidate"
                            SetFocusOnError="true" />
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="form-header-group">
            <h3 class="form-header">
                <JXTControl:ucLanguageLiteral ID="ltJobFieldJobContactDetails" runat="server" SetLanguageCode="LabelJobContactDetails" />
            </h3>
        </div>
        <div class="form-line" id="jobs-contactdetails-field">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ltJobFieldContactDetails" runat="server" SetLanguageCode="LabelContactDetails" />
                :<span class="form-required">*</span></label>
            <div class="form-input">
                <asp:TextBox ID="txtContactDetails" runat="server" class="form-control" />
                <asp:RequiredFieldValidator ID="ReqVal_ContactDetails" runat="server" InitialValue=""
                    ControlToValidate="txtContactDetails" SetFocusOnError="true" Display="Dynamic" />
            </div>
        </div>
        <div class="form-line" id="jobs-jobcontactname-field">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ltJobFieldJobContactName" runat="server" SetLanguageCode="LabelName" />
                :</label>
            <div class="form-input">
                <asp:TextBox ID="txtJobContactName" runat="server" class="form-control" />
            </div>
        </div>
        <div class="form-line" id="jobs-jobcontactphone-field">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ltJobFieldJobContactPhone" runat="server" SetLanguageCode="LabelPhone" />
                :</label>
            <div class="form-input">
                <asp:TextBox ID="txtJobContactPhone" runat="server" class="form-control" />
            </div>
        </div>
        <div class="form-header-group">
            <h3 class="form-header">
                <JXTControl:ucLanguageLiteral ID="ltJobFieldJobCreateTemplate" runat="server" SetLanguageCode="LabelJobTemplate" />
            </h3>
        </div>
        <div class="form-group" id="jobs-jobtemplateid-field">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ltJobFieldJobTemplate" runat="server" SetLanguageCode="LabelJobTemplate" />
                :<span class="form-required">*</span></label>
            <div class="form-input">
                <asp:DropDownList runat="server" ID="ddlJobTemplateID" DataTextField="JobTemplateDescription"
                    DataValueField="JobTemplateID" CssClass="form-multiple-column form-control" OnSelectedIndexChanged="ddlJobTemplateID_SelectedIndexChanged" />
                <asp:RequiredFieldValidator ID="ReqValJobTemplate" runat="server" ControlToValidate="ddlJobTemplateID"
                    SetFocusOnError="true" Display="Dynamic" />
                <br />
                <asp:Image ID="imgAdvJobTemplate" runat="server" />
            </div>
        </div>
        <div>
            <div class="form-header-group">
                <h3 class="form-header">
                    <JXTControl:ucLanguageLiteral ID="ltJobFieldJobCreateTemplateLogo" runat="server"
                        SetLanguageCode="LabelJobTemplateLogo" />
                </h3>
            </div>
        </div>
        <div class="form-line" id="jobs-advertiserjobtemplatelogoid-field">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ltJobFieldAdvertiserJobTemplate" runat="server"
                    SetLanguageCode="LabelJobTemplateLogo" />
                :</label>
            <div class="form-input">
                <asp:DropDownList runat="server" ID="ddlAdvertiserJobTemplateLogo" DataTextField="JobLogoName"
                    DataValueField="AdvertiserJobTemplateLogoID" CssClass="form-multiple-column form-control" />
                <asp:LinkButton ID="btnNewJobLogo" runat="server" Text="New Logo" CausesValidation="false"
                    OnClientClick="NewLogoClicked(); return false;" />
            </div>
        </div>
        <div id="liNewJobLogoTitle" style="display: none;">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral5" runat="server" SetLanguageCode="LabelAdvertiserJobTemplateLogoName" />
                :<span class="form-required">*</span></label>
            <div class="form-input">
                <asp:TextBox runat="server" ID="tbJobLogoName" DataTextField="JobLogoName" DataValueField="AdvertiserJobTemplateLogoID"
                    CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvAdvJobTemplateLogoName" runat="server" ControlToValidate="tbJobLogoName"
                    SetFocusOnError="true" Display="Dynamic" Enabled="false"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="cvalFileName" runat="server" OnServerValidate="cvalFileName_ServerValidate"
                    SetFocusOnError="true" Display="Dynamic"></asp:CustomValidator>
            </div>
        </div>
        <div class="form-group" id="liNewJobLogoFileTitle" style="display: none;">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral17" runat="server" SetLanguageCode="LabelAdvertiserJobTemplateLogoSelectDoc" />
                :</label>
            <div class="form-input">
                <asp:FileUpload ID="docInput" runat="server" CssClass="form-control" />&nbsp;
                <asp:RequiredFieldValidator ID="rfvAdvJobTemplateLogoImage" runat="server" ControlToValidate="docInput"
                    SetFocusOnError="true" Display="Dynamic" Enabled="false"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="cvalFile" runat="server" OnServerValidate="cvalFile_ServerValidate"
                    SetFocusOnError="true" Display="Dynamic"></asp:CustomValidator>
                <asp:LinkButton ID="btnCancelJobLogo" runat="server" Text="Cancel" CausesValidation="false"
                    OnClientClick="CancelNewLogoClicked(); return false;" />
            </div>
        </div>
        <div class="form-header-group">
            <h3 class="form-header">
                <JXTControl:ucLanguageLiteral ID="ltJobFieldJobAdOptions" runat="server" SetLanguageCode="LabelJobAdOptions" />
            </h3>
        </div>
        <div class="form-group" id="jobs-qualificationsrecognised-field">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ltJobFieldQualificationsRecognised" runat="server"
                    SetLanguageCode="LabelQualificationsRecognised" />
                :</label>
            <div class="form-input">
                <asp:CheckBox ID="chkQualificationsRecognised" runat="server" />
            </div>
        </div>
        <div class="form-group" id="jobs-residentonly-field">
            <label class="form-label-left">
                <JXTControl:ucLanguageLiteral ID="ltJobFieldResidentOnly" runat="server" SetLanguageCode="LabelResidentOnly" />
                :</label>
            <div class="form-input">
                <asp:CheckBox ID="chkResidentOnly" runat="server" />
            </div>
        </div>
        <asp:PlaceHolder ID="phPostedDates" runat="server">
            <div class="form-group" id="jobs-expiried-field">
                <label class="form-label-left">
                    <JXTControl:ucLanguageLiteral ID="ltJobFieldExpired" runat="server" SetLanguageCode="LabelExpired" />
                    :</label>
                <div class="form-input">
                    <asp:CheckBox ID="chkJobExpired" runat="server" />
                </div>
            </div>
            <div class="form-group" id="jobs-dateposted-field">
                <hr />
                <label class="form-label-left">
                    <JXTControl:ucLanguageLiteral ID="ltJobFieldDatePosted" runat="server" SetLanguageCode="LabelDatePosted" />
                    :</label>
                <div class="form-input">
                    <asp:Label ID="lblDatePosted" runat="server" />
                </div>
            </div>
            <div class="form-group" id="jobs-expirydate-field">
                <label class="form-label-left">
                    <JXTControl:ucLanguageLiteral ID="ltJobFieldExpiryDate" runat="server" SetLanguageCode="LabelExpiryDate" />
                    :</label>
                <div class="form-input">
                    <asp:Label ID="lblExpiryDate" runat="server" />
                </div>
            </div>
            <div class="form-group" id="jobs-lastmodified-field">
                <label class="form-label-left">
                    <JXTControl:ucLanguageLiteral ID="ltJobFieldLastModified" runat="server" SetLanguageCode="LabelLastModified" />
                    :</label>
                <div class="form-input">
                    <asp:Label ID="lblLastModified" runat="server" />
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phPostedBy" runat="server">
            <div class="form-group" id="jobs-postedby">
                <label class="form-label-left">
                    <JXTControl:ucLanguageLiteral ID="ltJobFieldpostedBy" runat="server" SetLanguageCode="lblPostedByAdvertiserUser" />
                    :</label>
                <div class="form-input">
                    <asp:Label ID="lblPostedByAdvertiserUser" runat="server" />
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="phlastmodifiedByAdvuserID" runat="server">
            <div class="form-group" id="jobs-lastmodifiedbyadvertiseruserid-field">
                <label class="form-label-left">
                    <JXTControl:ucLanguageLiteral ID="ltJobFieldLastModifiedByAdvertiserUser" runat="server"
                        SetLanguageCode="LabelLastModifiedByAdvertiserUser" />
                    :</label>
                <div class="form-input">
                    <asp:Label ID="lblLastModifiedByAdvertiserUserId" runat="server" />
                </div>
            </div>
        </asp:PlaceHolder>
        <div class="form-group">
            <asp:Button ID="InsertButton" runat="server" ClientIDMode="Static" CssClass="btn btn-primary"
                CausesValidation="true" Text="Insert" OnClick="InsertButton_Click" Visible="false" />
            <asp:Button ID="UpdateButton" runat="server" ClientIDMode="Static" CssClass="btn btn-primary"
                CausesValidation="true" Text="Update" OnClick="UpdateButton_Click" Visible="false" />
        </div>
        </form>
    </div>
    <%--    <script type="text/javascript">
        function initialize() {
            var initialValue = getQueryStringParameter(location.href, "value");
            //Set the experience drop-down to the current value
            var dropdown = document.getElementById("experience");
            for (i = 0; i < dropdown.options.length; i++) {
                if (dropdown.options[i].value == initialValue) {
                    dropdown.options[i].selected = true;
                    return;
                }
            }
        }

        function setValue(value) {
            alert(location.href); //https://www.jito.co/job/bullhornintegration.aspx?entitytype=job%20posting&entityid=-1&userid=7&corporationid=7064&privatelabelid=9972&height=150&width=600&basecontrolname=jobposting%5fcustomtext16&value=https%3a%2f%2fwww%2ejito%2eco%2fjob%2fbullhornintegration%2easpx&currentbullhornurl=https%3a%2f%2fbhnext%2ebullhornstaffing%2ecom%2fbullhornstaffing%2fjobposting%2fforms%2feditjobposting%2ecfm%3f
            var controlName = "jobPosting_customText16"; //  decodeURIComponent(getQueryStringParameter(location.href, "baseControlName"));
            var origin = "https://bhnext.bullhornstaffing.com/bullhornstaffing/jobposting/forms/editjobposting.cfm?"; //   decodeURIComponent(getQueryStringParameter(location.href, "currentBullhornUrl").replace(/\+/g, " "));

            //sets the value of the customtext box
            window.parent.postMessage(JSON.stringify(
                { name: controlName, value: 'TEST VALUE SUCCESS' }
            ), origin);

        }

        //Generic function to extract values from the referring URL
        function getQueryStringParameter(href, paramName) {
            var regexS = "[\\?&]" + paramName + "=([^&#]*)";
            var regex = new RegExp(regexS);
            var results = regex.exec(href);
            if (results == null) {
                return "";
            } else {
                return results[1];
            }
        }

    
 
    </script>--%>
    <script type="text/javascript">

        $(document).ready(function () {

            // Goto top of the page.
            $("#tempInput").focus();


            var nowTemp = new Date();
            var now = new Date(nowTemp.getFullYear(), nowTemp.getMonth(), nowTemp.getDate() + 1, 0, 0, 0, 0);

            $('#tbExpiryDate').datepicker({
                format: '<%=DateFormat %>',
                onRender: function (date) {
                    return date.valueOf() < now.valueOf() ? 'disabled' : '';
                }
            });


        });
    </script>
    <asp:PlaceHolder runat="server" ID="pnhScripts">
        <script type="text/javascript">

            //Google Map Variable
            var gMap, gMapMarker;
            var geocoder = new google.maps.Geocoder();

            var FriendlyUrlValue = '';
            
            if (typeof $('#<%= txtFriendlyUrl.ClientID %>') === 'undefined' && $('#<%= txtFriendlyUrl.ClientID %>').val() != '')
            {
                FriendlyUrlValue  = $('#<%= txtFriendlyUrl.ClientID %>').val().toLowerCase();
            }

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
                    FriendlyUrlValue = $('#<%= txtJobName.ClientID %>').val().toLowerCase();

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

            function SalaryChange() {

                $('#txtSalaryLowerBand').prop('disabled', (($('#ddlSalary').val() == 0 || $('#ddlSalary').val() == 3) ? true : false));
                $('#txtSalaryUpperBand').prop('disabled', (($('#ddlSalary').val() == 0 || $('#ddlSalary').val() == 3) ? true : false));


                var placeholdertag = ($("#ddlSalary option:selected").attr('placeholdertag'));

                if ($('#ddlSalary').val() == 3) {
                    $('#chkShowSalaryRange').prop('checked', false);
                    $('#chkShowSalaryRange').prop('disabled', true);
                    $('#txtSalaryText').val('');
                    $('#txtSalaryText').prop('disabled', true);
                    $('#chkShowSalaryDetails').prop('checked', false);
                    $('#chkShowSalaryDetails').prop('disabled', true);


                }
                else {
                    $('#chkShowSalaryRange').prop('disabled', false);
                    $('#txtSalaryText').prop('disabled', false);
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
            
            /*function ScrollPageToTop()
            {
                $('#submitMessages').focus();
            }*/
            
            function ScrollPageToBottom()
            {
                $('#UpdateButton').focus(); 
            }

            $(document).ready(function () {
                
                // Goto top of the page.
                $("#tempInput").focus();

                if ($('#hfFileError').val() != "") {
                    NewLogoClicked();
                    $('html, body').animate({
                        scrollTop: $("#<%= tbJobLogoName.ClientID %>").offset().top
                    }, 0);
                }


                $("#<%= txtJobName.ClientID %>").blur(function () {
                    if ($("#<%= txtFriendlyUrl.ClientID %>").val().length < 1)
                        checkFriendlyUrlChanged();
                });

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
                $('#txtSalaryLowerBand').prop('disabled', ($('#ddlSalary').val() == 0 ? true : false));
                $('#txtSalaryUpperBand').prop('disabled', ($('#ddlSalary').val() == 0 ? true : false));


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

        </script>
    </asp:PlaceHolder>
</body>
</html>
