<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="Jobs" Title="Jobs List" CodeBehind="Jobs.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Jobs List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="3" border="0" class="grid" id="tblAdvertiserRepeater" visible="false">
        <asp:Repeater ID="rptJobs" runat="server" OnItemDataBound="rptJobs_ItemDataBound">
            <HeaderTemplate>
                <thead>
                    <tr class="grid-header">
                        <th scope="col">
                            &nbsp;
                        </th>
                        <th scope="col">
                            <asp:Label ID="lbRefNo" runat="server">Ref No</asp:Label>
                        </th>
                        <th scope="col">
                            <asp:Label ID="lblJobName" runat="server">Job Title</asp:Label>
                        </th>
                        <th scope="col">
                            <asp:Label ID="lbDescription" runat="server">Description</asp:Label>
                        </th>
                        <th scope="col">
                            <asp:Label ID="lblApplicationEmailAddress" runat="server">Application Email Address</asp:Label>
                        </th>
                        <th scope="col">
                            <asp:Label ID="lbExpired" runat="server">Expired</asp:Label>
                        </th>
                        <th scope="col">
                            <asp:Label ID="ltBilled" runat="server">Billed</asp:Label>
                        </th>
                        <th scope="col">
                            <asp:Label ID="ltDatePosted" runat="server">Date Posted</asp:Label>
                        </th>
                        <th scope="col">
                            <asp:Label ID="ltExpiryDate" runat="server">Expiry Date</asp:Label>
                        </th>
                        <th scope="col">
                            <asp:Label ID="ltLastModified" runat="server">Last Modified</asp:Label>
                        </th>
                    </tr>
                </thead>
                <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <a href='/Admin/JobsEdit.aspx?JobId=<%# Eval("JobID") %>&AdvertiserID=<%# Eval("AdvertiserID") %>&advertiseruserid=<%# Eval("EnteredByAdvertiserUserID") %>'>Edit</a>
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltRefNo" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltJobTitle" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltDescription" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltApplicationEmailAddress" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltExpired" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltBilled" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltDatePosted" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltExpiryDate" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltLastModified" runat="server" />
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
                        <td colspan="8">
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
    <asp:Button runat="server" ID="btnJobs" OnClientClick="javascript:location.href='JobsEdit.aspx'; return false;"
        Text="Add New"></asp:Button>
</asp:Content>
