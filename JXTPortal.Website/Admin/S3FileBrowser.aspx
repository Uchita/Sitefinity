<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="S3FileBrowser.aspx.cs" Inherits="JXTPortal.Website.Admin.S3FileBrowser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>File Browser</title>
    <link rel="stylesheet" type="text/css" href="css/bootstrap.css">
    <link rel="stylesheet" type="text/css" href="css/bootstrap-fileupload.css">
    <link rel="stylesheet" type="text/css" href="css/vscontext.css">
    <link rel="stylesheet" type="text/css" href="css/overwrite.css">
    <link rel="stylesheet" type="text/css" href="css/jqueryui.css" />
    <link href="/Admin/styles/jquery.treeview.css" rel="stylesheet" type="text/css" />
    <!--[if gte IE 9 ]><link rel="stylesheet" type="text/css" href="css/treeview.css" media="screen"><![endif]-->
    <!--[if !IE]>-->
    <link rel="stylesheet" type="text/css" href="css/treeview.css" media="screen">
    <!--<![endif]-->
    <link rel="stylesheet" type="text/css" href="css/normalise.css">
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/jqueryui.js"></script>
    <script type="text/javascript" language="javascript" src="/admin/scripts/jquery.treeview.js"></script>
    <script type="text/javascript" src="js/blockUI.js"></script>
    <script type="text/javascript" src="js/bootstrap.js"></script>
    <script type="text/javascript" src="js/bootstrap-fileupload.js"></script>
    <script type="text/javascript" src="js/menu_action.js"></script>
    <script type="text/javascript" src="js/vscontext.jquery.js"></script>
    <script type="text/javascript" src="js/selectivizr.js"></script>
    <script type="text/javascript" src="js/html5shiv.js"></script>
    <script type="text/javascript" src="js/jquery.zclip.min.js"></script>
    <script type="text/javascript">
        var imagefiletypes = '<%=ImageFileTypes %>';

        function GetUrlParam(paramName) {
            var oRegex = new RegExp('[\?&]' + paramName + '=([^&]+)', 'i');
            var oMatch = oRegex.exec(window.top.location.search);

            if (oMatch && oMatch.length > 1)
                return decodeURIComponent(oMatch[1]);
            else
                return '';
        }

        function OpenFile(fileUrl) {

            //PATCH: Using CKEditors API we set the file in preview window.	

            funcNum = GetUrlParam('CKEditorFuncNum');

            //fixed the issue: images are not displayed in preview window when filename contain spaces due encodeURI encoding already encoded fileUrl

            window.top.opener.CKEDITOR.tools.callFunction(funcNum, fileUrl);

            ///////////////////////////////////
            window.top.close();
            window.top.opener.focus();
        }

        $(document).ready(function (e) {
            $('#image-browser div').hide();

            $('.droppable').click(function () {
                $('.droppable').removeClass('active');
                $(this).addClass('active');

                var fileurl = $(this).find('input[type="hidden"]').first().val();
                var parts = fileurl.split("/");
                $('#footer-row').find('input[type="text"]').first().val(fileurl);
                $('#file-display-info').val(parts[parts.length - 1]);
                $('#sidebar-insert').find("button").first().click(function () {
                    OpenFile(fileurl);
                });

                var extensions = imagefiletypes.split(",");
                var isImage = false;
                for (var i = 0; i < extensions.length; i++) {
                    var extension = extensions[i];

                    if (fileurl.length >= extension.length && fileurl.substr(fileurl.length - extension.length) == extension) {
                        isImage = true;
                        break;
                    }
                }

                if (isImage) {
                    $('#file-display-thumb').attr('src', fileurl);
                    $('#file-display-thumb').show();
                }
                else {
                    $('#file-display-thumb').hide();
                }

                $('#image-browser div').show();
            });
        });

    </script>
</head>
<body>
   
    <form id="form1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="toolkitScriptManager" runat="server"></ajaxToolkit:ToolkitScriptManager> 
    <div class="file-manager-holder">
        <div class="container-fluid" id="file-manager-bg">
            <div class="row-fluid">
                <div class="span12">
                    <strong>
                        <p>
                            Please select a file from below list</p>
                    </strong>
                </div>
            </div>
            <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="row-fluid">

                    <table cellpadding="0" cellspacing="0" border="0" style="vertical-align:top; border:none;">
                    
                    <tr>
                    <td width="70%">
                    <JXTControl:S3FileManagerFiles ID="FileManagerFiles" runat="server" BrowserMode="True" />
                    </td>
                    <td width="30%">
                    
                    <div class="span12" id="image-browser">
                            <!--Sidebar content-->
                            <div id="sidebar-thumb-preview">
                                <img src="images/thumb1.jpg" id="file-display-thumb" />
                            </div>
                            <div id="sidebar-file-info">
                                 <input id="file-display-info" class="span8" type="text" placeholder="Copy Url of file" readonly="">
                            </div>
                            <div id="sidebar-insert">
                                <button class="btn btn-large btn-primary" type="button">
                                    Insert into Page</button>
                            </div>
                        </div>
                    </td>
                    </tr>
                    </table>
                        
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="row-fluid" id="footer-row">
                <span class="help-inline file-url-label">File Path / Url: </span>
                <input type="text" class="span9" placeholder="File URL" readonly>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
