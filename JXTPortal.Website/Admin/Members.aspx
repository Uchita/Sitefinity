<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" EnableEventValidation ="false"
    AutoEventWireup="true" Inherits="Members" Title="Members List" CodeBehind="Members.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Members List
    <a href='http://support.jxt.com.au/solution/categories/116125/folders/190961/articles/116439-members' class='jxt-help-page' title='click here for help on this page'  target='_blank'>help on this page</a>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="scriptManager" runat="server" />
    <div class="form-all">
        <table class="tblNoBorder">
            <tbody>
                <tr>
                    <td>
                        <label>
                            Member ID</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAdminMemberListingMemberID" runat="server" CssClass="form-textbox2"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <label>
                            Username</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAdminMemberListingUsername" runat="server" CssClass="form-textbox2"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>
                            First Name</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAdminMemberListingFirstname" runat="server" CssClass="form-textbox2"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <label>
                            Surname</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAdminListingSurname" runat="server" CssClass="form-textbox2"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>
                            Email Address</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAdminListingEmail" runat="server" CssClass="form-textbox2"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <asp:Panel ID="pnlSiteID" runat="server">
                        <td>
                            <label>
                                Site</label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSite" TabIndex="11" runat="server" class="form-dropdown" />
                        </td>
                    </asp:Panel>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                            CssClass="jxtadminbutton" ValidationGroup="AdminMember" />
                    </td>
                    <td>
                        <asp:Button ID="btnDownload" runat="server" Text="Download" OnClick="btnDownload_Click"
                            CssClass="jxtadminbutton" />
                    </td>
                </tr>
            </tbody>
        </table>
        <span class="form-message">
            <asp:Label ID="lblErrorMsg" runat="server" class="form-required" Visible="false" />
        </span>
        <asp:CompareValidator ID="ctmAdminMemberID" runat="server" ErrorMessage="* MemberID must be numbers"
            ControlToValidate="txtAdminMemberListingMemberID" Type="Integer" Operator="DataTypeCheck"></asp:CompareValidator>
        <asp:RegularExpressionValidator ID="revEmailAddress" runat="server" ControlToValidate="txtAdminListingEmail"
            ErrorMessage="* A valid email address is required">  
        </asp:RegularExpressionValidator>
        
        <asp:Repeater ID="rptAdminMembers" runat="server" OnItemDataBound="rptAdminMembers_ItemDataBound">
            <HeaderTemplate>
                <table cellpadding="3" border="0" class="grid">
                    <thead>
                        <tr class="grid-header">
                            <th scope="col">
                                &nbsp;
                            </th>
                            <th scope="col">
                                MemberID
                            </th>
                            <th scope="col">
                                First Name
                            </th>
                            <th scope="col">
                                Surname
                            </th>
                            <th scope="col">
                                Username
                            </th>
                            <th scope="col">
                                Email Address
                            </th>
                            <th scope="col">
                                <asp:Label ID="Label4" runat="server">Email Format</asp:Label>
                            </th>
                            <th scope="col">
                                <asp:Label ID="Label5" runat="server">Is Validated</asp:Label>
                            </th>
                            <th scope="col">
                                <asp:Label ID="Label2" runat="server">Registration Date</asp:Label>
                            </th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <a href='/Admin/MembersEdit.aspx?memberID=<%# Eval("MemberID") %>'>
                            <asp:Literal ID="ltViewMember" runat="server" /></a>
                    </td>
                    <td scope="col">
                        <asp:Label ID="Label1" runat="server">
                            <asp:Literal ID="ltAdminMemberID" runat="server" />
                        </asp:Label></td><td scope="col">
                        <asp:Label runat="server">
                            <asp:Literal ID="ltAdminMemberFirstName" runat="server" />
                        </asp:Label></td><td scope="col">
                        <asp:Label runat="server">
                            <asp:Literal ID="ltAdminMemberSurname" runat="server" />
                        </asp:Label></td><td scope="col">
                        <asp:Label runat="server">
                            <asp:Literal ID="ltAdminMemberUsername" runat="server" />
                        </asp:Label></td><td scope="col">
                        <asp:Label runat="server">
                            <asp:Literal ID="ltAdminMemberEmail" runat="server" />
                        </asp:Label></td><td scope="col">
                        <asp:Label runat="server">
                            <asp:Literal ID="ltAdminMemberEmailFormat" runat="server" />
                        </asp:Label></td><td scope="col">
                        <asp:Label ID="Label3" runat="server">
                            <asp:Literal ID="ltAdminMemberIsValidated" runat="server" />
                        </asp:Label></td><td scope="col">
                        <asp:Literal ID="ltAdminMembersRegisteredDate" runat="server" />
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
    </div>
</asp:Content>
