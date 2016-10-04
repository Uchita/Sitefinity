<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="jobbrowse.aspx.cs" Inherits="JXTPortal.Website.jobbrowse" %>

<%@ Register Src="~/usercontrols/job/ucBrowseCountry.ascx" TagName="ucBrowseCountry"
    TagPrefix="uc1" %>
<%@ Register Src="~/usercontrols/job/ucBrowseProfession.ascx" TagName="ucBrowseProfession"
    TagPrefix="uc2" %>
<%@ Register Src="~/usercontrols/job/ucBrowseWorkType.ascx" TagName="ucBrowseWorkType"
    TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        //<!--
        oldRow = '';
        function MouseMover_row(id) {
            if (oldRow != '')
                oldRow.className = '';
            id.className = 'job-container';
            oldRow = id;
        }
        function MouseOut_row(id) {
            id.className = '';
        }

        //-->
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div class="content-holder">
            <div class="breadcrumbs">
                Your Path:
                <asp:Literal ID="litBreadCrumb" runat="server" /></div>
            <JXTControl:ucSystemDynamicPage ID="ucSystemDynamicPage" runat="server" SetSystemPageCode="SystemPage_JobBrowse" />
            <div id="jobbrowse-topholder">
                <div class="jobbrowse-LHC">
                    <uc2:ucbrowseprofession id="ucBrowseProfession1" runat="server" />
                </div>
                <div class="jobbrowse-RHC">
                    <div id="jobbrowse-country" class="jobbrowse-listbox">
                        <uc1:ucbrowsecountry id="ucBrowseCountry1" runat="server" />
                    </div>
                    <div id="jobbrowse-worktype" class="jobbrowse-listbox">
                        <uc3:ucbrowseworktype id="ucBrowseWorkType1" runat="server" />
                    </div>
                </div>
            </div>
            <div id="jobsearch-top">
                <div class="num-results">
                    Your search resulted in: <span class="searchresult-number">
                        <asp:Literal ID="ltResultNo" runat="server" /></span> position(s)</div>
            </div>
            <div class="line-break">
            </div>
            <asp:Repeater ID="rptJobResults" runat="server" OnItemDataBound="rptJobResults_ItemDataBound">
                <ItemTemplate>
                    <asp:Literal ID="ltlJob" runat="server" />
                </ItemTemplate>
            </asp:Repeater>
            <asp:Repeater ID="rptPaging" runat="server" OnItemDataBound="rptPaging_ItemDataBound"
                OnItemCommand="rptPaging_ItemCommand">
                <HeaderTemplate>
                    <div id="tnt_pagination">
                        <asp:HyperLink ID="lnkButtonPrevious" runat="server" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:HyperLink ID="lnkButtonPaging" runat="server" /></ItemTemplate>
                <FooterTemplate>
                    <asp:HyperLink ID="lnkButtonNext" runat="server" />
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
