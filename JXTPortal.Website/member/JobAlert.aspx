<%@ Page Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="JobAlert.aspx.cs" Inherits="JXTPortal.Website.members.JobAlert" %>

<%--<%@ Register Src="~/usercontrols/job/ucJobAlert.ascx" TagName="ucJobAlert" TagPrefix="uc1" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="//images.jxt.net.au/mining-people-2014/css/alert.css" />
    <script type="text/javascript" src="/scripts/strength.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
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
    <asp:ScriptManager ID="scriptManager" runat="server" />
    <%--<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>--%>
    <%--<script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.1/js/bootstrap.min.js"></script>--%>
    <%--if (this.Page.Master.FindControl("ltlMetaContent") != null && !(((Literal)this.Page.Master.FindControl("ltlMetaContent")).Text.Contains("bootstrap.min.js")))
       { %>
    <script src='//images.jxt.net.au/COMMON/cvbuilder/js/lib/bootstrap.min.js' type="text/javascript"></script>
    <% } --%>
    <asp:HiddenField ID="hfDefaultCountryID" runat="server" />
    <div class="container-fluid BoardyCreateAlertContainer uniForm">
        <div class="row alert-header-section">
            <div class="col-sm-12">
                <JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage" runat="server" SetSystemPageCode="SystemPage_MemberCreateJobAlert" />
            </div>
        </div>
        <!-- top level alerts -->
        <!-- <div class="alert alert-danger" role="alert">Please check and correct the errors below</div>
		<div class="alert alert-success" role="alert">Congratulations, your alert has been created</div>
		<div class="alert alert-success" role="alert">Congratulations, your favourite search has been saved</div> -->
        <!-- if user is logged in, Ca-ProfileSection will be hidden from view and required fields will not be relevant -->
        <asp:PlaceHolder ID="phProfileSection" runat="server">
            <div class="row alert-row-level Ca-ProfileSection1">
                <asp:Literal ID="ltlMessage" runat="server" />
                <div class="col-sm-6">
                    <div class="form-group">
                        <label>
                            <JXTControl:ucLanguageLiteral ID="ltFirstName" runat="server" SetLanguageCode="LabelFirstName" />
                            <span class="form-required">*</span></label>
                        <asp:TextBox ID="tbFirstName" runat="server" size="50" class="form-control" placeholder="First Name"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="tbFirstName"
                            Display="Dynamic" CssClass="error" ErrorMessage="First name is required" />
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="form-group">
                        <label>
                            <JXTControl:ucLanguageLiteral ID="ltSurname" runat="server" SetLanguageCode="LabelSurname" />
                            <span class="form-required">*</span></label>
                        <asp:TextBox ID="tbSurname" runat="server" size="50" class="form-control" placeholder="Last Name"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="tbSurname"
                            CssClass="error" ErrorMessage="Last name is required" Display="Dynamic" />
                    </div>
                </div>
            </div>
            <div class="row alert-row-level Ca-ProfileSection2">
                <div class="col-sm-6">
                    <div class="form-group">
                        <label>
                            <JXTControl:ucLanguageLiteral ID="ltEmail" runat="server" SetLanguageCode="LabelEmail" />
                            <span class="form-required">*</span></label>
                        <asp:TextBox ID="tbEmail" runat="server" size="60" class="form-control" placeholder="Email"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="tbEmail"
                            CssClass="error" ErrorMessage="Email is required" Display="Dynamic" />
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="form-group">
                        <label>
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral3" runat="server" SetLanguageCode="LabelPassword" />
                            <span class="form-required">*</span></label>
                        <asp:TextBox ID="tbPassword" runat="server" class="form-control" placeholder="Password" TextMode="Password" autocomplete="off" ClientIDMode="Static"></asp:TextBox>
                        <p id="pPasswordError" class="help-block"><asp:RegularExpressionValidator ID="revPassword" runat="server" ErrorMessage="" Display="Dynamic" ClientIDMode="Static"
                                                        ControlToValidate="tbPassword" ValidationExpression="^(?=.{8,}$)(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9]).*$" /><JXTControl:ucLanguageLiteral ID="ltPasswordPrompt" runat="server" SetLanguageCode="LabelPasswordPrompt" /></p>
                    </div>
                </div>
                
            </div>
            <div class="row alert-row-level Ca-ProfileSection2">
                <div class="col-sm-6">
                    <div class="form-group">
                        <label>
                            <JXTControl:ucLanguageLiteral ID="ucPhoneMobile" runat="server" SetLanguageCode="LabelTelephone" />
                        </label>
                        <asp:TextBox ID="txtMobilePhone" runat="server" class="form-control" placeholder="Enter contact number" />
                        <!-- <span class="error">Last name is required</span> -->
                    </div>
                </div>
            </div>
        </asp:PlaceHolder>
        <div class="row alert-row-level Ca-AlertDetail">
            <div class="col-sm-6">
                <div class="form-group">
                    <!-- The label will require to be updated dynamically depending on the type (favourite or job alert) -->
                    <label>
                        <JXTControl:ucLanguageLiteral ID="ltMemberCreateAlertNameFeed" runat="server" SetLanguageCode="LabelNameOfFeed" />
                        <span class="form-required">*</span></label>
                    <asp:TextBox ID="txtNameOfTheFeed" runat="server" CssClass="form-control" placeholder="Enter name of alert" />
                    <asp:RequiredFieldValidator ID="rfvNameOfTheFeed" runat="server" ControlToValidate="txtNameOfTheFeed"
                        CssClass="error" ErrorMessage=" Name of alert/search is required" Display="Dynamic" />
                    <!-- <span class="error">Name of alert/search is required</span> -->
                </div>
            </div>
            <div class="col-sm-6">
                <div class="form-group">
                    <label>
                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral2" runat="server" SetLanguageCode="LabelKeyword" />
                    </label>
                    <asp:TextBox ID="txtKeywords" runat="server" CssClass="form-control" placeholder="Enter keyword eg: title of job" />
                    <%--<input type="text" class="form-control" id="name-of-alert" placeholder="Enter keyword eg: title of job">--%>
                </div>
            </div>
        </div>
       
        <div class="row alert-row-level">

        <div class="col-sm-6">
            <div id="divClassificationSection" class="Ca-ClassSection">
                <label for="">
                    <JXTControl:ucLanguageLiteral ID="ltClassifications" runat="server" SetLanguageCode="LabelClassifications" />
                </label>
                <div class="boardy-checkbox-holder">
                    <asp:Repeater ID="rptClassification" runat="server" OnItemDataBound="rptClassification_ItemDataBound">
                        <ItemTemplate>
                            <div class="checkbox">
                                <label>
                                    <asp:HiddenField ID="hfClassification" runat="server" />
                                    <asp:CheckBox ID="cbClassification" runat="server" />
                                    <asp:Literal ID="ltClassification" runat="server" />
                                </label>
                            </div>
                            <asp:Repeater ID="rptSubClassification" runat="server" OnItemDataBound="rptSubClassification_ItemDataBound">
                                <ItemTemplate>
                                    <div id="divSubClassification" runat="server" class="checkbox Ca-ChildRecord">
                                        <label>
                                            <asp:HiddenField ID="hfSubClassification" runat="server" />
                                            <asp:CheckBox ID="cbSubClassification" runat="server" />
                                            <asp:Literal ID="ltSubClassification" runat="server" />
                                        </label>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <asp:HiddenField ID="hfProfessionSelected" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hfRoleSelected" runat="server" ClientIDMode="Static" />
                <!-- end of checkbox holder -->
            </div>
            <!-- end of sm4 div -->
            
            </div>

      <div class="col-sm-6">


            <asp:UpdatePanel ID="upSubClassification" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="Ca-CountrySection">
                        <label for="">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelCountry" />
                            <span class="form-required">*</span></label>
                        <div id="divCountry" class="boardy-checkbox-holder">
                            <asp:Repeater ID="rptCountry" runat="server" OnItemDataBound="rptCountry_ItemDataBound">
                                <ItemTemplate>
                                    <div class="checkbox">
                                        <label>
                                            <asp:HiddenField ID="hfCountry" runat="server" />
                                            <asp:CheckBox ID="cbCountry" runat="server" CausesValidation="false" AutoPostBack="true"
                                                OnCheckedChanged="cbCountry_CheckedChanged" onclick="$('#divCountry input').prop('disabled', true);$('#divLocAreaSection input').prop('disabled', true); CountryChanged();" />
                                            <asp:Literal ID="ltCountry" runat="server" />
                                        </label>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <!-- <span class="error">Please select country first</span> -->
                        <asp:CustomValidator ID="cvCountry" runat="server" CssClass="error" ErrorMessage="Please select country first"
                            OnServerValidate="cvCountry_ServerValidate" />
                        <!-- end of checkbox holder -->
                    </div>
                    <!-- end of sm4 div -->
                    <div id="divLocAreaSection" class="Ca-LocAreaSection">
                        <label for="">
                            <JXTControl:ucLanguageLiteral ID="ltUcJobAlertLocation" runat="server" SetLanguageCode="LabelLocation" />
                            /
                            <JXTControl:ucLanguageLiteral ID="ltUcJobAlertArea" runat="server" SetLanguageCode="LabelArea" />
                        </label>
                        <div class="boardy-checkbox-holder">
                            <asp:Repeater ID="rptCountryLocationArea" runat="server" OnItemDataBound="rptCountryLocationArea_ItemDataBound">
                                <ItemTemplate>
                                    <div>
                                        <h3>
                                            <asp:Literal ID="ltCountry" runat="server" />
                                        </h3>
                                    </div>
                                    <asp:Repeater ID="rptLocation" runat="server" OnItemDataBound="rptLocation_ItemDataBound">
                                        <ItemTemplate>
                                            <div class="checkbox">
                                                <label>
                                                    <asp:HiddenField ID="hfLocation" runat="server" />
                                                    <asp:CheckBox ID="cbLocation" runat="server" />
                                                    <asp:Literal ID="ltLocation" runat="server" />
                                                </label>
                                            </div>
                                            <asp:Repeater ID="rptArea" runat="server" OnItemDataBound="rptArea_ItemDataBound">
                                                <ItemTemplate>
                                                    <div id="divArea" runat="server" class="checkbox Ca-ChildRecord">
                                                        <label>
                                                            <asp:HiddenField ID="hfArea" runat="server" />
                                                            <asp:CheckBox ID="cbArea" runat="server" />
                                                            <asp:Literal ID="ltArea" runat="server" />
                                                        </label>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <!-- end of checkbox holder -->
                        <!-- <span class="error">Please select country first</span> -->
                    </div>
                    <asp:HiddenField ID="hfLocationSelected" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hfAreaSelected" runat="server" ClientIDMode="Static" />
                </ContentTemplate>
            </asp:UpdatePanel>

              <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                
                    <asp:Panel ID="phSalary" runat="server" Enabled="false" CssClass="Ca-SalarySection">
                        <label class="label-SalarySection">
                            <JXTControl:ucLanguageLiteral ID="ltUcJobAlertSalary" runat="server" SetLanguageCode="LabelSalary" />
                        </label>
                        <div class="form-group">
                            <asp:DropDownList ID="ddlSalaryType" runat="server" CssClass="form-control" onchange="SalaryChanged()"
                                ClientIDMode="Static">
                                <asp:ListItem Value="0">Please select salary type</asp:ListItem>
                                <asp:ListItem Value="1">Annually</asp:ListItem>
                                <asp:ListItem Value="2">Hourly</asp:ListItem>
                            </asp:DropDownList>
                            <!-- <span class="error">Please select salary type</span> -->
                        </div>
                        <div class="form-group">
                            <div class="col-sm-5 no-spacing">
                                <asp:TextBox ID="tbSalaryFrom" runat="server" CssClass="form-control" placeholder="From"
                                    Enabled="false" ClientIDMode="Static" />
                            </div>
                            <div class="col-sm-2 text-center salary-ToLabel">
                                to</div>
                            <div class="col-sm-5 no-spacing">
                                <asp:TextBox ID="tbSalaryTo" runat="server" CssClass="form-control" placeholder="To"
                                    Enabled="false" ClientIDMode="Static" />
                            </div>
                        </div>
                        <!-- <span class="error">Please enter numeric values only</span> -->
                    </asp:Panel>
             
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="clearfix"></div>
            <div class="Ca-WorktypeSection">
                <label class="label-WorktypeSection">
                    <JXTControl:ucLanguageLiteral ID="ltWorkType" runat="server" SetLanguageCode="LabelWorkType" />
                </label>
                <div class="boardy-checkbox-holder">
                    <asp:Repeater ID="rptWorkType" runat="server" OnItemDataBound="rptWorkType_ItemDataBound">
                        <ItemTemplate>
                            <div class="checkbox">
                                <label>
                                    <asp:HiddenField ID="hfWorkType" runat="server" />
                                    <asp:CheckBox ID="cbWorkType" runat="server" />
                                    <asp:Literal ID="ltWorkType" runat="server" />
                                </label>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <!-- end of checkbox holder -->
            </div>


            </div>
        </div>
        <!-- end of sm4 div -->
      
        <div class="row alert-row-level">
            <div class="col-sm-6">
                <div class="checkbox">
                    <label class="Ca-CheckboxLabel">
                        <asp:CheckBox ID="chkSendEmailAlerts" runat="server" />
                        <JXTControl:ucLanguageLiteral ID="ltMemberCreateAlertMainAlert" runat="server" SetLanguageCode="LabelSendEmailAlerts" />
                        &nbsp;<img src="//images.jxt.net.au/mining-people-2014/images/info.svg" style="width:18px;" alt="" class="tip" data-toggle="tooltip" data-placement="top" title="By checking this option, you will enable all matching alerts to be sent to your nominated email address. Unchecking the option will save the record as a favourite search">
                    </label>
                </div>
            </div>
        </div>
        <!-- end of row -->
        <div class="row alert-row-level">
            <div class="col-sm-12">
                <asp:Button ID="btnSave" runat="server" Text="Create Alert" CssClass="mini-new-buttons btn btn-primary"
                    OnClick="btnSave_Click" OnClientClick="ApplyCheck(event);" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete Alert" CssClass="mini-new-buttons btn btn-primary"
                    OnClick="btnDelete_Click" Visible="false" />
            </div>
        </div>
        <JXTControl:ucPrivacySettings ID="ucPrivacySettings" runat="server" />
        <!-- end of container -->
        <script>
            $('.tip').tooltip();
        </script>
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

            function AreaChecked(areaid, locationid) {
                if ($('#' + areaid).prop('checked')) {
                    $('#' + locationid).prop('checked', true);
                }
                ResetLocationAreaSelected();
            }

            function LocationChecked(locationid) {
                var checked = $('#' + locationid).prop('checked');

                var el = document.getElementById(locationid);

                var topparent = el.parentNode.parentNode;
                var currentNode = topparent.nextSibling.nextSibling;

                while (currentNode) {
                    var cbArea = currentNode.getElementsByTagName("input")[1];
                    
                    currentNode = currentNode.nextSibling.nextSibling;
                    cbArea.checked = checked;
                    
                    if (currentNode == null || currentNode.className == "checkbox") {
                        break;
                    }

                    if (checked) {
                        $("#" + currentNode.id).show();
                    }
                    else {
                        $("#" + currentNode.id).hide();
                    }
                }

                ResetLocationAreaSelected();
            }

            function SubClassificationChecked(roleid, professionid) {
                if ($('#' + roleid).prop('checked')) {
                    $('#' + professionid).prop('checked', true);
                }

                ResetClassificationsSelected();
            }

            function ClassificationChecked(professionid) {
                var checked = $('#' + professionid).prop('checked');

                var el = document.getElementById(professionid);

                var topparent = el.parentNode.parentNode;
                var currentNode = topparent.nextSibling.nextSibling;

                while (currentNode) {
                    var cbArea = currentNode.getElementsByTagName("input")[1];

                    currentNode = currentNode.nextSibling.nextSibling;
                    cbArea.checked = checked;
                    
                    if (currentNode == null || currentNode.className == "checkbox") {
                        break;
                    }

                    if (checked) {
                        $("#" + currentNode.id).show();
                    }
                    else {
                        $("#" + currentNode.id).hide();
                    }
                }

                ResetClassificationsSelected();
            }

            function ResetLocationAreaSelected() {
                var strLocation = "";
                var strArea = "";
                var i;
                var list = $('#divLocAreaSection input');
                var input = list[i];
                var hidden;
                for (i = 0; i < list.length; i++) {
                    var input = list[i];
                    var hidden;

                    if (input.type == 'checkbox') {
                        input = list[i];
                        hidden = list[i - 1];

                        if (input.checked) {
                            if (input.id.indexOf('cbArea') > 0) {
                                strArea += hidden.value + ",";
                            }
                            else {
                                strLocation += hidden.value + ",";
                            }
                        }
                    }
                }

                $('#hfLocationSelected').val(strLocation);
                $('#hfAreaSelected').val(strArea);

            }

            function ResetClassificationsSelected() {
                var strProfession = "";
                var strRole = "";
                var i;
                var list = $('#divClassificationSection input');
                var input = list[i];
                var hidden;
                for (i = 0; i < list.length; i++) {
                    var input = list[i];
                    var hidden;

                    if (input.type == 'checkbox') {
                        input = list[i];
                        hidden = list[i - 1];

                        if (input.checked) {
                            if (input.id.indexOf('SubClassification') > 0) {
                                strRole += hidden.value + ",";
                            }
                            else {
                                strProfession += hidden.value + ",";
                            }
                        }
                    }
                }

                $('#hfProfessionSelected').val(strProfession);
                $('#hfRoleSelected').val(strRole);

            }

            function SalaryChanged() {
                var enabled = ($('#ddlSalaryType').val() != 0);
                if (enabled) {
                    $('#tbSalaryFrom').prop("disabled", false);
                    $('#tbSalaryTo').prop("disabled", false);
                }
                else {
                    $('#tbSalaryFrom').val('');
                    $('#tbSalaryTo').val('');
                    $('#tbSalaryFrom').prop("disabled", true);
                    $('#tbSalaryTo').prop("disabled", true);
                }
            }

            function CountryChanged() {
                if ($('#divCountry input:checked').length > 1) {
                    $('#ddlSalaryType').val('0')
                    $('#tbSalaryFrom').val('');
                    $('#tbSalaryTo').val('');
                    $('#ddlSalaryType').prop("disabled", true);
                    $('#tbSalaryFrom').prop("disabled", true);
                    $('#tbSalaryTo').prop("disabled", true);
                }
                else {
                    $('#ddlSalaryType').prop("disabled", false);
                }
            }

        </script>
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