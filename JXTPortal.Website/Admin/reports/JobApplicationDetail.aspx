<%@ Page Title="All Job Statistics - Job Application Details by Date" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true"
    CodeBehind="JobApplicationDetail.aspx.cs" Inherits="JXTPortal.Website.Admin.reports.JobApplicationDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Job Application Details by Date
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="form-message">
        <asp:Literal ID="ltlMessage" runat="server" />
    </span>
    <asp:GridView ID="gvJobApplicationDetail" runat="server" AutoGenerateColumns="false"
        CssClass="grid" AlternatingRowStyle-CssClass="grid-alt-row">
        <HeaderStyle CssClass="grid-header" />
        <Columns>
            <asp:BoundField ReadOnly="true" HeaderText="JobID" DataField="JobID" />
            <asp:BoundField ReadOnly="true" HeaderText="RefNo" DataField="RefNo" />
            <asp:BoundField ReadOnly="true" HeaderText="JobName" DataField="JobName" />
            <asp:BoundField ReadOnly="true" HeaderText="AdvertiserID" DataField="AdvertiserID" />
            <asp:BoundField ReadOnly="true" HeaderText="CompanyName" DataField="CompanyName" />
            <asp:BoundField ReadOnly="true" HeaderText="MemberID" DataField="MemberID" />
            <asp:BoundField ReadOnly="true" HeaderText="FirstName" DataField="FirstName" />
            <asp:BoundField ReadOnly="true" HeaderText="Surname" DataField="Surname" />
            <asp:BoundField ReadOnly="true" HeaderText="Applied With" DataField="AppliedWith" />
            <asp:BoundField ReadOnly="true" HeaderText="URL Referral" DataField="URL_Referral" />
            <asp:BoundField ReadOnly="true" HeaderText="Application Date" DataField="ApplicationDate"
                DataFormatString="{0:MMMM d, yyyy}" />
        </Columns>
    </asp:GridView>
</asp:Content>
