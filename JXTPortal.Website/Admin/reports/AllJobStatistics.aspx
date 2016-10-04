<%@ Page Title="All Job Statistics" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true"
    CodeBehind="AllJobStatistics.aspx.cs" Inherits="JXTPortal.Website.Admin.reports.AllJobStatistics" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    All Job Statistics 
    <a href='http://support.jxt.com.au/solution/articles/116405-alljobstatistics' class='jxt-help-page' title='click here for help on this page' target="_blank">help on this page</a>

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
    </div>
    <asp:GridView ID="gvAllJobStatistics" runat="server" AutoGenerateColumns="false"
        CssClass="grid" AlternatingRowStyle-CssClass="grid-alt-row">
        <HeaderStyle CssClass="grid-header" />
        <Columns>
            <asp:BoundField ReadOnly="true" HeaderText="Job Status" DataField="JobStatus" />
            <asp:BoundField ReadOnly="true" HeaderText="Total View" DataField="TotalView" />
            <asp:BoundField ReadOnly="true" HeaderText="Total Application" DataField="TotalApplication" />
        </Columns>
    </asp:GridView>
</asp:Content>
