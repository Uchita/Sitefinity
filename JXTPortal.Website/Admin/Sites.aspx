<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" Inherits="Sites" Title="Sites List" CodeBehind="Sites.aspx.cs" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">Sites</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="form-all">   
        <asp:Panel runat="server" ID="pnlAdminSiteSearch">  
            <table class="tblNoBorder">
                <tbody>
                        <tr>
                            <td>
                                <label>
                                    Site ID</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAdminSitesListingSiteID" runat="server" CssClass="form-textbox1"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <label>
                                    Site Name</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAdminSitesListingSiteName" runat="server" CssClass="form-textbox2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    Site URL</label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtAdminSitesListingSiteURL" runat="server" CssClass="form-textbox2"></asp:TextBox>
                            </td>                    
                        </tr>                    
                        <tr>
                            <td>
                                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                                    CssClass="jxtadminbutton" ValidationGroup="AdminSites" />
                            </td>
                        </tr>
                    
                </tbody>
            </table>
        
            <span class="form-message">
                <asp:Label ID="lblErrorMsg" runat="server" class="form-required" Visible="false" />
            </span>
            <asp:CompareValidator ID="ctmAdminSiteID" runat="server" ErrorMessage="* Site ID must be numbers"
                ControlToValidate="txtAdminSitesListingSiteID" Type="Integer" Operator="DataTypeCheck"></asp:CompareValidator>
        
        </asp:Panel>
         
        <asp:Repeater ID="rptAdminSites" runat="server" OnItemDataBound="rptAdminSites_ItemDataBound">
            <HeaderTemplate>
               <table cellpadding="3" border="0" class="grid">
                    <thead>
                        <tr class="grid-header">
                            <th scope="col">
                                &nbsp;
                            </th>
                            <th scope="col">
                                &nbsp;
                            </th>
                            <th scope="col">
                                Site
                            </th>
                            <th scope="col">
                                URL
                            </th>
                            <th scope="col">
                                Description
                            </th>
                            <th scope="col">
                                Is Live
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
                        <a href='SitesEdit.aspx?SiteId=<%# Eval("SiteId") %>'>
                            <asp:Literal ID="ltViewSite" runat="server" /></a>
                    </td>
                    <td>
                        <a href='GlobalSettingsEdit.aspx?SiteId=<%# Eval("SiteId") %>'>
                            <asp:Literal ID="ltViewGlobalSetting" runat="server" /></a>
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltAdminSiteName" runat="server" />                        
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltAdminSiteURL" runat="server" />                        
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltAdminSiteDesc" runat="server" />                        
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltIsLive" runat="server" />                        
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltAdminSiteLastModifiedDate" runat="server" />                        
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
    </div>
    
</asp:Content>
