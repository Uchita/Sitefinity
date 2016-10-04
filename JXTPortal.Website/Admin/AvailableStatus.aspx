<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="AvailableStatus" Title="Members - Availability Status"
    CodeBehind="AvailableStatus.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Available Status List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="form-all">
        
        <asp:Repeater ID="rptAdminAvailableStatus" runat="server" OnItemDataBound="rptAdminAvailableStatus_ItemDataBound" Visible="false">
            <HeaderTemplate>
                <table cellpadding="3" border="0" class="grid">
                    <thead>
                        <tr class="grid-header">
                            <th scope="col">
                                &nbsp;
                            </th>
                            <th scope="col">Available Status name
                            </th>
                            <th scope="col">Global Template                                
                            </th>
                            <%--<th scope="col">Sequence
                            </th>--%>
                            <th scope="col">Last Modified
                            </th>                            
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <a href='/admin/availableStatusEdit.aspx?AvailableStatusId=<%# Eval("AvailableStatusID") %>'>
                            <asp:Literal ID="ltAdminAvailableStatusView" runat="server" /></a>
                    </td>
                    <td scope="col">
                            <asp:Literal ID="ltAdminAvailableStatusName" runat="server" />                        
                    </td>
                    <td scope="col">
                            <asp:CheckBox ID="chkAvailableGlobalTemplate" runat="server" Enabled="false" />
                    </td>
                    <%--<td scope="col">
                            <asp:Literal ID="ltAdminAvailableStatusSequence" runat="server" />--%>
                    </td>
                    <td scope="col">
                            <asp:Literal ID="ltAdminAvailableStatusLastModified" runat="server" />
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
        
        <asp:Button runat="server" ID="btnAvailableStatus" OnClientClick="javascript:location.href='AvailableStatusEdit.aspx'; return false;" Text="Add New"></asp:Button>
    </div>

</asp:Content>
