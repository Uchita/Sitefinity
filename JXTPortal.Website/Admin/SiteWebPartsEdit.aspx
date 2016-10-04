<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    ValidateRequest="false" AutoEventWireup="true" Inherits="SiteWebPartsEdit" Title="Web Containers - Web Parts Edit"
    CodeBehind="SiteWebPartsEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Site Web Parts - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table class="tblNoBorder">
        <tr>
            <td>
                Web Part Type
            </td>
            <td>
                <asp:DropDownList ID="ddlWebPartType" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Web Part Name
            </td>
            <td>
                <asp:TextBox ID="txtWebPartName" runat="server"/>
            </td>
        </tr>
        <tr>
            <td>
                Web Part Content
            </td>
            <td>
                [[top-navbar]]
                <br />
                [[left-navbar]]
                <br />
                [[footer-default]]<br />
                [[dynamic-navigation]]<br />
                [[related-pages]]<br />
                [[webpart-breadcrumb]]<br />
                [[custom-widget-group-left]]<br />
                [[custom-widget-group-right]]<br />
                [[member-status]]<br />
                [[member-status-dashboard]]<br />
                [[user-loginstatus-no-menu]]<br />
                [[user-loginstatus-with-menu]]<br />
                [[member-savedjobs-count]]<br />
                [[member-applicationtracker-count]]<br />
                [[member-favsearches-count]]<br />
                <%--<FredCK:CKEditorControl ID="txtWebPartContent" runat="server" Width="650px" Height="400px"
                    CustomConfig="custom_config.js" Toolbar="FullToolbar" EnableViewState="false">
                </FredCK:CKEditorControl>--%>
                <asp:TextBox id="txtWebPartContent" runat="server" TextMode="MultiLine" Rows="15" style="height: 450px; width: 700px;" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnApply" runat="server" Text="Apply" OnClick="btnSave_Click" CssClass="jxtadminbutton" /><asp:Button
                    ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="jxtadminbutton" />
            </td>
            <td>
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false"
                    OnClick="btnCancel_Click" CssClass="jxtadminbutton" />
            </td>
        </tr>
    </table>
</asp:Content>
