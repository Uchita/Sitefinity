<%@ Page Title="Team List" Language="C#" MasterPageFile="~/MasterPages/admin.Master"
    AutoEventWireup="true" CodeBehind="Consultants.aspx.cs" Inherits="JXTPortal.Website.Admin.Consultants" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Team List
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <table class="tblNoBorder">
        <tbody>
            <tr>
                <td>
                    <label>
                        Name</label>
                </td>
                <td>
                    <asp:TextBox ID="tbName" runat="server" CssClass="form-textbox2"></asp:TextBox>&nbsp;
                </td>
                <td>
                    <label>
                        Position Title</label>
                </td>
                <td>
                    <asp:TextBox ID="tbPositionTitle" runat="server" CssClass="form-textbox2"></asp:TextBox>&nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <label>
                        Status</label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlStatus" runat="server" class="form-dropdown">
                        <asp:ListItem Value="0">All</asp:ListItem>
                        <asp:ListItem Value="1">Visible</asp:ListItem>
                        <asp:ListItem Value="2">Not Visible</asp:ListItem>
                        <asp:ListItem Value="3">Archived</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                        CssClass="jxtadminbutton" ValidationGroup="AdminMember" />
                </td>
            </tr>
        </tbody>
    </table>
    <asp:Label ID="lblErrorMsg" runat="server" class="form-required" Visible="false"
        CssClass="form-message">Result Not Found</asp:Label>
    <table cellpadding="3" border="0" class="grid" id="tblConsultantsRepeater">
        <asp:Repeater ID="rptConsultants" runat="server" OnItemCommand="rptConsultants_ItemCommand"
            OnItemDataBound="rptConsultants_ItemDataBound">
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
                            &nbsp;
                        </th>
                        <th scope="col">
                            <asp:LinkButton ID="lbSortFirstName" runat="server" CommandName="FirstName">First Name</asp:LinkButton>
                        </th>
                        <th scope="col">
                            Last Name
                        </th>
                        <th scope="col">
                            Email
                        </th>
                        <th scope="col">
                            Position Title
                        </th>
                        <th scope="col">
                            Status
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
                        <asp:LinkButton ID="lbDelete" runat="server" Text="Delete" CommandName="Delete" OnClientClick="return confirm('Are you sure?');" />
                    </td>
                    <td>
                        <a href="/t/<%# DataBinder.Eval(Container.DataItem, "FriendlyURL") %>" target="_blank">Preview</a>
                    </td>
                    <td>
                        <asp:Literal ID="ltName" runat="server" />
                    </td>
                    <td>
                        <asp:Literal ID="ltLastName" runat="server" />
                    </td>
                    <td>
                        <asp:Literal ID="ltEmail" runat="server" />
                    </td>
                    <td>
                        <asp:Literal ID="ltPositionTitle" runat="server" />
                    </td>
                    <td>
                        <asp:Literal ID="ltStatus" runat="server" />
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
    <asp:Button ID="btnConsultants" runat="server" OnClientClick="javascript:location.href='ConsultantsEdit.aspx'; return false;"
        Text="Add New"></asp:Button>
</asp:Content>
