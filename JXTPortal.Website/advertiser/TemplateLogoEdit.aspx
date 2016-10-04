<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="TemplateLogoEdit.aspx.cs" Inherits="JXTPortal.Website.advertiser.TemplateLogoEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="content-holder">
            <div class="breadcrumbs">
                Your Path: <a href="#">My X</a></div>
            <h1>
                Edit Logo</h1>
            <p class="form-top-paragraph">
                Welcome to the Member login page. Please enter your user login details in the form
                below. If you have forgotten your login details please click on the link below "forgotten
                password" and follow instruction on retreiving your details. If you want to login
                as a Advertiser please <a href="#">click here</a></p>
            <div class="form-all">
                <!--DO NOT REMOVE - THIS IS GLOBAL CONTAINER-->
                <ul class="form-section">
                    <li class="form-line" id="adv-selectDocument-field">
                        <label class="form-label-left">
                            Select Document:</label>
                        <div class="form-input">
                            <asp:FileUpload ID="docInput" runat="server" class="form-textbox validate[required]" />
                        </div>
                    </li>
                    <li class="form-line" id="adv-advertiserlogo-field">
                        <asp:Label ID="lblNoLogo" runat="server">You currently have no logo.</asp:Label>
                           <div class="form-input">
                            <asp:CustomValidator ID="cvalFileName" runat="server" ErrorMessage="Invalid file type. GIF, JPG and JPEG are the only valid images types allowed for upload."
                                Display="Dynamic" OnServerValidate="cvalFileName_ServerValidate"></asp:CustomValidator>
                            <asp:CustomValidator ID="cvalFile" runat="server" ErrorMessage="CustomValidator"
                                Display="Dynamic" OnServerValidate="cvalFile_ServerValidate"></asp:CustomValidator>
                            <asp:CustomValidator ID="cvalFileType" runat="server" Display="Dynamic" ErrorMessage="The image uploaded is not a valid image format. Please check the file is either a GIF, JPG or JPEG format and try again."></asp:CustomValidator>
                            <br />
                            <asp:Image ID="imgLogo" runat="server"></asp:Image>
                        </div>
                    </li>
                    <li class="form-line" id="adv-bottom-button">
                        <div class="form-input-wide">
                            <div class="form-buttons-wrapper">
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="mini-new-buttons" OnClick="btnUpdate_Click" />
                            </div>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
