<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CustomMain.Master"
    AutoEventWireup="true" CodeBehind="Copy of profile.aspx.cs" Inherits="JXTPortal.Website.member.enworld.__profile" %>

<%@ Register TagPrefix="uc1" Namespace="JXTPortal.Website.usercontrols.common" Assembly="JXTPortal.WebSite" %>
<%@ Register Src="/usercontrols/navigation/ucMemberAccountNavigation.ascx" TagName="ucMemberAccountNavigation"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Expires" content="-1">
    <link rel="stylesheet" href="http://netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.css" />
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/cvbuilder/css/lib/bootstrap.min.css" />
    <%--<link rel="stylesheet" href="//images.jxt.net.au/COMMON/cvbuilder/css/lib/bootstrap-fileupload.min.css" />--%>
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/cvbuilder/css/lib/jquery.tagsinput.css" />
    <%--<link rel="stylesheet" href="//images.jxt.net.au/COMMON/cvbuilder/css/lib/bootstrap-multiselect.css" />--%>
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
    <script type="text/javascript">
        var skill__c;
        var skill__name__c;
        var sector_experience__c;
        var sector_detail__c;
        var job_function__c;
        var job_function_experience__c;

        var sector_experience_records;
        var sector_reference_records;
        var education_history_records;

        $(document).ready(function () {

            $('#dpExpStart, #dpExpEnd').datepicker();

            //sector experience
            var secExpExpOnClickEdit = function (id) { SectorExpExperienceEdit(id, sector_experience_records, "sectorExpActionMsg"); };
            var secExpExpOnClickDelete = function (id) { SectorExpExperienceDelete(id, "sectorExpActionMsg"); };
            GenerateTableData("secExpExperienceTable", sector_experience_records, ["ts2__Name__c", "ts2__Job_Title__c", "ts2__Location__c", "ts2__Employment_Start_Date__c", "ts2__Employment_End_Date__c"], "secExpExp", secExpExpOnClickEdit, secExpExpOnClickDelete);

            //sector reference
            var secExpRefOnClickEdit = function (id) { SectorExpReferenceEdit(id, sector_reference_records, "sectorRefActionMsg"); };
            var secExpRefOnClickDelete = function (id) { SectorExpReferenceDelete(id, "sectorRefActionMsg"); };
            GenerateTableData("secExpRefTable", sector_reference_records, ["ts2__Name__c", "ts2__Company__c", "ts2__Role_Title__c", "ts2__Phone__c", "ts2__Email__c"], "secExpRef", secExpRefOnClickEdit, secExpRefOnClickDelete);

            //education history
            var eduHistOnClickEdit = function (id) { EducationEdit(id, education_history_records, "eduHistActionMsg"); };
            var eduHistOnClickDelete = function (id) { EducationDelete(id, "eduHistActionMsg"); };
            GenerateTableData("eduHistoryTable", education_history_records, ["ts2__Name__c", "ts2__DegreePicklist__c", "ts2__Major__c", "ts2__Graduation_Year__c"], "eduHistory", eduHistOnClickEdit, eduHistOnClickDelete);

        });


        function GenerateTableData(tableID, records, varNames, tableRowIDPrefix, onclickEditFunc, onclickDeleteFunc) {

            $.each(records, function (index, recValue) {
                var tableDatasStr = "";
                //loop each varNames
                $.each(varNames, function (index, varNameValue) {
                    tableDatasStr += "<td>" + recValue[varNameValue] + "</td>";
                });

                //add buttons
                var editButton = $("<button type='button'><i class='fa fa-pencil'></i>Edit</button>").addClass("btn btn-success btn-xs").on("click", function () { onclickEditFunc(recValue["Id"]); });
                var deleteButton = $("<button type='button'><i class='fa fa-times'></i>Delete</button>").addClass("btn btn-success btn-xs").on("click", function () { onclickDeleteFunc(recValue["Id"]); });

                var newTD = $("<td></td>").addClass("text-right").append(editButton).append(deleteButton);

                var tableRow = $("<tr></tr>").attr("id", tableRowIDPrefix + recValue["Id"]).append(tableDatasStr).append(newTD);
                $("#" + tableID + " tbody").append(tableRow);
            });
        }

    </script>
    <asp:Literal ID="ModelPreserveJSBlock" runat="server"></asp:Literal>
    <style type="text/css">
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
        }
        .dashboard-tabs .table-responsive .btn
        {
            margin-left: 5px;
        }
        /* end dashboard-tabs */</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        formtocheck = $('#aspnetForm')[0];
    </script>
    <div id="dynamic-container" class="container">
        <div class="row">
            <div class="col-sm-12 col-md-12">
                <div id="dynamic-content-holder">
                    <uc1:ucMemberAccountNavigation ID="ucMemberAccountNavigation1" runat="server" />
                    <!-- Start the CV Builder wizard block -->
                    <h1 class="CV-Builder-title">
                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral4" runat="server" SetLanguageCode="LabelUpdateProfile" />
                    </h1>
                    <asp:Literal ID="ltGeneralMessage" runat="server"></asp:Literal>
                    <asp:PlaceHolder ID="plCVBuilder" runat="server">
                        <div id="CV-Builder" class="form-horizontal">
                            <div id="profileNavTabs" class="dashboard-tabs">
                                <ul class="nav nav-pills nav-justified" role="tablist">
                                    <li class="active"><a aria-controls="background" data-toggle="tab" href="#background"
                                        role="tab" onclick="NavTabDirectClick(true,false)">Background &amp; Preferences</a>
                                    </li>
                                    <li class=""><a aria-controls="job-function" data-toggle="tab" href="#job-function"
                                        role="tab" onclick="NavTabDirectClick(false,false)">Job Function &amp; Experience</a>
                                    </li>
                                    <li class=""><a aria-controls="sector" data-toggle="tab" href="#sector" role="tab"
                                        onclick="NavTabDirectClick(false,false)">Sector Experience</a> </li>
                                    <li><a aria-controls="education" data-toggle="tab" href="#education" role="tab" onclick="NavTabDirectClick(false,true)">
                                        Education</a> </li>
                                </ul>
                                <div class="tab-content">
                                    <div class="tab-pane" id="background" role="tabpanel">
                                        <h3>
                                            Background</h3>
                                        <%--http://full-enworld.cs6.force.com/forms/jsforms__forminclude?formId=a1h10000002puhpAAA&ContactId=003N000000SbITA--%>
                                        <%--<iframe frameborder="0" height="1600" src="http://enworld.force.com/forms/jsforms__forminclude?formId=a1h10000002puhpAAA&amp;ContactId=<%= _SFContactID %>" style="border: 0" width="100%"></iframe>--%>
                                    </div>
                                    <asp:PlaceHolder ID="phExperience" runat="server" Visible="true">
                                        <div class="tab-pane" id="job-function" role="tabpanel">
                                            <h3>
                                                Skill</h3>
                                            <div id="form_skill" class="form-group experience-details">
                                                <div class="col-md-6">
                                                    <label class="control-label" for="startdate">
                                                        Skill
                                                    </label>
                                                    <div class='controls' id='Div3'>
                                                        <asp:DropDownList ID="SkillDDL" runat="server" CssClass="form-control" ClientIDMode="Static"
                                                            onchange="DependantPicklistValuesGet('skill', this);" />
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <label class="control-label" for="startdate">
                                                        Skill Name
                                                    </label>
                                                    <div class='controls' id='Div4'>
                                                        <asp:DropDownList ID="SkillNameDDL" runat="server" CssClass="form-control" ClientIDMode="Static" />
                                                    </div>
                                                </div>
                                                <div class="col-md-12">
                                                    <div id="skillActionMessage">
                                                    </div>
                                                    <a href="javascript:void(0)" onclick="SFObjAdd('skill', $('#SkillDDL'),$('#SkillNameDDL'), 'skillActionMessage');"
                                                        class="btn btn-default btn-file"><i class="fa fa-plus"></i>Add Skill</a>
                                                </div>
                                                <div class="col-md-12">
                                                    <div id="skillTable" class="table-responsive">
                                                        <table class="table table-striped">
                                                            <thead>
                                                                <tr>
                                                                    <th>
                                                                        Skill
                                                                    </th>
                                                                    <th>
                                                                        Skill Name
                                                                    </th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <asp:Repeater ID="rptSkillSkillName" runat="server" OnItemDataBound="rptSkillSkillName_ItemDataBound">
                                                                    <ItemTemplate>
                                                                        <tr id="skill<%# Eval("Id") %>">
                                                                            <td>
                                                                                <asp:Literal ID="ltSkill" runat="server" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Literal ID="ltSkillName" runat="server" />
                                                                            </td>
                                                                            <td class="text-right">
                                                                                <button type="button" class="btn btn-success btn-xs" onclick="SFObjDelete('skill', '<%# Eval("Id") %>', 'skillActionMessage');">
                                                                                    <i class="fa fa-times"></i>Delete</button>
                                                                            </td>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                            <hr />
                                            <div class="form-group experience-details">
                                                <h3>
                                                    Sector Experience</h3>
                                                <div class="col-md-6">
                                                    <label class="control-label" for="startdate">
                                                        Sector Experience
                                                    </label>
                                                    <div class='controls' id='Div2'>
                                                        <asp:DropDownList ID="SecExpDDL" runat="server" CssClass="form-control" ClientIDMode="Static"
                                                            onchange="DependantPicklistValuesGet('sector', this);" />
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <label class="control-label" for="startdate">
                                                        Sector Detail
                                                    </label>
                                                    <div class='controls' id='Div1'>
                                                        <asp:DropDownList ID="SecDetailDDL" runat="server" CssClass="form-control" ClientIDMode="Static" />
                                                    </div>
                                                </div>
                                                <div class="col-md-12">
                                                    <div id="sectorActionMessage">
                                                    </div>
                                                    <a href="javascript:void(0)" onclick="SFObjAdd('sector', $('#SecExpDDL'),$('#SecDetailDDL'), 'sectorActionMessage');"
                                                        class="btn btn-default btn-file"><i class="fa fa-plus"></i>Add Sector Experience</a>
                                                </div>
                                                <div class="col-md-12">
                                                    <div id="sectorTable" class="table-responsive">
                                                        <table class="table table-striped">
                                                            <thead>
                                                                <tr>
                                                                    <th>
                                                                        Sector Experience
                                                                    </th>
                                                                    <th>
                                                                        Sector Detail
                                                                    </th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <asp:Repeater ID="rptSecExpDetail" runat="server" OnItemDataBound="rptSecExpDetail_ItemDataBound">
                                                                    <ItemTemplate>
                                                                        <tr id="sector<%# Eval("Id") %>">
                                                                            <td>
                                                                                <asp:Literal ID="ltCol1" runat="server" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Literal ID="ltCol2" runat="server" />
                                                                            </td>
                                                                            <td class="text-right">
                                                                                <button type="button" class="btn btn-success btn-xs" onclick="SFObjDelete('sector', '<%# Eval("Id") %>', 'sectorActionMessage');">
                                                                                    <i class="fa fa-times"></i>Delete</button>
                                                                            </td>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                            <hr />
                                            <div class="form-group experience-details">
                                                <h3>
                                                    Job Function</h3>
                                                <div class="col-md-6">
                                                    <label class="control-label" for="startdate">
                                                        Job Function
                                                    </label>
                                                    <div class='controls' id='Div5'>
                                                        <asp:DropDownList ID="JobFuncDDL" runat="server" CssClass="form-control" ClientIDMode="Static"
                                                            onchange="DependantPicklistValuesGet('jobfunction', this);" />
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <label class="control-label" for="startdate">
                                                        Experience
                                                    </label>
                                                    <div class='controls' id='Div6'>
                                                        <asp:DropDownList ID="JobFuncExpDDL" runat="server" CssClass="form-control" ClientIDMode="Static" />
                                                    </div>
                                                </div>
                                                <div class="col-md-12">
                                                    <div id="jobfunctionActionMessage">
                                                    </div>
                                                    <a href="javascript:void(0)" onclick="SFObjAdd('jobfunction', $('#JobFuncDDL'),$('#JobFuncExpDDL'), 'jobfunctionActionMessage');"
                                                        class="btn btn-default btn-file"><i class="fa fa-plus"></i>Add Job Function</a>
                                                </div>
                                                <div class="col-md-12">
                                                    <div id="jobfunctionTable" class="table-responsive">
                                                        <table class="table table-striped">
                                                            <thead>
                                                                <tr>
                                                                    <th>
                                                                        Job Function
                                                                    </th>
                                                                    <th>
                                                                        Experience
                                                                    </th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <asp:Repeater ID="rptJobFunction" runat="server" OnItemDataBound="rptJobFunction_ItemDataBound">
                                                                    <ItemTemplate>
                                                                        <tr id="sector<%# Eval("Id") %>">
                                                                            <td>
                                                                                <asp:Literal ID="ltCol1" runat="server" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:Literal ID="ltCol2" runat="server" />
                                                                            </td>
                                                                            <td class="text-right">
                                                                                <button type="button" class="btn btn-success btn-xs" onclick="SFObjDelete('jobfunction', '<%# Eval("Id") %>', 'jobfunctionActionMessage');">
                                                                                    <i class="fa fa-times"></i>Delete</button>
                                                                            </td>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </asp:PlaceHolder>
                                    <asp:PlaceHolder ID="phSector" runat="server" Visible="true">
                                        <div class="tab-pane" id="sector" role="tabpanel">
                                            <h3>
                                                Sector Experience</h3>
                                            <div id="secExpExpFormWrap">
                                                <h4>
                                                    Experience</h4>
                                                <div class="form-group experience-detail">
                                                    <div class="col-md-6">
                                                        <label for="title">
                                                            <JXTControl:ucLanguageLiteral ID="ucJobTitle" runat="server" SetLanguageCode="LabelJobTitle" />
                                                        </label>
                                                        <asp:TextBox ID="tbSecExpJobTitle" runat="server" CssClass="form-control" placeholder="Job title"
                                                            ClientIDMode="Static" />
                                                    </div>
                                                    <div class="col-md-6">
                                                        <label for="company">
                                                            <JXTControl:ucLanguageLiteral ID="ucCompanyName" runat="server" SetLanguageCode="LabelCompanyName" />
                                                        </label>
                                                        <asp:TextBox ID="tbSecExpCompanyName" runat="server" CssClass="form-control" placeholder="Company Name"
                                                            ClientIDMode="Static" />
                                                    </div>
                                                </div>
                                                <div class="form-group experience-detail">
                                                    <div class="col-md-6">
                                                        <label for="title">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelJobLocation" />
                                                        </label>
                                                        <asp:TextBox ID="tbSecExpJobLocation" runat="server" CssClass="form-control" placeholder="Job location"
                                                            ClientIDMode="Static" />
                                                    </div>
                                                    <div class="col-md-6">
                                                        <label for="tbSummary" class="control-label">
                                                            Reason for leaving
                                                        </label>
                                                        <asp:TextBox ID="tbSecExpReason" runat="server" CssClass="form-control" placeholder="Reason for leaving"
                                                            ClientIDMode="Static" />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="col-md-6">
                                                        <label for="tbSecExpStart">
                                                            Start Date</label>
                                                        <div class="input-append date" id="dpExpStart" data-date="<%=DateTime.Now.ToString("yyyy-MM-dd") %>"
                                                            data-date-format="yyyy-mm-dd" data-date-viewmode="years">
                                                            <div class="input-group">
                                                                <asp:TextBox ID="tbSecExpStart" runat="server" CssClass="form-control dateInput"
                                                                    placeholder="Start date" ClientIDMode="Static" />
                                                                <div class="input-group-addon add-on">
                                                                    <i class="fa fa-calendar"></i>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <label for="tbSecExpEnd">
                                                            End Date</label>
                                                        <div class="input-append date" id="dpExpEnd" data-date="<%=DateTime.Now.ToString("yyyy-MM-dd") %>"
                                                            data-date-format="yyyy-mm-dd" data-date-viewmode="years">
                                                            <div class="input-group">
                                                                <asp:TextBox ID="tbSecExpEnd" runat="server" CssClass="form-control dateInput" placeholder="End date"
                                                                    ClientIDMode="Static" />
                                                                <div class="input-group-addon add-on">
                                                                    <i class="fa fa-calendar"></i>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div>
                                                <div id="sectorExpExpActionMsg">
                                                </div>
                                                <div id="SectorExpExpAddBtns">
                                                    <a href="javascript:void(0)" onclick="SectorExpExperienceAdd(null, sector_experience_records, 'sectorExpExpActionMsg');"
                                                        class="btn btn-default btn-file"><i class="fa fa-plus"></i>Add Experience</a>
                                                </div>
                                                <div id="SectorExpExpEditBtns" class="hide">
                                                    <a href="javascript:void(0)" onclick="SectorExpExperienceSave(this, sector_experience_records, 'sectorExpExpActionMsg');"
                                                        class="btn btn-default btn-file btn-edit"><i class="fa fa-save"></i>Save</a>
                                                    <a href="javascript:void(0)" onclick="EditCancel('SectorExpExpAddBtns','SectorExpExpEditBtns', 'secExpExpFormWrap', 'secExpExperienceTable');"
                                                        class="btn btn-default btn-file"><i class="fa fa-remove"></i>Cancel</a>
                                                </div>
                                            </div>
                                            <div class="col-md-12">
                                                <div id="secExpExperienceTable" class="table-responsive">
                                                    <table class="table table-striped">
                                                        <thead>
                                                            <tr>
                                                                <th>
                                                                    Company
                                                                </th>
                                                                <th>
                                                                    Title / Role
                                                                </th>
                                                                <th>
                                                                    Location
                                                                </th>
                                                                <th>
                                                                    Start
                                                                </th>
                                                                <th>
                                                                    End
                                                                </th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                            <hr />
                                            <div id="secExpRefFormWrap">
                                                <h4>
                                                    References</h4>
                                                <div class="form-group experience-detail">
                                                    <div class="col-md-6">
                                                        <label for="title">
                                                            Name
                                                        </label>
                                                        <asp:TextBox ID="secExpRefName" runat="server" CssClass="form-control" placeholder="Reference name"
                                                            ClientIDMode="Static" />
                                                        <asp:PlaceHolder ID="PlaceHolder5" runat="server" Visible="false">
                                                            <label for="tbJobTitle" class="error">
                                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral5" runat="server" SetLanguageCode="LabelThisFieldIsRequired" />
                                                            </label>
                                                        </asp:PlaceHolder>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <label for="company">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral6" runat="server" SetLanguageCode="LabelCompanyName" />
                                                        </label>
                                                        <asp:TextBox ID="secExpRefComp" runat="server" CssClass="form-control" placeholder="Company Name"
                                                            ClientIDMode="Static" />
                                                        <asp:PlaceHolder ID="PlaceHolder6" runat="server" Visible="false">
                                                            <label for="tbCompanyName" class="error">
                                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral10" runat="server" SetLanguageCode="LabelThisFieldIsRequired" />
                                                            </label>
                                                        </asp:PlaceHolder>
                                                    </div>
                                                </div>
                                                <div class="form-group experience-detail">
                                                    <div class="col-md-12">
                                                        <label for="title">
                                                            Role
                                                        </label>
                                                        <asp:TextBox ID="secExpRefRole" runat="server" CssClass="form-control" placeholder="Reference role in the company"
                                                            ClientIDMode="Static" />
                                                    </div>
                                                </div>
                                                <div class="form-group experience-date">
                                                    <div class="col-md-6">
                                                        <label for="start-date">
                                                            Phone
                                                        </label>
                                                        <asp:TextBox ID="secExpRefPhone" runat="server" CssClass="form-control" placeholder="Reference phone contact"
                                                            ClientIDMode="Static" />
                                                    </div>
                                                    <div class="col-md-6">
                                                        <label for="end-date">
                                                            Email
                                                        </label>
                                                        <asp:TextBox ID="secExpRefEmail" runat="server" CssClass="form-control" placeholder="Reference email contact"
                                                            ClientIDMode="Static" />
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div>
                                                <div id="sectorRefActionMsg">
                                                </div>
                                                <div id="SectorExpRefAddBtns">
                                                    <a href="javascript:void(0)" onclick="SectorExpReferenceAdd(null, sector_reference_records, 'sectorRefActionMsg');"
                                                        class="btn btn-default btn-file"><i class="fa fa-plus"></i>Add Reference</a>
                                                </div>
                                                <div id="SectorExpRefEditBtns" class="hide">
                                                    <a href="javascript:void(0)" onclick="SectorExpReferenceSave(this, sector_reference_records, 'sectorRefActionMsg');"
                                                        class="btn btn-default btn-file btn-edit"><i class="fa fa-save"></i>Save</a>
                                                    <a href="javascript:void(0)" onclick="EditCancel('SectorExpRefAddBtns','SectorExpRefEditBtns', 'secExpRefFormWrap', 'secExpRefTable');"
                                                        class="btn btn-default btn-file"><i class="fa fa-remove"></i>Cancel</a>
                                                </div>
                                            </div>
                                            <div class="col-md-12">
                                                <div id="secExpRefTable" class="table-responsive">
                                                    <table class="table table-striped">
                                                        <thead>
                                                            <tr>
                                                                <th>
                                                                    Name
                                                                </th>
                                                                <th>
                                                                    Company
                                                                </th>
                                                                <th>
                                                                    Role
                                                                </th>
                                                                <th>
                                                                    Phone
                                                                </th>
                                                                <th>
                                                                    Email
                                                                </th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </asp:PlaceHolder>
                                    <asp:PlaceHolder ID="PlaceHolder3" runat="server" Visible="true">
                                        <div class="tab-pane" id="education" role="tabpanel">
                                            <h3>
                                                Education History</h3>
                                            <div id="eduHistFormWrap">
                                                <div class="form-group qualification-details">
                                                    <div class="col-md-6">
                                                        <label class="control-label" for="institution">
                                                            <JXTControl:ucLanguageLiteral ID="ucInstitutionName" runat="server" SetLanguageCode="LabelInstitutionName" />
                                                        </label>
                                                        <asp:TextBox ID="tbEduInstitution" runat="server" CssClass="form-control" MaxLength="150"
                                                            ClientIDMode="Static" placeholder="University of Sydney" />
                                                    </div>
                                                    <div class="col-md-6">
                                                        <label class="control-label" for="qualification-title">
                                                            Degree
                                                        </label>
                                                        <asp:DropDownList ID="ddlEduDegree" runat="server" CssClass="form-control" ClientIDMode="Static" />
                                                    </div>
                                                </div>
                                                <div class="form-group qualification-dates">
                                                    <div class="col-md-6">
                                                        <label class="control-label" for="institution">
                                                            Major
                                                        </label>
                                                        <asp:TextBox ID="tbEduMajor" runat="server" CssClass="form-control" MaxLength="150"
                                                            ClientIDMode="Static" placeholder="Degree major" />
                                                    </div>
                                                    <div class="col-md-6">
                                                        <label class="control-label" for="startdate">
                                                            Graduation Year
                                                        </label>
                                                        <div class='controls' id='startdate'>
                                                            <asp:DropDownList ID="ddlEduGradYear" runat="server" CssClass="form-control" ClientIDMode="Static" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div>
                                                <div id="eduHistActionMsg">
                                                </div>
                                                <div id="EduHistAddBtns">
                                                    <a href="javascript:void(0)" onclick="EducationAdd(null, education_history_records, 'eduHistActionMsg');"
                                                        class="btn btn-default btn-file"><i class="fa fa-plus"></i>Add Education History</a>
                                                </div>
                                                <div id="EduHistEditBtns" class="hide">
                                                    <a href="javascript:void(0)" onclick="EducationSave(this, education_history_records, 'eduHistActionMsg');"
                                                        class="btn btn-default btn-file btn-edit"><i class="fa fa-save"></i>Save</a>
                                                    <a href="javascript:void(0)" onclick="EditCancel('EduHistAddBtns','EduHistEditBtns', 'eduHistFormWrap', 'eduHistoryTable');"
                                                        class="btn btn-default btn-file"><i class="fa fa-remove"></i>Cancel</a>
                                                </div>
                                            </div>
                                            <div class="col-md-12">
                                                <div id="eduHistoryTable" class="table-responsive">
                                                    <table class="table table-striped">
                                                        <thead>
                                                            <tr>
                                                                <th>
                                                                    Institution
                                                                </th>
                                                                <th>
                                                                    Degree
                                                                </th>
                                                                <th>
                                                                    Major
                                                                </th>
                                                                <th>
                                                                    Grad Year
                                                                </th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </asp:PlaceHolder>
                                    <ul class="pager wizard">
                                        <asp:HiddenField ID="hfCurrentTab" runat="server" ClientIDMode="Static" />
                                        <li class="previous"><a href="#" id="formPrevBtn" class="hide" onclick="ShowPrevTab();">
                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral25" runat="server" SetLanguageCode="LabelBtnPrevious" />
                                        </a></li>
                                        <li class="next"><a href="#" id="formNextBtn" onclick="ShowNextTab();">
                                            <JXTControl:ucLanguageLiteral ID="ucButtonSave" runat="server" SetLanguageCode="LabelNext" />
                                        </a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </asp:PlaceHolder>
                    <!-- CV-Builder -->
                </div>
            </div>
        </div>
    </div>
</asp:Content>
