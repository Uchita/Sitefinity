<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="SiteAreaEdit" Title="SiteArea Edit" CodeBehind="SiteAreaEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Site Area - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
        <asp:MultiView ID="MultiViewSiteProfession" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewSiteProfession" runat="server">
                <ul class="form-section">
                    <li class="form-line" id="sa-defaultarea-field">
                        <label class="form-label-left">
                            <strong>Default Area</strong></label>
                        <div class="form-input">
                        </div>
                    </li>
                    
                    <li class="form-line" id="sa-defaultlocationname-field">
                        <label class="form-label-left">
                            Location:</label>
                        <div class="form-input">
                            <asp:Label ID="lbLocation" runat="server" />
                        </div>
                    </li>
                    <li class="form-line" id="sa-defaultareaname-field">
                        <label class="form-label-left">
                            Area Name:</label>
                        <div class="form-input">
                            <asp:Label ID="lbAreaName" runat="server" />
                        </div>
                    </li>
                    <li class="form-line" id="sa-defaultarea-field">
                        <label class="form-label-left">
                            <strong>Site Area</strong></label>
                        <div class="form-input">
                        </div>
                    </li>
                    
                    <li class="form-line" id="sa-sitelocation-field">
                        <label class="form-label-left">
                            Location:</label>
                        <div class="form-input">
                            <asp:Label ID="lbSiteLocation" runat="server" />
                        </div>
                    </li>
                    <li class="form-line" id="sa-sitearea-field">
                        <label class="form-label-left">
                            Area Name:</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataAreaName" runat="server" Width="250" />
                            <asp:RequiredFieldValidator ID="ReqVal_AreaName" runat="server" ErrorMessage="Required"
                                ControlToValidate="dataAreaName" />
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
