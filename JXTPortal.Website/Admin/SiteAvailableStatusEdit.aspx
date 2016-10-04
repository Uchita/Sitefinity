<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true" CodeBehind="SiteAvailableStatusEdit.aspx.cs" Inherits="JXTPortal.Website.Admin.SiteAvailableStatusEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div class="form-all">
        <span class="form-message"><asp:Literal ID="ltlMessage" runat="server" /></span>
            
        <asp:MultiView ID="MultiViewSiteResource" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewSiteResource" runat="server">                
                <ul class="form-section">
                    <li class="form-line" id="siteAvailableStatus-defaultsettings-field">
                        <label class="form-label-left"><strong>Default Settings</strong></label>
                    </li>
                    <li class="form-line" id="siteAvailableStatus-DefaultAvailableStatusName-field">
                        <label class="form-label-left">Available Status Name:</label>
                        <div class="form-input">
                            <asp:Label ID="lblDefaultAvailableStatusName" runat="server" />
                        </div>
                    </li>
                </ul>    
                
                <%--<ul class="form-section">
                    <!--start of form list-->
                    <li class="form-line" id="siteAvailableStatus-currentsettings-field">
                        <label class="form-label-left"><strong>Current Settings</strong></label>
                    </li>
                    <li class="form-line" id="siteAvailableStatus-CurrentAvailableStatusName-field">
                        <label class="form-label-left">Available Status Name:</label>
                        <div class="form-input">
                            <asp:Label ID="lblCurrentAvailableStatusName" runat="server" />
                        </div>
                    </li>
                    <li class="form-line" id="siteAvailableStatus-currentlastmodified-field">
                        <label class="form-label-left">
                            Last Modified:</label>
                        <div class="form-input">
                            <asp:Label runat="server" ID="lbCurrentLastModified"></asp:Label>
                        </div>
                    </li>
                    <li class="form-line" id="siteAvailableStatus-currentmodifiedby-field">
                        <label class="form-label-left">
                            Modified By:</label>
                        <div class="form-input">
                            <asp:Label runat="server" ID="lbCurrentModifiedBy"></asp:Label>
                        </div>
                    </li>
                </ul>--%>
                
                <ul class="form-section">
                    <li class="form-line" id="siteAvailableStatus-newsettings-field">
                        <label class="form-label-left"><strong>New Settings</strong></label>
                    </li>
                    <li class="form-line" id="siteAvailableStatus-newAvailableStatusName-field">
                        <label class="form-label-left">Available Status Name:<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:TextBox ID="txtNewAvailableStatusName" runat="server" Width="250" Style="vertical-align: top;" />
                            <asp:RequiredFieldValidator ID="ReqVal_NewAvailableStatusName" runat="server" ErrorMessage="Required"
                                ControlToValidate="txtNewAvailableStatusName" />
                        </div>
                    </li>
                    <li class="form-line" id="siteAvailableStatus-currentlastmodified-field">
                        <label class="form-label-left">
                            Last Modified:</label>
                        <div class="form-input">
                            <asp:Label runat="server" ID="lbCurrentLastModified"></asp:Label>
                        </div>
                    </li>
                    <li class="form-line" id="siteAvailableStatus-currentmodifiedby-field">
                        <label class="form-label-left">
                            Modified By:</label>
                        <div class="form-input">
                            <asp:Label runat="server" ID="lbCurrentModifiedBy"></asp:Label>
                        </div>
                    </li>
                    <li class="form-line">
                        <div class="form-input-wide">
                            <div class="form-buttons-wrapper">
                                <asp:Button ID="btnEditSave" runat="server" Text="Update" OnClick="btnEditSave_Click"
                                    CssClass="form-submit-button" />
                                <asp:Button ID="btnUseDefault" runat="server" Text="Use Default" OnClick="btnUseDefault_Click"
                                    CssClass="form-submit-button" />
                                <asp:Button ID="btnReturn" runat="server" Text="Return" OnClick="btnReturn_Click"
                                    CssClass="form-submit-button" CausesValidation="false" />
                            </div>
                        </div>
                    </li>
                </ul>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
