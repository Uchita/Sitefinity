<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="Advertisers" Title="Advertisers List" CodeBehind="Advertisers.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Advertisers List <a href='http://support.jxt.com.au/solution/articles/116457-advertisers'
        class='jxt-help-page' title='click here for help on this page' target='_blank'>help
        on this page</a>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tblNoBorder">
        <tbody>
            <tr>
                <td>
                    <label>
                        Advertiser ID</label>
                </td>
                <td>
                    <asp:TextBox ID="txtAdvertiserListingAdvertiserID" runat="server" CssClass="form-textbox2"></asp:TextBox>&nbsp;
                </td>
                <td>
                    <label>
                        Company Name</label>
                </td>
                <td>
                    <asp:TextBox ID="txtAdvertiserListingCommpanyName" runat="server" CssClass="form-textbox2"></asp:TextBox>&nbsp;
                </td>
            </tr>
            <tr>
            </tr>
            <tr>
                <td>
                    <label>
                        Business Type</label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlBusinessType" TabIndex="11" runat="server" class="form-dropdown" />
                </td>
                <td>
                    <label>
                        Account Type</label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlAccountType" TabIndex="11" runat="server" class="form-dropdown" />
                </td>
            </tr>
            <tr>
                <td>
                    <label>
                        Account Status</label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlAccountStatus" TabIndex="11" runat="server" class="form-dropdown" />
                </td>
                <asp:Panel ID="pnlSiteID" runat="server">
                    <td>
                        <label>
                            Site</label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSite" TabIndex="11" runat="server" class="form-dropdown"
                            AutoPostBack="false" />
                    </td>
                </asp:Panel>
            </tr>
            <tr>
            </tr>
            <tr>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                        CssClass="jxtadminbutton" ValidationGroup="AdminMember" />
                    <asp:Button ID="btnCreateNewAdv" runat="server" Text="Create Advertiser" OnClick="btnCreateNewAdv_Click"
                        CssClass="jxtadminbutton" />
                </td>
            </tr>
        </tbody>
    </table>
    <asp:Label ID="lblErrorMsg" runat="server" class="form-required" Visible="false"
        CssClass="form-message" />
    <asp:CompareValidator ID="ctmAdminAdvertiserID" runat="server" ErrorMessage=" * Advertiser ID must be numbers"
        ControlToValidate="txtAdvertiserListingAdvertiserID" Type="Integer" Operator="DataTypeCheck"></asp:CompareValidator>
    <table cellpadding="3" border="0" class="grid" id="tblAdvertiserRepeater" visible="false">
        <asp:Repeater ID="rptAdminAdvertiser" runat="server" OnItemDataBound="rptAdminAdvertiser_ItemDataBound">
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
                            &nbsp;
                        </th>
                        <th scope="col">
                            &nbsp;
                        </th>
                        <th scope="col">
                            &nbsp;
                        </th>
                        <th scope="col">
                            Advertiser ID
                        </th>
                        <th scope="col">
                            Account Type
                        </th>
                        <th scope="col">
                            Account Status
                        </th>
                        <th scope="col">
                            Company Name
                        </th>
                        <th scope="col">
                            Registered Date
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
                        <a href='/Admin/AdvertisersEdit.aspx?AdvertiserId=<%# Eval("AdvertiserId") %>'>
                            <asp:Literal ID="ltViewAdvertiser" runat="server" Text="Select" /></a>
                    </td>
                    <td>
                        <a href='/Admin/AdvertiserUsersEdit.aspx?AdvertiserId=<%# Eval("AdvertiserId") %>'>Create
                            User</a>
                    </td>
                    <td>
                        <a href='/admin/advertiserjobtemplatelogo.aspx?AdvertiserID=<%# Eval("AdvertiserId") %>'>
                            Job Template Logo</a>
                    </td>
                    <td>
                        <a href='/admin/advertiser/jobsbyadvertiser.aspx?AdvertiserID=<%# Eval("AdvertiserId") %>'>
                            Jobs By Advertiser</a>
                    </td>
                    <td>
                        <a href='/admin/advertiser/advertiserjobpricing.aspx?advertiserid=<%# Eval("AdvertiserId") %>'>
                             Job Pricing</a>
                    </td>
                    <td scope="col">
                        <a href='/admin/advertiserUsers.aspx?advertiserID=<%# Eval("AdvertiserId") %>'>User
                            List </a>
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltAdminAdvertiserID" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltAdminAdvAccType" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltAdminAdvAccStatus" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltAdminAdvCompanyName" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltAdminAdvRegisteredDate" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltAdminAdvLastModified" runat="server" />
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
</asp:Content>
