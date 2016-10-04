<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="DynamicPageWebPartTemplates" Title="Web Containers"
    CodeBehind="DynamicPageWebPartTemplates.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Dynamic Page Web Part Templates List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lblErrorMsg" runat="server" class="form-required" Visible="false"
        CssClass="form-message" />
    <table cellpadding="3" border="0" class="grid" id="tblAdvertiserRepeater" visible="false">
        <asp:Repeater ID="rptWebContainer" runat="server" OnItemDataBound="rptWebContainer_ItemDataBound">
            <HeaderTemplate>
                <thead>
                    <tr class="grid-header">
                        <th scope="col">
                            &nbsp;
                        </th>
                        <th scope="col">
                            &nbsp;
                        </th>
                       
                        <th scope="col">
                            Web Container Name
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
                        <a href='/Admin/DynamicPageWebPartTemplatesEdit.aspx?DynamicPageWebPartTemplateId=<%# Eval("DynamicPageWebPartTemplateID") %>'>
                            <asp:Literal ID="ltViewWebContainer" runat="server" Text="Select" /></a>
                    </td>
                    <td>
                        <a href='/Admin/DynamicPageWebPartTemplatesLinkEdit.aspx?DynamicPageWebPartTemplateId=<%# Eval("DynamicPageWebPartTemplateID") %>'>Add Web Part</a>
                    </td>
                    <td>
                        <%# Eval("DynamicPageWebPartName") %>
                    </td>
                    <td>
                        <asp:Literal ID="ltLastModified" runat="server" />
                    </td>
                    
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
            </FooterTemplate>
        </asp:Repeater>
    </table>

    <input type="submit" name="btnEditSaveTop" value="Add" id="btnEditSaveTop" class="jxtadminbutton" onclick="location.href='/Admin/DynamicPageWebPartTemplatesEdit.aspx'; return false;">
</asp:Content>
