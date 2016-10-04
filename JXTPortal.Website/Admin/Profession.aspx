<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="Profession" Title="Global - Default Professions"
    CodeBehind="Profession.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Profession List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-all">
    <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
        <asp:Repeater ID="rptProfession" runat="server" 
            onitemdatabound="rptProfession_ItemDataBound">
            <HeaderTemplate>
                <table cellpadding="3" border="0" class="grid">
                    <thead>
                        <tr class="grid-header">
                            <th scope="col">
                                &nbsp;
                            </th>
                            <th scope="col">
                                ProfessionName
                            </th>
                            <th scope="col">
                                Valid
                            </th>
                            <th scope="col">
                                MetaTitle
                            </th>
                            <th scope="col">
                                MetaKeywords
                            </th>
                            <th scope="col">
                                MetaDescription
                            </th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <a href='ProfessionEdit.aspx?ProfessionId=<%# Eval("ProfessionId") %>'>
                            Select</a>
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltProfessionName" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:CheckBox ID="ltValid" runat="server" Enabled="false" />
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltMetaTitle" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltMetaKeywords" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltMetaDescription" runat="server" />
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
