<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="validate.aspx.cs" Inherits="JXTPortal.Website.members.validate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="robots" content="nofollow" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="content-holder">
            <h2 class="form-header">
                <asp:Literal ID="ltMemberValidation" runat="server" Text="Member Validation"></asp:Literal></h2>
            <p style="width: 700px;">
                <asp:Literal ID="ltMessage" runat="server" />
            </p>
        </div>
    </div>
</asp:Content>
