<%@ Page Title="All Job Statistics - Advertiser Type Statistics" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true"
    CodeBehind="AdvertiserTypeStatistics.aspx.cs" Inherits="JXTPortal.Website.Admin.reports.AdvertiserTypeStatistics" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Advertiser Type Statistics
    <a href='http://support.jxt.com.au/solution/articles/116427-advertiser-type-statistics' class='jxt-help-page' title='click here for help on this page'  target='_blank'>help on this page</a>

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
                        <asp:DropDownList ID="ddlSite" runat="server" AutoPostBack="true" 
                            onselectedindexchanged="ddlSite_SelectedIndexChanged" />
                    </div>
                </li>
            </ul>
        </asp:Panel>
    </div>
    <asp:GridView ID="gvAdvertiserTypeStatistics" runat="server" AutoGenerateColumns="false"
        CssClass="grid" AlternatingRowStyle-CssClass="grid-alt-row">
        <HeaderStyle CssClass="grid-header" />
        <Columns>
            <asp:BoundField ReadOnly="true" HeaderText="Business Type" DataField="BusinessType" />
            <asp:BoundField ReadOnly="true" HeaderText="Business Name" DataField="BusinessName" />
            <asp:BoundField ReadOnly="true" HeaderText="Total Job" DataField="TotalJob" />
            <asp:BoundField ReadOnly="true" HeaderText="Total Application" DataField="TotalApplication" />
            <asp:BoundField ReadOnly="true" HeaderText="Total View" DataField="TotalView" />
        </Columns>
    </asp:GridView>
</asp:Content>
