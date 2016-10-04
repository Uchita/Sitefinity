<%@ Page Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true"
    CodeBehind="FileUpload.aspx.cs" Inherits="JXTPortal.Website.Admin.FileUpload"
    Title="File Management - File Uploads" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    File Upload
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scriptManager" runat="server" />
    <script type="text/javascript">
        function CheckFileExists() {
            var lbFile = document.getElementById("<%=lbFile.ClientID %>");
            var fuFile = document.getElementById("<%=fuFile.ClientID %>");
            var i = 0;

            for (i = 0; i < lbFile.options.length; i++) {

                var opt = lbFile.options[i];

                if (fuFile.value.indexOf(opt.value) > 0) {
                    return confirm("File Exists. Do you wish to overwrite?");
                }
            }
             
            return true;
        }
    </script>

    <div class="form-all">
        <p>
            Current Files</p>
        <asp:Label ID="lblErrorMsg" runat="server" class="form-required" Visible="false" /><br />
        <asp:ListBox ID="lbFile" runat="server" Rows="10" />
        <span id="lMessage" class="form-message"><asp:Literal ID="litMessage" runat="server" /></span>
        <br />
        <br />
        <asp:FileUpload ID="fuFile" runat="server" />
        <asp:CustomValidator ID="cvalDocument" runat="server" CssClass="fieldstar" ErrorMessage="CustomValidator"
            Display="Dynamic" OnServerValidate="cvalDocument_ServerValidate"></asp:CustomValidator><br />
        <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click"
            OnClientClick="return CheckFileExists();" />
    </div>
</asp:Content>
