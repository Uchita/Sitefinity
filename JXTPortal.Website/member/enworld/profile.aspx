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

            MultiselectInit();

            var nowTemp = new Date();
            var now = new Date(nowTemp.getFullYear(), nowTemp.getMonth(), nowTemp.getDate(), 0, 0, 0, 0);

            $('#tbDOB').datepicker({
            format: 'dd-mm-yyyy',
                onRender: function (date) {
                    return date.valueOf() > now.valueOf() ? 'disabled' : '';
                }
            });
        });

        function MultiselectInit() {
            $('.multiselect').multiselect({
                maxHeight: 200,
                numberDisplayed: 2,
                buttonClass: 'form-control'
            });

            // Desired Location
            if ($('#ddlPrimDesiredLocation option').size() < 2) {
                $('#ddlPrimDesiredLocation').val('--None--');
                $('#ddlPrimDesiredLocation').prop("disabled", true);
                $('#ddlPrimDesiredLocation').multiselect({
                    maxHeight: 200,
                    numberDisplayed: 3,
                    buttonClass: 'form-control',
                    nonSelectedText: '- Please select a Primary Desired Country -'
                });
            }
            else {

                $('#ddlPrimDesiredLocation').prop("disabled", false);
                $('#ddlPrimDesiredLocation').multiselect({
                    maxHeight: 200,
                    numberDisplayed: 3,
                    buttonClass: 'form-control',
                    nonSelectedText: 'None selected'
                });
            }


            if ($('#ddlPrmDesiredJobFunction option').size() < 2) {
                $('#ddlPrmDesiredJobFunction').prop("disabled", true);
                $('#ddlPrmDesiredJobFunction').multiselect({
                    maxHeight: 200,
                    numberDisplayed: 2,
                    buttonClass: 'form-control',
                    nonSelectedText: '- Please select a Primary Desired Job Category -'
                });
            }
            else {

                $('#ddlPrmDesiredJobFunction').prop("disabled", false);
                $('#ddlPrmDesiredJobFunction').multiselect({
                    maxHeight: 200,
                    numberDisplayed: 2,
                    buttonClass: 'form-control',
                    nonSelectedText: 'None selected'
                });
            }


            

        }

        function DataDropdownChanged(caller, target, dataStore, defaultMessage, blnRefreshMultiselect, childFieldRequired) {

            var selectedVal = $(caller).val();

            if (selectedVal == "--None--") {
                $(target).empty().append("<option disabled='disabled'>" + defaultMessage + "</option>");

                if (blnRefreshMultiselect) {

                    $(target).multiselect("destroy");
                    $(target).multiselect({
                        maxHeight: 200,
                        numberDisplayed: 2,
                        buttonClass: 'form-control'
                    });
                }
            }
            else {

                $.each(dataStore, function (index, cVal) {

                    if (cVal.Value == selectedVal) {

                        $(target).empty();

                        if (!childFieldRequired) {
                            $(target).append("<option value=''>- Not Specified -</option>");
                        }

                        if (cVal.Childs.length > 0) {
                            $.each(cVal.Childs, function (index, childVal) {

                                if (childVal.indexOf("|") > 0) {
                                    var otext = childVal.split("|")[0];
                                    var ovalue = childVal.split("|")[1];

                                    $(target).append("<option value='" + ovalue + "'>" + otext + "</option>");
                                }
                                else {
                                    $(target).append("<option value='" + childVal + "'>" + childVal + "</option>");
                                }
                            });
                        }
                        else {
                            $(target).append("<option disabled='disabled'>- All Areas -</option>");
                        }

                        if (blnRefreshMultiselect) {

                            $(target).multiselect("destroy");
                            $(target).multiselect({
                                maxHeight: 200,
                                numberDisplayed: 2,
                                buttonClass: 'form-control'
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
        input::-webkit-calendar-picker-indicator{ display: none; }
        input[type="date"]::-webkit-input-placeholder{ visibility: hidden !important; }
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
                        My Profile</h2>
                    <div class="dashboard-tabs">
                        <!-- Nav tabs -->
                        <ul id="profileNavTabs" class="nav nav-pills nav-justified" role="tablist">
                            <li class="active"><a aria-controls="name-location" data-toggle="tab" href="#name-location"
                                role="tab" onclick="$('#tab3Message2').remove();">Basic Information</a> </li>
                            <li><a aria-controls="work-history" data-toggle="tab" href="#work-history" role="tab"
                                onclick="$('#tab3Message2').remove();">Current Role</a> </li>
                            <li><a id="aDesiredPosition" aria-controls="desired-position" data-toggle="tab" href="#desired-position"
                                role="tab" onclick="$('#tab3Message2').remove();">Desired Position</a> </li>
                        </ul>
                        <!-- Tab panes -->
                        <div class="tab-content">
                            <div class="tab-pane active" id="name-location" role="tabpanel">
                                <div>
                                    <br />
                                    <div class="row form-group">
                                        <div class="col-sm-6 form-group-element">
                                            <label>
                                                Gender</label>
                                            <asp:DropDownList ID="ddlGender" ClientIDMode="Static" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-6 form-group-element">
                                            <label>
                                                Date Of Birth</label>
                                            <asp:TextBox ID="tbDOB" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-6 form-group-element">
                                            <label>
                                                Mobile Phone</label>
                                            <asp:TextBox ID="tbMobilePhone" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                placeholder="Mobile phone"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-6 form-group-element">
                                            <label>
                                                Home Phone</label>
                                            <asp:TextBox ID="tbHomePhone" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                placeholder="Home phone"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-6 form-group-element">
                                            <label>
                                                Country<span class="form-required">*</span></label>
                                            <asp:DropDownList ID="ddlCountry" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                onchange="DataDropdownChanged(this, $('#ddlState'), countryData, '- Please Select A Country -', false, false);">
                                            </asp:DropDownList>
                                            <div id="ddlCountryMsg" class="errormsg">
                                            </div>
                                        </div>
                                        <div class="col-sm-6 form-group-element">
                                            <label>
                                                Secondary Email</label>
                                            <asp:TextBox ID="tbSecondEmail" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                placeholder="Secondary email" type="email"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-6 form-group-element">
                                            <label>
                                                Address</label>
                                            <asp:TextBox ID="tbAddress1" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                placeholder="Address"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-6 form-group-element">
                                            <label>
                                                City</label>
                                            <asp:TextBox ID="tbCity" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                placeholder="City"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-6 form-group-element">
                                            <label>
                                                State</label>
                                            <asp:DropDownList ID="ddlState" ClientIDMode="Static" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-6 form-group-element">
                                            <label>
                                                Zip Code</label>
                                            <asp:TextBox ID="tbZip" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                placeholder="Zip/Postcode"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-6 form-group-element">
                                            <label>
                                                Native Language<span class="form-required">*</span></label>
                                            <asp:DropDownList ID="ddlNativeLanguage" ClientIDMode="Static" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                            <div id="ddlNativeLanguageMsg" class="errormsg">
                                            </div>
                                        </div>
                                        <div class="col-sm-6 form-group-element">
                                            <label>
                                                Secondary Language</label>
                                            <asp:DropDownList ID="ddlSecondaryLanguage" ClientIDMode="Static" runat="server"
                                                CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-6 form-group-element">
                                            <label>
                                                Secondary Language Level</label>
                                            <asp:DropDownList ID="ddlSecondaryLanguageLevel" ClientIDMode="Static" runat="server"
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
                                            Save &amp; Next</button>&nbsp;<span id="tab1Loader" class="hide"><i class="fa fa-spinner fa-spin"></i></span>
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
                                                    Company<span class="form-required">*</span></label>
                                                <asp:TextBox ID="tbCurrentCompany" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                    placeholder="Current company name"></asp:TextBox>
                                                <div id="tbCurrentCompanyMsg" class="errormsg">
                                                </div>
                                            </div>
                                            <div class="col-sm-6 form-group-element">
                                                <label>
                                                    Job Title<span class="form-required">*</span></label>
                                                <asp:TextBox ID="tbCurrentJobTitle" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                    placeholder="Current job title"></asp:TextBox>
                                                <div id="tbCurrentJobTitleMsg" class="errormsg">
                                                </div>
                                            </div>
                                            <div class="col-sm-6 form-group-element">
                                                <label>
                                                    Industry<span class="form-required">*</span></label>
                                                <asp:DropDownList ID="ddlIndustry" ClientIDMode="Static" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                                <div id="ddlIndustryMsg" class="errormsg">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row form-group">
                                            <div class="col-sm-6 form-group-element">
                                                <label>
                                                    Job Category<span class="form-required">*</span></label>
                                                <asp:DropDownList ID="ddlJobCategory" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                    onchange="DataDropdownChanged(this, $('#ddlJobFunctions'), jobFuncData, '- Please select a Job Category -', true, true);">
                                                </asp:DropDownList>
                                                <div id="ddlJobCategoryMsg" class="errormsg">
                                                </div>
                                            </div>
                                            <div class="col-sm-6 form-group-element">
                                                <label>
                                                    Job Functions<span class="form-required">*</span></label>
                                                <div class="multiselect-drpdn">
                                                    <asp:ListBox ID="ddlJobFunctions" ClientIDMode="Static" runat="server" CssClass="multiselect form-control"
                                                        SelectionMode="Multiple"></asp:ListBox>
                                                </div>
                                                <div id="ddlJobFunctionsMsg" class="errormsg">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row form-group">
                                            <div class="col-sm-6 form-group-element">
                                                <label>
                                                    Employment Type</label>
                                                <asp:DropDownList ID="ddlEmploymentType" ClientIDMode="Static" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                                <div id="ddlEmploymentTypeMsg" class="errormsg">
                                                </div>
                                            </div>
                                            <div class="col-sm-6 form-group-element">
                                                <label>
                                                    Salary Period</label>
                                                <asp:DropDownList ID="ddlSalaryPeriod" ClientIDMode="Static" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-6 form-group-element">
                                                <label>
                                                    Fixed Salary</label>
                                                <asp:TextBox ID="tbFixedSalary" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                    placeholder="Fixed salary"></asp:TextBox>
                                                <div id="tbFixedSalaryMsg" class="errormsg">
                                                </div>
                                            </div>
                                            <div class="col-sm-6 form-group-element">
                                                <label>
                                                    Incentive Salary</label>
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
                                            Save &amp; Next</button>&nbsp;<span id="tab2Loader" class="hide"><i class="fa fa-spinner fa-spin"></i></span>
                                    </div>
                                    <div class="clearfix">
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane" id="desired-position" role="tabpanel">
                                <div>
                                    <div class="form-group">
                                        <h4>
                                            Resume Upload</h4>
                                        <asp:PlaceHolder ID="plUploadFileTable" runat="server" Visible="false">
                                            <div class="table">
                                                <table width="100%">
                                                    <thead>
                                                        <tr>
                                                            <th>
                                                                File Title
                                                            </th>
                                                            <th>
                                                                File Name
                                                            </th>
                                                            <th>
                                                                Uploaded Date
                                                            </th>
                                                            <th>
                                                                Actions
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
                                                                            Download </a>
                                                                        <asp:LinkButton ID="lbRemove" runat="server" CssClass="btn btn-danger btn-xs" CommandName="Delete">
                                                        Remove
                                                                        </asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </tbody>
                                                </table>
                                                <div class="form-group">
                                                    * You may upload upto 3 resumes
                                                </div>
                                        </asp:PlaceHolder>
                                        <asp:PlaceHolder ID="phFileUpload" runat="server">
                                            <div class="form-group row">
                                                <div class="col-md-6 form-group-element">
                                                    <label>
                                                        Add Resume File</label>
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
                                        Desired Position</h4>
                                </div>
                                <asp:UpdatePanel ID="upCountry" runat="server">
                                    <ContentTemplate>
                                        <div class="row form-group">
                                            <div class="col-sm-6 form-group-element">
                                                <label>
                                                    Primary Desired Country<span class="form-required">*</span></label>
                                                <asp:DropDownList ID="ddlPrimDesiredCountry" runat="server" CssClass="form-control"
                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlPrimDesiredCountry_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <div id="ctl00_ContentPlaceHolder1_ddlPrimDesiredCountryMsg" class="errormsg">
                                                </div>
                                            </div>
                                            <div class="col-sm-6 form-group-element">
                                                <label>
                                                    Primary Desired Location<span class="form-required">*</span></label>
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
                                                    Secondary Desired Countries</label>
                                                <div class="multiselect-drpdn">
                                                    <asp:ListBox ID="ddlSecondDesiredCountry" ClientIDMode="Static" runat="server" CssClass="multiselect form-control"
                                                        SelectionMode="Multiple"></asp:ListBox>
                                                </div>
                                            </div>


                                            <div class="col-sm-6 form-group-element">
                                                <label>
                                                    Primary Desired Industry<span class="form-required">*</span></label>
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
                                                    Primary Desired Job Category<span class="form-required">*</span></label>
                                                <asp:DropDownList ID="ddlPrimDesiredJobCategory" runat="server" CssClass="form-control"
                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlPrimDesiredJobCategory_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <div id="ctl00_ContentPlaceHolder1_ddlPrimDesiredJobCategoryMsg" class="errormsg">
                                                </div>
                                            </div>
                                            <div class="col-sm-6 form-group-element">
                                                <label>
                                                    Primary Desired Job Function<span class="form-required">*</span></label>
                                                <div class="multiselect-drpdn">
                                                    <asp:ListBox ID="ddlPrmDesiredJobFunction" ClientIDMode="Static" runat="server" CssClass="form-control"
                                                        SelectionMode="Multiple"></asp:ListBox>
                                                </div>
                                                <div id="ddlPrmDesiredJobFunctionMsg" class="errormsg">
                                                </div>
                                            </div>
                                            <div class="col-sm-6 form-group-element">
                                                <label>
                                                    Employment Types<span class="form-required">*</span></label>
                                                <div class="multiselect-drpdn">
                                                    <asp:ListBox ID="ddlDesiredEmployType" ClientIDMode="Static" runat="server" CssClass="multiselect form-control"
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
                                                    Save</button>&nbsp;<span id="tab3Loader" class="hide"><i class="fa fa-spinner fa-spin"></i></span>
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
        </div> </asp:PlaceHolder>
</asp:Content>
