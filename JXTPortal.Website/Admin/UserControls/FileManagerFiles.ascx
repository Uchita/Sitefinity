<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FileManagerFiles.ascx.cs"
    Inherits="JXTPortal.Website.Admin.UserControls.FileManagerFiles" %>
<div class="filebrowser1" runat="server" id="file_browser1">
    <div class="row-fluid" id="header-filebrowser1">
        <div class="span4">
            <label for="">
                Name</label></div>
        <div class="span4">
            <label for="">
                Modified</label></div>
        <div class="span2">
            <label for="">
                Size</label></div>
    </div>
    <!-- end of header-filebrowser1 div to hold the header-->
    <div class="row-fluid">
        <div class="span12" id="file-browser2">
            <asp:HiddenField ID="hfCurrentPath" runat="server" />
            <asp:HiddenField ID="hfIsRoot" runat="server" />
            <asp:Repeater ID="rptFiles" runat="server" OnItemDataBound="rptFiles_ItemDataBound">
                <ItemTemplate>
                    <asp:Literal ID="ltlDivClass" runat="server" Text="<div>" />
                    <div class="span4">
                        <asp:LinkButton ID="btnFileLink" runat="server" OnClick="btnFileLink_Click" />
                    </div>
                    <asp:HiddenField ID="hfFileURL" runat="server" />
                    <asp:HiddenField ID="hfIsFolder" runat="server" />
                    <div class="span4">
                        <label for="">
                            <asp:Literal ID="ltlModified" runat="server" />
                        </label>
                    </div>
                    <div class="span2">
                        <label for="">
                            <asp:Literal ID="ltlSize" runat="server" /></label>
                    </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <!-- end of file-browser2 div to hold the list of files-->
    </div>
    <!-- end of row fluid to hold list and header -->
</div>
