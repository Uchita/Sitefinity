<%@ Page Title="All Job Statistics - All Advertisers" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true"
    CodeBehind="AllAdvertisers.aspx.cs" Inherits="JXTPortal.Website.Admin.reports.AllAdvertisers" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
All Advertiser
<a href='http://support.jxt.com.au/solution/categories/116125/folders/190946/articles/116423-all-advertisers' class='jxt-help-page' title='click here for help on this page'  target='_blank'>help on this page</a>

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
    <asp:GridView ID="gvAllAdvertisers" runat="server" AutoGenerateColumns="false" CssClass="grid"
        AlternatingRowStyle-CssClass="grid-alt-row">
        <HeaderStyle CssClass="grid-header" />
        <Columns>
            <asp:BoundField ReadOnly="true" HeaderText="ID" DataField="AdvertiserID" />
            <asp:BoundField ReadOnly="true" HeaderText="Company Name" DataField="CompanyName" />
            <asp:BoundField ReadOnly="true" HeaderText="Account Type" DataField="AdvertiserAccountTypeName" />
            <asp:BoundField ReadOnly="true" HeaderText="Business Type" DataField="AdvertiserBusinessTypeName" />
            <asp:BoundField ReadOnly="true" HeaderText="Email" DataField="AccountsPayableEmail" />
        </Columns>
    </asp:GridView>
</asp:Content>
