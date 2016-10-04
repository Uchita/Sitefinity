<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="KnowledgeBaseCategories" Title="Knowledgebase Categories"
    CodeBehind="KnowledgeBaseCategories.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Knowledge Base Categories List <a href='http://support.jxt.com.au/solution/articles/116440-news-categories-'
        class='jxt-help-page' title='click here for help on this page' target='_blank'>help
        on this page</a>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <span class="form-message">
        <asp:Label ID="lblErrorMsg" runat="server" class="form-required" Visible="false" />
    </span>
    <table cellpadding="3" border="0" class="grid" id="tblKnowledgeBaseCategoriesRepeater">
        <asp:Repeater ID="rptKnowledgeBaseCategories" runat="server">
            <HeaderTemplate>
                <table cellpadding="3" border="0" class="grid">
                    <thead>
                        <tr class="grid-header">
                            <th scope="col">
                                &nbsp;
                            </th>
                            <th scope="col">
                                Category Name
                            </th>
                            <th scope="col">
                                Valid
                            </th>
                            <th scope="col">
                                Sequence
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
                        <a href='KnowledgeBaseCategoryEdit.aspx?Id=<%# Eval("Id") %>'>Edit</a>
                    </td>
                    <td scope="col">
                        <%# Eval("KnowledgeBaseCategoryName")%>
                    </td>
                    <td scope="col">
                        <%# Eval("Valid")%>
                    </td>
                    <td scope="col">
                        <%# Eval("Sequence")%>
                    </td>
                    <td scope="col">
                        <%# Eval("LastModified")%>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
            </FooterTemplate>
        </asp:Repeater>
    </table>
    <br />
    <asp:Button runat="server" ID="btnKnowledgeBaseCategory" OnClientClick="javascript:location.href='KnowledgeBaseCategoryEdit.aspx'; return false;"
        Text="Add New"></asp:Button>
</asp:Content>
