<%@ Page Title="Custom Widget CSS" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true"
    CodeBehind="CustomWidgetCSS.aspx.cs" Inherits="JXTPortal.Website.Admin.CustomWidgetCSS" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Custom Widget CSS Selector
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="form-message">
        <asp:Label ID="lblErrorMsg" runat="server" class="form-required" />
    </span>
    <table cellpadding="3" border="0" class="grid">
        <thead>
            <tr class="grid-header">
                <th scope="col">
                    Valid
                </th>
                <th scope="col">
                    CSS Selector
                </th>
                <th scope="col">
                    CSS Class Name
                </th>
                <th scope="col">
                    Count
                </th>
            </tr>
        </thead>
        <asp:Repeater ID="rptCustomWidget" runat="server" 
            onitemdatabound="rptCustomWidget_ItemDataBound">
            <HeaderTemplate>
                <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td scope="col">
                        <asp:CheckBox ID="cbCSSSelector" runat="server" />
                        <asp:HiddenField ID="hfCustomWidgetCSSSelector" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:TextBox ID="tbCSSSelector" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:TextBox ID="tbCSSClassName" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltCount" runat="server" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
            </FooterTemplate>
        </asp:Repeater>
        <tfoot>
            <tr>
                <td scope="col">
                    &nbsp;</td>
                <td scope="col">
                    <asp:TextBox ID="tbCSSSelector" runat="server" />
                </td>
                <td scope="col">
                    <asp:TextBox ID="tbCSSClassName" runat="server" />
                </td>
                <td scope="col">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="jxtadminbutton" 
                        onclick="btnSave_Click" />
                </td>
            </tr>
        </tfoot>
    </table>
    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="jxtadminbutton" 
        onclick="btnUpdate_Click" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
