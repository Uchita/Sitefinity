<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="EmailMe.aspx.cs" Inherits="JXTPortal.Website.member.EmailMe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="robots" content="nofollow" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="content-holder">
            <div class="form-header-group">
                <h2 class="form-header">
                    <JXTControl:ucLanguageLiteral ID="ltEmailMe" runat="server" SetLanguageCode="LabelEmailMe" />
                </h2>
            </div>
            <div class="form-all">
                <asp:Literal ID="litMessage" runat="server" />
                <asp:HiddenField ID="hfBackUrl" runat="server" />
                <ul class="form-section">
                    <li class="form-line" id="ef-bottom-button">
                        <div class="form-input-wide">
                            <div class="form-buttons-wrapper">
                                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="mini-new-buttons" CausesValidation="false" OnClick="btnBack_Click" />
                            </div>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
