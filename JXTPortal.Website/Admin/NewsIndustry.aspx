<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true" CodeBehind="NewsIndustry.aspx.cs" Inherits="JXTPortal.Website.Admin.NewsIndustry" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
Default News Industry List
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<br />
    <table cellpadding="3" border="0" class="grid" id="tblEducationRepeater">
        <asp:Repeater ID="rptNewsIndustry" runat="server" OnItemCommand="rptNewsIndustry_ItemCommand"
            OnItemDataBound="rptNewsIndustry_ItemDataBound">
            <HeaderTemplate>
                <thead>
                    <tr class="grid-header">
                        <th scope="col">
                            &nbsp;
                        </th>
                        <th scope="col">
                            News Industry Name
                        </th>
                        <th scope="col">
                            Global Template
                        </th>
                        <th scope="col">
                            Sequence
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
                        <asp:LinkButton ID="lbSelect" runat="server" Text="Select" CommandName="Select" />
                    </td>
                    <td>
                        <asp:Literal ID="litNewsIndustryName" runat="server" />
                    </td>
                    <td>
                        <asp:CheckBox ID="cbGlobalTemplate" runat="server" Enabled="false" />
                    </td>
                    <td>
                        <asp:Literal ID="litSequence" runat="server" />
                    </td>
                    <td>
                        <asp:Literal ID="litLastModified" runat="server" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Repeater ID="rptPage" runat="server" OnItemCommand="rptPage_ItemCommand" OnItemDataBound="rptPage_ItemDataBound">
            <HeaderTemplate>
                 <tfoot>
                    <tr>
                        <td colspan="5">
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
                </tr> </table> </td> </tr> </tfoot>
            </FooterTemplate>
        </asp:Repeater>
    </table>
    <br />
    <asp:Button runat="server" ID="btnNewsIndustry" OnClientClick="javascript:location.href='NewsIndustryEdit.aspx'; return false;"
        Text="Add New"></asp:Button>
	    		
</asp:Content>

