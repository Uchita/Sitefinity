<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="SiteProfessionEdit" Title="Site Locations - Site Profession Edit"
    CodeBehind="SiteProfessionEdit.aspx.cs" EnableViewState="true" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Site Profession - Add/Edit <a href='http://support.jxt.com.au/solution/articles/116445-site-professions-roles'
        class='jxt-help-page' title='click here for help on this page' target='_blank'>help
        on this page</a>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
        <asp:MultiView ID="MultiViewSiteProfession" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewSiteProfession" runat="server">
                <ul class="form-section">
                    <li class="form-line" id="sp-defaultprofession-field">
                        <label class="form-label-left">
                            <strong>Default Profession</strong></label>
                        <div class="form-input">
                        </div>
                    </li>
                    <li class="form-line" id="sp-defaultprofessionname-field">
                        <label class="form-label-left">
                            Profession Name:</label>
                        <div class="form-input">
                            <asp:Label ID="lbProfessionName" runat="server" />
                        </div>
                    </li>
                    <li class="form-line" id="sp-defaultprofessionvalid-field">
                        <label class="form-label-left">
                            Valid:</label>
                        <div class="form-input">
                            <asp:Label ID="lbValid" runat="server" />
                        </div>
                    </li>
                    <asp:PlaceHolder ID="phDefaultMeta" runat="server" Visible="false">
                        <li class="form-line" id="sp-defaultprofessionmetatitle-field">
                            <label class="form-label-left">
                                Meta Title:</label>
                            <div class="form-input">
                                <asp:Label ID="lbMetaTitle" runat="server" />
                            </div>
                        </li>
                        <li class="form-line" id="sp-defaultprofessionmetakeywords-field">
                            <label class="form-label-left">
                                Meta Keywords:</label>
                            <div class="form-input">
                                <asp:Label ID="lbMetaKeywords" runat="server" />
                            </div>
                        </li>
                        <li class="form-line" id="sp-defaultprofessionmetadescription-field">
                            <label class="form-label-left">
                                Meta Description:</label>
                            <div class="form-input">
                                <asp:Label ID="lbMetaDescription" runat="server" />
                            </div>
                        </li>
                    </asp:PlaceHolder>
                    <li class="form-line" id="sp-defaultcanonicalurl-field">
                        <label class="form-label-left">
                            Canonoical Url:</label>
                        <div class="form-input">
                            <asp:Label ID="lbCanonicalUrl" runat="server" />
                        </div>
                    </li>
                    <li class="form-line" id="sp-siteprofession-field">
                        <label class="form-label-left">
                            <strong>Site Profession</strong></label>
                        <div class="form-input">
                        </div>
                    </li>
                    <li class="form-line" id="sp-siteprofessionname-field">
                        <label class="form-label-left">
                            Profession Name:</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataProfessionName" runat="server" Width="250" />
                            <asp:RequiredFieldValidator ID="ReqVal_ProfessionName" runat="server" ErrorMessage="Required"
                                ControlToValidate="dataProfessionName" />
                        </div>
                    </li>
                    <li class="form-line" id="Li1">
                        <label class="form-label-left">
                            Friendly Url:</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataFriendlyUrl" runat="server" Width="250" />
                            <asp:RequiredFieldValidator ID="ReqVal_dataFriendlyUrl" runat="server" ErrorMessage="Required"
                                ControlToValidate="dataFriendlyUrl" />
                        </div>
                    </li>
                    <asp:PlaceHolder ID="phSequence" runat="server" Visible="false">
                        <li class="form-line" id="Li2">
                            <label class="form-label-left">
                                Sequence:</label>
                            <div class="form-input">
                                <asp:TextBox ID="dataSequence" runat="server" Width="250" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required"
                                    ControlToValidate="dataSequence" />
                            </div>
                        </li>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="phMeta" runat="server" Visible="false">
                        <li class="form-line" id="sp-siteprofessionmetatitle-field">
                            <label class="form-label-left">
                                Meta Title:</label>
                            <div class="form-input">
                                <asp:TextBox ID="dataMetaTitle" runat="server" Width="250" />
                            </div>
                        </li>
                        <li class="form-line" id="sp-siteprofessionmetakeywords-field">
                            <label class="form-label-left">
                                Meta Keywords:</label>
                            <div class="form-input">
                                <asp:TextBox ID="dataMetaKeywords" runat="server" Width="250" />
                            </div>
                        </li>
                        <li class="form-line" id="sp-siteprofessionmetadescription-field">
                            <label class="form-label-left">
                                Meta Description:</label>
                            <div class="form-input">
                                <asp:TextBox ID="dataMetaDescription" runat="server" Width="250" />
                            </div>
                        </li>
                    </asp:PlaceHolder>
                    <li class="form-line" id="sp-canonicalurl-field">
                        <label class="form-label-left">
                            Canonical Url:</label>
                        <div class="form-input">
                            <asp:TextBox ID="tbCanonicalUrl" runat="server" Width="250" />
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
