<%@ Page Title="Order Payment" Language="C#" MasterPageFile="~/MasterPages/CustomMain.Master"
    AutoEventWireup="true" CodeBehind="OrderPayment.aspx.cs" Inherits="JXTPortal.Website.advertiser.OrderPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="robots" content="nofollow" />
    <script type="text/javascript" src="//images.jxt.net.au/COMMON/js/jquery.js"></script>
    <script type="text/javascript" src="//images.jxt.net.au/COMMON/js/jxtscript.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scriptManager" runat="server" />
    <div id="content-container" class="container">
        <div id="content" class="col-sm-12 col-md-12" style="box-sizing: border-box; width: 100%;">
            <h1>
                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral" runat="server" SetLanguageCode="LabelCheckout" />
            </h1>
            <div class="jxt-form jxt-form-advertiser-checkout">
                <section class="jxt-form-section jxt-form-section-your-order">
		            <h2><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral2" runat="server" SetLanguageCode="LabelYourOrder" /></h2>
                    <div class="table-responsive">
                            <table class="box-table table table-hover">
                                <thead>
				                <tr>
					                <th><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral3" runat="server" SetLanguageCode="LabelItem" /></th>
					                <th><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral4" runat="server" SetLanguageCode="LabelOrderNumber" /></th>
					                <th><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral5" runat="server" SetLanguageCode="LabelQuantity" /></th>
                                    <th>&nbsp;</th>
					                <th align="left"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral6" runat="server" SetLanguageCode="LabelPrice" /></th>
				                </tr>
                                    </thead>
                                    <tbody>
                                <asp:Repeater ID="rptOrder" runat="server" OnItemCommand="rptOrder_ItemCommand" OnItemDataBound="rptOrder_ItemDataBound">
                                <ItemTemplate>
                                    <tr>
					                    <td><asp:LinkButton ID="lbDelete" runat="server" CssClass="jxt-cart-remove" CausesValidation="false"></asp:LinkButton>                                
                                            <asp:Literal ID="ltItem" runat="server" /></td>
					                    <td><%# Container.ItemIndex + 1 %></td>
                                        <td>
                                            <asp:Literal ID="ltQuantity" runat="server" />
                                        </td>
                                        <td>&nbsp;</td>
                                        <td>
                                            <%# CurrencySymbol %><asp:Literal ID="ltPrice" runat="server" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                </asp:Repeater>
                                <tr>
							        <td colspan="3" rowspan="3" class="coupon-holder">
                                        <asp:Panel ID="panelPromoCode" runat="server" Visible="false">
								            <label for="" class="coupon-label"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral8" runat="server" SetLanguageCode="LabelEnterPromoCode" /></label>
								            <input type="text" class="coupon-input">
								            <a class="mini-new-buttons coupon-btn"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral14" runat="server" SetLanguageCode="LabelValidate" /></a>
                                        </asp:Panel>
								            <small class="currency-based"><JXTControl:ucLanguageLiteral ID="ltCurrencyBaseText" runat="server" SetLanguageCode="LabelCurrencyBaseText" />
                                                <strong>
                                                    <asp:Literal ID="ltCurrencyDisplay" runat="server"></asp:Literal>
                                                    <asp:Literal ID="ltCurrencySpecialNote" runat="server" Visible="false" Text="*" />
                                                </strong></small>
						            </td>
						            <td class="sub-totals-section"><span class="basketTotals"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral15" runat="server" SetLanguageCode="LabelSubtotal" /></span></td>
						            <td align="left" class="sub-totals-section"><%: this.CurrencySymbol%><asp:Literal ID="ltTotal" runat="server" /></td>
					            </tr>
					            <tr>
						            <td class="sub-totals-section"><span class="basketTotals"><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral16" runat="server" SetLanguageCode="LabelGST" /></span></td>
						            <td align="left" class="sub-totals-section"><%: this.CurrencySymbol%><asp:Literal ID="ltGST" runat="server" /></td>
					            </tr>
					            <tr>
						            <td class="sub-totals-section">
                                        <span class="basketTotals">
                                            <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral17" runat="server" SetLanguageCode="LabelNetTotal" />
                                        </span>
                                    </td>
						            <td align="left" class="sub-totals-section"><%: this.CurrencySymbol%><asp:Literal ID="ltNet" runat="server" /></td>
					            </tr>
                            </tbody>
                        </table>
                    </div>
	            </section>
                <section class="jxt-form-section">
                     <asp:Button ID="btnCompleteOrder" runat="server" CssClass="mini-new-buttons pull-right" OnClick="btnCompleteOrder_Click" CausesValidation="false" Visible="false"></asp:Button>
                     <asp:LinkButton ID="btnExpress" runat="server" Text="Express Paypal Checkout" onclick="btnExpress_Click" CssClass="jxt-paypal-button pull-right" CausesValidation="false" />
	            </section>
                <div class="jxt-form-error jxt-form-error-payment">
                            <asp:Literal ID="ltPaymentError" runat="server" />
                        </div>
                <hr />
                <%--                <asp:UpdatePanel ID="panelCreditCardForm" runat="server">
                    <ContentTemplate>
                --%>
                <section class="jxt-form-section jxt-form-section-credit-card-payment">
		            <h2><JXTControl:ucLanguageLiteral ID="ltCreditCardPayment" runat="server" SetLanguageCode="LabelCreditCardPayment" /></h2>
		            <fieldset class="jxt-form-fieldset jxt-form-fieldset-credit-card-type">
			            <legend><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral9" runat="server" SetLanguageCode="LabelCreditCardType" /></legend>
			            <div class="jxt-form-group jxt-form-credit-card-type">
				            <div id="divVisa" runat="server" class="jxt-form-combined" clientidmode="Static">
					            <label for="rbVisa"><input id="rbVisa" runat="server" type="radio" name="cardtype" value="visa" checked="true" clientidmode="Static" /> <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral10" runat="server" SetLanguageCode="LabelVisa" /></label>
				            </div>
				            <div id="divAmex" runat="server" class="jxt-form-combined" clientidmode="Static">
					            <label for="rbAmex"><input id="rbAmex" runat="server" type="radio" name="cardtype" value="amex" clientidmode="Static" /> <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral11" runat="server" SetLanguageCode="LabelAMEX" /></label>
				            </div>
				            <div  id="divMastercard" runat="server" class="jxt-form-combined" clientidmode="Static">
					            <label for="rbMastercard"><input id="rbMastercard" runat="server" type="radio" name="cardtype" value="mastercard" clientidmode="Static" /> <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral12" runat="server" SetLanguageCode="LabelMastercard" /></label>
				            </div>
			            </div>
		            </fieldset>
		            <fieldset class="jxt-form-fieldset jxt-form-fieldset-credit-card">
			            <legend><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral13" runat="server" SetLanguageCode="LabelCreditCardDetails" /></legend>
			            <div class="jxt-form-group jxt-form-credit-card-number">
				            <div class="jxt-form-label">
					            <label for=""><JXTControl:ucLanguageLiteral ID="ltCreditCardNumber" runat="server" SetLanguageCode="LabelCreditCardNumber" /><span class="form-required">*</span></label>
				            </div>
				            <div class="jxt-form-field">
                                <asp:TextBox ID="tbCreditCardNumber" runat="server" autocomplete="off"/>
                                <asp:RequiredFieldValidator ID="reqValCCNumber" runat="server" ControlToValidate="tbCreditCardNumber" CssClass="jxt-error" ErrorMessage="Credit card number is required" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="rangeValCCNumber" runat="server" ControlToValidate="tbCreditCardNumber" CssClass="jxt-error" ErrorMessage="Invalid credit card number" ValidationExpression="^[0-9]{15,17}$" Display="Dynamic"></asp:RegularExpressionValidator>
				            </div>
			            </div>
			            <div class="jxt-form-group jxt-form-credit-card-number">
				            <div class="jxt-form-label">
					            <label for=""><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral7" runat="server" SetLanguageCode="LabelCreditCardName" /><span class="form-required">*</span></label>
				            </div>
				            <div class="jxt-form-field">
                                <asp:TextBox ID="tbCreditCardName" runat="server" autocomplete="off"/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbCreditCardName" CssClass="jxt-error" ErrorMessage="Name on card is required" Display="Dynamic"></asp:RequiredFieldValidator>
				            </div>
			            </div>
			            <div class="jxt-form-group jxt-form-credit-card-expiry-month">
				            <div class="jxt-form-label">
					            <label for=""><JXTControl:ucLanguageLiteral ID="ltExpiryDate" runat="server" SetLanguageCode="LabelExpiryMonth" /><span class="form-required">*</span></label>
				            </div>
				            <div class="jxt-form-field">
                                <asp:DropDownList ID="ddlMonth" runat="server">
                                    <asp:ListItem Value="1" Text="Jan" />
                                    <asp:ListItem Value="2" Text="Feb" />
                                    <asp:ListItem Value="3" Text="Mar" />
                                    <asp:ListItem Value="4" Text="Apr" />
                                    <asp:ListItem Value="5" Text="May" />
                                    <asp:ListItem Value="6" Text="Jun" />
                                    <asp:ListItem Value="7" Text="Jul" />
                                    <asp:ListItem Value="8" Text="Aug" />
                                    <asp:ListItem Value="9" Text="Sep" />
                                    <asp:ListItem Value="10" Text="Oct" />
                                    <asp:ListItem Value="11" Text="Nov" />
                                    <asp:ListItem Value="12" Text="Dec" />
                                </asp:DropDownList>                    
				            </div>
			            </div>
			            <div class="jxt-form-group jxt-form-credit-card-expiry-year">
				            <div class="jxt-form-label">
					            <label for=""><JXTControl:ucLanguageLiteral ID="UcLanguageLiteral1" runat="server" SetLanguageCode="LabelExpiryYear" /><span class="form-required">*</span></label>
				            </div>
				            <div class="jxt-form-field">
                                <asp:DropDownList ID="ddlYear" runat="server"/>
				            </div>
			            </div>
			            <div class="jxt-form-group jxt-form-credit-card-scs">
				            <div class="jxt-form-label">
					            <label for=""><JXTControl:ucLanguageLiteral ID="ltCSC" runat="server" SetLanguageCode="LabelCVV" /><span class="form-required">*</span></label>
				            </div>
				            <div class="jxt-form-field">
					            <asp:TextBox ID="tbCVV" runat="server" autocomplete="off" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbCVV" CssClass="jxt-error" ErrorMessage="CVV is required" Display="Dynamic"></asp:RequiredFieldValidator>
				            </div>
			            </div>
                        
<%--
                        <div class="jxt-form-groupe">
                            <label class="form-label-left">
                                <JXTControl:ucLanguageLiteral ID="UcLanguageLiteral14" runat="server" SetLanguageCode="LabelSuccessfulPayment" />
                            </label>
                            <asp:CheckBox ID="cbTemp" runat="server" CssClass="form-textbox2" />
                        </div>--%>
                        </fieldset>
                        <div class="jxt-form-submit">
                            <div class="jxtPaymentButton">
                            </div>
                        </div>
		            
	            </section>
                <hr />
                <div class="jxt-form-footer-navigation">
                    <asp:Button ID="btnPrevious" runat="server" CssClass="mini-new-buttons jxt-form-previous"
                        OnClick="btnPrevious_Click" CausesValidation="false"></asp:Button>
                
                    <asp:Button ID="btnMakePayment" runat="server" Text="Make Payment" CssClass="mini-new-buttons pull-right"
                        OnClick="btnMakePayment_Click"></asp:Button>
                </div>
                <%--                    </ContentTemplate>
                </asp:UpdatePanel>
                --%>
            </div>
        </div>
        <!-- /#full-width-content -->
    </div>
</asp:Content>
