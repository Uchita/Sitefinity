<%@ Page Language="C#" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"
    Inherits="SitesEdit" Title="Sites Edit" CodeBehind="SitesEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Sites - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scriptManager" runat="server" />
    <script type="text/javascript">
    function SetStagingUrl(tbid, stbid)
    {
        var tb = document.getElementById(tbid);
        var stb = document.getElementById(stbid);

        if (tb && stb) {
            stb.value = tb.value + "<%=URLPOSTFIX %>";
        }
    }
    </script>

    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
        <ul class="form-section">
            <li class="form-line">
                <label class="form-label-left">
                    Site Name:<span class="form-required">*</span>
                </label>
                <div class="form-input">
                    <asp:TextBox ID="txtSiteName" runat="server" Width="300px" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                        ControlToValidate="txtSiteName" ErrorMessage="Required"></asp:RequiredFieldValidator><br />
                </div>
            </li>
            <li class="form-line">
                <label class="form-label-left">
                    Site URL:<span class="form-required">*</span>
                    <br />
                    (Remove http://www.)
                </label>
                <div class="form-input">
                    <asp:TextBox ID="txtSiteURL" runat="server" Width="300px" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                        ControlToValidate="txtSiteURL" ErrorMessage="Required"></asp:RequiredFieldValidator><br />
                </div>
            </li>
            <li class="form-line">
                <label class="form-label-left">
                    Staging URL:
                </label>
                <div class="form-input">
                    <asp:TextBox ID="txtStagingSiteUrl" runat="server" ReadOnly="true" Width="300px" />(<%=URLPOSTFIX%>)
                </div>
            </li>
            <%--
            <li class="form-line">
                <label class="form-label-left">
                    Mobile Site URL:
                    <br />
                    (Remove http://www.)
                </label>
                <div class="form-input">
                    <asp:TextBox ID="txtMobileUrl" runat="server" Width="300px" />
                    <!--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
                        ControlToValidate="txtMobileUrl" ErrorMessage="Required"></asp:RequiredFieldValidator>--!><br />
                </div>
            </li>--%>
            <li class="form-line">
                <label class="form-label-left">
                    Site Description:<span class="form-required">*</span>
                </label>
                <div class="form-input">
                    <asp:TextBox ID="txtSiteDescription" runat="server" Width="300px" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                        ControlToValidate="txtSiteDescription" ErrorMessage="Required"></asp:RequiredFieldValidator><br />
                </div>
            </li>
            <li class="form-line">
                <label class="form-label-left">
                    Live:<span class="form-required">*</span>
                </label>
                <div class="form-input">
                    <asp:CheckBox ID="chkLive" runat="server" />
                </div>
            </li>
            <li class="form-line">
                <label class="form-label-left">
                    Site Admin Logo:
                    <br />
                    (width - 300px)
                </label>
                <div class="form-input">
                    <asp:Image ID="imgSiteLogo" runat="server" Width="300" /><br />
                    <asp:FileUpload ID="flAdminSiteLogo" runat="server" />
                </div>
            </li>
            <asp:Panel runat="server" ID="pnlGlobalSettings" Visible="false">
                <li class="form-line">
                    <label class="form-label-left">
                        Global Settings:
                    </label>
                    <div class="form-input">
                        <a href='/admin/GlobalSettingsEdit.aspx?SiteID=<%=Request.QueryString["SiteId"] %>'>
                            Click Here</a>
                    </div>
                </li>
            </asp:Panel>
            <li class="form-line">
                <div class="form-input-wide">
                    <div class="form-buttons-wrapper">
                        <asp:Button ID="btnEditSave" runat="server" Text="Update" OnClick="btnEditSave_Click"
                            CssClass="form-submit-button" />
                        <asp:Button ID="btnReturn" runat="server" Text="Return" OnClick="btnReturn_Click"
                            CssClass="form-submit-button" CausesValidation="false" />
                    </div>
                </div>
            </li>
        </ul>
    </div>
</asp:Content>
