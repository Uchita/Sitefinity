<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true"
    CodeBehind="MemberActivity.aspx.cs" Inherits="JXTPortal.Website.Admin.reports.MemberActivity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Member Activity
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-all">
        <asp:Panel ID="pnlSite" runat="server">
            <ul class="form-section">
                <li class="form-line">
                    <label class="form-label-left">
                        Site:&nbsp;
                    </label>
                    <div class="form-input-wide">
                        <asp:DropDownList ID="ddlSite" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSite_SelectedIndexChanged" />
                    </div>
                </li>
            </ul>
        </asp:Panel>
        <asp:Repeater ID="rptMemberActivity" runat="server" 
            onitemdatabound="rptMemberActivity_ItemDataBound1">
            <HeaderTemplate>
                <ul class="form-section">
            </HeaderTemplate>
            <ItemTemplate>
                <li class="form-line">
                    <label class="form-label-left">
                        <strong>
                            <asp:Literal ID="litTitle" runat="server" />:&nbsp;</strong>
                    </label>
                    <div class="form-input-wide">
                        <asp:Literal ID="litTotal" runat="server" />
                    </div>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
