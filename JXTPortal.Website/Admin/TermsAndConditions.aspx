<%@ Page Title="Terms &amp Conditions" Language="C#" MasterPageFile="~/MasterPages/admin.Master"
    AutoEventWireup="true" CodeBehind="TermsAndConditions.aspx.cs" Inherits="TermsAndConditions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Terms &amp; Conditions
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="form-message">
        <asp:Label ID="lblErrorMsg" runat="server" class="form-required" />
    </span>
    <i>In Global Settings -> Privacy Settings Textbox - Please add shortcode [Terms&amp;ConditionsLink] for Terms &amp; Conditions Link for Advertiser / Member</i>
    <ul class="form-section">
        <li class="form-line" id="adv-accountsettings-field">
            <label class="form-label-left">
                <h2>Advertiser Settings</h2></label>
            <div class="form-input">
            </div>
        </li>
        <li class="form-line" id="adv-makeactive-field">
            <label class="form-input">
                <asp:CheckBox ID="cbAdvMarkActive" runat="server" />&nbsp;Make Active<br />
            </label>
        </li>
        <li class="form-line" id="Li5">
            <label class="form-input">
                <strong>Advertiser - Title</strong></label>
        </li>
        <li class="form-line" id="Li6">
            <label class="form-input">
                <asp:TextBox ID="tbAdvertiserTCTitle" runat="server" TextMode="SingleLine" Width="650px" MaxLength="2000" />
            </label>
        </li>
        <li class="form-line" id="Li1">
            <label class="form-input">
                <strong>Advertiser - Terms Introduction</strong></label>
        </li>
        <li class="form-line" id="Li2">
            <label class="form-input">
                <FredCK:CKEditorControl ID="tbAdvertiserTCIntroduction" runat="server" Width="650px"
                    Height="100px" CustomConfig="custom_config.js" Toolbar="SmallToolbar" EnableViewState="false" MaxLength="2000">
                </FredCK:CKEditorControl>
            </label>
        </li>
        <li class="form-line" id="Li3">
            <label class="form-input">
                <strong>Advertiser - Terms &amp; Conditions</strong></label>
        </li>
        <li class="form-line" id="Li4">
            <label class="form-input">
                <FredCK:CKEditorControl ID="tbAdvertiserTC" runat="server" Width="650px" Height="400px"
                    CustomConfig="custom_config.js" Toolbar="SmallToolbar" EnableViewState="false">
                </FredCK:CKEditorControl>
            </label>
        </li>
        <li class="form-line" id="adv-lastmodified-field">
            <label class="form-label-left">
                Last Modified:</label>
            <div class="form-input">
                <asp:Label runat="server" ID="dataLastModified" MaxLength="10"></asp:Label>
            </div>
        </li>
        <li class="form-line" id="adv-modifiedby-field">
            <label class="form-label-left">
                Last Modified By:</label>
            <div class="form-input">
                <asp:Label runat="server" ID="dataModifiedBy" MaxLength="10"></asp:Label>
            </div>
        </li>
    </ul>
    <ul class="form-section">
        <li class="form-line">
            <div class="form-input-wide">
                <div class="form-buttons-wrapper-left">
                    <asp:Button ID="btnSubmit" runat="server" Text="Save Advertiser" CssClass="jxtadminbutton" 
                        onclick="btnSubmit_Click" />
                </div>
            </div>
        </li>
    </ul>
    <hr />
        <ul class="form-section">
        <li class="form-line" id="Li7">
            <label class="form-label-left">
                <h2>Candidate Settings</h2></label>
            <div class="form-input">
            </div>
        </li>
        <li class="form-line" id="Li8">
            <label class="form-input">
                <asp:CheckBox ID="cbMemberMarkActive" runat="server" />&nbsp;Make Active<br />
            </label>
        </li>
        <li class="form-line" id="Li9">
            <label class="form-input">
                <strong>Candidate - Title</strong></label>
        </li>
        <li class="form-line" id="Li10">
            <label class="form-input">
                <asp:TextBox ID="tbMemberTCTitle" runat="server" TextMode="SingleLine" Width="650px" MaxLength="2000" />
            </label>
        </li>
        <li class="form-line" id="Li11">
            <label class="form-input">
                <strong>Candidate - Terms Introduction</strong></label>
        </li>
        <li class="form-line" id="Li12">
            <label class="form-input">
                <FredCK:CKEditorControl ID="tbMemberTCIntroduction" runat="server" Width="650px"
                    Height="100px" CustomConfig="custom_config.js" Toolbar="SmallToolbar" EnableViewState="false" MaxLength="2000">
                </FredCK:CKEditorControl>
            </label>
        </li>
        <li class="form-line" id="Li13">
            <label class="form-input">
                <strong>Candidate - Terms &amp; Conditions</strong></label>
        </li>
        <li class="form-line" id="Li14">
            <label class="form-input">
                <FredCK:CKEditorControl ID="tbMemberTC" runat="server" Width="650px" Height="400px"
                    CustomConfig="custom_config.js" Toolbar="SmallToolbar" EnableViewState="false">
                </FredCK:CKEditorControl>
            </label>
        </li>
        <li class="form-line" id="Li15">
            <label class="form-label-left">
                Last Modified:</label>
            <div class="form-input">
                <asp:Label runat="server" ID="dataMemberLastModified" MaxLength="10"></asp:Label>
            </div>
        </li>
        <li class="form-line" id="Li16">
            <label class="form-label-left">
                Last Modified By:</label>
            <div class="form-input">
                <asp:Label runat="server" ID="dataMemberModifiedBy" MaxLength="10"></asp:Label>
            </div>
        </li>
    </ul>
    <ul class="form-section">
        <li class="form-line">
            <div class="form-input-wide">
                <div class="form-buttons-wrapper-left">
                    <asp:Button ID="btnMemberSubmit" runat="server" Text="Save Candidate" 
                        CssClass="jxtadminbutton" onclick="btnMemberSubmit_Click" />
                </div>
            </div>
        </li>
    </ul>
</asp:Content>
