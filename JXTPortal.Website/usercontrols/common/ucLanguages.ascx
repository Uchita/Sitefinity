<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucLanguages.ascx.cs" Inherits="JXTPortal.Website.usercontrols.common.ucLanguages" %>
<div class="languages">
<%--<asp:Repeater ID="rptLanguages" runat="server" OnItemCommand="rptLanguages_ItemCommand">
    <ItemTemplate>
        <asp:LinkButton ID="lnkLanguage" runat="server" CommandName="SelectLanguage" CommandArgument='<%# Eval("LanguageID") %>'
            CausesValidation="false"><%# Eval("SiteLanguageName") %></asp:LinkButton>
    </ItemTemplate>    
</asp:Repeater>--%>
<asp:DropDownList ID="ddlLanguages" runat="server" AutoPostBack="true" 
        onselectedindexchanged="ddlLanguages_SelectedIndexChanged"  ClientIDMode="Static"
        onload="ddlLanguages_Load" ondatabound="ddlLanguages_DataBound">
</asp:DropDownList>
</div>
