<%@ Page Title="Custom Widget" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true"
    CodeBehind="CustomWidget.aspx.cs" Inherits="JXTPortal.Website.Admin.CustomWidget" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Custom Widget
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Button ID="btnAdd" runat="server" Text="Add New" CssClass="jxtadminbutton" CausesValidation="false" 
        onclick="btnAdd_Click" />
    <span class="form-message">
        <asp:Label ID="lblErrorMsg" runat="server" class="form-required" />
    </span>
    <asp:Repeater ID="rptCustomWidget" runat="server" OnItemDataBound="rptCustomWidget_ItemDataBound">
        <HeaderTemplate>
            <table cellpadding="3" border="0" class="grid">
                <thead>
                    <tr class="grid-header">
                        <th scope="col">
                            &nbsp;
                        </th>
                        <th scope="col">
                            Custom Widget ID
                        </th>
                        <th scope="col">
                            Custom Widget Name
                        </th>
                        <th scope="col">
                            CSS Selected
                        </th>
                        <th scope="col">
                            Last Modified
                        </th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <a href='CustomWidgetEdit.aspx?CustomWidgetID=<%# Eval("CustomWidgetID") %>'>Edit</a>
                </td>
                <td scope="col">
                    <%# Eval("CustomWidgetID")%>
                </td>
                <td scope="col">
                    <%# Eval("CustomWidgetName")%>
                </td>
                <td scope="col">
                    <%# Eval("CustomWidgetCSSSelectorName")%>
                </td>
                <td scope="col">
                    <asp:Literal ID="ltModifiedDate" runat="server" />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody></table></FooterTemplate>
    </asp:Repeater>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
