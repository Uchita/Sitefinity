<%@ Page Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true"
    CodeBehind="SiteAdvertisersFilter.aspx.cs" Inherits="JXTPortal.Website.Admin.SiteAdvertisersFilter"
    Title="Sites - Advertiser Filters List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Advertiser Filters List - Add/Edit
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-all">
        <p>
            Please Note: If you have created an advertiser ID for the current site, you can
            leave the below field blank……</p>
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
        <ul class="form-section">
            <li class="form-line" id="mlr-language-field">
                <label class="form-label-left">
                    Advertiser ID:<span class="form-required">*</span>
                </label>
                <div class="form-input">
                    <asp:TextBox ID="txtAdvertiserID" runat="server" />
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Only Integers"
                        ControlToValidate="txtAdvertiserID" MaximumValue="9999999" MinimumValue="1" SetFocusOnError="True"></asp:RangeValidator>
                </div>
            </li>
            <li class="form-line" id="Li2">
                <div class="form-input" style="width: 400px">
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Add Advertiser" CssClass="jxtadminbutton" />
                    <asp:Button ID="btnBlock" runat="server" Text="Block Advertiser" CssClass="jxtadminbutton" style="float: right; background: Red;" OnClick="btnBlock_Click" />
                </div>
            </li>
        </ul>
    </div>
    <table>
        <tbody>
            <tr>
                <th>
                    Added Advertiser
                </th>
                <th>
                    Blocked Advertiser
                </th>
            </tr>
            <tr>
                <td>
                    <asp:PlaceHolder ID="phAdvertiserFilter" runat="server">
                        <asp:Repeater ID="rptAdvertiserFilter" runat="server" OnItemDataBound="rptAdvertiserFilter_ItemDataBound"
                            OnItemCommand="rptAdvertiserFilter_ItemCommand">
                            <HeaderTemplate>
                                <table border="0" class="grid">
                                    <tbody>
                                        <tr class="grid-header">
                                            <th scope="col">
                                            </th>
                                            <th scope="col">
                                                AdvertiserID
                                            </th>
                                            <th scope="col">
                                                Company Name
                                            </th>
                                        </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:LinkButton CssClass="red" ID="lnkSelectFile" runat="server" CommandName="Delete"
                                            CausesValidation="false">Delete</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltAdvertiserID" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltCompanyName" runat="server" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody> </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </asp:PlaceHolder>
                </td>
                <td>
                    <asp:PlaceHolder ID="phBlockedAdvertiserFilter" runat="server">
                        <asp:Repeater ID="rptBlockedAdvertiserFilter" runat="server" OnItemDataBound="rptBlockedAdvertiserFilter_ItemDataBound"
                            OnItemCommand="rptBlockedAdvertiserFilter_ItemCommand">
                            <HeaderTemplate>
                                <table border="0" class="grid">
                                    <tbody>
                                        <tr class="grid-header">
                                            <th scope="col">
                                            </th>
                                            <th scope="col">
                                                AdvertiserID
                                            </th>
                                            <th scope="col">
                                                Company Name
                                            </th>
                                        </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:LinkButton CssClass="red" ID="lnkSelectFile" runat="server" CommandName="Delete"
                                            CausesValidation="false">Delete</asp:LinkButton>
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltAdvertiserID" runat="server" />
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltCompanyName" runat="server" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody> </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </asp:PlaceHolder>
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
