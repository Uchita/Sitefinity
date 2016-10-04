<%@ Page Language="C#" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"
    Inherits="DynamicPages" Title="Dynamic Pages List" CodeBehind="DynamicPages.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Dynamic Pages List
    <a href='http://support.jxt.com.au/solution/articles/116442-dynamic-pages' class='jxt-help-page' title='click here for help on this page'  target='_blank'>help on this page</a>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Button runat="server" ID="btnAddNew" OnClientClick="javascript:location.href='DynamicPageRevisions.aspx'; return false;"
        Text="Add New"></asp:Button>
    <asp:Button runat="server" ID="btnSearchDynamicPage" OnClientClick="javascript:location.href='DynamicPageSearch.aspx'; return false;"
        Text="Search Dynamic Page"></asp:Button>
    <table class="tblDynamicPages">
        <tr>
            <td>
                <strong>Language</strong>
            </td>
            <td>
                <asp:DropDownList ID="ddlLanguage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLanguage_SelectedIndexChanged" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div id="treecontrol">
                    <a title="Collapse the entire tree below" href="#">Collapse All</a> <a title="Expand the entire tree below"
                        href="#">Expand All</a> <a title="Toggle the tree below, opening closed branches, closing open branches"
                            href="#">Toggle All</a>
                </div>
                <asp:Literal ID="ltlDynamicPages" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">

    <script type="text/javascript" language="javascript" src="/admin/scripts/jquery.treeview.js"></script>

    <link href="/Admin/styles/jquery.treeview.css" rel="stylesheet" type="text/css" />
</asp:Content>
