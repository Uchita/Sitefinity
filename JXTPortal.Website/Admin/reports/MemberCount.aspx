<%@ Page Title="All Job Statistics - Member Count" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true"
    CodeBehind="MemberCount.aspx.cs" Inherits="JXTPortal.Website.Admin.reports.MemberCount" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Member Count
    <a href='http://support.jxt.com.au/solution/articles/116417-member-count' class='jxt-help-page' title='click here for help on this page'  target='_blank'>help on this page</a>

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
        <asp:Repeater ID="rptMemberCount" runat="server" 
            onitemdatabound="rptMemberCount_ItemDataBound">
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
