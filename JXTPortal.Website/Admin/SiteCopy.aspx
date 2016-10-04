<%@ Page Title="Sites - Site Copy" Language="C#" MasterPageFile="~/MasterPages/admin.Master"
    AutoEventWireup="true" CodeBehind="SiteCopy.aspx.cs" Inherits="JXTPortal.Website.Admin.SiteCopy" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Site Copy
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="toolkitScriptManager" runat="server" CombineScripts="true"
        ScriptMode="Release">
    </ajaxToolkit:ToolkitScriptManager>
    <script language="javascript" type="text/javascript">
     
        function client_OnTreeNodeChecked(e) {
            var ev;
            if (window.event)
            { ev = window.event; }
            else { ev = e; }
            var obj = (ev.srcElement || ev.target);
            var treeNodeFound = false;
            var checkedState;
            if (obj.tagName == "INPUT" && obj.type == "checkbox") {
                var treeNode = obj;
                checkedState = treeNode.checked;
                do {
                    obj = (obj.parentElement || obj.parentNode);
                } while (obj.tagName != "TABLE")

                if ((obj.parentElement || obj.parentNode).previousSibling.innerHTML.indexOf("tbody>") > 0 || (obj.parentElement || obj.parentNode).previousSibling.innerHTML.indexOf("TBODY>") > 0) {
                    var prevObj;
                    prevObj = (obj.parentElement || obj.parentNode).previousSibling;
                    prevObj.getElementsByTagName("input")[0].checked = true;
                }

                var parentTreeLevel = obj.rows[0].cells.length;
                var parentTreeNode = obj.rows[0].cells[0];
                var tables = (obj.parentElement || obj.parentNode).getElementsByTagName("TABLE");
                var numTables = tables.length
                if (numTables >= 1) {
                    for (i = 0; i < numTables; i++) {
                        if (tables[i] == obj) {
                            treeNodeFound = true;
                            i++;
                            if (i == numTables) {
                                return;
                            }
                        }
                        if (treeNodeFound == true) {
                            var childTreeLevel = tables[i].rows[0].cells.length;
                            if (childTreeLevel > parentTreeLevel) {
                                var cell = tables[i].rows[0].cells[childTreeLevel - 1];
                                var inputs = cell.getElementsByTagName("INPUT");
                                inputs[0].checked = checkedState;
                            }
                            else {
                                return;
                            }
                        }
                    }
                }
            }
        }
    </script>
    <div class="form-all">
        <strong>
            <asp:Literal ID="ltlMessage" runat="server"></asp:Literal></strong>
        <ajaxToolkit:TabContainer ID="tabContainerSiteCopy" runat="server" Width="800px"
            ActiveTabIndex="4">
            <ajaxToolkit:TabPanel ID="tabPanelSites" runat="server" HeaderText="Sites">
                <HeaderTemplate>
                    Sites
                </HeaderTemplate>
                <ContentTemplate>
                    <ul class="form-section">
                        <li class="form-line" id="adv-accountsettings-field">
                            <label class="form-label-left">
                                <strong>Site:</strong></label>
                            <div class="form-input">
                                <asp:DropDownList ID="ddlSites" runat="server">
                                </asp:DropDownList>
                            </div>
                        </li>
                        <li class="form-line" id="reg-bottom-button">
                            <div class="form-input-wide">
                                <div class="form-buttons-wrapper">
                                    <asp:Button ID="btnNextOptions" runat="server" Text="Next" CausesValidation="False"
                                        OnClick="btnNextOptions_Click" CssClass="jxtadminbutton" />
                                </div>
                            </div>
                        </li>
                    </ul>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="tabPanelOptions" runat="server" HeaderText="Global" Enabled="false">
                <ContentTemplate>
                    <ul class="form-section">
                        <li class="form-line" id="Li1">
                            <label class="form-label-left">
                                <strong>Site Name:</strong></label>
                            <div class="form-input">
                                <asp:TextBox ID="txtSiteName" runat="server" />
                                <asp:RequiredFieldValidator ID="ReqVal_SiteName" runat="server" ControlToValidate="txtSiteName"
                                    ErrorMessage="Required" Display="Dynamic" ValidationGroup="Global" />
                                <asp:CustomValidator ID="CusVal_Name" runat="server" ControlToValidate="txtSiteName"
                                    Display="Dynamic" ValidationGroup="Global" />
                            </div>
                        </li>
                        <li class="form-line" id="Li2">
                            <label class="form-label-left">
                                <strong>URL:</strong></label>
                            <div class="form-input">
                                <asp:TextBox ID="txtSiteUrl" runat="server" />
                                <asp:RequiredFieldValidator ID="ReqVal_URL" runat="server" ControlToValidate="txtSiteUrl"
                                    ErrorMessage="Required" Display="Dynamic" ValidationGroup="Global" />
                                <asp:CustomValidator ID="CusVal_URL" runat="server" ControlToValidate="txtSiteUrl"
                                    Display="Dynamic" ValidationGroup="Global" />
                            </div>
                        </li>
                        <li class="form-line" id="Li3">
                            <label class="form-label-left">
                                <strong>Description:</strong></label>
                            <div class="form-input">
                                <asp:TextBox ID="txtDescription" runat="server" />
                            </div>
                        </li>
                        <li class="form-line" id="Li5">
                            <label class="form-label-left">
                                <strong>File Manager Folder name:</strong></label>
                            <div class="form-input">
                                <asp:TextBox ID="txtFtpFolderLocation" runat="server" />
                                <asp:RequiredFieldValidator ID="ReqVal_FTP" runat="server" ControlToValidate="txtFtpFolderLocation"
                                    ErrorMessage="Required" Display="Dynamic" ValidationGroup="Global" />
                                (Please create the Folder in FTP Site)
                            </div>
                        </li>
                        <li class="form-line" id="Li4">
                            <label class="form-label-left">
                            </label>
                            <div class="form-input">
                                <asp:CheckBox ID="chkGlobalSettings" runat="server" Text="Global Settings" Checked="true"
                                    Enabled="false" />
                            </div>
                        </li>
                        <li class="form-line" id="Li6">
                            <label class="form-label-left">
                            </label>
                            <div class="form-input">
                                <asp:CheckBox ID="chkSiteLocation" runat="server" Text="Locations / Areas" Checked="true" />
                            </div>
                        </li>
                        <li class="form-line" id="Li19">
                            <label class="form-label-left">
                            </label>
                            <div class="form-input">
                                <asp:CheckBox ID="chkUseCustomProfessionRoles" runat="server" Text="Use Custom Profession Roles"
                                    AutoPostBack="true" OnCheckedChanged="chkUseCustomProfessionRoles_CheckedChanged"
                                    CausesValidation="false" />
                            </div>
                        </li>
                        <li class="form-line" id="Li7">
                            <label class="form-label-left">
                            </label>
                            <div class="form-input">
                                <asp:CheckBox ID="chkProfessionRoles" runat="server" Text="Profession / Roles" Checked="true" />
                            </div>
                        </li>
                        <li class="form-line" id="Li8">
                            <label class="form-label-left">
                            </label>
                            <div class="form-input">
                                <asp:CheckBox ID="chkSalaryTypes" runat="server" Text="Salary Types" Checked="true" />
                            </div>
                        </li>
                        <li class="form-line" id="Li9">
                            <label class="form-label-left">
                            </label>
                            <div class="form-input">
                                <asp:CheckBox ID="chkWorkTypes" runat="server" Text="Work Types" Checked="true" />
                            </div>
                        </li>
                        <li class="form-line" id="Li10">
                            <label class="form-label-left">
                            </label>
                            <div class="form-input">
                                <asp:CheckBox ID="chkEducation" runat="server" Text="Education" Checked="true" />
                            </div>
                        </li>
                        <li class="form-line" id="Li11">
                            <label class="form-label-left">
                            </label>
                            <div class="form-input">
                                <asp:CheckBox ID="chkAvailableStatus" runat="server" Text="Available Status" Checked="true" />
                            </div>
                        </li>
                        <li class="form-line" id="Li12">
                            <label class="form-label-left">
                            </label>
                            <div class="form-input">
                                <asp:CheckBox ID="chkWidgets" runat="server" Text="Widgets" Checked="true" />
                            </div>
                        </li>
                        <li class="form-line" id="Li13">
                            <label class="form-label-left">
                            </label>
                            <div class="form-input">
                                <asp:CheckBox ID="chkEmailTemplates" runat="server" Text="Email Templates" Checked="true" />
                            </div>
                        </li>
                        <li class="form-line" id="Li14">
                            <label class="form-label-left">
                            </label>
                            <div class="form-input">
                                <asp:CheckBox ID="chkWebParts" runat="server" Text="Web Parts" Checked="true" Enabled="false" />
                            </div>
                        </li>
                        <li class="form-line" id="Li15">
                            <div class="form-input-wide">
                                <div class="form-buttons-wrapper">
                                    <asp:Button ID="btnDataImport" runat="server" Text="Next" OnClick="btnNextDataImport_Click"
                                        ValidationGroup="Global" CssClass="jxtadminbutton" />
                                </div>
                            </div>
                        </li>
                    </ul>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="tabPanelDataImport" runat="server" HeaderText="Data Import"
                Enabled="false">
                <ContentTemplate>
                    <asp:CheckBox ID="cbImportAdminUser" runat="server" AutoPostBack="false" Text=" Create Admin User" Checked="true"
                        Font-Bold="true" />
                    <ul class="form-section">
                        <li class="form-line" id="Li37">
                            <label class="form-label-left">
                                &nbsp;
                            </label>
                            <div class="form-input">
                                <asp:CustomValidator ID="cvImportAdminUser" runat="server" Display="Dynamic" ValidationGroup="DataImport" SetFocusOnError="true" ErrorMessage="Please fill in all Admin User fields" OnServerValidate="cvImportAdminUser_ServerValidate" />
                            </div>
                        </li>
                        <li class="form-line" id="Li32">
                            <label class="form-label-left">
                                First Name:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="tbAdminFirstName" runat="server" Text="Admin" />
                            </div>
                        </li>
                        <li class="form-line" id="Li33">
                            <label class="form-label-left">
                                Last Name:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="tbAdminLastName" runat="server" Text="User" />
                            </div>
                        </li>
                        <li class="form-line" id="Li34">
                            <label class="form-label-left">
                                Email:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="tbAdminEmail" runat="server" Text="forms@jxt.com.au" />
                            </div>
                        </li>
                        <li class="form-line" id="Li35">
                            <label class="form-label-left">
                                Username:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="tbAdminUsername" runat="server" Text="admin_user" />
                            </div>
                        </li>
                        <li class="form-line" id="Li36">
                            <label class="form-label-left">
                                Password:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="tbAdminPassword" runat="server" Text="Admin!@" />
                            </div>
                        </li>
                    </ul>
                    <br /><br />
                    <asp:CheckBox ID="cbImportMember" runat="server" AutoPostBack="false" Text=" Create Member" Checked="true"
                        Font-Bold="true" />
                    <ul class="form-section">
                        <li class="form-line" id="Li38">
                            <label class="form-label-left">
                                &nbsp;
                            </label>
                            <div class="form-input">
                                <asp:CustomValidator ID="cvImportMember" runat="server" Display="Dynamic" ValidationGroup="DataImport" SetFocusOnError="true" ErrorMessage="Please fill in all Member fields" OnServerValidate="cvImportMember_ServerValidate" />
                            </div>
                        </li>
                        <li class="form-line" id="Li22">
                            <label class="form-label-left">
                                First Name:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="tbMemberFirstName" runat="server" Text="Member" />
                            </div>
                        </li>
                        <li class="form-line" id="Li23">
                            <label class="form-label-left">
                                Last Name:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="tbMemberLastName" runat="server" Text="User" />
                            </div>
                        </li>
                        <li class="form-line" id="Li21">
                            <label class="form-label-left">
                                Email:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="tbMemberEmail" runat="server" Text="forms@jxt.com.au" />
                            </div>
                        </li>
                        <li class="form-line" id="Li30">
                            <label class="form-label-left">
                                Username:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="tbMemberUsername" runat="server" Text="member_user" />
                            </div>
                        </li>
                        <li class="form-line" id="Li24">
                            <label class="form-label-left">
                                Password:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="tbMemberPassword" runat="server" Text="Member!@" />
                            </div>
                        </li>
                    </ul>
                    <br /><br />
                    <asp:CheckBox ID="cbImportAdvertiser" runat="server" AutoPostBack="false" Checked="true" Text=" Create Advertiser / Advertiser User"
                        Font-Bold="true" ClientIDMode="Static" />
                    <ul class="form-section">
                        <li class="form-line" id="Li39">
                            <label class="form-label-left">
                                &nbsp;
                            </label>
                            <div class="form-input">
                                <asp:CustomValidator ID="cvImportAdvertiser" runat="server" Display="Dynamic" ValidationGroup="DataImport" SetFocusOnError="true" ErrorMessage="Please fill in all Advertiser fields" OnServerValidate="cvImportAdvertiser_ServerValidate" />
                            </div>
                        </li>
                        <li class="form-line" id="Li25">
                            <label class="form-label-left">
                                First Name:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="tbAdvertiserFirstName" runat="server" Text="Advertiser" />
                            </div>
                        </li>
                        <li class="form-line" id="Li26">
                            <label class="form-label-left">
                                Last Name:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="tbAdvertiserLastName" runat="server" Text="User" />
                            </div>
                        </li>
                        <li class="form-line" id="Li27">
                            <label class="form-label-left">
                                Email:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="tbAdvertiserEmail" runat="server" Text="forms@jxt.com.au" />
                            </div>
                        </li>
                        <li class="form-line" id="Li29">
                            <label class="form-label-left">
                                Company Name:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="tbAdvertiserCompanyName" runat="server" Text="JXT Consulting" />
                            </div>
                        </li>
                        <li class="form-line" id="Li31">
                            <label class="form-label-left">
                                Username:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="tbAdvertiserUsername" runat="server" Text="advertiser" />
                            </div>
                        </li>
                        <li class="form-line" id="Li28">
                            <label class="form-label-left">
                                Password:
                            </label>
                            <div class="form-input">
                                <asp:TextBox ID="tbAdvertiserPassword" runat="server" Text="Advertiser!@" />
                            </div>
                        </li>
                    </ul><br /><br />
                    <div id="divJobTemplate">
                        <asp:Repeater ID="rptJobTemplate" runat="server" OnItemDataBound="rptJobTemplate_ItemDataBound">
                            <HeaderTemplate>
                                <strong>Import Job Templates (Under Advertiser)</strong>
                                <ul class="form-section">
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li class="form-line" id="Li1">
                                    <asp:CheckBox ID="chkJobTemplate" runat="server" />
                                    <asp:HiddenField ID="hfJobTemplateID" runat="server" />
                                    <asp:Literal ID="ltJobTemplate" runat="server" />
                                </li>
                            </ItemTemplate>
                            <FooterTemplate>
                                </ul>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                    <ul class="form-section">
                        <li class="form-line" id="Li20">
                            <div class="form-input-wide">
                                <div class="form-buttons-wrapper">
                                    <asp:Button ID="btnPreviousSite" runat="server" Text="Previous" CssClass="jxtadminbutton" OnClick="btnPreviousOptions_Click" />
                                    <asp:Button ID="btnNextLanguage" runat="server" Text="Next" OnClick="btnNextLanguage_Click"
                                        ValidationGroup="DataImport" CssClass="jxtadminbutton" />
                                </div>
                            </div>
                        </li>
                    </ul>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="tabPanelLanguages" runat="server" HeaderText="Languages"
                Enabled="false">
                <ContentTemplate>
                    Display List of Languages with checkboxes<br />
                    <br />
                    <asp:CheckBoxList ID="chkLanguages" runat="server" RepeatLayout="Flow">
                    </asp:CheckBoxList>
                    <br />
                    <asp:CustomValidator ID="CusValLanguage" runat="server" ErrorMessage="Please select a Language"
                        ValidationGroup="Language" />
                    <ul class="form-section">
                        <li class="form-line" id="Li16">
                            <div class="form-input-wide">
                                <div class="form-buttons-wrapper">
                                    <asp:Button ID="btnPreviousDataImport" runat="server" Text="Previous" CssClass="jxtadminbutton"
                                        OnClick="btnPreviousDataImport_Click" />
                                    <asp:Button ID="btnNextDynamicPages" runat="server" Text="Next" ValidationGroup="Language"
                                        CssClass="jxtadminbutton" />
                                </div>
                            </div>
                        </li>
                    </ul>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="tabPanelDynamicPages" runat="server" HeaderText="Dynamic Pages"
                Enabled="false">
                <ContentTemplate>
                    Display List of Dynamic Pages with Languages tab<br />
                    <br />
                    <asp:Repeater ID="rptLanguages" runat="server" OnItemDataBound="rptLanguages_ItemDataBound">
                        <ItemTemplate>
                            <ul class="form-section">
                                <li class="form-line" id="Li1">
                                    <label class="form-label-left">
                                        <strong>
                                            <asp:Literal ID="litLanguage" runat="server" /></strong>
                                    </label>
                                </li>
                            </ul>
                            <div id="tree-section-container">
                                <asp:TreeView ID="tvDynamicPages" runat="server" ShowCheckBoxes="All" onclick="client_OnTreeNodeChecked(event);">
                                </asp:TreeView>
                            </div>
                            <asp:Repeater ID="rptDynamicPages" runat="server" OnItemDataBound="rptDynamicPages_ItemDataBound">
                                <HeaderTemplate>
                                    <ul class="form-section">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li class="form-line" id="Li1">
                                        <asp:Literal ID="ltlSpacing" runat="server" /><asp:CheckBox ID="chkDynamicPage" runat="server"
                                            onclick="client_OnTreeNodeChecked(this);" />
                                        <asp:Literal ID="ltlDynamicPage" runat="server" />
                                    </li>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ul>
                                </FooterTemplate>
                            </asp:Repeater>
                            <br />
                            <br />
                        </ItemTemplate>
                    </asp:Repeater>
                    <ul class="form-section">
                        <li class="form-line" id="Li17">
                            <div class="form-input-wide">
                                <div class="form-buttons-wrapper">
                                    <asp:Button ID="btnPreviousLanguages" runat="server" Text="Previous" OnClick="btnPreviousLanguages_Click"
                                        CssClass="jxtadminbutton" />
                                    <asp:Button ID="btnNextFileManagement" runat="server" Text="Next" OnClick="btnNextFileManagement_Click"
                                        CssClass="jxtadminbutton" />
                                </div>
                            </div>
                        </li>
                    </ul>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="tabPanelFileManagement" runat="server" HeaderText="File Management"
                Enabled="false">
                <HeaderTemplate>
                    File Management
                </HeaderTemplate>
                <ContentTemplate>
                    <asp:Repeater ID="rptFileManagement" runat="server" OnItemDataBound="rptFileManagement_ItemDataBound">
                        <HeaderTemplate>
                            <ul class="form-section">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Literal ID="ltlHeading" runat="server" />
                            <li class="form-line" id="Li1">&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="chkFile" runat="server" />
                                <asp:Literal ID="ltlFile" runat="server" />
                                <asp:HiddenField ID="hfFile" runat="server" />
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                        </FooterTemplate>
                    </asp:Repeater>
                    <ul class="form-section">
                        <li class="form-line" id="Li18">
                            <div class="form-input-wide">
                                <div class="form-buttons-wrapper">
                                    <asp:Button ID="btnPreviousFileManagement" runat="server" Text="Previous" OnClick="btnPreviousFileManagement_Click"
                                        CssClass="jxtadminbutton" />
                                    <asp:Button ID="btnCopy" runat="server" Text="Copy" OnClick="btnCopy_Click" CssClass="jxtadminbutton" />
                                </div>
                            </div>
                        </li>
                    </ul>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
        <script type="text/javascript">
            if ($('input.ckparent').length) {
                $('input.ckparent').click(function (event) {
                    var checked = $(this).is(':checked');
                    var parentID = $(this).attr('parentid');

                    if (checked) {
                        $('input[parentid="' + parentID + '"]').attr('checked', 'true');
                    }
                    else {
                        $('input[parentid="' + parentID + '"]').attr('checked', '');
                    }
                });
            }
            if ($('input.ckchild1').length) {
                $('input.ckchild1').click(function (event) {
                    var checked = $(this).is(':checked');

                    var parentID = $(this).attr('parentid');

                    if (checked) {
                        //$('input[parentid=' + parentID + ']).ckchild2').attr('checked', 'true');
                        $(this).nextAll('input[parentid=' + parentID + ']).ckchild2').attr('checked', 'true');
                        $('input[parentid=' + parentID + '].ckparent').attr('checked', 'true');
                    }
                    else {
                        $('input[parentid=' + parentID + '].ckchild2').attr('checked', '');
                    }
                });
            }
            if ($('input.ckchild2').length) {
                $('input.ckchild2').click(function (event) {
                    var checked = $(this).is(':checked');

                    var parentID = $(this).attr('parentid');

                    if (checked) {
                        //alert($(this).prev('.ckchild1').attr('id'));
                        $(this).prevAll('.ckchild1').attr('checked', 'true');
                        $('input[parentid=' + parentID + '].ckparent').attr('checked', 'true');

                    }
                    else {

                    }

                });
            }

            if ($('#cbImportAdvertiser').prop("checked")) {
                $("#divJobTemplate").show();
            }

            $('#cbImportAdvertiser').change(function () {
                if ($(this).prop("checked")) {
                    $("#divJobTemplate").show();
                }
                else {
                    $("#divJobTemplate").hide();
                }
                // not checked
            });
        </script>
    </div>
</asp:Content>
