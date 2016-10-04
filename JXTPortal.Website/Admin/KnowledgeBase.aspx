<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="KnowledgeBase" Title="Knowledge Base - List"
    CodeBehind="KnowledgeBase.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Knowledge Base List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <table cellpadding="3" border="0" class="grid" id="tblKnowledgeBaseRepeater">
        <asp:Repeater ID="rptKnowledgeBase" runat="server">
            <HeaderTemplate>
                <thead>
                    <tr class="grid-header">
                        <th scope="col">
                            &nbsp;
                        </th>
                        <th scope="col">
                            Subject
                        </th>
                        <th scope="col">
                            Valid
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
                        <a href='KnowledgeBaseEdit.aspx?Id=<%# Eval("Id") %>'>Edit</a>
                    </td>
                    <td>
                        <%# Eval("Subject")%>
                    </td>
                    <td>
                        <%# Eval("Valid")%>
                    </td>
                    <td>
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
    <asp:Button runat="server" ID="btnKnowledgeBase" OnClientClick="javascript:location.href='KnowledgeBaseEdit.aspx'; return false;"
        Text="Add New"></asp:Button>
</asp:Content>
