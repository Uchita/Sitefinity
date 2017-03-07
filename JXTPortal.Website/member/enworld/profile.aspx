<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CustomMain.Master"
    EnableEventValidation="false" AutoEventWireup="true" CodeBehind="profile.aspx.cs"
    Inherits="JXTPortal.Website.member.enworld.profile" %>

<%@ Register TagPrefix="uc1" Namespace="JXTPortal.Website.usercontrols.common" Assembly="JXTPortal.WebSite" %>
<%@ Register Src="/usercontrols/navigation/ucMemberAccountNavigation.ascx" TagName="ucMemberAccountNavigation"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Expires" content="-1">
    <link rel="stylesheet" href="//netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.css" />
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/cvbuilder/css/lib/bootstrap.min.css" />
    <%--<link rel="stylesheet" href="//images.jxt.net.au/COMMON/cvbuilder/css/lib/bootstrap-fileupload.min.css" />--%>
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/cvbuilder/css/lib/jquery.tagsinput.css" />
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/cvbuilder/css/lib/bootstrap-multiselect.css" />
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/cvbuilder/css/CV-Builder-style.css" />
    <link href="/scripts/bootstrap-datepicker/css/datepicker.css" rel="stylesheet" type="text/css" />
    <!--[if lt IE 9]>
<script src="//images.jxt.net.au/COMMON/cvbuilder/js/lib/html5shiv.js" type="text/javascript"></script>
<script src="//images.jxt.net.au/COMMON/cvbuilder/js/lib/respond.min.js" type="text/javascript"></script>
<![endif]-->
    <% if (this.Page.Master.FindControl("ltlMetaContent") != null && !(((Literal)this.Page.Master.FindControl("ltlMetaContent")).Text.Contains("bootstrap.min.js")))
       { %>
    <script src='//images.jxt.net.au/COMMON/cvbuilder/js/lib/bootstrap.min.js'></script>
    <% } %>
    <script src="/scripts/enworld_profile.js" type="text/javascript"></script>
    <script src="/scripts/bootstrap-datepicker/js/bootstrap-datepicker.js" type="text/javascript"></script>
    <script src='//images.jxt.net.au/COMMON/cvbuilder/js/lib/bootstrap-multiselect.js'></script>
    <script type="text/javascript">

        var countryData;
        var desiredCountryData;
        var jobFuncData;

        $(document).ready(function () {

            //This has been init in the aspx
            //MultiselectInit();

            var nowTemp = new Date();
            var now = new Date(nowTemp.getFullYear(), nowTemp.getMonth(), nowTemp.getDate(), 0, 0, 0, 0);

            $('#tbDOB').datepicker({
                format: 'dd-mm-yyyy',
                onRender: function (date) {
                    return date.valueOf() > now.valueOf() ? 'disabled' : '';
                }
            });

            $('#name-location input').keydown(function (event) {
                if (event.keyCode == 13) {
                    $('#name-location button').click();

                    event.preventDefault();
                    return false;
                }
            });

            $('#work-history input').keydown(function (event) {
                if (event.keyCode == 13) {
                    $('#work-history button').click();

                    event.preventDefault();
                    return false;
                }
            });

            $('#desired-position input').keydown(function (event) {
                if (event.keyCode == 13) {
                    $('#desired-position button').click();

                    event.preventDefault();
                    return false;
                }
            });


        });

        function MultiselectInit() {

            $('#ddlSecondDesiredCountry, #ddlDesiredEmployType').multiselect({
                maxHeight: 200,
                buttonClass: 'form-control',
                nonSelectedText: '<%=JXTPortal.Website.CommonFunction.GetResourceValue("DDLPleaseSelect") %>'
            });

            // Desired Location
            if ($('#ddlPrimDesiredLocation option').length == 0) {
                $('#ddlPrimDesiredLocation').attr("disabled", true);

                $('#ddlPrimDesiredLocation').multiselect({
                    maxHeight: 200,
                    buttonClass: 'form-control',
                    nonSelectedText: '<%=JXTPortal.Website.CommonFunction.GetResourceValue("DDLPleaseSelectPrimaryDesiredCountry") %>'
                });
            }
            else {
                $('#ddlPrimDesiredLocation').prop("disabled", false);
                $('#ddlPrimDesiredLocation').multiselect({
                    maxHeight: 200,
                    buttonClass: 'form-control',
                    nonSelectedText: '<%=JXTPortal.Website.CommonFunction.GetResourceValue("DDLPleaseSelect") %>'
                });
            }

            if ($('#ddlPrmDesiredJobFunction option').length == 0) {
                $('#ddlPrmDesiredJobFunction').prop("disabled", true);
                $('#ddlPrmDesiredJobFunction').multiselect({
                    maxHeight: 200,
                    buttonClass: 'form-control',
                    nonSelectedText: '<%=JXTPortal.Website.CommonFunction.GetResourceValue("DDLPleaseSelectPrimaryDesiredJobCategory") %>'
                });
            }
            else {

                $('#ddlPrmDesiredJobFunction').prop("disabled", false);
                $('#ddlPrmDesiredJobFunction').multiselect({
                    maxHeight: 200,
                    buttonClass: 'form-control',
                    nonSelectedText: '<%=JXTPortal.Website.CommonFunction.GetResourceValue("DDLPleaseSelect") %>'
                });
            }


            if ($('#ddlJobFunctions option').length == 0) {
                $('#ddlJobFunctions').prop("disabled", true);
                $('#ddlJobFunctions').multiselect({
                    maxHeight: 200,
                    buttonClass: 'form-control',
                    nonSelectedText: '<%=JXTPortal.Website.CommonFunction.GetResourceValue("DDLPleaseSelectJobCategory") %>'
                });
            }
            else {
                $('#ddlJobFunctions').prop("disabled", false);
                $('#ddlJobFunctions').multiselect({
                    maxHeight: 200,
                    buttonClass: 'form-control',
                    nonSelectedText: '<%=JXTPortal.Website.CommonFunction.GetResourceValue("DDLPleaseSelect") %>'
                });
            }

        }

        function DataDropdownChanged(caller, target, dataStore, defaultMessage, selectMessage, blnRefreshMultiselect, childFieldRequired) {
            var selectedVal = $(caller).val();

            if (selectedVal == "--None--") {

                $(target).empty().prop("disabled", true);

                if (blnRefreshMultiselect) {

                    $(target).multiselect("destroy");
                    $(target).multiselect({
                        maxHeight: 200,
                        buttonClass: 'form-control',
                        nonSelectedText: defaultMessage
                    });
                }
            }
            else {

                $(target).prop("disabled", false);

                $.each(dataStore, function (index, cVal) {

                    if (cVal.Value == selectedVal) {

                        $(target).empty();

                        if (!childFieldRequired) {
                            $(target).append("<option value=''>- Not Specified -</option>");
                        }

                        for (var key in cVal.Childs) {
                            $(target).append("<option value='" + key + "'>" + cVal.Childs[key] + "</option>");
                        }

                        if (blnRefreshMultiselect) {
                            $(target).multiselect("destroy");
                            $(target).multiselect({
                                maxHeight: 200,
                                buttonClass: 'form-control',
                                nonSelectedText: selectMessage
                            });
                        }
                        return;
                    }
                });
            }
        }

    </script>
    <asp:Literal ID="ModelPreserveJSBlock" runat="server"></asp:Literal>
    <style type="text/css">
        #profileNavTabs
        {
            margin: 0px !important;
        }
        .page-title
        {
            font-size: 28px;
            margin-bottom: 25px;
            color: #16b2e3;
        }
        /* dashboard-tabs */
        .dashboard-tabs .nav-pills > li.active > a, .dashboard-tabs .nav-pills > li.active > a:hover, .dashboard-tabs .nav-pills > li.active > a:focus
        {
            background-color: #fff;
            color: #16b2e3;
            border-top: 4px solid #16b2e3;
            border-radius: 0;
        }
        .dashboard-tabs .nav-pills > li > a
        {
            background-color: #455660;
            color: #fff;
            border-radius: 0;
            padding: 15px 0;
            border: 1px solid #fff;
        }
        .dashboard-tabs .nav-pills > li:hover > a
        {
            background-color: #16b2e3;
            color: #fff;
        }
        .dashboard-tabs .table-responsive .btn
        {
            margin-left: 5px;
        }
        .form-group-element
        {
            margin-top: 5px;
            height: 75px !important;
        }
        .form-group h4
        {
            color: #16b2e3;
            margin-top: 20px;
            padding: 0px 0px 10px 0px;
            border-bottom: 1px solid #16b2e3;
        }
        .title-wrapper input[type="text"]
        {
            width: 100%;
            max-width: 350px;
        }
        .file-upload-btns input[type="file"]
        {
            display: inline-block;
        }
        .errormsg
        {
            font-style: italic;
            color: Red;
            font-size: 12px;
            font-weight: bold;
        }
        .multiselect-drpdn .btn-group
        {
            display: block;
        }
        .multiselect-drpdn .btn-group button
        {
            text-align: left;
        }
        .multiselect-drpdn .btn-group button .caret
        {
            float: right;
            margin-top: 8px;
            clear: both;
        }
        .multiselect-drpdn .multiselect-container.dropdown-menu
        {
            width: 100%;
        }
        input::-webkit-calendar-picker-indicator
        {
            display: none;
        }
        input[type="date"]::-webkit-input-placeholder
        {
            visibility: hidden !important;
        }
        /* end dashboard-tabs */</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <script type="text/javascript">
        formtocheck = $('#aspnetForm')[0];
    </script>
    <asp:PlaceHolder ID="plCVBuilder" runat="server">
        <asp:Literal ID="ltGeneralMessage" runat="server"></asp:Literal>
        <div id="content-container">
            <div id="content">
                <div class="content-holder container">
                    <uc1:ucMemberAccountNavigation ID="ucMemberAccountNavigation1" runat="server" />
                    <h2>
                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral37" runat="server" SetLanguageCode="labelMyProfile" />
                    </h2>
                    <div class="dashboard-tabs">
                        <!-- Nav tabs -->
                        <ul id="profileNavTabs" class="nav nav-pills nav-justified" role="tablist">
                            <li class="active"><a aria-controls="name-location" data-toggle="tab" href="#name-location"
                                role="tab" onclick="$('#tab3Message2').remove();">
                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral36" runat="server" SetLanguageCode="labelBasicInformation" />
                            </a></li>
                            <li><a aria-controls="work-history" data-toggle="tab" href="#work-history" role="tab"
                                onclick="$('#tab3Message2').remove();">
                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral35" runat="server" SetLanguageCode="labelCurrentRole" />
                            </a></li>
                            <li><a id="aDesiredPosition" aria-controls="desired-position" data-toggle="tab" href="#desired-position"
                                role="tab" onclick="$('#tab3Message2').remove();">
                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral34" runat="server" SetLanguageCode="LabelDesiredPosition" />
                            </a></li>
                        </ul>
                        <!-- Tab panes -->
                        <div class="tab-content">
                            <div class="tab-pane active" id="name-location" role="tabpanel">
                                <div>
                                    <br />
                                    <div class="row form-group">
                                        <div class="col-sm-6 form-group-element">
                                            <label>
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelGender" />
                                            </label>
                                            <asp:DropDownList ID="ddlGender" ClientIDMode="Static" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-6 form-group-element">
                                            <label>
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral2" runat="server" SetLanguageCode="LabelDateOfBirth" />
                                            </label>
                                            <asp:TextBox ID="tbDOB" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-6 form-group-element">
                                            <label>
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral3" runat="server" SetLanguageCode="LabelPhoneMobileFull" />
                                            </label>
                                            <asp:TextBox ID="tbMobilePhone" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                placeholder="Mobile phone"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-6 form-group-element">
                                            <label>
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral4" runat="server" SetLanguageCode="LabelPhoneHomeFull" />
                                            </label>
                                            <asp:TextBox ID="tbHomePhone" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                placeholder="Home phone"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-6 form-group-element">
                                            <label>
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral5" runat="server" SetLanguageCode="LabelCountry" />
                                                <span class="form-required">*</span></label>
                                            <asp:DropDownList ID="ddlCountry" ClientIDMode="Static" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                            <div id="ddlCountryMsg" class="errormsg">
                                            </div>
                                        </div>
                                        <div class="col-sm-6 form-group-element">
                                            <label>
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral6" runat="server" SetLanguageCode="LabelSecondaryEmail" />
                                            </label>
                                            <asp:TextBox ID="tbSecondEmail" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                placeholder="Secondary email" type="email"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-6 form-group-element">
                                            <label>
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral7" runat="server" SetLanguageCode="LabelAddress" />
                                            </label>
                                            <asp:TextBox ID="tbAddress1" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                placeholder="Address"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-6 form-group-element">
                                            <label>
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral8" runat="server" SetLanguageCode="LabelCity" />
                                            </label>
                                            <asp:TextBox ID="tbCity" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                placeholder="City"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-6 form-group-element">
                                            <label>
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral9" runat="server" SetLanguageCode="LabelState" />
                                            </label>
                                            <asp:DropDownList ID="ddlState" ClientIDMode="Static" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-6 form-group-element">
                                            <label>
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral10" runat="server" SetLanguageCode="LabelZipCode" />
                                            </label>
                                            <asp:TextBox ID="tbZip" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                placeholder="Zip/Postcode"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-6 form-group-element">
                                            <label>
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral101" runat="server" SetLanguageCode="LabelEnglishLanguageLevel" />
                                                <!--<span class="form-required">*</span>-->
                                            </label>
                                            <asp:DropDownList ID="ddlEnglishLanguageLevel" ClientIDMode="Static" runat="server"
                                                CssClass="form-control">
                                            </asp:DropDownList>
                                            <div id="ddlEnglishLanguageLevelMsg" class="errormsg">
                                            </div>
                                        </div>
                                        <div class="col-sm-6 form-group-element">
                                            <label>
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral102" runat="server" SetLanguageCode="LabelJapaneseLanguageLevel" />
                                            </label>
                                            <asp:DropDownList ID="ddlJapaneseLanguageLevel" ClientIDMode="Static" runat="server"
                                                CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-6 form-group-element">
                                            <label>
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral103" runat="server" SetLanguageCode="LabelOtherLanguage" />
                                            </label>
                                            <asp:DropDownList ID="ddlOtherLanguage" ClientIDMode="Static" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-6 form-group-element">
                                            <label>
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral38" runat="server" SetLanguageCode="LabelOtherLanguageLevel" />
                                            </label>
                                            <asp:DropDownList ID="ddlOtherLanguageLevel" ClientIDMode="Static" runat="server"
                                                CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row form-group">
                                    <div id="tab1Message" class="col-xs-12 errormsg">
                                    </div>
                                    <div class="col-xs-12">
                                        <button type="button" class="btn btn-primary" onclick="Tab1Save(this, $('#tab1Loader'));">
                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral11" runat="server" SetLanguageCode="LabelBtnSaveNext" />
                                        </button>
                                        &nbsp;<span id="tab1Loader" class="hide"><i class="fa fa-spinner fa-spin"></i></span>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane" id="work-history" role="tabpanel">
                                <div>
                                    <br />
                                    <div id="experienceForm">
                                        <div class="row form-group">
                                            <div class="col-sm-6 form-group-element">
                                                <label>
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral12" runat="server" SetLanguageCode="LabelCompany" />
                                                    <span class="form-required">*</span></label>
                                                <asp:TextBox ID="tbCurrentCompany" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                    placeholder="Current company name"></asp:TextBox>
                                                <div id="tbCurrentCompanyMsg" class="errormsg">
                                                </div>
                                            </div>
                                            <div class="col-sm-6 form-group-element">
                                                <label>
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral13" runat="server" SetLanguageCode="LabelJobTitle" />
                                                    <span class="form-required">*</span></label>
                                                <asp:TextBox ID="tbCurrentJobTitle" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                    placeholder="Current job title"></asp:TextBox>
                                                <div id="tbCurrentJobTitleMsg" class="errormsg">
                                                </div>
                                            </div>
                                            <div class="col-sm-6 form-group-element">
                                                <label>
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral131" runat="server" SetLanguageCode="LabelIndustry" />
                                                    <span class="form-required">*</span></label>
                                                <asp:DropDownList ID="ddlIndustry" ClientIDMode="Static" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                                <div id="ddlIndustryMsg" class="errormsg">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row form-group">
                                            <div class="col-sm-6 form-group-element">
                                                <label>
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral132" runat="server" SetLanguageCode="LabelJobCategory" />
                                                    <span class="form-required">*</span></label>
                                                <asp:DropDownList ID="ddlJobCategory" ClientIDMode="Static" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                                <div id="ddlJobCategoryMsg" class="errormsg">
                                                </div>
                                            </div>
                                            <div class="col-sm-6 form-group-element">
                                                <label>
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral14" runat="server" SetLanguageCode="LabelJobFunction" />
                                                    <span class="form-required">*</span></label>
                                                <div class="multiselect-drpdn">
                                                    <asp:ListBox ID="ddlJobFunctions" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                        SelectionMode="Multiple"></asp:ListBox>
                                                </div>
                                                <div id="ddlJobFunctionsMsg" class="errormsg">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row form-group">
                                            <div class="col-sm-6 form-group-element">
                                                <label>
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral15" runat="server" SetLanguageCode="LabelEmploymentType" />
                                                </label>
                                                <asp:DropDownList ID="ddlEmploymentType" ClientIDMode="Static" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                                <div id="ddlEmploymentTypeMsg" class="errormsg">
                                                </div>
                                            </div>
                                            <div class="col-sm-6 form-group-element">
                                                <label>
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral16" runat="server" SetLanguageCode="LabelSalaryPeriod" />
                                                </label>
                                                <asp:DropDownList ID="ddlSalaryPeriod" ClientIDMode="Static" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-6 form-group-element">
                                                <label>
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral17" runat="server" SetLanguageCode="LabelFixedSalary" />
                                                </label>
                                                <asp:DropDownList ID="ddlSalaryCurrency" ClientIDMode="Static" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                                <asp:TextBox ID="tbFixedSalary" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                    placeholder="Fixed salary"></asp:TextBox>
                                                <div id="tbFixedSalaryMsg" class="errormsg">
                                                </div>
                                            </div>
                                            <div class="col-sm-6 form-group-element">
                                                <label>
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral18" runat="server" SetLanguageCode="LabelIncentiveSalary" />
                                                </label>
                                                <asp:TextBox ID="tbIncentiveSalary" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                    placeholder="Incentive salary"></asp:TextBox>
                                                <div id="tbIncentiveSalaryMsg" class="errormsg">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row form-group">
                                    <div id="tab2Message" class="col-xs-12 errormsg">
                                    </div>
                                    <div class="col-xs-12">
                                        <button type="button" class="btn btn-primary" onclick="Tab2Save(this, $('#tab2Loader'));">
                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral19" runat="server" SetLanguageCode="LabelBtnSaveNext" />
                                        </button>
                                        &nbsp;<span id="tab2Loader" class="hide"><i class="fa fa-spinner fa-spin"></i></span>
                                    </div>
                                    <div class="clearfix">
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane" id="desired-position" role="tabpanel">
                                <div>
                                    <div class="form-group">
                                        <h4>
                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral20" runat="server" SetLanguageCode="LabelResumeUpload" />
                                        </h4>
                                        <asp:PlaceHolder ID="plUploadFileTable" runat="server" Visible="false">
                                            <div class="table">
                                                <table width="100%">
                                                    <thead>
                                                        <tr>
                                                            <th>
                                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral21" runat="server" SetLanguageCode="LabelFileTitle" />
                                                            </th>
                                                            <th>
                                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral22" runat="server" SetLanguageCode="LabelFileName" />
                                                            </th>
                                                            <th>
                                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral23" runat="server" SetLanguageCode="LabelUploadedDate" />
                                                            </th>
                                                            <th>
                                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral24" runat="server" SetLanguageCode="LabelActions" />
                                                            </th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:Repeater ID="rptResume" runat="server" OnItemDataBound="rptResume_ItemDataBound"
                                                            OnItemCommand="rptResume_ItemCommand">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Literal ID="resumeFileTitle" runat="server"></asp:Literal>
                                                                    </td>
                                                                    <td>
                                                                        <a href="/download.aspx?type=mf&id=<%#Eval("MemberFileId") %>">
                                                                            <asp:Literal ID="resumeFileName" runat="server"></asp:Literal>
                                                                        </a>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Literal ID="resumeUploadDate" runat="server"></asp:Literal>
                                                                    </td>
                                                                    <td>
                                                                        <a href="/download.aspx?type=mf&id=<%#Eval("MemberFileId") %>" class="btn btn-info btn-xs">
                                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral241" runat="server" SetLanguageCode="LabelDownload" />
                                                                        </a>
                                                                        <asp:LinkButton ID="lbRemove" runat="server" CssClass="btn btn-danger btn-xs" CommandName="Delete">
                                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral242" runat="server" SetLanguageCode="LabelRemove" />
                                                                        </asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </tbody>
                                                </table>
                                                <div class="form-group">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral243" runat="server" SetLanguageCode="LabelUploadResumeUpto" />
                                                </div>
                                            </div>
                                        </asp:PlaceHolder>
                                        <asp:PlaceHolder ID="phFileUpload" runat="server">
                                            <div class="form-group row">
                                                <div class="col-md-6 form-group-element">
                                                    <label>
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral244" runat="server" SetLanguageCode="LabelAddResumeFile" />
                                                    </label>
                                                    <asp:TextBox ID="fileUploadTitle" CssClass="form-control" runat="server" placeholder="Enter File Title"></asp:TextBox>
                                                    <div class="errormsg">
                                                        <asp:Literal ID="FileUploadMessage" runat="server"></asp:Literal>
                                                    </div>
                                                </div>
                                                <div class="col-md-6 form-group-element">
                                                    <label>
                                                    </label>
                                                    <div class="file-upload-btns">
                                                        <asp:FileUpload ID="fuTest" runat="server" />
                                                        <asp:Button ID="btnUpload" runat="server" Text="Upload File" CssClass="btn btn-info"
                                                            OnClick="btnUpload_Click" />
                                                    </div>
                                                </div>
                                                <div class="clearfix">
                                                </div>
                                            </div>
                                        </asp:PlaceHolder>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <h4>
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral25" runat="server" SetLanguageCode="LabelDesiredPosition" />
                                    </h4>
                                </div>
                                <asp:UpdatePanel ID="upCountry" runat="server">
                                    <ContentTemplate>
                                        <div class="row form-group">
                                            <div class="col-sm-6 form-group-element">
                                                <label>
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral26" runat="server" SetLanguageCode="LabelPrimaryDesiredCountry" />
                                                    <span class="form-required">*</span></label>
                                                <asp:DropDownList ID="ddlPrimDesiredCountry" runat="server" CssClass="form-control"
                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlPrimDesiredCountry_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <div id="ctl00_ContentPlaceHolder1_ddlPrimDesiredCountryMsg" class="errormsg">
                                                </div>
                                            </div>
                                            <div class="col-sm-6 form-group-element">
                                                <label>
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral27" runat="server" SetLanguageCode="LabelPrimaryDesiredLocation" />
                                                    <span class="form-required">*</span></label>
                                                <div class="multiselect-drpdn">
                                                    <asp:ListBox ID="ddlPrimDesiredLocation" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                        SelectionMode="Multiple"></asp:ListBox>
                                                </div>
                                                <div id="ddlPrimDesiredLocationMsg" class="errormsg">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row form-group">
                                            <div class="col-sm-6 form-group-element">
                                                <label>
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral28" runat="server" SetLanguageCode="LabelSecondaryDesiredCountries" />
                                                </label>
                                                <div class="multiselect-drpdn">
                                                    <asp:ListBox ID="ddlSecondDesiredCountry" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                        SelectionMode="Multiple"></asp:ListBox>
                                                </div>
                                            </div>
                                            <div class="col-sm-6 form-group-element">
                                                <label>
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral29" runat="server" SetLanguageCode="LabelPrimaryDesiredIndustry" />
                                                    <span class="form-required">*</span></label>
                                                <asp:DropDownList ID="ddlPrimDesiredIndustry" ClientIDMode="Static" runat="server"
                                                    CssClass="form-control">
                                                </asp:DropDownList>
                                                <div id="ddlPrimDesiredIndustryMsg" class="errormsg">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row form-group">
                                            <div class="col-sm-6 form-group-element">
                                                <label>
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral30" runat="server" SetLanguageCode="LabelPrimaryDesiredJobCategory" />
                                                    <span class="form-required">*</span></label>
                                                <asp:DropDownList ID="ddlPrimDesiredJobCategory" runat="server" CssClass="form-control"
                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlPrimDesiredJobCategory_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <div id="ctl00_ContentPlaceHolder1_ddlPrimDesiredJobCategoryMsg" class="errormsg">
                                                </div>
                                            </div>
                                            <div class="col-sm-6 form-group-element">
                                                <label>
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral31" runat="server" SetLanguageCode="LabelPrimaryDesiredJobFunction" />
                                                    <span class="form-required">*</span></label>
                                                <div class="multiselect-drpdn">
                                                    <asp:ListBox ID="ddlPrmDesiredJobFunction" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                        SelectionMode="Multiple"></asp:ListBox>
                                                </div>
                                                <div id="ddlPrmDesiredJobFunctionMsg" class="errormsg">
                                                </div>
                                            </div>
                                            <div class="col-sm-6 form-group-element">
                                                <label>
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral32" runat="server" SetLanguageCode="LabelEmploymentTypes" />
                                                    <span class="form-required">*</span></label>
                                                <div class="multiselect-drpdn">
                                                    <asp:ListBox ID="ddlDesiredEmployType" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                        SelectionMode="Multiple"></asp:ListBox>
                                                </div>
                                                <div id="ddlDesiredEmployTypeMsg" class="errormsg">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row form-group">
                                            <div id="tab3Message" class="col-xs-12 errormsg">
                                            </div>
                                            <div class="col-xs-12">
                                                <button type="button" class="btn btn-primary" onclick="Tab3Save(this, $('#tab3Loader'));">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral33" runat="server" SetLanguageCode="LabelSave" />
                                                </button>
                                                &nbsp;<span id="tab3Loader" class="hide"><i class="fa fa-spinner fa-spin"></i></span>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:PlaceHolder>
</asp:Content>
