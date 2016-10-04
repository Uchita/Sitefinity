﻿<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" Inherits="SiteRolesEdit" Title="SiteRoles Edit" CodeBehind="SiteRolesEdit.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Site Roles - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-all">
        <span class="form-message">
            <asp:Literal ID="ltlMessage" runat="server" /></span>
        <asp:MultiView ID="MultiViewSiteRoles" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewSiteRoles" runat="server">
                <ul class="form-section">
                    <li class="form-line" id="sr-defaultroles-field">
                        <label class="form-label-left">
                            <strong>Default Role</strong></label>
                        <div class="form-input">
                        </div>
                    </li>
                    <li class="form-line" id="sr-defaultrolename-field">
                        <label class="form-label-left">
                            Role Name:</label>
                        <div class="form-input">
                            <asp:Label ID="lbRoleName" runat="server" />
                        </div>
                    </li>
                    <asp:PlaceHolder ID="phDefaultMeta" runat="server" Visible="false">
                        <li class="form-line" id="sr-defaultrolemetatitle-field">
                            <label class="form-label-left">
                                Meta Title:</label>
                            <div class="form-input">
                                <asp:Label ID="lbMetaTitle" runat="server" />
                            </div>
                        </li>
                        <li class="form-line" id="sr-defaultrolemetakeywords-field">
                            <label class="form-label-left">
                                Meta Keywords:</label>
                            <div class="form-input">
                                <asp:Label ID="lbMetaKeywords" runat="server" />
                            </div>
                        </li>
                        <li class="form-line" id="sr-defaultrolemetadescription-field">
                            <label class="form-label-left">
                                Meta Description:</label>
                            <div class="form-input">
                                <asp:Label ID="lbMetaDescription" runat="server" />
                            </div>
                        </li>
                    </asp:PlaceHolder>
                    <li class="form-line" id="sr-defaultcanonicalurl-field">
                        <label class="form-label-left">
                            Canonoical Url:</label>
                        <div class="form-input">
                            <asp:Label ID="lbCanonicalUrl" runat="server" />
                        </div>
                    </li>
                    <li class="form-line" id="sr-siterole-field">
                        <label class="form-label-left">
                            <strong>Site Role</strong></label>
                        <div class="form-input">
                        </div>
                    </li>
                    <li class="form-line" id="sr-siterolename-field">
                        <label class="form-label-left">
                            Role Name:</label>
                        <div class="form-input">
                            <asp:TextBox ID="dataRoleName" runat="server" Width="250" />
                            <asp:RequiredFieldValidator ID="ReqVal_RoleName" runat="server" ErrorMessage="Required"
                                ControlToValidate="dataRoleName" />
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
                        <li class="form-line" id="sr-siterolemetatitle-field">
                            <label class="form-label-left">
                                Meta Title:</label>
                            <div class="form-input">
                                <asp:TextBox ID="dataMetaTitle" runat="server" Width="250" />
                            </div>
                        </li>
                        <li class="form-line" id="sr-siterolemetakeywords-field">
                            <label class="form-label-left">
                                Meta Keywords:</label>
                            <div class="form-input">
                                <asp:TextBox ID="dataMetaKeywords" runat="server" Width="250" />
                            </div>
                        </li>
                        <li class="form-line" id="sr-siterolemetadescription-field">
                            <label class="form-label-left">
                                Meta Description:</label>
                            <div class="form-input">
                                <asp:TextBox ID="dataMetaDescription" runat="server" Width="250" />
                            </div>
                        </li>
                    </asp:PlaceHolder>
                    <li class="form-line" id="sr-canonicalurl-field">
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
