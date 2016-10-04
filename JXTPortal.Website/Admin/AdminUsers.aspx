<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="AdminUsers" Title="Global - Admin Users" CodeBehind="AdminUsers.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Admin Users List
    <a href='http://support.jxt.com.au/solution/articles/116437-create-edit-admin-content-editor-and-external-users' class='jxt-help-page' title='click here for help on this page'  target='_blank'>help on this page</a>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
<%--    <data:EntityGridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
         DataKeyNames="AdminUserId" 
        AllowMultiColumnSorting="false" DefaultSortColumnName=""
        DefaultSortDirection="Ascending" 
        ExcelExportFileName="Export_AdminUsers.xls" 
        onpageindexchanging="GridView1_PageIndexChanging">
        <Columns>
            <asp:CommandField ShowSelectButton="True" ShowEditButton="False" />
            <asp:BoundField DataField="UserName" HeaderText="User Name" SortExpression="[UserName]" />
            <asp:TemplateField HeaderText="Role">
                <ItemTemplate>
                    <asp:Label ID="lbRole" runat="Server" Text='<%# ((JXTPortal.Entities.PortalEnums.Admin.AdminRole)Convert.ToInt32(Eval("AdminRoleID"))).ToString() %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="[FirstName]" />
            <asp:BoundField DataField="Surname" HeaderText="Surname" SortExpression="[Surname]" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="[Email]" />
        </Columns>
        <EmptyDataTemplate>
            <b>No AdminUsers Found!</b>
        </EmptyDataTemplate>
    </data:EntityGridView>
    <br />
        
    --%>
            <span class="form-message">
                <asp:Label ID="lblErrorMsg" runat="server" class="form-required" Visible="false" />
            </span>
            
        <asp:Repeater ID="rptAdminUsers" runat="server" OnItemDataBound="rptAdminUsers_ItemDataBound">
            <HeaderTemplate>
               <table cellpadding="3" border="0" class="grid">
                    <thead>
                        <tr class="grid-header">
                            <th scope="col">
                                &nbsp;
                            </th>
                            <th scope="col">
                                UserName
                            </th>
                            <th scope="col">
                                FirstName
                            </th>
                            <th scope="col">
                                Surname
                            </th>
                            <th scope="col">
                                Email
                            </th>
                            <th scope="col">
                                Type
                            </th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <a href='AdminUsersEdit.aspx?AdminUserId=<%# Eval("AdminUserID") %>'>
                            Edit</a>
                    </td>
                    <td scope="col">
                        <%# Eval("UserName")%>              
                    </td>
                    <td scope="col">
                        <%# Eval("FirstName")%>                     
                    </td>
                    <td scope="col">
                        <%# Eval("Surname")%>
                    </td>
                    <td scope="col">
                        <%# Eval("Email")%>                   
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltType" runat="server" />
                    </td>                    
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody></FooterTemplate>
        </asp:Repeater>
        
        
        <asp:Repeater ID="rptPage" runat="server" OnItemCommand="rptPage_ItemCommand" OnItemDataBound="rptPage_ItemDataBound">
            <HeaderTemplate>
                <tfoot>
                    <tr>
                        <td colspan="8">
                            <table>
                                <tr>
                                    <td>
                                        Page:
                                    </td>
            </HeaderTemplate>
            <ItemTemplate>
                <td>
                    <asp:LinkButton ID="lbPageNo" runat="server" CommandName="Page" ValidationGroup="AdminSites" />
                </td>
            </ItemTemplate>
            <FooterTemplate>
                </tr> </table> </td> </tr> </tfoot>
            </FooterTemplate>
            
        </asp:Repeater>
        </table>
        
    <asp:Button runat="server" ID="btnAdminUsers" OnClientClick="javascript:location.href='AdminUsersEdit.aspx'; return false;"
        Text="Add New" CssClass="jxtadminbutton"></asp:Button>
</asp:Content>
