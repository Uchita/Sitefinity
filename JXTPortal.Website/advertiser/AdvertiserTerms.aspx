<%@ Page Title="Advertiser Terms &amp; Conditions" Language="C#" MasterPageFile="~/MasterPages/CustomMain.Master"
    AutoEventWireup="true" CodeBehind="AdvertiserTerms.aspx.cs" Inherits="JXTPortal.Website.advertiser.AdvertiserTerms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="robots" content="nofollow" />
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/newdash/lib/bootstrap.min.css" />
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/newdash/newDash.css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-container" class="newDash">
        <div id="content">
            <div class="content-holder">
                <div class="boardyNewTermsModule">
                    <h1>
                        <asp:Literal ID="ltTitle" runat="server" /></h1>
                        <p class="termsIntro">
                            <asp:Literal ID="ltIntroduction" runat="server" /></p>
                        <div class="scrollingTermsContainer">
                            <asp:Literal ID="ltDescription" runat="server" />
                        </div>
                        <asp:PlaceHolder ID="phAction" runat="server" Visible="false">
                            <p>
                                <asp:LinkButton ID="btnAccept" runat="server" CssClass="mini-new-buttons acceptTermsBtn"
                                    Text="Accept &amp; Continue" OnClick="Accept" />&nbsp;
                                <asp:LinkButton ID="btnCancel" runat="server" CssClass="mini-new-buttons declineTermsBtn"
                                    Text="Decline &amp; Logout" OnClick="Cancel" />
                            </p>
                        </asp:PlaceHolder>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
