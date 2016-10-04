<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true" CodeBehind="Industry.aspx.cs" Inherits="JXTPortal.Website.Admin.Industry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Industry
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-all">
    <asp:Label ID="lblErrorMsg" runat="server" class="form-required" Visible="false"
        CssClass="form-message">There is currently no industry set </asp:Label>

        <asp:Repeater ID="rptIndustry" runat="server" OnItemDataBound="rptIndustry_ItemDataBound">
            <HeaderTemplate>
                <table cellpadding="3" border="0" class="grid">
                    <thead>
                        <tr class="grid-header">
                            <th scope="col">
                                &nbsp;
                            </th>
                            <th scope="col">
                                Industry Name
                            </th>
                            <th scope="col">
                                Sequence
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
                    <td>
                        <a href='/Admin/IndustryEdit.aspx?industryid=<%# Eval("IndustryID") %>'>
                            Select</a>
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltIndustryName" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltSequence" runat="server" />
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

         <br />
    <asp:Button runat="server" ID="btnIndustry" OnClientClick="javascript:location.href='IndustryEdit.aspx'; return false;"
        Text="Add New"></asp:Button>
    </div>
</asp:Content>
