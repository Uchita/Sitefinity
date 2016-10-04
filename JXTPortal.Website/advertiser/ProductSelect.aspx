<%@ Page Title="Advertiser Product Selection" Language="C#" MasterPageFile="~/MasterPages/CustomMain.Master"
    AutoEventWireup="true" CodeBehind="ProductSelect.aspx.cs" Inherits="JXTPortal.Website.advertiser.ProductSelect" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="robots" content="nofollow" />
    <script type="text/javascript">

        function CalculateTotalItemCost() {

            var perItemCost = $("#ddlProductSingle").find(":selected").data('costs');
            var qtySelected = $("#ddlNumber").val();

            $("#itemTotalDisp").html("<%: this.CurrencySymbol%>" + (perItemCost * qtySelected).toFixed(<%: this.currencyNeedRounding ? "0" : "2"%>));

        }

        $(document).ready(function () {

            //jquery bindings
            $("#ddlProductSingle").on("change", CalculateTotalItemCost);
            $("#ddlNumber").on("change", CalculateTotalItemCost);

            //init
            $("#ddlProductSingle").change();

        });


    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scriptManager" runat="server" />

    <div id="content-container" class="full-width-content">
        <div id="content">
            <h1>
                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral7" runat="server" SetLanguageCode="LabelProduct" />
            </h1>
            <asp:PlaceHolder ID="phNoCredit" runat="server" Visible="false">
                <div class="alert alert-warning" role="alert">
                    Oops! Seems you don't have job credits. In order to post a job, you must first
                    purchase credits below.</div>
            </asp:PlaceHolder>
            <div class="jxt-form jxt-form-advertiser-select-product">
                <section class="jxt-form-section jxt-form-section-your-cart">
                    <h2>
                        <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelViewCart" />
                    </h2>
                    <JXTControl:ucLanguageLiteral runat="server" ID="lblCartEmptyText" SetLanguageCode="LabelCartEmpty"
                        Visible="false" />
                    <asp:Repeater ID="rptCart" runat="server" OnItemCommand="rptCart_ItemCommand" OnItemDataBound="rptCart_ItemDataBound">
                        <HeaderTemplate>
                            <ul class="jxt-cart-product-list">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li>
                                <asp:LinkButton ID="lbRemove" runat="server" Text="Remove" CssClass="jxt-cart-remove" />
                            
                                <asp:Literal ID="ltItemQty" runat="server" />
                                x
                                <asp:Literal ID="ltItemProduct" runat="server" />
                                -
                                <asp:Literal ID="ltItemPrice" runat="server" />
                            </li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                        </FooterTemplate>
                    </asp:Repeater>
                </section>
                <section class="jxt-form-section jxt-form-section-select-product">
                    <h2>
                        <JXTControl:ucLanguageLiteral ID="ltSelectYourProduct" runat="server" SetLanguageCode="LabelPleaseSelectYourProduct" />
                    </h2>
                    <fieldset class="jxt-form-fieldset jxt-form-fieldset-product-details">
                        <legend><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral4" runat="server" SetLanguageCode="LabelProductDetails" /></legend>
                        <div class="jxt-form-group jxt-form-product">
                            <div class="jxt-form-label">
                                <label for="">
                                    <JXTControl:ucLanguageLiteral ID="ltProduct" runat="server" SetLanguageCode="LabelProductType" />
                                    &nbsp;<span class="form-required">*</span></label>
                            </div>
                            <div class="jxt-form-field">
                                <asp:DropDownList ID="ddlProductSingle" runat="server" ClientIDMode="Static" CssClass="form-multiple-column" />
                            </div>
                        </div>
                        <div class="jxt-form-group jxt-form-product-type">
                            <div class="jxt-form-label">
                                <label for="">
                                    <JXTControl:ucLanguageLiteral ID="ltNumber" runat="server" SetLanguageCode="LabelQuantity" />
                                    &nbsp;<span class="form-required">*</span></label>
                            </div>
                            <div class="jxt-form-field">
                                <asp:DropDownList ID="ddlNumber" runat="server" ClientIDMode="Static" CssClass="form-multiple-column">
                                    <asp:ListItem Value="1">1</asp:ListItem>
                                    <asp:ListItem Value="2">2</asp:ListItem>
                                    <asp:ListItem Value="3">3</asp:ListItem>
                                    <asp:ListItem Value="4">4</asp:ListItem>
                                    <asp:ListItem Value="5">5</asp:ListItem>
                                    <asp:ListItem Value="6">6</asp:ListItem>
                                    <asp:ListItem Value="7">7</asp:ListItem>
                                    <asp:ListItem Value="8">8</asp:ListItem>
                                    <asp:ListItem Value="9">9</asp:ListItem>
                                    <asp:ListItem Value="10">10</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="jxt-form-group jxt-form-product-number">
                            <div class="jxt-form-label">
                                <label for="">
                                    <JXTControl:ucLanguageLiteral ID="ltPurchaseItemTotal" runat="server" SetLanguageCode="LabelPurchaseTotal" /></label>
                            </div>
                            <div class="jxt-form-field">
                                <span id="itemTotalDisp"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral5" runat="server" SetLanguageCode="LabelProductCostNA" /></span>
                            </div>
                        </div>
                    </fieldset>
                    <div class="jxt-form-submit jxt-form-add-to-cart">
                        <div class="jxt-form-button">
                            <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" CssClass="mini-new-buttons"
                                OnClick="btnAddToCart_Click" CommandArgument="Single" />
                        </div>
                    </div>
                </section>
                <asp:Panel ID="plPackageSelectPanel" runat="server" Visible="false">
                    <section class="jxt-form-section jxt-form-section-select-package">
                    <h2><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral8" runat="server" SetLanguageCode="LabelPleaseSelectYourPackage" /></h2>
                    <fieldset class="jxt-form-fieldset jxt-form-fieldset-product-details">
                        <legend><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral6" runat="server" SetLanguageCode="LabelPackageDetails" /></legend>
                        <div class="jxt-form-group jxt-form-product">
                            <div class="jxt-form-label">
                                <label for="">
                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral2" runat="server" SetLanguageCode="LabelProductType" />
                                    &nbsp;<span class="form-required">*</span></label>
                            </div>
                            <div class="jxt-form-field">
                                <asp:DropDownList ID="ddlProductPackages" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProductPackages_IndexChanged" />
                            </div>
                        </div>
                        <div class="jxt-form-group jxt-form-product-type">
                            <div class="jxt-form-label">
                                <label for="">
                                    <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral3" runat="server" SetLanguageCode="LabelPackageContains" />
                                    </label>
                            </div>
                            <div class="jxt-form-field">
                                <asp:TextBox ID="ddlProductPackagesContains" runat="server" CssClass="form-multiple-column"
                                    Enabled="false" />
                            </div>
                        </div>
                    </fieldset>
                    <div class="jxt-form-submit jxt-form-add-to-cart">
                        <div class="jxt-form-button">
                            <asp:Button ID="Button1" runat="server" Text="Add to Cart" CssClass="mini-new-buttons"
                                OnClick="btnAddToCart_Click" CommandArgument="Package" />
                        </div>
                    </div>
                </section>
                </asp:Panel>
            </div>
            <div class="jxt-form-footer-navigation">
                <asp:Button ID="Button2" runat="server" Text="Previous" CssClass="mini-new-buttons jxt-form-previous"
                    OnClick="btnPrevious_Click" Visible="true" />
                <asp:Button ID="btnContinue" runat="server" Text="Continue" CssClass="mini-new-buttons jxt-form-next"
                    OnClick="btnContinue_Click" Visible="false" />
            </div>
        </div>
        <!-- /#full-width-content -->
    </div>
</asp:Content>
