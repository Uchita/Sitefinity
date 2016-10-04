<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="LogoEdit.aspx.cs" Inherits="JXTPortal.Website.advertiser.LogoEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="robots" content="nofollow" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="content-holder">
            <JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage" runat="server" SetSystemPageCode="SystemPage_AdvertiserLogoEdit" />
            <%--<div class="form-header-group">
                <h2 class="form-header">
                    <JXTControl:ucLanguageLiteral ID="ltheaderAdvertiserLogoEdit" runat="server" SetLanguageCode="LinkButtonViewChangeLogo" />
                </h2>
            </div>--%>
            
            <div class="form-all">
                
                    <div class="form-line" id="adv-selectDocument-field">
                        <label class="form-label-left" for="ctl00_ContentPlaceHolder1_docInput">
                            <JXTControl:ucLanguageLiteral ID="ltAdvertiserLogoEditSelect" runat="server" SetLanguageCode="LabelCompanyLogo" />
                            </label>
                        <div class="form-input">
                            <asp:FileUpload ID="docInput" runat="server" class="form-textbox validate[required]" />
                        </div>
                    </div>
                    <div class="form-line" id="adv-advertiserlogo-field">
                        <asp:Label ID="lblNoLogo" runat="server">
                            <JXTControl:ucLanguageLiteral ID="ltAdvertiserLogoEditNologo" runat="server" SetLanguageCode="LabelYouhavenologo" />
                        </asp:Label><br />
                        <div class="form-input">                            
                            <asp:Image ID="imgLogo" runat="server"></asp:Image>
                        </div>
                    </div>
                    <div>
                        <asp:CustomValidator ID="cvalFileName" runat="server" Display="Dynamic" OnServerValidate="cvalFileName_ServerValidate"></asp:CustomValidator>
                        <asp:CustomValidator ID="cvalFile" runat="server" Display="Dynamic" OnServerValidate="cvalFile_ServerValidate"></asp:CustomValidator>
                        <asp:CustomValidator ID="cvalFileType" runat="server" Display="Dynamic"></asp:CustomValidator>
                    </div>
                    <div class="form-line" id="adv-bottom-button">
                        
                        <div class="form-buttons-wrapper">
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="mini-new-buttons" OnClick="btnUpdate_Click" />
                        </div>
                        
                    </div>
                
            </div>
        </div>
    </div>
</asp:Content>
