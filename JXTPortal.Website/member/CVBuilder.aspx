<%@ Page Title="CV Builder" Language="C#" MasterPageFile="~/MasterPages/CustomMain.Master"
    AutoEventWireup="true" CodeBehind="CVBuilder.aspx.cs" Inherits="JXTPortal.Website.member.CVBuilder" %>

<%@ Register TagPrefix="uc1" Namespace="JXTPortal.Website.usercontrols.common" Assembly="JXTPortal.WebSite" %>
<%@ Register Src="/usercontrols/navigation/ucMemberAccountNavigation.ascx" TagName="ucMemberAccountNavigation"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Expires" content="-1">
    <link rel="stylesheet" href="//netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.css" />
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/cvbuilder/css/lib/bootstrap.min.css" />
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/cvbuilder/css/lib/bootstrap-fileupload.min.css" />
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/cvbuilder/css/lib/jquery.tagsinput.css" />
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/cvbuilder/css/lib/bootstrap-multiselect.css" />
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/cvbuilder/css/CV-Builder-style.css" />
    <!--[if lt IE 9]>
<script src="//images.jxt.net.au/COMMON/cvbuilder/js/lib/html5shiv.js" type="text/javascript"></script>
<script src="//images.jxt.net.au/COMMON/cvbuilder/js/lib/respond.min.js" type="text/javascript"></script>
<![endif]-->
    <% if (this.Page.Master.FindControl("ltlMetaContent") != null && !(((Literal)this.Page.Master.FindControl("ltlMetaContent")).Text.Contains("bootstrap.min.js")))
       { %>
    <script src='//images.jxt.net.au/COMMON/cvbuilder/js/lib/bootstrap.min.js'></script>
    <% } %>
    <script src='//images.jxt.net.au/COMMON/cvbuilder/js/lib/jquery.bootstrap.wizard.js'></script>
    <script src='//images.jxt.net.au/COMMON/cvbuilder/js/lib/bootstrap-fileupload.min.js'></script>
    <script src='//images.jxt.net.au/COMMON/cvbuilder/js/lib/moment.js'></script>
    <script src='//images.jxt.net.au/COMMON/cvbuilder/js/lib/jquery.tagsinput.min.js'></script>
    <script src='//images.jxt.net.au/COMMON/cvbuilder/js/lib/bootstrap-maxlength.min.js'></script>
    <script src='//images.jxt.net.au/COMMON/cvbuilder/js/lib/bootstrap-multiselect.js'></script>
    <script src='//images.jxt.net.au/COMMON/cvbuilder/js/CV-Builder-scripts.js'></script>
    <script type="text/javascript">
        var formtocheck;

        function CurrentChanged() {
            var checked = document.getElementById("cbExperienceCurrent").checked;

            if (checked)
            {
                $('#ddlExperienceEndMonth').attr('disabled', 'disabled');
                $('#ddlExperienceEnd').attr('disabled', 'disabled');
            }
            else
            {
                $('#ddlExperienceEndMonth').removeAttr('disabled', 'disabled');
                $('#ddlExperienceEnd').removeAttr('disabled', 'disabled');
            }
        }

        function DirectorshipCurrentChanged() {
            var checked = document.getElementById("cbDirectorshipCurrent").checked;

            if (checked)
            {
                $('#ddlDirectorshipEndMonth').attr('disabled', 'disabled');
                $('#ddlDirectorshipEnd').attr('disabled', 'disabled');
            }
            else
            {
                $('#ddlDirectorshipEndMonth').removeAttr('disabled', 'disabled');
                $('#ddlDirectorshipEnd').removeAttr('disabled', 'disabled');
            }
        }

        function OthersChanged() {
            var checked = document.getElementById("cbOthers").checked;

            document.getElementById("divOthers").style = (checked) ? "" : "display: none;";
        }

        <%
            if(!Page.IsPostBack && Request["tab"] != null )
            {        
        %>
                $(document).ready(function(){

                    $("a[href=#<%=Request["tab"] %>]").click();

                });
        <%
            }
        %>

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="toolkitScriptManager" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <script type="text/javascript">
                formtocheck = $('#aspnetForm')[0];
            </script>
            <div id="content-container" class="newDash container">
                <div id="CV-content" class="row">
                    <div id="CV-content-holder" class="col-md-12">
                        <uc1:ucMemberAccountNavigation ID="ucMemberAccountNavigation1" runat="server" />
                        <!-- Start the CV Builder wizard block -->
                        <h1 class="CV-Builder-title">
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral4" runat="server" SetLanguageCode="LabelUpdateProfile" />
                        </h1>
                        <div id="CV-Builder" class="form-horizontal">
                            <div id="rootwizard">
                                <ul class="wizard-steps">
                                    <asp:PlaceHolder ID="phProfileStep" runat="server" Visible="false">
                                        <asp:Literal ID="ltProfileStep" runat="server" /></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="phCoverLetterResumeStep" runat="server" Visible="false">
                                        <asp:Literal ID="ltCoverLetterResumeStep" runat="server" /></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="phRolePreferencesStep" runat="server" Visible="false">
                                        <asp:Literal ID="ltRolePreferencesStep" runat="server" /></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="phEducationStep" runat="server" Visible="false">
                                        <asp:Literal ID="ltEducationStep" runat="server" /></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="phMembershipsStep" runat="server" Visible="false">
                                        <asp:Literal ID="ltMembershipsStep" runat="server" /></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="phDirectorshipStep" runat="server" Visible="false">
                                        <asp:Literal ID="ltDirectorshipStep" runat="server" /></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="phExperienceStep" runat="server" Visible="false">
                                        <asp:Literal ID="ltExperienceStep" runat="server" /></asp:PlaceHolder>
                                    <asp:PlaceHolder ID="phSkillsStep" runat="server" Visible="false">
                                        <asp:Literal ID="ltSkillsStep" runat="server" /></asp:PlaceHolder>
                                </ul>
                                <div class="tab-content">
                                    <asp:PlaceHolder ID="phProfile" runat="server" Visible="false">
                                        <asp:Literal ID="ltProfile" runat="server" />
                                        <div class="form-group">
                                            <div class="col-sm-4 col-md-3 image-upload">
                                                <div class="fileupload fileupload-new" data-provides="fileupload">
                                                    <div class="fileupload-preview thumbnail" style="width: 200px; height: 150px;">
                                                        <asp:Image ID="imProfile" runat="server" Visible="false" />
                                                    </div>
                                                    <div>
                                                        <asp:label id="lbUploadProfileImage" runat="server" AssociatedControlID="fuProfile">
                                                            <JXTControl:ucLanguageLiteral ID="ucLoabelUploadProfileImage" runat="server" SetLanguageCode="LabelUploadProfileImage" />
                                                        </asp:label>
                                                        <br>
                                                        <span class="btn btn-default btn-file"><span class="fileupload-new">
                                                            <JXTControl:ucLanguageLiteral ID="ucBrowse" runat="server" SetLanguageCode="LabelBrowse" />
                                                        </span><span class="fileupload-exists">
                                                            <JXTControl:ucLanguageLiteral ID="ucChangeProfileImage" runat="server" SetLanguageCode="LabelChange" />
                                                        </span>
                                                            <asp:FileUpload ID="fuProfile" runat="server" ClientIDMode="Static" /></span><span
                                                                class="help-block"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral18" runat="server"
                                                                    SetLanguageCode="LabelUploadProfileImageDesc" />
                                                            </span>
                                                        <asp:PlaceHolder ID="phProfileErrorType" runat="server" Visible="false">
                                                            <label for="fuProfile" class="error">
                                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral19" runat="server" SetLanguageCode="LabelUploadProfileImageInvalid" />
                                                            </label>
                                                        </asp:PlaceHolder>
                                                        <asp:PlaceHolder ID="phProfileErrorSize" runat="server" Visible="false">
                                                            <label for="fuProfile" class="error">
                                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral20" runat="server" SetLanguageCode="LabelUploadProfileImageInvalidFileSize" />
                                                            </label>
                                                        </asp:PlaceHolder>
                                                        <a href="#" class="btn fileupload-exists" data-dismiss="fileupload">
                                                            <JXTControl:ucLanguageLiteral ID="ucRemove" runat="server" SetLanguageCode="LabelRemove" />
                                                        </a>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-8 col-md-9">
                                                <div class="form-group">
                                                    <div class="col-md-6">
                                                        <asp:label id="lbHeadline" runat="server" AssociatedControlID="tbHeadline">
                                                            <JXTControl:ucLanguageLiteral ID="ucHeadline" runat="server" SetLanguageCode="LabelHeadline" />
                                                        </asp:label>
                                                        <div class="controls">
                                                            <asp:TextBox ID="tbHeadline" runat="server" CssClass="form-control" ClientIDMode="Static"
                                                                placeholder="Headline" />
                                                            <asp:PlaceHolder ID="phHeadline" runat="server" Visible="false">
                                                                <label for="tbHeadline" class="error">
                                                                    <JXTControl:ucLanguageLiteral ID="ucHeadlineRequired" runat="server" SetLanguageCode="LabelThisFieldIsRequired" />
                                                                </label>
                                                            </asp:PlaceHolder>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <asp:label ID="lbCurrentStatus" runat="server" cssclass="control-label" AssociatedControlID="ddlCurrentStatus">
                                                            <JXTControl:ucLanguageLiteral ID="ucCurrentStatus" runat="server" SetLanguageCode="LabelCurrentStatus" />
                                                        </asp:label>
                                                        <div class="controls">
                                                            <asp:DropDownList ID="ddlCurrentStatus" runat="server" CssClass="form-control" ClientIDMode="Static" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <asp:label ID="lbShortBio" runat="server" AssociatedControlID="tbShortBio" cssclass="control-label">
                                                    <JXTControl:ucLanguageLiteral ID="ucShortBio" runat="server" SetLanguageCode="LabelShortBio" />
                                                </asp:label>
                                                <div class="controls">
                                                    <asp:TextBox ID="tbShortBio" runat="server" Columns="5" Rows="5" MaxLength="500"
                                                        TextMode="MultiLine" ClientIDMode="Static" />
                                                    <asp:PlaceHolder ID="phShortBio" runat="server" Visible="false">
                                                        <label for="tbShortBio" class="error">
                                                            <JXTControl:ucLanguageLiteral ID="ucShortBioRequired" runat="server" SetLanguageCode="LabelThisFieldIsRequired" />
                                                        </label>
                                                    </asp:PlaceHolder>
                                                </div>
                                            </div>
                                        </div>
                                        <asp:Literal ID="ltProfileClose" runat="server" />
                                        <!-- tab1 -->
                                    </asp:PlaceHolder>
                                    <asp:PlaceHolder ID="phCoverLetterResume" runat="server" Visible="false">
                                        <asp:Literal ID="ltCoverLetterResume" runat="server" />
                                        <asp:UpdatePanel ID="upCV" runat="server">
                                            <ContentTemplate>
                                                <div class="fileupload fileupload-new" data-provides="fileupload">
                                                    <asp:RadioButton ID="rbUploadCoverLetter" runat="server" GroupName="CoverLetter"
                                                        Checked="true" OnCheckedChanged="CoverLetter_CheckedChanged" AutoPostBack="true" />
                                                    <asp:label ID="lbCoverLetter" runat="server" AssociatedControlID="fuCoverletter" class="control-label">
                                                        <JXTControl:ucLanguageLiteral ID="ucUploadACoverLetter" runat="server" SetLanguageCode="LabelUploadACoverLetter" />
                                                    </asp:label>
                                                    <asp:PlaceHolder ID="phUploadCoverLetter" runat="server">
                                                        <div class="input-append">
                                                            <div class="uneditable-input span3">
                                                                <i class="icon-file fileupload-exists"></i><span class="fileupload-preview"></span>
                                                            </div>
                                                            <span class="btn btn-default btn-file"><span class="fileupload-new">
                                                                <JXTControl:ucLanguageLiteral ID="ucCVBrowse" runat="server" SetLanguageCode="LabelBrowse" />
                                                            </span><span class="fileupload-exists">
                                                                <JXTControl:ucLanguageLiteral ID="ucCVChange" runat="server" SetLanguageCode="LabelChange" />
                                                            </span>
                                                                <asp:FileUpload ID="fuCoverletter" runat="server" ClientIDMode="Static" /></span><span
                                                                    class="help-block">
                                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral21" runat="server" SetLanguageCode="LabelUploadCoverDesc" />
                                                                </span>
                                                            <asp:PlaceHolder ID="phCoverLetterError" runat="server" Visible="false">
                                                                <label for="fuCoverletter" class="error">
                                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral24" runat="server" SetLanguageCode="LabelUploadProfileImageInvalid" />
                                                                </label>
                                                            </asp:PlaceHolder>
                                                            <a href="#" class="btn fileupload-exists" data-dismiss="fileupload">
                                                                <JXTControl:ucLanguageLiteral ID="ucCVRemove" runat="server" SetLanguageCode="LabelRemove" />
                                                            </a>
                                                        </div>
                                                    </asp:PlaceHolder>
                                                </div>
                                                <asp:RadioButton ID="rbWriteCoverLetter" runat="server" GroupName="CoverLetter" OnCheckedChanged="CoverLetter_CheckedChanged"
                                                    AutoPostBack="true" />
                                                <asp:label ID="lbWriteOneNow" runat="server" cssclass="control-label" AssociatedControlID="tbWriteCoverLetter">
                                                    <JXTControl:ucLanguageLiteral ID="UcOrWriteOneNow" runat="server" SetLanguageCode="LabelOrWriteOneNow" />
                                                </asp:label>
                                                <asp:PlaceHolder ID="phWriteCoverLetter" runat="server" Visible="false">
                                                    <div class="controls">
                                                        <asp:TextBox ID="tbWriteCoverLetter" runat="server" Columns="5" Rows="5" MaxLength="500"
                                                            TextMode="MultiLine" ClientIDMode="Static" />
                                                    </div>
                                                </asp:PlaceHolder>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <br>
                                        <h4>
                                            <JXTControl:ucLanguageLiteral ID="ucResume" runat="server" SetLanguageCode="LabelResume" />
                                        </h4>
                                        <div class="fileupload fileupload-new" data-provides="fileupload">
                                            <asp:label ID="lbUploadAResume" runat="server" AssociatedControlID="fuResume">
                                                <JXTControl:ucLanguageLiteral ID="ucUploadAResume" runat="server" SetLanguageCode="LabelUploadAResume" />
                                            </asp:label>
                                            <div class="input-append">
                                                <div class="uneditable-input span3">
                                                    <i class="icon-file fileupload-exists"></i><span class="fileupload-preview"></span>
                                                </div>
                                                <span class="btn btn-default btn-file"><span class="fileupload-new">
                                                    <JXTControl:ucLanguageLiteral ID="ucResumeBrowse" runat="server" SetLanguageCode="LabelBrowse" />
                                                </span><span class="fileupload-exists">
                                                    <JXTControl:ucLanguageLiteral ID="ucResumeChange" runat="server" SetLanguageCode="LabelChange" />
                                                </span>
                                                    <asp:FileUpload ID="fuResume" runat="server" ClientIDMode="Static" />
                                                </span><span class="help-block">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral22" runat="server" SetLanguageCode="LabelUploadCoverDesc" />
                                                </span>
                                                <asp:PlaceHolder ID="phResumeError" runat="server" Visible="false">
                                                    <label for="fuResume" class="error">
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral23" runat="server" SetLanguageCode="LabelUploadProfileImageInvalid" />
                                                    </label>
                                                </asp:PlaceHolder>
                                                <a href="#" class="btn fileupload-exists" data-dismiss="fileupload">
                                                    <JXTControl:ucLanguageLiteral ID="ucResumeRemove" runat="server" SetLanguageCode="LabelRemove" />
                                                </a>
                                            </div>
                                        </div>
                                        <!-- Resume -->
                                        <asp:UpdatePanel ID="upResume" runat="server">
                                            <ContentTemplate>
                                                <asp:PlaceHolder ID="phFileList" runat="server" Visible="false">
                                                    <br>
                                                    <div class="qualification-list">
                                                        <div class="table-responsive">
                                                            <table class="table table-striped">
                                                                <thead>
                                                                    <tr>
                                                                        <th>
                                                                            <JXTControl:ucLanguageLiteral ID="ucDocumentName" runat="server" SetLanguageCode="LabelDocumentName" />
                                                                        </th>
                                                                        <th>
                                                                            <JXTControl:ucLanguageLiteral ID="ucFileType" runat="server" SetLanguageCode="LabelFileType" />
                                                                        </th>
                                                                        <th class="text-right">
                                                                            <JXTControl:ucLanguageLiteral ID="ucFileActions" runat="server" SetLanguageCode="LabelActions" />
                                                                        </th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                                    <asp:PlaceHolder ID="phCoverLetter" runat="server" Visible="false">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:HiddenField ID="hfCoverLetterID" runat="server" />
                                                                                <asp:Literal ID="ltCoverLetterFileName" runat="server" />
                                                                            </td>
                                                                            <td>
                                                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral2" runat="server" SetLanguageCode="LabelCoverLetter" />
                                                                            </td>
                                                                            <td class="text-right">
                                                                                <asp:HyperLink ID="hlCoverLetterDownload" runat="server" Text="Download" CssClass="btn btn-success btn-xs">
                                                                                    <i class="fa fa-download"></i>
                                                                                    <JXTControl:ucLanguageLiteral ID="ucDownloadLetter" runat="server" SetLanguageCode="LabelDownload" />
                                                                                </asp:HyperLink>
                                                                                <asp:LinkButton ID="btnCoverLetterDelete" runat="server" Text="Delete" CssClass="btn btn-danger btn-xs"
                                                                                    OnClick="btnCoverLetterDelete_Click" />
                                                                            </td>
                                                                        </tr>
                                                                    </asp:PlaceHolder>
                                                                    <asp:PlaceHolder ID="phResume" runat="server" Visible="false">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:HiddenField ID="hfResumeDocID" runat="server" />
                                                                                <asp:Literal ID="ltResumeFileName" runat="server" />
                                                                            </td>
                                                                            <td>
                                                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelResume" />
                                                                            </td>
                                                                            <td class="text-right">
                                                                                <asp:HyperLink ID="hlResumeDownload" runat="server" Text="Download" CssClass="btn btn-success btn-xs">
                                                                                    <i class="fa fa-download"></i>
                                                                                    <JXTControl:ucLanguageLiteral ID="ucDownloadResume" runat="server" SetLanguageCode="LabelDownload" />
                                                                                </asp:HyperLink>
                                                                                <asp:LinkButton ID="btnResumeDelete" runat="server" Text="Delete" CssClass="btn btn-danger btn-xs"
                                                                                    OnClick="btnResumeDelete_Click" />
                                                                            </td>
                                                                        </tr>
                                                                    </asp:PlaceHolder>
                                                                </tbody>
                                                            </table>
                                                        </div>
                                                    </div>
                                                </asp:PlaceHolder>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:Literal ID="ltCoverLetterResumeClose" runat="server" />
                                        <!-- tab2 -->
                                    </asp:PlaceHolder>
                                    <asp:PlaceHolder ID="phRolePreferences" runat="server" Visible="false">
                                        <asp:Literal ID="ltRolePreferences" runat="server" />
                                        <div class="form-group role-location">
                                            <asp:UpdatePanel ID="upLocation" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="col-md-6">
                                                        <asp:label ID="lbLocation" runat="server" AssociatedControlID="ddlLocations" CssClass="control-label">
                                                            <JXTControl:ucLanguageLiteral ID="ucLocationPreferences" runat="server" SetLanguageCode="LabelLocation" />
                                                        </asp:label>
                                                        <div class="controls">
                                                            <uc1:DropDownListX ID="ddlLocations" runat="server" CssClass="form-control" AutoPostBack="true"
                                                                OnSelectedIndexChanged="ddlLocations_SelectedIndexChanged" />
                                                            <%--<asp:DropDownList ID="ddlLocations" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlLocations_SelectedIndexChanged"
                                                                AutoPostBack="true" />--%>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <asp:label ID="lbArea" runat="server" AssociatedControlID="ltArea" CssClass="control-label" for="area">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral6" runat="server" SetLanguageCode="LabelArea" />
                                                        </asp:label>
                                                        <div class="controls multiselect-group">
                                                            <asp:Literal ID="ltArea" runat="server" />
                                                            <asp:HiddenField ID="hfArea" runat="server" ClientIDMode="Static" />
                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="form-group role-classification">
                                            <asp:UpdatePanel ID="upRoles" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="col-md-6">
                                                        <asp:label ID="lbClassification"  runat="server" cssclass="control-label" AssociatedControlID="ddlClassification">
                                                            <JXTControl:ucLanguageLiteral ID="ucClassificationAndSubClassification" runat="server"
                                                                SetLanguageCode="LabelClassification" />
                                                        </asp:label>
                                                        <div class="controls">
                                                            <asp:DropDownList ID="ddlClassification" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlClassification_SelectedIndexChanged"
                                                                AutoPostBack="true" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <asp:label id="lbSubClassification" runat="server" cssclass="control-label" AssociatedControlID="ltSubClassification" >
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral7" runat="server" SetLanguageCode="LabelSubClassification" />
                                                        </asp:label>
                                                        <div class="controls multiselect-group">
                                                            <asp:Literal ID="ltSubClassification" runat="server" />
                                                            <asp:HiddenField ID="hfSubClassification" runat="server" ClientIDMode="Static" />
                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="form-group role-type">
                                            <div class="col-md-6">
                                                <asp:label id="lbWorkType" runat="server" cssclass="control-label" AssociatedControlID="ltWorkType">
                                                    <JXTControl:ucLanguageLiteral ID="ucWorkType" runat="server" SetLanguageCode="LabelWorkType" />
                                                </asp:label>
                                                <div class="controls multiselect-group">
                                                    <asp:Literal ID="ltWorkType" runat="server" />
                                                    <asp:HiddenField ID="hfWorkType" runat="server" ClientIDMode="Static" />
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                &nbsp;
                                            </div>
                                        </div>
                                        <asp:Literal ID="ltRolesClose" runat="server" />
                                        <!-- tab3 -->
                                    </asp:PlaceHolder>
                                    <asp:PlaceHolder ID="phEducation" runat="server" Visible="false">
                                        <asp:Literal ID="ltEducation" runat="server" />
                                        <asp:UpdatePanel ID="upEducation" runat="server">
                                            <ContentTemplate>
                                                <div class="qualification">
                                                    <div class="form-group qualification-details">
                                                        <div class="col-md-6">
                                                            <asp:label id="lbQualification" runat="server" cssclass="control-label" AssociatedControlID="tbQualificationTitle">
                                                                <JXTControl:ucLanguageLiteral ID="ucQualification" runat="server" SetLanguageCode="LabelQualification" />
                                                            </asp:label>
                                                            <asp:HiddenField ID="hfQualificationID" runat="server" />
                                                            <asp:TextBox ID="tbQualificationTitle" runat="server" CssClass="form-control" MaxLength="150"
                                                                ClientIDMode="Static" placeholder="Master of Business Management" />
                                                            <asp:PlaceHolder ID="phQualificationTitleError" runat="server" Visible="false">
                                                                <label for="tbQualificationTitle" class="error">
                                                                    <JXTControl:ucLanguageLiteral ID="ucQualificationTitleRequired" runat="server" SetLanguageCode="LabelThisFieldIsRequired" />
                                                                </label>
                                                            </asp:PlaceHolder>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <asp:label ID="lbInstitutionName" runat="server" cssclass="control-label" AssociatedControlID="tbInstitutionName">
                                                                <JXTControl:ucLanguageLiteral ID="ucInstitutionName" runat="server" SetLanguageCode="LabelInstitutionName" />
                                                            </asp:label>
                                                            <asp:TextBox ID="tbInstitutionName" runat="server" CssClass="form-control" MaxLength="150"
                                                                ClientIDMode="Static" placeholder="University of Sydney" />
                                                            <asp:PlaceHolder ID="phInstitutionNameError" runat="server" Visible="false">
                                                                <label for="tbInstitutionName" class="error">
                                                                    <JXTControl:ucLanguageLiteral ID="ucInstitutionNameRequired" runat="server" SetLanguageCode="LabelThisFieldIsRequired" />
                                                                </label>
                                                            </asp:PlaceHolder>
                                                        </div>
                                                    </div>
                                                    <div class="form-group qualification-dates">
                                                        <div class="col-md-6">
                                                            <asp:label ID="lbStartDate" runat="server" cssclass="control-label" AssociatedControlID="ddlStartDate">
                                                                <JXTControl:ucLanguageLiteral ID="ucStartDate" runat="server" SetLanguageCode="LabelStart" />
                                                            </asp:label>
                                                            <div class='controls' id='startdate'>
                                                                <asp:DropDownList ID="ddlStartDate" runat="server" CssClass="form-control" ClientIDMode="Static" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <asp:label ID="lbEndDate" runat="server" cssclass="control-label" AssociatedControlID="ddlEndDate">
                                                                <JXTControl:ucLanguageLiteral ID="ucEndDate" runat="server" SetLanguageCode="LabelEnd" />
                                                            </asp:label>
                                                            <div class='controls' id='enddate'>
                                                                <asp:DropDownList ID="ddlEndDate" runat="server" CssClass="form-control" ClientIDMode="Static" />
                                                                <asp:PlaceHolder ID="phEndDate" runat="server" Visible="false">
                                                                    <label for="ddlEndDate" class="error">
                                                                        <JXTControl:ucLanguageLiteral ID="ucEndDateError" runat="server" SetLanguageCode="LabelEndDateError" />
                                                                    </label>
                                                                </asp:PlaceHolder>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!-- qualification -->
                                                <br>
                                                <asp:PlaceHolder ID="phAddEducation" runat="server">
                                                    <asp:LinkButton ID="lbAddEducation" runat="server" CssClass="btn btn-default btn-file"
                                                        OnClick="lbAddEducation_Click">
                                                        <i class="fa fa-plus"></i>
                                                        <JXTControl:ucLanguageLiteral ID="ucAddAnotherQualification" runat="server" SetLanguageCode="LabelAddAnotherQualification" />
                                                    </asp:LinkButton>
                                                </asp:PlaceHolder>
                                                <asp:PlaceHolder ID="phEditEducation" runat="server" Visible="false">
                                                    <asp:LinkButton ID="lbEditEducation" runat="server" CssClass="btn btn-default btn-file"
                                                        OnClick="lbEditEducation_Click">
                                                        <JXTControl:ucLanguageLiteral ID="ucSaveEducation" runat="server" SetLanguageCode="LabelSave" />
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="lbCancelEducation" runat="server" CssClass="btn btn-default btn-file"
                                                        OnClick="lbCancelEducation_Click">
                                                        <JXTControl:ucLanguageLiteral ID="ucCancelEducation" runat="server" SetLanguageCode="LabelCancel" />
                                                    </asp:LinkButton>
                                                </asp:PlaceHolder>
                                                <br>
                                                <div class="qualification-list">
                                                    <div class="table-responsive">
                                                        <asp:Repeater ID="rptQualifications" runat="server" OnItemDataBound="rptQualifications_ItemDataBound"
                                                            OnItemCommand="rptQualifications_ItemCommand">
                                                            <HeaderTemplate>
                                                                <table class="table table-striped">
                                                                    <thead>
                                                                        <tr>
                                                                            <th>
                                                                                <JXTControl:ucLanguageLiteral ID="ucQualification" runat="server" SetLanguageCode="LabelQualification" />
                                                                            </th>
                                                                            <th>
                                                                                <JXTControl:ucLanguageLiteral ID="ucQualificationInstitutionName" runat="server"
                                                                                    SetLanguageCode="LabelInstitutionName" />
                                                                            </th>
                                                                            <th>
                                                                                <JXTControl:ucLanguageLiteral ID="ucStart" runat="server" SetLanguageCode="LabelStart" />
                                                                            </th>
                                                                            <th>
                                                                                <JXTControl:ucLanguageLiteral ID="ucEnd" runat="server" SetLanguageCode="LabelEnd" />
                                                                            </th>
                                                                            <th class="text-right">
                                                                                <JXTControl:ucLanguageLiteral ID="ucActions" runat="server" SetLanguageCode="LabelActions" />
                                                                            </th>
                                                                        </tr>
                                                                    </thead>
                                                                    <tbody>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Literal ID="ltQualification" runat="server" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Literal ID="ltQualificationInstitutionName" runat="server" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Literal ID="ltStart" runat="server" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Literal ID="ltEnd" runat="server" />
                                                                    </td>
                                                                    <td class="text-right">
                                                                        <asp:LinkButton ID="lbEdit" runat="server" CssClass="btn btn-success btn-xs" CommandName="Edit">
                                                                            <asp:PlaceHolder ID="phEditInner" runat="server"><i class="fa fa-pencil"></i>
                                                                                <JXTControl:ucLanguageLiteral ID="ucEducationEdit" runat="server" SetLanguageCode="LabelEdit" />
                                                                            </asp:PlaceHolder>
                                                                        </asp:LinkButton>
                                                                        <asp:LinkButton ID="lbDelete" runat="server" CssClass="btn btn-danger btn-xs" CommandName="Delete">
                                                                            <asp:PlaceHolder ID="phDeleteInner" runat="server"><i class="fa fa-times"></i>
                                                                                <JXTControl:ucLanguageLiteral ID="ucEducationDelete" runat="server" SetLanguageCode="LabelDelete" />
                                                                            </asp:PlaceHolder>
                                                                        </asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                </tbody> </table>
                                                            </FooterTemplate>
                                                        </asp:Repeater>
                                                    </div>
                                                </div>
                                                <asp:Literal ID="ltEducationClose" runat="server" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <!-- tab4 -->
                                    </asp:PlaceHolder>
                                    <asp:PlaceHolder ID="phMemberships" runat="server" Visible="false">
                                        <asp:Literal ID="ltMemberships" runat="server" />
                                        <asp:Repeater ID="rptAMC" runat="server" OnItemDataBound="rptAMC_ItemDataBound">
                                            <ItemTemplate>
                                                <div class="checkbox dynamic-content">
                                                    <asp:label id="lbMembership" runat="server" AssociatedControlID="cbAMC">
                                                        <asp:HiddenField ID="hfMembershipID" runat="server" />
                                                        <asp:CheckBox ID="cbAMC" runat="server" /><asp:Literal ID="ltAMC" runat="server" />
                                                    </asp:label>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <div class="checkbox dynamic-content others">
                                            <asp:label ID="lbOther" runat="server" AssociatedControlID="cbOthers">
                                                <input type="checkbox" value="option-other" id="cbOthers" runat="server" clientidmode="Static"
                                                    onchange="OthersChanged" />
                                                <JXTControl:ucLanguageLiteral ID="ucOthers" runat="server" SetLanguageCode="LabelOther" />
                                            </asp:label>
                                        </div>
                                        <div id="divOthers" runat="server" class="dynamic-content othersfield" style="display: none;">
                                            <asp:TextBox ID="tbOthers" runat="server" CssClass="form-control" placeholder="Please specify"
                                                ClientIDMode="Static" />
                                        </div>
                                        <asp:Literal ID="ltMembershipsClose" runat="server" />
                                        <!-- tab5 -->
                                    </asp:PlaceHolder>
                                    <asp:PlaceHolder ID="phDirectorship" runat="server" Visible="false">
                                        <asp:Literal ID="ltDirectorship" runat="server" />
                                        <asp:UpdatePanel ID="upDirectorship" runat="server">
                                            <ContentTemplate>
                                                <div class="form-group experience-detail">
                                                    <div class="col-md-6">
                                                        <asp:label id="lbJobTitle" runat="server" AssociatedControlID="tbDirectorshipJobTitle">
                                                            <asp:HiddenField ID="hfDirectorshipID" runat="server" />
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral8" runat="server" SetLanguageCode="LabelJobTitle" />
                                                        </asp:label>
                                                        <asp:TextBox ID="tbDirectorshipJobTitle" runat="server" CssClass="form-control" placeholder="Job title"
                                                            ClientIDMode="Static" />
                                                        <asp:PlaceHolder ID="phDirectorshipJobTitleError" runat="server" Visible="false">
                                                            <label for="tbDirectorshipJobTitle" class="error">
                                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral9" runat="server" SetLanguageCode="LabelThisFieldIsRequired" />
                                                            </label>
                                                        </asp:PlaceHolder>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <asp:label ID="lbDirectorshipCompanyName" runat="server" AssociatedControlID="tbDirectorshipCompanyName">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral10" runat="server" SetLanguageCode="LabelCompanyName" />
                                                        </asp:label>
                                                        <asp:TextBox ID="tbDirectorshipCompanyName" runat="server" CssClass="form-control"
                                                            placeholder="Company Name" ClientIDMode="Static" />
                                                        <asp:PlaceHolder ID="phDirectorshipCompanyNameError" runat="server" Visible="false">
                                                            <label for="tbDirectorshipCompanyName" class="error">
                                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral11" runat="server" SetLanguageCode="LabelThisFieldIsRequired" />
                                                            </label>
                                                        </asp:PlaceHolder>
                                                    </div>
                                                </div>
                                                <div class="form-group experience-date">
                                                    <div class="col-md-6">
                                                        <asp:label ID="lbDirectorshipStartMonth" runat="server" AssociatedControlID="ddlDirectorshipStartMonth">
                                                            <JXTControl:ucLanguageLiteral ID="ucDirectorshipStartDate" runat="server" SetLanguageCode="LabelStart" />
                                                        </asp:label>
                                                        <div class="controls">
                                                            <asp:DropDownList ID="ddlDirectorshipStartMonth" runat="server" CssClass="form-control"
                                                                ClientIDMode="Static" />
                                                            <asp:DropDownList ID="ddlDirectorshipStart" runat="server" CssClass="form-control"
                                                                ClientIDMode="Static" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <asp:label id="lbDirectorshipEndDate" runat="server" AssociatedControlID="ddlDirectorshipEndMonth">
                                                            <JXTControl:ucLanguageLiteral ID="ucDirectorshipEndDate" runat="server" SetLanguageCode="LabelEnd" />
                                                        </asp:label>
                                                        <div class="controls">
                                                            <asp:DropDownList ID="ddlDirectorshipEndMonth" runat="server" CssClass="form-control"
                                                                ClientIDMode="Static" />
                                                            <asp:DropDownList ID="ddlDirectorshipEnd" runat="server" CssClass="form-control"
                                                                ClientIDMode="Static" />
                                                            <asp:PlaceHolder ID="phDirectorshipEndError" runat="server" Visible="false">
                                                                <label for="ddlDirectorshipEnd" class="error">
                                                                    <JXTControl:ucLanguageLiteral ID="ucDirectorshipEndError" runat="server" SetLanguageCode="LabelEndDateError" />
                                                                </label>
                                                            </asp:PlaceHolder>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="checkbox qualification-current">
                                                    <asp:label ID="lbDirectorshipCurrent" runat="server" AssociatedControlID="cbDirectorshipCurrent">
                                                        <input id="cbDirectorshipCurrent" type="checkbox" runat="server" onchange="DirectorshipCurrentChanged();"
                                                            clientidmode="Static" />
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral12" runat="server" SetLanguageCode="LabelCurrent" />
                                                    </asp:label>
                                                </div>
                                                <div class="form-group">
                                                    <div class="col-md-12">
                                                        <asp:label id="lbDirectorshipSummary" runat="server" AssociatedControlID="tbDirectorshipSummary">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral13" runat="server" SetLanguageCode="LabelSummary" />
                                                        </asp:label>
                                                        <div class="controls">
                                                            <asp:TextBox ID="tbDirectorshipSummary" CssClass="form-control" runat="server" Columns="5"
                                                                Rows="5" MaxLength="500" TextMode="MultiLine" ClientIDMode="Static" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="col-md-12">
                                                        <asp:label ID="lbOrganisationWebsite" runat="server" AssociatedControlID="tbOrganisationWebsite">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral14" runat="server" SetLanguageCode="LabelOrganisationWebsite" />
                                                        </asp:label>
                                                        <div class="controls">
                                                            <asp:TextBox ID="tbOrganisationWebsite" CssClass="form-control" runat="server" MaxLength="255"
                                                                ClientIDMode="Static" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="col-md-12">
                                                        <asp:label id="lbResponsibilities" runat="server" AssociatedControlID="tbResponsibilities">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral15" runat="server" SetLanguageCode="LabelResponsibilitiesAndAchievements" />
                                                        </asp:label>
                                                        <div class="controls">
                                                            <asp:TextBox ID="tbResponsibilities" CssClass="form-control" runat="server" Columns="5"
                                                                Rows="5" TextMode="MultiLine" ClientIDMode="Static" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="col-md-12">
                                                        <asp:label ID="lbTypeOfDirectorship" runat="server" AssociatedControlID="ddlTypeOfDirectorship">
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral16" runat="server" SetLanguageCode="LabelTypeOfDirectorship" />
                                                        </asp:label>
                                                        <div class="controls">
                                                            <asp:DropDownList ID="ddlTypeOfDirectorship" CssClass="form-control" runat="server"
                                                                Width="48.5%">
                                                                <asp:ListItem Value="chair" Text="Chair" />
                                                                <asp:ListItem Value="nonexecutiveDirector" Text="Non-executive Director" />
                                                                <asp:ListItem Value="executivedirector" Text="Executive Director" />
                                                                <asp:ListItem Value="managingdirector" Text="Managing Director" />
                                                                <asp:ListItem Value="other" Text="Other" />
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="col-md-12">
                                                        <label>
                                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral17" runat="server" SetLanguageCode="LabelAdditionalRolesAndResponsibilities" />
                                                        </label>
                                                        <div class="controls">
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="cbAuditCommittee" runat="server" />Audit Committee
                                                                </label>
                                                            </div>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="cbRiskCommittee" runat="server" />Risk Committee
                                                                </label>
                                                            </div>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="cbNominationsCommittee" runat="server" />Nominations Committee
                                                                </label>
                                                            </div>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="cbRemunerationCommittee" runat="server" />Remuneration Committee
                                                                </label>
                                                            </div>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="cbOHSCommittee" runat="server" />OH&S Committee
                                                                </label>
                                                            </div>
                                                            <div class="checkbox">
                                                                <label>
                                                                    <asp:CheckBox ID="cbOther" runat="server" />Other</label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <!-- Directorship -->
                                                <asp:PlaceHolder ID="phAddDirectorship" runat="server">
                                                    <asp:LinkButton ID="lbAddDirectorship" runat="server" CssClass="btn btn-default btn-file"
                                                        OnClick="lbAddDirectorship_Click">
                                                        <i class="fa fa-plus"></i>
                                                        <JXTControl:ucLanguageLiteral ID="ucAddAnotherDirectorship" runat="server" SetLanguageCode="LabelAddAnotherDirectorship" />
                                                    </asp:LinkButton>
                                                </asp:PlaceHolder>
                                                <asp:PlaceHolder ID="phEditDirectorship" runat="server" Visible="false">
                                                    <asp:LinkButton ID="lbEditDirectorship" runat="server" CssClass="btn btn-default btn-file"
                                                        OnClick="lbEditDirectorship_Click">
                                                        <JXTControl:ucLanguageLiteral ID="ucSaveDirectorship" runat="server" SetLanguageCode="LabelSave" />
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="lbCancelDirectorship" runat="server" CssClass="btn btn-default btn-file"
                                                        OnClick="lbCancelDirectorship_Click">
                                                        <JXTControl:ucLanguageLiteral ID="ucCancelDirectorship" runat="server" SetLanguageCode="LabelCancel" />
                                                    </asp:LinkButton>
                                                </asp:PlaceHolder>
                                                <br>
                                                <div class="Directorship-list">
                                                    <div class="table-responsive">
                                                        <asp:Repeater ID="rptDirectorship" runat="server" OnItemDataBound="rptDirectorship_ItemDataBound"
                                                            OnItemCommand="rptDirectorship_ItemCommand">
                                                            <HeaderTemplate>
                                                                <table class="table table-striped">
                                                                    <thead>
                                                                        <tr>
                                                                            <th>
                                                                                <JXTControl:ucLanguageLiteral ID="ucTitle" runat="server" SetLanguageCode="LabelJobTitle" />
                                                                            </th>
                                                                            <th>
                                                                                <JXTControl:ucLanguageLiteral ID="ucCompany" runat="server" SetLanguageCode="LabelCompanyName" />
                                                                            </th>
                                                                            <th>
                                                                                <JXTControl:ucLanguageLiteral ID="ucDirectorshipStart" runat="server" SetLanguageCode="LabelStart" />
                                                                            </th>
                                                                            <th>
                                                                                <JXTControl:ucLanguageLiteral ID="ucDirectorshipEnd" runat="server" SetLanguageCode="LabelEnd" />
                                                                            </th>
                                                                            <th class="text-right">
                                                                                <JXTControl:ucLanguageLiteral ID="ucActions" runat="server" SetLanguageCode="LabelActions" />
                                                                            </th>
                                                                        </tr>
                                                                    </thead>
                                                                    <tbody>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Literal ID="ltTitle" runat="server" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Literal ID="ltCompany" runat="server" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Literal ID="ltDirectorshipStart" runat="server" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Literal ID="ltDirectorshipEnd" runat="server" />
                                                                    </td>
                                                                    <td class="text-right">
                                                                        <asp:LinkButton ID="lbEdit" runat="server" CssClass="btn btn-success btn-xs" CommandName="Edit">
                                                                            <asp:PlaceHolder ID="phEditInner" runat="server"><i class="fa fa-pencil"></i>
                                                                                <JXTControl:ucLanguageLiteral ID="ucDirectorshipEdit" runat="server" SetLanguageCode="LabelEdit" />
                                                                            </asp:PlaceHolder>
                                                                        </asp:LinkButton>
                                                                        <asp:LinkButton ID="lbDelete" runat="server" CssClass="btn btn-danger btn-xs" CommandName="Delete">
                                                                            <asp:PlaceHolder ID="phDeleteInner" runat="server"><i class="fa fa-times"></i>
                                                                                <JXTControl:ucLanguageLiteral ID="ucDirectorshipDelete" runat="server" SetLanguageCode="LabelDelete" />
                                                                            </asp:PlaceHolder>
                                                                        </asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                </tbody> </table>
                                                            </FooterTemplate>
                                                        </asp:Repeater>
                                                    </div>
                                                </div>
                                                <asp:Literal ID="ltDirectorshipClose" runat="server" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <!-- tab6 -->
                                    </asp:PlaceHolder>
                                    <asp:PlaceHolder ID="phExperience" runat="server" Visible="false">
                                        <asp:Literal ID="ltExperience" runat="server" />
                                        <asp:UpdatePanel ID="upExperience" runat="server">
                                            <ContentTemplate>
                                                <div class="form-group experience-detail">
                                                    <div class="col-md-6">
                                                        <asp:label id="JobTitle" runat="server" AssociatedControlID="tbJobTitle">
                                                            <asp:HiddenField ID="hfExperienceID" runat="server" />
                                                            <JXTControl:ucLanguageLiteral ID="ucJobTitle" runat="server" SetLanguageCode="LabelJobTitle" />
                                                        </asp:label>
                                                        <asp:TextBox ID="tbJobTitle" runat="server" CssClass="form-control" placeholder="Job title"
                                                            ClientIDMode="Static" />
                                                        <asp:PlaceHolder ID="phJobTitleError" runat="server" Visible="false">
                                                            <label for="tbJobTitle" class="error">
                                                                <JXTControl:ucLanguageLiteral ID="ucJobTitleRequired" runat="server" SetLanguageCode="LabelThisFieldIsRequired" />
                                                            </label>
                                                        </asp:PlaceHolder>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <asp:label ID="lbCompanyName" runat="server" AssociatedControlID="tbCompanyName">
                                                            <JXTControl:ucLanguageLiteral ID="ucCompanyName" runat="server" SetLanguageCode="LabelCompanyName" />
                                                        </asp:label>
                                                        <asp:TextBox ID="tbCompanyName" runat="server" CssClass="form-control" placeholder="Company Name"
                                                            ClientIDMode="Static" />
                                                        <asp:PlaceHolder ID="phCompanyNameError" runat="server" Visible="false">
                                                            <label for="tbCompanyName" class="error">
                                                                <JXTControl:ucLanguageLiteral ID="ucCompanyNameRequired" runat="server" SetLanguageCode="LabelThisFieldIsRequired" />
                                                            </label>
                                                        </asp:PlaceHolder>
                                                    </div>
                                                </div>
                                                <div class="form-group experience-date">
                                                    <div class="col-md-6">
                                                        <asp:label ID="lbExperienceStartDate" runat="server" AssociatedControlID="ddlExperienceStartMonth">
                                                            <JXTControl:ucLanguageLiteral ID="ucExperienceStartDate" runat="server" SetLanguageCode="LabelStart" />
                                                        </asp:label>
                                                        <div class="controls">
                                                            <asp:DropDownList ID="ddlExperienceStartMonth" runat="server" CssClass="form-control"
                                                                ClientIDMode="Static" />
                                                            <asp:DropDownList ID="ddlExperienceStart" runat="server" CssClass="form-control"
                                                                ClientIDMode="Static" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <asp:label ID="lbExperienceEndDate" runat="server" AssociatedControlID="ddlExperienceEndMonth" >
                                                            <JXTControl:ucLanguageLiteral ID="ucExperienceEndDate" runat="server" SetLanguageCode="LabelEnd" />
                                                        </asp:label>
                                                        <div class="controls">
                                                            <asp:DropDownList ID="ddlExperienceEndMonth" runat="server" CssClass="form-control"
                                                                ClientIDMode="Static" />
                                                            <asp:DropDownList ID="ddlExperienceEnd" runat="server" CssClass="form-control" ClientIDMode="Static" />
                                                            <asp:PlaceHolder ID="phExperienceEndError" runat="server" Visible="false">
                                                                <label for="ddlExperienceEnd" class="error">
                                                                    <JXTControl:ucLanguageLiteral ID="ucExperienceEndError" runat="server" SetLanguageCode="LabelEndDateError" />
                                                                </label>
                                                            </asp:PlaceHolder>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="checkbox qualification-current">
                                                    <asp:label ID="lbExperienceCurrent" runat="server" AssociatedControlID="cbExperienceCurrent">
                                                        <input id="cbExperienceCurrent" type="checkbox" runat="server" onchange="CurrentChanged();"
                                                            clientidmode="Static" />
                                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral5" runat="server" SetLanguageCode="LabelCurrent" />
                                                    </asp:label>
                                                </div>
                                                <asp:label ID="lbSummary" runat="server" AssociatedControlID="tbSummary" cssclass="control-label">
                                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral3" runat="server" SetLanguageCode="LabelSummary" />
                                                </asp:label>
                                                <div class="controls">
                                                    <asp:TextBox ID="tbSummary" CssClass="form-control" runat="server" Columns="5" Rows="5"
                                                        MaxLength="500" TextMode="MultiLine" ClientIDMode="Static" />
                                                </div>
                                                <br>
                                                <!-- experience -->
                                                <asp:PlaceHolder ID="phAddExperience" runat="server">
                                                    <asp:LinkButton ID="lbAddExperience" runat="server" CssClass="btn btn-default btn-file"
                                                        OnClick="lbAddExperience_Click">
                                                        <i class="fa fa-plus"></i>
                                                        <JXTControl:ucLanguageLiteral ID="ucAddAnotherExperience" runat="server" SetLanguageCode="LabelAddAnotherExperience" />
                                                    </asp:LinkButton>
                                                </asp:PlaceHolder>
                                                <asp:PlaceHolder ID="phEditExperience" runat="server" Visible="false">
                                                    <asp:LinkButton ID="lbEditExperience" runat="server" CssClass="btn btn-default btn-file"
                                                        OnClick="lbEditExperience_Click">
                                                        <JXTControl:ucLanguageLiteral ID="ucSaveExperience" runat="server" SetLanguageCode="LabelSave" />
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="lbCancelExperience" runat="server" CssClass="btn btn-default btn-file"
                                                        OnClick="lbCancelExperience_Click">
                                                        <JXTControl:ucLanguageLiteral ID="ucCancelExperience" runat="server" SetLanguageCode="LabelCancel" />
                                                    </asp:LinkButton>
                                                </asp:PlaceHolder>
                                                <br>
                                                <div class="experience-list">
                                                    <div class="table-responsive">
                                                        <asp:Repeater ID="rptExperience" runat="server" OnItemDataBound="rptExperience_ItemDataBound"
                                                            OnItemCommand="rptExperience_ItemCommand">
                                                            <HeaderTemplate>
                                                                <table class="table table-striped">
                                                                    <thead>
                                                                        <tr>
                                                                            <th>
                                                                                <JXTControl:ucLanguageLiteral ID="ucTitle" runat="server" SetLanguageCode="LabelJobTitle" />
                                                                            </th>
                                                                            <th>
                                                                                <JXTControl:ucLanguageLiteral ID="ucCompany" runat="server" SetLanguageCode="LabelCompanyName" />
                                                                            </th>
                                                                            <th>
                                                                                <JXTControl:ucLanguageLiteral ID="ucExperienceStart" runat="server" SetLanguageCode="LabelStart" />
                                                                            </th>
                                                                            <th>
                                                                                <JXTControl:ucLanguageLiteral ID="ucExperienceEnd" runat="server" SetLanguageCode="LabelEnd" />
                                                                            </th>
                                                                            <th class="text-right">
                                                                                <JXTControl:ucLanguageLiteral ID="ucActions" runat="server" SetLanguageCode="LabelActions" />
                                                                            </th>
                                                                        </tr>
                                                                    </thead>
                                                                    <tbody>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Literal ID="ltTitle" runat="server" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Literal ID="ltCompany" runat="server" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Literal ID="ltExperienceStart" runat="server" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:Literal ID="ltExperienceEnd" runat="server" />
                                                                    </td>
                                                                    <td class="text-right">
                                                                        <asp:LinkButton ID="lbEdit" runat="server" CssClass="btn btn-success btn-xs" CommandName="Edit">
                                                                            <asp:PlaceHolder ID="phEditInner" runat="server"><i class="fa fa-pencil"></i>
                                                                                <JXTControl:ucLanguageLiteral ID="ucExperienceEdit" runat="server" SetLanguageCode="LabelEdit" />
                                                                            </asp:PlaceHolder>
                                                                        </asp:LinkButton>
                                                                        <asp:LinkButton ID="lbDelete" runat="server" CssClass="btn btn-danger btn-xs" CommandName="Delete">
                                                                            <asp:PlaceHolder ID="phDeleteInner" runat="server"><i class="fa fa-times"></i>
                                                                                <JXTControl:ucLanguageLiteral ID="ucExperienceDelete" runat="server" SetLanguageCode="LabelDelete" />
                                                                            </asp:PlaceHolder>
                                                                        </asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                </tbody> </table>
                                                            </FooterTemplate>
                                                        </asp:Repeater>
                                                    </div>
                                                </div>
                                                <asp:Literal ID="ltExperienceClose" runat="server" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <!-- tab6 -->
                                    </asp:PlaceHolder>
                                    <asp:PlaceHolder ID="phSkills" runat="server" Visible="false">
                                        <asp:Literal ID="ltSkills" runat="server" />
                                        <asp:TextBox ID="skillTags" runat="server" ClientIDMode="Static" placeholder="Type to add another skill" />
                                        <p class="help-block">
                                            <JXTControl:ucLanguageLiteral ID="ltComa" runat="server" SetLanguageCode="LabelSeperateSkillComma" />
                                        </p>
                                        <asp:Literal ID="ltSkillsClose" runat="server" />
                                    </asp:PlaceHolder>
                                    <!-- tab7 -->
                                    <ul class="pager wizard">
                                        <%--<li class="previous"><a href="javascript:;">Previous</a></li>
                                <li class="next"><a href="javascript:;">Save&nbsp;&amp;&nbsp;Continue</a></li>
                                <li class="next finish" style="display: none;"><a href="javascript:;">Finish</a></li>--%>
                                        <asp:HiddenField ID="hfCurrentTab" runat="server" ClientIDMode="Static" />
                                        <li class="previous">
                                            <asp:HyperLink ID="hlPrevious" runat="server" NavigateUrl="javascript:;" ClientIDMode="Static">
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral25" runat="server" SetLanguageCode="LabelBtnPrevious" />
                                            </asp:HyperLink>
                                        </li>
                                        <li class="next" id="linext" runat="server" clientidmode="Static">
                                            <asp:LinkButton ID="btnSaveAndContinue" runat="server" OnClick="lbSaveAndContinue_Click"
                                                OnClientClick="$('#hfCurrentTab').val($('#rootwizard ul li.active a').attr('href'));"
                                                ClientIDMode="Static">
                                                <JXTControl:ucLanguageLiteral ID="ucButtonSave" runat="server" SetLanguageCode="LabelBtnSaveContinue" />
                                            </asp:LinkButton>
                                            <%--<asp:LinkButton ID="lbSaveAndContinue" runat="server" Text="Save & Continue" ClientIDMode="Static"
                                                OnClick="lbSaveAndContinue_Click" OnClientClick="$('#hfCurrentTab').val($('#rootwizard ul li.active a').attr('href'));" />--%></li>
                                        <li class="next finish" id="liFinish" runat="server" style="display: none;">
                                            <asp:LinkButton ID="lbFinish" runat="server" ClientIDMode="Static" OnClick="lbFinish_Click">
                                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral26" runat="server" SetLanguageCode="LabelBtnFinish" />
                                            </asp:LinkButton></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <!-- CV-Builder -->
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSaveAndContinue" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>