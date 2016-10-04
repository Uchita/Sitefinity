<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/CustomMain.Master"
    AutoEventWireup="true" CodeBehind="PaymentConfirmation.aspx.cs" Inherits="JXTPortal.Website.advertiser.PaymentConfirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="robots" content="nofollow" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-container" class="container">
        <div id="full-width-content">
            <h1>
                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral" runat="server" SetLanguageCode="LabelYouMadeAPayment" />
            </h1>
            <div class="jxt-receipt">
                <asp:Repeater ID="rptPyament" runat="server" OnItemDataBound="rptPyament_ItemDataBound">
                    <HeaderTemplate>
                        <p>
                            <asp:Literal runat="server" id="ltPaymentConfirmation" />
                        </p>
                        <h2>
                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral2" runat="server" SetLanguageCode="LabelPurchaseDetails" />
                        </h2>
                        <table class="box-table table table-hovered">
                            <thead>
                                <tr>
                                    <th>
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral3" runat="server" SetLanguageCode="LabelItem" />
                                    </th>
                                    <th>
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral4" runat="server" SetLanguageCode="LabelAmount" />
                                    </th>
                                    <th>
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral5" runat="server" SetLanguageCode="LabelQuantity" />
                                    </th>
                                    <th>
                                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral6" runat="server" SetLanguageCode="LabelTotal" />
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Literal ID="ltProduct" runat="server" />
                            </td>
                            <td>
                                <asp:Literal ID="ltPrice" runat="server" />
                            </td>
                            <td>
                                <asp:Literal ID="ltQuantity" runat="server" />
                            </td>
                            <td>
                                <asp:Literal ID="ltProductTotal" runat="server" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tr> </tbody>
                        <tfoot>
                            <tr>
                                <th colspan="3">
                                    <asp:Literal ID="ltTaxLabel" runat="server" />
                                </th>
                                <td>
                                    <asp:Literal ID="ltTax" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <th colspan="3">
                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral7" runat="server" SetLanguageCode="LabelTotalAmount" />
                                </th>
                                <td>
                                    <asp:Literal ID="ltTotal" runat="server" />
                                </td>
                            </tr>
                        </tfoot>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:PlaceHolder ID="phMessage" runat="server" Visible="false"><span class="jxt-error">
                    <asp:Literal ID="ltMessage" runat="server" /></span></asp:PlaceHolder>
                <!--<h2>
                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral6" runat="server" SetLanguageCode="LabelContactInformation" />
                </h2>
                <dl class="jxt-receipt-list">
                    <dt>
                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral7" runat="server" SetLanguageCode="LabelBusinessName" />
                    </dt>
                    <dd>
                        <asp:Literal ID="ltBusinessName" runat="server" />JXT</dd>
                    <dt>
                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral8" runat="server" SetLanguageCode="LabelEmail" />
                    </dt>
                    <dd>
                        <asp:Literal ID="ltEmail" runat="server" />User1@jxt.com.au</dd>
                </dl>-->
            </div>
            <p>
                <a href="/advertiser/default.aspx" class="mini-new-buttons">
                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral9" runat="server" SetLanguageCode="LabelDashBoard" />
                </a> <a href="/advertiser/jobcreate.aspx" class="mini-new-buttons">
                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral10" runat="server" SetLanguageCode="LabelPostAJob" />
                </a>
            </p>
        </div>
    </div>
</asp:Content>
