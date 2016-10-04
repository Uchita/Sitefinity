<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="jobadderapplication.aspx.cs" Inherits="JXTPortal.Website.jobs_jobadderapplication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeftNav" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .jobs_iframe
        {
            width: 552px;
            height: 840px;
            overflow: hidden;
        }
    </style>

    <div id="content">
        <div id="jobdetail-left-bg">
            <div class="jobdetail-top">
                <div class="backtoresults">
                    <a href="/advancedsearch.aspx?search=1&amp;retainsearch=1">Back to results </a>
                </div>
            </div>
            <div class="jobs_iframe-thirdPartyApp">
                <iframe scrolling="no" frameborder="0" id="iframe_app" runat="server" width="750px"
                    height="850px" style="margin-left: -100px" allowtransparency="true">
                </iframe>
            </div>
        </div>
    </div>
</asp:Content>
