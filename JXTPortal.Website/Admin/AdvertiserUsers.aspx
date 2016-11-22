<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="AdvertiserUsers" Title="Advertisers - Advertiser Users List"
    CodeBehind="AdvertiserUsers.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Advertiser Users List
    <a href='http://support.jxt.com.au/solution/categories/116125/folders/190961/articles/116438-advertiser-user' class='jxt-help-page' title='click here for help on this page'  target='_blank'>help on this page</a>

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-all">
        <table class="tblNoBorder">
            <tbody>
                <tr>
                    <td>
                        <label>
                            Advertiser User ID</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAdvertiserUserListingAdvertiserUserID" runat="server" CssClass="form-textbox2"></asp:TextBox>&nbsp;
                    </td>
                    <td>
                        <label>
                            Advertiser ID</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAdvertiserUserListingAdvertiserID" runat="server" CssClass="form-textbox2"></asp:TextBox>&nbsp;
                    </td>
                </tr>
                <tr>
                </tr>
                <tr>
                    <td>
                        <label>
                            Email Address</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAdvertiserUserListingEmail" runat="server" CssClass="form-textbox2"></asp:TextBox>
                    </td>
                    <td>
                        <label>
                            Username</label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAdvertiserUserListingUsername" runat="server" CssClass="form-textbox2"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>First Name</td>
                    <td>
                        <asp:TextBox ID="txtAdvertiserUserListingFirstName" runat="server" CssClass="form-textbox2"></asp:TextBox>
                    </td>
                    <td>Surname</td>
                    <td>
                        <asp:TextBox ID="txtAdvertiserUserListingSurname" runat="server" CssClass="form-textbox2"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <asp:Panel ID="pnlSiteID" runat="server">                
                        <td>Site</td>
                        <td>
                            <asp:DropDownList ID="ddlSite" TabIndex="11" runat="server" class="form-dropdown" />
                        </td>                       
                    </asp:Panel>
                </tr>
                <tr>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                            CssClass="jxtadminbutton" ValidationGroup="AdminMember" />
                    </td>
                </tr>
            </tbody>
        </table>
        <span class="form-message">
            <asp:Label ID="lblErrorMsg" runat="server" class="form-required" Visible="false" />
        </span>
        <asp:CompareValidator ID="ctmAdminAdvertiserUserID" runat="server" ErrorMessage=" * AdvertiserUserID must be numbers"
            ControlToValidate="txtAdvertiserUserListingAdvertiserUserID" Type="Integer" Operator="DataTypeCheck" ValidationGroup="AdminMember"></asp:CompareValidator>
        <asp:CompareValidator ID="ctmAdminAdvertiserID" runat="server" ErrorMessage=" * AdvertiserID must be numbers"
            ControlToValidate="txtAdvertiserUserListingAdvertiserID" Type="Integer" Operator="DataTypeCheck" ValidationGroup="AdminMember"></asp:CompareValidator>
        <asp:RegularExpressionValidator ID="revEmailAddress" runat="server" ControlToValidate="txtAdvertiserUserListingEmail" ValidationGroup="AdminMember"
            ErrorMessage=" * A valid email address is required">  
        </asp:RegularExpressionValidator>
        <table cellpadding="3" border="0" class="grid">
            <asp:Repeater ID="rptAdminAdvertiserUser" runat="server" OnItemCommand="rptAdminAdvertiserUser_ItemCommand"
                OnItemDataBound="rptAdminAdvertiserUser_ItemDataBound">
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
                                Company Name
                            </th>
                            <th scope="col">
                                AdvertiserUser ID
                            </th>
                            <th scope="col">
                                Site ID
                            </th>
                            <th scope="col">
                                Advertiser ID
                            </th>
                            <th scope="col">
                                Primary Account
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
                                Email
                            </th>
                            <%--<th scope="col">
                                Last Modified
                            </th>--%>
                            <th scope="col">
                                Validated
                            </th>
                            <%--<th scope="col">
                                Last Login Date
                            </th>--%>
                        </tr>
                    </thead>
                    <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <a href='/admin/advertiserUsersEdit.aspx?AdvertiserUserID=<%# Eval("AdvertiserUserID") %>'>
                                Edit</a>
                        </td>
                        <td>
                            <a href='/admin/jobsEdit.aspx?AdvertiserID=<%# Eval("AdvertiserId") %>&AdvertiserUserID=<%# Eval("AdvertiserUserID") %>'>Create Job</a>
                        </td>
                        <td>
                            <asp:LinkButton ID="lbAdvertiser" runat="server" CommandName="Advertiser" />
                        </td>
                        <td scope="col">
                            <asp:Literal ID="ltAdminAdvertiserUserID" runat="server" />
                        </td>
                        <td scope="col">
                            <asp:Literal ID="ltAdminAdvertiserUserSiteID" runat="server" />
                        </td>
                        <td scope="col">
                            <asp:Literal ID="ltAdminAdvertiserID" runat="server" />
                        </td>
                        <td scope="col">
                            <asp:Literal ID="ltAdminAdvertiserUserPrimaryAccount" runat="server" />
                        </td>
                        <td scope="col">
                            <asp:Literal ID="ltAdminAdvertiserUserFirstName" runat="server" />
                        </td>
                        <td scope="col">
                            <asp:Literal ID="ltAdminAdvertiserUserSurname" runat="server" />
                        </td>
                        <td scope="col">
                            <asp:Literal ID="ltAdminAdvertiserUserUsername" runat="server" />
                        </td>
                        <td scope="col">
                            <asp:Literal ID="ltAdminAdvertiserUserEmail" runat="server" />
                        </td>
                        <%--<td scope="col">
                            <asp:Literal ID="ltAdminAdvertiserUserLastModified" runat="server" />
                        </td>--%>
                        <td scope="col">
                            <asp:Literal ID="ltAdminAdvertiserUserValidated" runat="server" />
                        </td>
                        <%--<td scope="col">
                            <asp:Literal ID="ltAdminAdvertiserUserLastLoginDate" runat="server" />
                        </td>--%>
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
                            <td colspan="12">
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
    </div>
</asp:Content>
