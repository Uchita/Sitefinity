<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="validate.aspx.cs" Inherits="JXTPortal.Website.advertiser.validate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="robots" content="nofollow" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-holder">
        <div class="form-header-group">
            <h1 class="form-header">
            <JXTControl:ucLanguageLiteral ID="lbValidateAdvertiser" runat="server" SetLanguageCode="LabelAdvertiserValidation" /></h1>
        </div>
        <div class="search-sequence">
            <p style="width: 700px;">
                <asp:Literal ID="litMessage" runat="server" />
            </p>
        </div>
    </div>
</asp:Content>
