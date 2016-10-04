<%@ Page Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true"
    CodeBehind="CountriesEdit.aspx.cs" Inherits="CountriesEdit" Title="Global - Default Countries Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Countries - Add/Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
        <asp:MultiView ID="MultiViewCountries" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewCountries" runat="server">
                <ul class="form-section">
                    <li class="form-line" id="country-countryname-field">
                        <label class="form-label-left">
                            Country Name:<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:TextBox ID="dataCountryName" runat="server" />
                            <asp:RequiredFieldValidator ID="ReqVal_Country" runat="server" ErrorMessage="Required"
                                ControlToValidate="dataCountryName" />
                        </div>
                    </li>
                    <li class="form-line" id="locountryc-abbr-field">
                        <label class="form-label-left">
                            Abbr:<span class="form-required">*</span></label>
                        <div class="form-input">
                            <asp:TextBox ID="dataAbbr" runat="server" />
                            <asp:RequiredFieldValidator ID="ReqVal_Abbr" runat="server" ErrorMessage="Required"
                                ControlToValidate="dataAbbr" />
                        </div>
                    </li>
                    <li class="form-line" id="loc-valid-field">
                        <label class="form-label-left">
                            Valid:</label>
                        <div class="form-input">
                            <asp:CheckBox ID="dataValid" runat="server" />
                        </div>
                    </li>
                    <li class="form-line" id="reg-bottom-button">
                        <div class="form-input-wide">
                            <div class="form-buttons-wrapper">
                                <asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                                    Text="Insert" CssClass="jxtadminbutton" OnClick="InsertButton_Click" />
                                <asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                                    Text="Update" CssClass="jxtadminbutton" OnClick="UpdateButton_Click" />
                                <asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                                    Text="Cancel" CssClass="jxtadminbutton" OnClick="CancelButton_Click" />
                            </div>
                        </div>
                    </li>
                </ul>
            </asp:View>
        </asp:MultiView>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
