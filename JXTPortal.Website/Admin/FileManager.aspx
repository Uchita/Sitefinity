<%@ Page Title="File Manager" Language="C#" MasterPageFile="~/MasterPages/admin.Master"
    AutoEventWireup="true" CodeBehind="FileManager.aspx.cs" Inherits="JXTPortal.Website.Admin.FileManager"
    ClientIDMode="AutoID" EnableEventValidation="false" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    File Manager
    <a href='http://support.jxt.com.au/solution/articles/116443-file-manager' class='jxt-help-page' title='click here for help on this page'  target='_blank'>help on this page</a>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<ajaxToolkit:ToolkitScriptManager ID="toolkitScriptManager" runat="server"></ajaxToolkit:ToolkitScriptManager>
    <div class="file-manager-holder">
        <asp:UpdatePanel ID="updatePanel" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:PlaceHolder ID="phFileManager" runat="server">
                    <div class="container-fluid" id="file-manager-bg">
                        <div class="row-fluid">
                            <table cellpadding="0" cellspacing="0" border="0" class="filemanager-holder-tble">
                                <tr>
                                    <td width="60%" valign="top" align="left">
                                        <asp:FileUpload ID="fileUpload" runat="server" size="20" />
                                        <button runat="server" id="btnUpload" data-loading-text="Loading..." onserverclick="btnUpload_Click"
                                            onclick="FileAlreadyExists(); return false;" class="btn btn-success">
                                            Upload file</button>
                                        <%--<div class="fileupload fileupload-new" data-provides="fileupload">
                                            <input type="hidden" value="" name="">
                                            <span class="btn btn-file"><span class="fileupload-new">Select file</span><span class="fileupload-exists">Change</span></span> <span class="fileupload-preview"></span>
                                            <a href="#" class="close fileupload-exists" data-dismiss="fileupload">×</a>
                                        </div>--%>
                                    </td>
                                    <td width="40%" valign="top" align="right">
                                        <a class="btn btn-warning" role="button" data-toggle="modal" id="jxt-create-folder"
                                            href="#myModal5"><i class="icon-folder-open icon-white"></i>Create Folder</a>
                                        <a class="btn btn-info" id="jxt-move-selected-file" href="#myModal6" role="button"
                                            data-toggle="modal"><i class="icon-folder-open icon-white"></i>Move Selected File</a>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <!-- end of header section -->
                        <div class="row-fluid">
                            <table cellpadding="0" cellspacing="0" border="none" class="filemanager-holder-tble">
                                <tr>
                                    <td width="25%" valign="top" align="left" style="vertical-align: top;">
                                        <div id="root-browser">
                                            <!--Sidebar content-->
                                            <div id="root-scroll">
                                                <p class="jxt-root-final">
                                                    <asp:LinkButton ID="btnRoot" runat="server" Text="Root" OnClick="btnRoot_Click" /></p>
                                                <asp:Repeater ID="rptFolders" runat="server" OnItemDataBound="rptFolders_ItemDataBound"
                                                    OnItemCreated="rptFolders_ItemCreated">
                                                    <ItemTemplate>
                                                        <p class="subfolder1">
                                                            <asp:LinkButton ID="btnFolder" runat="server" OnClientClick="$.blockUI.defaults.blockMsgClass = 'blockUI-loading';  $.blockUI({ message: '<img src=images/ajax-loader.gif /><span>Loading...</span>' });" />
                                                        </p>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                <!--end of tree control div-->
                                            </div>
                                            <!--end of root scroll span12 div-->
                                        </div>
                                    </td>
                                    <!--end of root browser span3 div-->
                                    <td width="75%" valign="top" align="left">
                                        <JXTControl:FileManagerFiles ID="FileManagerFiles" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <!-- end of middle block-->
                        <div class="row-fluid" id="footer-row">
                            <span class="help-inline file-url-label">File Path / Url: </span>
                            <input id="fileurl" type="text" class="span9" placeholder="File URL">
                        </div>
                    </div>
                </asp:PlaceHolder>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnFileDownload" />
                <asp:PostBackTrigger ControlID="btnNonImageDownload" />
                <asp:PostBackTrigger ControlID="btnUpload" />
                <asp:AsyncPostBackTrigger ControlID="btnCreateFolderConfirm" />
            </Triggers>
        </asp:UpdatePanel>
        <script type='text/javascript'>
            $(function () {
                $('#browser').treeview({ control: '#treecontrol' }); $('#browser').bind('contextmenu',
    function (event) {
        if ($(event.target).is('li') || $(event.target).parents('li').length) {
            $('#browser').treeview({ remove: $(event.target).parents('li').filter(':first')
            }); return false;
        }
    });
            }) </script>
    </div>
    <div class="vs-context-menu1">
        <input type="hidden" id="hfFileURL" runat="server" />
        <ul>
            <li class="preview"><a href="#myModal" role="button" data-toggle="modal">Preview</a></li>
            <li class="download">
                <asp:LinkButton ID="btnFileDownload" runat="server" Text="Download" OnClick="btnFileDownload_Click" />
            </li>
            <li class="edit"><a href="#myModal3" role="button" data-toggle="modal">Rename</a></li>
            <li class="delete">
                <asp:LinkButton ID="btnFileDelete" runat="server" Text="Delete" OnClick="btnFileDelete_Click"
                    OnClientClick="$.blockUI.defaults.blockMsgClass = 'blockUI-loading'; $.blockUI({ message: '<img src=images/ajax-loader.gif /><span>Deleting File...</span>' });" />
            </li>
        </ul>
    </div>
    <div class="vs-context-menu2">
        <input type="hidden" id="hfFolderName" runat="server" />
        <ul>
            <li class="open-folder">
                <asp:LinkButton ID="btnFolderOpen" runat="server" Text="Open" OnClick="btnFolderOpen_Click" />
            </li>
            <li class="edit"><a href="#myModal4" role="button" data-toggle="modal">Rename</a></li>
            <li class="delete">
                <asp:LinkButton ID="btnFolderDelete" runat="server" Text="Delete" OnClick="btnFolderDelete_Click"
                    OnClientClick="$.blockUI.defaults.blockMsgClass = 'blockUI-loading'; $.blockUI({ message: '<img src=images/ajax-loader.gif /><span>Deleting Folder...</span>' });" /></li>
        </ul>
    </div>
    <div class="vs-context-menu3">
        <input type="hidden" id="hfNonImageFileURL" runat="server" />
        <ul>
            <li class="download">
                <asp:LinkButton ID="btnNonImageDownload" runat="server" Text="Download" OnClick="btnNonImageDownload_Click" /></li>
            <li class="edit"><a href="#myModal3" role="button" data-toggle="modal">Rename</a></li>
            <li class="delete">
                <asp:LinkButton ID="btnNonImageDelete" runat="server" Text="Delete" OnClick="btnNonImageDelete_Click" /></li>
        </ul>
    </div>
    <div class="fixedVersion">
        <div id="myModal" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
            aria-hidden="true">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    &times;</button>
                <h3 id="myModalLabel">
                    File Preview</h3>
            </div>
            <div class="modal-body">
                <div class="thumb-outter-popup">
                    <div class="thumb-inner-popup">
                        <img src="images/filemanager-interface1.png">
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <label>
                    File Url:</label>
                <div class="controls">
                    <input class="span7" type="text" placeholder="Copy Url of file" readonly>
                </div>
            </div>
        </div>
        <!--end of modal 1-->
        <div id="myModal2" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
            aria-hidden="true">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    &times;</button>
                <h3 id="myModalLabel">
                    Move Selected file</h3>
            </div>
            <div class="modal-body">
                <select class="span6">
                    <option value="">Folder</option>
                    <option value="">Folder</option>
                    <option value="">Folder</option>
                    <option value="">Folder</option>
                    <option value="">Folder</option>
                </select>
            </div>
            <div class="modal-footer">
                <button class="btn btn-success">
                    Confirm</button>
            </div>
        </div>
        <!--end of modal 2-->
        <div id="myModal3" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
            aria-hidden="true">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    &times;</button>
                <h3 id="H1">
                    Rename Selected File</h3>
            </div>
            <div class="modal-body">
                <input type="hidden" runat="server" id="hfOriginalFileName" />
                <asp:TextBox ID="tbRenameFile" runat="server" /><span id="spFileExtension" runat="server"></span>
                <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                    <ProgressTemplate>
                        <img src="/Admin/images/ajax-loader.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:RequiredFieldValidator ID="rfvRenameFile" runat="server" ErrorMessage="File Name cannot be empty"
                    ControlToValidate="tbRenameFile" ValidationGroup="RenameFile" />
                <asp:CustomValidator ID="cvRenameFile" runat="server" ValidationGroup="RenameFile"
                    OnServerValidate="cvRenameFile_ServerValidate" />
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-success" id="btnRenameFileConfirm" runat="server"
                    validationgroup="RenameFile" onserverclick="btnRenameFileConfirm_Click" causesvalidation="true">
                    Confirm</button>
            </div>
        </div>
        <!--end of modal 3-->
        <div id="myModal4" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
            aria-hidden="true">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    &times;</button>
                <h3 id="H2">
                    Rename Selected Folder</h3>
            </div>
            <div class="modal-body">
                <input type="hidden" runat="server" id="hfOriginalFolderName" />
                <asp:TextBox ID="tbRenameFolder" runat="server" />
                <asp:UpdateProgress ID="UpdateProgress3" runat="server">
                    <ProgressTemplate>
                        <img src="/Admin/images/ajax-loader.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:RequiredFieldValidator ID="rfvRenameFolder" runat="server" ErrorMessage="Folder Name cannot be empty"
                    ControlToValidate="tbRenameFolder" ValidationGroup="RenameFolder" />
                <asp:CustomValidator ID="cvRenameFolder" runat="server" ValidationGroup="RenameFolder"
                    OnServerValidate="cvRenameFolder_ServerValidate" />
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-success" id="btnRenameFolderConfirm" runat="server"
                    validationgroup="RenameFolder" onserverclick="btnRenameFolderConfirm_Click" causesvalidation="true">
                    Confirm</button>
            </div>
        </div>
        <!--end of modal 4-->
        <div id="myModal5" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
            aria-hidden="true">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    &times;</button>
                <h3 id="H3">
                    Create Folder</h3>
            </div>
            <div class="modal-body">
                <asp:TextBox ID="tbCreateFolder" runat="server" Width="512" ValidationGroup="CreateFolder" />
                <asp:UpdateProgress ID="upCreateFolder" runat="server">
                    <ProgressTemplate>
                        <img src="/Admin/images/ajax-loader.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:RequiredFieldValidator ID="rfvCreateFolder" runat="server" ErrorMessage="Folder Name cannot be empty"
                    ControlToValidate="tbCreateFolder" ValidationGroup="CreateFolder" />
                <asp:CustomValidator ID="cvCreateFolder" runat="server" ValidationGroup="CreateFolder"
                    OnServerValidate="cvCreateFolder_ServerValidate" />
            </div>
            <div class="modal-footer">
                <input type="button" class="btn btn-success" id="btnCreateFolderConfirm" runat="server"
                    validationgroup="CreateFolder" causesvalidation="true" value="Confirm" onserverclick="btnCreateFolderConfirm_Click" />
            </div>
        </div>
        <!--end of modal 5-->
        <div id="myModal6" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
            aria-hidden="true">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    &times;</button>
                <h3 id="H4">
                    Move Selected File</h3>
            </div>
            <div class="modal-body">
                <input type="hidden" runat="server" id="hfMoveSelectedFileName" />
                <asp:DropDownList ID="ddlFolders" runat="server" AutoPostBack="false" />
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <img src="/Admin/images/ajax-loader.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-success" id="btnMoveSelectedFileConfirm" runat="server"
                    onserverclick="btnMoveSelectedFileConfirm_Click" causesvalidation="false">
                    Confirm</button>
            </div>
        </div>
        <!--end of modal 6-->
        <div id="myModal7" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
            aria-hidden="true">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    &times;</button>
                <h3 id="H5">
                    Replace File</h3>
            </div>
            <div class="modal-body">
                Replacing file, Are you sure?
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-success" id="Button1" runat="server"
                    onserverclick="btnMoveSelectedFileConfirm_Click" causesvalidation="false">
                    Confirm</button>
            </div>
        </div>
        <!--end of modal 7-->
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.context1').each(function (i, obj) { $(obj).vscontext({ menuBlock: 'vs-context-menu1' }, $(obj).find('input[type="hidden"]').first().val()); });
            $('.context2').each(function (i, obj) { $(obj).vscontext({ menuBlock: 'vs-context-menu2' }, $(obj).find('a').first().text()); });
            $('.context3').each(function (i, obj) { $(obj).vscontext({ menuBlock: 'vs-context-menu3' }, $(obj).find('input[type="hidden"]').first().val()); });
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    <link rel="stylesheet" type="text/css" href="css/bootstrap.css">
    <link rel="stylesheet" type="text/css" href="css/bootstrap-fileupload.css">
    <link rel="stylesheet" type="text/css" href="css/vscontext.css">
    <link rel="stylesheet" type="text/css" href="css/jqueryui.css" />
    <link href="/Admin/styles/jquery.treeview.css" rel="stylesheet" type="text/css" />
    <!--[if gte IE 9 ]><link rel="stylesheet" type="text/css" href="css/treeview.css" media="screen"><![endif]-->
    <!--[if !IE]>-->
    <link rel="stylesheet" type="text/css" href="css/treeview.css" media="screen">
    <!--<![endif]-->
    <link rel="stylesheet" type="text/css" href="css/normalise.css">
    <link rel="stylesheet" type="text/css" href="css/overwrite.css">
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
        var confirmed = false;

        $(document).ready(function (e) {
            
            $('.droppable').click(function () {
                $('.droppable').removeClass('active');
                $(this).addClass('active');

                var fileurl = $(this).find('input[type="hidden"]').first().val();
                $('#footer-row').find('input[type="text"]').first().val(fileurl);
            });

            $.blockUI.defaults.theme = true;

            //            $('body').remove('.fixedVersion');
        });

        function FileAlreadyExists() {
            var found = false;

            $('#file-browser2 .droppable .span4 a').each(function () {
                if ($('#ctl00_ContentPlaceHolder1_fileUpload').val().endsWith("\\" + $(this).html())) {
                    $.blockUI.defaults.blockMsgClass = 'blockUI-loading';
                    $.blockUI({
                        onOverlayClick: $.unblockUI,
                        message: 'File ' + $(this).html() + ' already exists. Are you sure you want to replace it?<br /><br /><input type="button" id="btnReplaceConfirm" onclick="__doPostBack(\'ctl00$ContentPlaceHolder1$btnUpload\',\'\')" class="btn btn-success" value="Yes" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type="button" id="btnReplaceReject" onclick="$.unblockUI()" class="btn btn-warning" value="No" />'
                    });

                    found = true;

                    return false;
                }
            });

            if (!found) {
                __doPostBack('ctl00$ContentPlaceHolder1$btnUpload', '');
            }
        }
    </script>
</asp:Content>
