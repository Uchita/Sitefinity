<%@ Page Title="All Job Statistics - Advertiser Count" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true"
    CodeBehind="AdvertiserCount.aspx.cs" Inherits="JXTPortal.Website.Admin.reports.AdvertiserCount" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Advertiser Count
    <a href='http://support.jxt.com.au/solution/articles/116425-advertiser-count' class='jxt-help-page' title='click here for help on this page'  target='_blank'>help on this page</a>

</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-all">
        <asp:Panel ID="pnlSite" runat="server">
            <ul class="form-section">
                <li class="form-line">
                    <label class="form-label-left">
                        Site:&nbsp;
                    </label>
                    <div class="form-input-wide" style="width: 600px;">
                        <asp:DropDownList ID="ddlSite" runat="server" AutoPostBack="true"
                            onselectedindexchanged="ddlSite_SelectedIndexChanged" />
                    </div>
                </li>
            </ul>
        </asp:Panel>
        <asp:Repeater ID="rptAdvertiserCount" runat="server" OnItemDataBound="rptAdvertiserCount_ItemDataBound">
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
