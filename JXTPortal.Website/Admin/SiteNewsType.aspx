<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true" CodeBehind="SiteNewsType.aspx.cs" Inherits="JXTPortal.Website.Admin.SiteNewsType" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    News Type List
    <a href='http://support.jxt.com.au/solution/articles/116440-news-categories-' class='jxt-help-page' title='click here for help on this page'  target='_blank'>help on this page</a>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <span class="form-message">
                <asp:Label ID="lblErrorMsg" runat="server" class="form-required" Visible="false" />
            </span>
            
        <asp:Repeater ID="rptNewsType" runat="server" OnItemDataBound="rptNewsType_ItemDataBound">
            <HeaderTemplate>
               <table cellpadding="3" border="0" class="grid">
                    <thead>
                        <tr class="grid-header">
                            <th scope="col">
                                &nbsp;
                            </th>
                            <th scope="col">
                                News Type Name
                            </th>
                            <th scope="col">
                                Sequence
                            </th>
                            <th scope="col">
                                Last Modified Date
                            </th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <a href='SiteNewsTypeEdit.aspx?NewsTypeId=<%# Eval("NewsTypeID") %>'>
                            Edit</a>
                    </td>
                    <td scope="col">
                        <%# Eval("NewsTypeName")%>              
                    </td>
                    <td scope="col">
                        <%# Eval("Sequence")%>                     
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltLastModifiedDate" runat="server" />               
                    </td>                   
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody></FooterTemplate>
        </asp:Repeater>
      
        </table>
    <br />
    <asp:Button runat="server" ID="btnNewsTypes" OnClientClick="javascript:location.href='SiteNewsTypeEdit.aspx'; return false;"
        Text="Add New"></asp:Button>
</asp:Content>