<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true" CodeBehind="ScreeningQuestionsTemplate.aspx.cs" Inherits="JXTPortal.Website.Admin.ScreeningQuestionsTemplate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Screening Questions Template
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Button ID="btnCreateNewTemplate" runat="server" 
        Text="Create Screening Questions Template" CssClass="jxtadminbutton" 
        onclick="btnCreateNewTemplate_Click" />

    <span class="form-message">
            <asp:Label ID="lblErrorMsg" runat="server" class="form-required" Visible="false" />
        </span>
        
        <asp:Repeater ID="rptScreeningQuestionsTemplate" runat="server" 
        onitemdatabound="rptScreeningQuestionsTemplate_ItemDataBound">
            <HeaderTemplate>
                <table cellpadding="3" border="0" class="grid">
                    <thead>
                        <tr class="grid-header">
                            <th scope="col">
                                &nbsp;
                            </th>
                            <th scope="col">
                                Template ID
                            </th>
                            <th scope="col">
                                Template Name
                            </th>
                            <th scope="col">
                                Visible
                            </th>
                            <th scope="col">
                                Last Modified
                            </th>
                            <th scope="col">
                                Last Modified By
                            </th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <a href='/Admin/ScreeningQuestionsTemplateEdit.aspx?screeningquestionstemplateid=<%# Eval("ScreeningQuestionsTemplateId") %>'>
                            <asp:Literal ID="ltViewTemplate" runat="server" Text="Select" /></a>
                    </td>
                    <td scope="col">
                            <asp:Literal ID="ltTemplateID" runat="server" /></td><td scope="col">
                        
                            <asp:Literal ID="ltTemplateName" runat="server" />
                        </td><td scope="col">
                        
                            <asp:Literal ID="ltVisible" runat="server" />
                        </td><td scope="col">
                        
                            <asp:Literal ID="ltLastModified" runat="server" />
                        </td><td scope="col">
                        
                            <asp:Literal ID="ltLastModifiedBy" runat="server" />
                        </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody></table></FooterTemplate>
        </asp:Repeater>
        <asp:Repeater ID="rptPage" runat="server" OnItemCommand="rptPage_ItemCommand" OnItemDataBound="rptPage_ItemDataBound">
            <HeaderTemplate>
                

                            <table class="grid">
                                <tr>
                                    <td>
                                        <asp:Literal ID="litPage" runat="server" Text="Page:" />
                                    </td>
            </HeaderTemplate>
            <ItemTemplate>
                <td>
                    <asp:LinkButton ID="lbPageNo" runat="server" CommandName="Page" ValidationGroup="AdminMember" />
                </td>
            </ItemTemplate>
            <FooterTemplate>
                </tr> </table> 
            </FooterTemplate>
        </asp:Repeater>
</asp:Content>
