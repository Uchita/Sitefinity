<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="SiteCountriesEdit" Title="SiteCountries Edit"
    CodeBehind="SiteCountriesEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Site Countries - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
        <asp:MultiView ID="MultiViewSiteProfession" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewSiteProfession" runat="server">
                <ul class="form-section">
                    <li class="form-line" id="sc-defaultcountry-field">
                        <label class="form-label-left">
                            <strong>Default Countty</strong></label>
                        <div class="form-input">
                        </div>
                    </li>
                    <li class="form-line" id="sc-defaultcountryname-field">
                        <label class="form-label-left">
                            Country Name:</label>
                        <div class="form-input">
                            <asp:Label ID="lbCountry" runat="server" />
                        </div>
                    </li>
                    <li class="form-line" id="sc-sitecountry-field">
                        <label class="form-label-left">
                            <strong>Site Country</strong></label>
                        <div class="form-input">
                        </div>
                    </li>
                    <li class="form-line" id="sc-sitecountryname-field">
                        <label class="form-label-left">
                            Country Name:</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataCountryName" runat="server" />
                            <asp:RequiredFieldValidator ID="ReqVal_CountryName" runat="server" ErrorMessage="Required"
                                ControlToValidate="dataCountryName" />
                        </div>
                    </li>
                    <li class="form-line" id="sc-sitecountryfriendlyurl-field">
                        <label class="form-label-left">
                            Friendly Url:</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataFriendlyUrl" runat="server" Width="250" />
                            <asp:RequiredFieldValidator ID="ReqVal_dataFriendlyUrl" runat="server" ErrorMessage="Required"
                                ControlToValidate="dataFriendlyUrl" />
                        </div>
                    </li>
                    <li class="form-line" id="Li1">
                        <label class="form-label-left">
                            Currency:</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataCurrency" runat="server" Width="250" MaxLength="5" />
                        </div>
                    </li>
                    <li class="form-line">
                        <div class="form-input-wide">
                            <div class="form-buttons-wrapper">
                                <asp:Button ID="btnEditSave" runat="server" Text="Update" OnClick="btnEditSave_Click"
                                    CssClass="jxtadminbutton" />
                                <asp:Button ID="btnReturn" runat="server" Text="Return" OnClick="btnReturn_Click"
                                    CssClass="jxtadminbutton" CausesValidation="false" />
                            </div>
                        </div>
                    </li>

                </ul>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
