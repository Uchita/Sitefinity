<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DynamicPageWebPartTemplatesLink.ascx.cs" Inherits="JXTPortal.Website.Admin.UserControls.DynamicPageWebPartTemplatesLink" %>

<asp:Repeater ID="rptWebParts" runat="server">
    <HeaderTemplate>
        <table cellpadding="3" border="0" class="grid">
            <tbody>
                <tr class="grid-header">
                    <th scope="col">&nbsp;</th>         
                    <th scope="col">Web Part Template Id</th>                        
                    <th scope="col">Web Container Name</th>
                    <th scope="col">Site WebPart Id</th>
                    <th scope="col">Site WebPart Name</th>
                    <th scope="col">Sequence</th>
                </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td><asp:LinkButton ID="lnkDeleteFile" Runat="server" OnClientClick="return confirm('Are you sure you want to delete this record?');"
                            CommandName="Delete" CommandArgument='<%# Eval("DynamicPageWebPartTemplateId") + "," + Eval("SiteWebPartId")%>' CausesValidation="false" 
                            OnClick="lnkDeleteFile_Click">Delete</asp:LinkButton>
            </td>
            <td><%# Eval("DynamicPageWebPartTemplateId")%></td>
            <td><%# Eval("DynamicPageWebPartName")%></td>
            <td><%# Eval("SiteWebPartId")%></td>
            <td><a href='SiteWebPartsEdit.aspx?SiteWebPartId=<%# Eval("SiteWebPartId")%>'><%# Eval("SiteWebPartName")%></a></td>
            <td><%# Eval("Sequence")%></td>
        </tr>
    </ItemTemplate>
    <AlternatingItemTemplate>
        <tr class="grid-alt-row">
            <td><asp:LinkButton ID="lnkDeleteFile" Runat="server" OnClientClick="return confirm('Are you sure you want to delete this record?');"
                            CommandName="Delete" CommandArgument='<%# Eval("DynamicPageWebPartTemplateId") + "," + Eval("SiteWebPartId")%>' CausesValidation="false" 
                            OnClick="lnkDeleteFile_Click">Delete</asp:LinkButton>
            </td>
            <td><%# Eval("DynamicPageWebPartTemplateId")%></td>                
            <td><%# Eval("DynamicPageWebPartName")%></td>
            <td><%# Eval("SiteWebPartId")%></td>
            <td><a href='SiteWebPartsEdit.aspx?SiteWebPartId=<%# Eval("SiteWebPartId")%>'><%# Eval("SiteWebPartName")%></a></td>
            <td><%# Eval("Sequence")%></td>
        </tr>
    </AlternatingItemTemplate>
    <FooterTemplate>
                </tbody>
        </table>
    </FooterTemplate>
</asp:Repeater>
    
    
