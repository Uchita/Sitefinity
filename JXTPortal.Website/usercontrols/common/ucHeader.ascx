<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucHeader.ascx.cs" Inherits="JXTPortal.Website.usercontrols.common.ucHeader" %>
<%@ Register Src="~/usercontrols/common/ucLanguages.ascx" TagName="ucLanguages" TagPrefix="uc1" %>
<div id='header'>
    <uc1:ucLanguages ID="ucLanguages1" runat="server" />
    <asp:Literal ID="ltlContent" runat="server" />
</div>
