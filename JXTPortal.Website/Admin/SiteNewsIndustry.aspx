<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true" CodeBehind="SiteNewsIndustry.aspx.cs" Inherits="JXTPortal.Website.Admin.SiteNewsIndustry" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    News Industry List
    <a href='http://support.jxt.com.au/solution/articles/116440-news-categories-' class='jxt-help-page' title='click here for help on this page'  target='_blank'>help on this page</a>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <span class="form-message">
                <asp:Label ID="lblErrorMsg" runat="server" class="form-required" Visible="false" />
            </span>
            
        <asp:Repeater ID="rptNewIndustry" runat="server" OnItemDataBound="rptNewIndustry_ItemDataBound">
            <HeaderTemplate>
               <table cellpadding="3" border="0" class="grid">
                    <thead>
                        <tr class="grid-header">
                            <th scope="col">
                                &nbsp;
                            </th>
                            <th scope="col">
                                News Industry Name
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
                        <a href='SiteNewsIndustryEdit.aspx?NewsIndustryId=<%# Eval("NewsIndustryID") %>'>
                            Edit</a>
                    </td>
                    <td scope="col">
                        <%# Eval("NewsIndustryName")%>              
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
    <asp:Button runat="server" ID="btnNewsIndustry" OnClientClick="javascript:location.href='SiteNewsIndustryEdit.aspx'; return false;"
        Text="Add New"></asp:Button>
</asp:Content>