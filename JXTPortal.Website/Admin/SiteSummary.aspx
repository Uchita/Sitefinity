<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true"
    CodeBehind="SiteSummary.aspx.cs" Inherits="JXTPortal.Website.Admin.SiteSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Site Summary
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="form-message">
        <asp:Label ID="lblErrorMsg" runat="server" class="form-required" Visible="false" />
    </span>
    <style>
        .grid { width: 100% }
        .grid td { min-width: 90px;}
    </style>
    <asp:Repeater ID="rptSiteSummary" runat="server" OnItemDataBound="rptSiteSummary_ItemDataBound">
        <HeaderTemplate>
            <table cellpadding="3" border="0" class="grid">
                <thead>
                    <tr class="grid-header">
                        <asp:PlaceHolder ID="phHeadCol" runat="server">
                            <th scope="col">
                                &nbsp;
                            </th>
                        </asp:PlaceHolder>
                        <th scope="col">
                            URL
                        </th>
                        <th scope="col">
                            Title
                        </th>
                        <th scope="col">
                            Description
                        </th>
                        <th scope="col">
                            Time Stamp
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
                <asp:PlaceHolder ID="phCol" runat="server">
                    <td>
                        <a href='/Admin/SiteSummaryEdit.aspx?SiteSummaryID=<%# Eval("SiteSummaryID") %>'>
                            Edit</a>
                    </td>
                </asp:PlaceHolder>
                <td scope="col">
                    <asp:HyperLink ID="hlURL" runat="server" Target="_blank" Text="View More Info" />
                </td>
                <td scope="col">
                    <asp:Literal ID="ltTitle" runat="server" />
                </td>
                <td scope="col">
                    <asp:Literal ID="ltDescription" runat="server" />
                </td>
                <td scope="col">
                    <asp:Literal ID="ltTimeStamp" runat="server" />
                </td>
                <td scope="col">
                    <asp:Literal ID="ltValid" runat="server" />
                </td>
                <td scope="col">
                    <asp:Literal ID="ltLastModified" runat="server" />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody></table></FooterTemplate>
    </asp:Repeater>
    <asp:Repeater ID="rptPage" runat="server" OnItemCommand="rptPage_ItemCommand" OnItemDataBound="rptPage_ItemDataBound">
        <HeaderTemplate>
            <table>
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
    <asp:Button runat="server" ID="btnSiteSummary" OnClientClick="javascript:location.href='SiteSummaryEdit.aspx'; return false;"
        Text="Add New" CssClass="jxtadminbutton"></asp:Button>
</asp:Content>
