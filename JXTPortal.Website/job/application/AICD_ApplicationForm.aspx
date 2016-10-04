<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CustomMain.Master"
    AutoEventWireup="true" CodeBehind="AICD_ApplicationForm.aspx.cs" Inherits="JXTPortal.Website.AICD_ApplictionForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="http://netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.css" />
    <link rel="stylesheet" href="http://images.jxt.net.au/COMMON/cvbuilder/css/lib/bootstrap.min.css" />
    <link rel="stylesheet" href="http://images.jxt.net.au/COMMON/cvbuilder/css/lib/bootstrap-fileupload.min.css" />
    <link rel="stylesheet" href="http://images.jxt.net.au/COMMON/cvbuilder/css/lib/jquery.tagsinput.css" />
    <link rel="stylesheet" href="http://images.jxt.net.au/COMMON/cvbuilder/css/lib/bootstrap-multiselect.css" />
    <link rel="stylesheet" href="http://images.jxt.net.au/COMMON/cvbuilder/css/CV-Builder-style.css" />
    <!--[if lt IE 9]>
<script src="http://images.jxt.net.au/COMMON/cvbuilder/js/lib/html5shiv.js" type="text/javascript"></script>
<script src="http://images.jxt.net.au/COMMON/cvbuilder/js/lib/respond.min.js" type="text/javascript"></script>
<![endif]-->
    <% if (this.Page.Master.FindControl("ltlMetaContent") != null && !(((Literal)this.Page.Master.FindControl("ltlMetaContent")).Text.Contains("bootstrap.min.js")))
       { %>
    <script src='http://images.jxt.net.au/COMMON/cvbuilder/js/lib/bootstrap.min.js'></script>
    <% } %>
    <script src='http://images.jxt.net.au/COMMON/cvbuilder/js/lib/jquery.bootstrap.wizard.js'></script>
    <script src='http://images.jxt.net.au/COMMON/cvbuilder/js/lib/bootstrap-fileupload.min.js'></script>
    <script src='http://images.jxt.net.au/COMMON/cvbuilder/js/lib/moment.js'></script>
    <script src='http://images.jxt.net.au/COMMON/cvbuilder/js/lib/jquery.tagsinput.min.js'></script>
    <script src='http://images.jxt.net.au/COMMON/cvbuilder/js/lib/bootstrap-maxlength.min.js'></script>
    <script src='http://images.jxt.net.au/COMMON/cvbuilder/js/lib/bootstrap-multiselect.js'></script>
    <script src='http://images.jxt.net.au/COMMON/cvbuilder/js/CV-Builder-scripts.js'></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#Button1").click(function (evt) {
                var fileUpload = $("#fuResume").get(0);
                var files = fileUpload.files;

                var data = new FormData();
                for (var i = 0; i < files.length; i++) {
                    data.append(files[i].name, files[i]);
                }

                var options = {};
                options.url = "/FileUploadTest.ashx";
                options.type = "POST";
                options.data = data;
                options.contentType = false;
                options.processData = false;
                options.success = function (result) { alert(result); };
                options.error = function (err) { alert(err.statusText); };

                $.ajax(options);

                evt.preventDefault();

                return false;
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="aicdApplicationFormContainer" class="container" runat="server">
        <div class="fileupload fileupload-new" data-provides="fileupload">
            <label for="resume">
                <JXTControl:ucLanguageLiteral ID="ucUploadAResume" runat="server" SetLanguageCode="LabelUploadAResume" />
            </label>
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
                </span><span class="help-block">Please upload your file as Microsoft Word (.doc or .docx),
                    Adobe Acrobat (.pdf) or text file (.txt or .rtf)</span><asp:PlaceHolder ID="phResumeError"
                        runat="server" Visible="false">
                        <label for="fuResume" class="error">
                            Please upload a valid file.</label>
                    </asp:PlaceHolder>
                <a href="#" class="btn fileupload-exists" data-dismiss="fileupload">
                    <JXTControl:ucLanguageLiteral ID="ucResumeRemove" runat="server" SetLanguageCode="LabelRemove" />
                </a>

                <asp:Button ID="Button1" runat="server" Text="Upload Selected File" ClientIDMode="Static" />
            </div>
        </div>
    </div>
    <asp:Button ID="btnSubmit" runat="server" Text="Test" OnClick="btnSubmit_Click" />
</asp:Content>
