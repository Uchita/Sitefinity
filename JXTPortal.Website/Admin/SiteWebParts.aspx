<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="SiteWebParts" Title="Web Containers - Web Parts"
    CodeBehind="SiteWebParts.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Web Containers</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lblErrorMsg" runat="server" class="form-required" Visible="false"
        CssClass="form-message" />
    <table cellpadding="3" border="0" class="grid" id="tblAdvertiserRepeater" visible="false">
        <asp:Repeater ID="rptWebPart" runat="server" 
            onitemdatabound="rptWebPart_ItemDataBound">
            <HeaderTemplate>
                <thead>
                    <tr class="grid-header">
                        <th scope="col">
                            &nbsp;
                        </th>
                       
                        <th scope="col">
                            Site Web Part Name
                        </th>
                        <th scope="col">
                            Site Web Part Type
                        </th>
                       
                    </tr>
                </thead>
                <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <a href='/Admin/SiteWebPartsEdit.aspx?SiteWebPartId=<%# Eval("SiteWebPartId") %>'>
                            <asp:Literal ID="ltViewWebContainer" runat="server" Text="Select" /></a>
                    </td>
                    <td>
                        <%# Eval("SiteWebPartName")%>
                    </td>
                    <td>
                        <asp:Literal ID="ltWebPartType" runat="server" />
                    </td>
                    
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
            </FooterTemplate>
        </asp:Repeater>
    </table>

    <input type="submit" name="btnEditSaveTop" value="Add" id="btnEditSaveTop" class="jxtadminbutton" onclick="location.href='/Admin/SiteWebPartsEdit.aspx'; return false;">
</asp:Content>
