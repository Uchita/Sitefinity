<%@ Page Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true"
    CodeBehind="advancedsearch.aspx.cs" Inherits="JXTPortal.Website.advancedsearch" %>

<%@ Register Src="~/usercontrols/job/ucAdvancedSearch.ascx" TagName="ucAdvancedSearch"
    TagPrefix="uc2" %>
<%@ Register Src="~/usercontrols/job/ucSearchResults.ascx" TagName="ucSearchResults"
    TagPrefix="uc1" %>
<%@ Register Src="~/usercontrols/job/ucJobSearchFilter.ascx" TagName="ucJobSearchFilter"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--[if IE 7]>
<style>
.job-navbtns {
width:100%
}
.button { 
display:inline; 
margin: 0px 2px;
}
</style>
<![endif]-->
    <%--<script language="javascript" type="text/javascript">
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
</script>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderLeftNav" runat="server">
    <asp:Panel ID="pnlJobSearchFilter" runat="server" Visible="false">
        <uc1:ucJobSearchFilter ID="ucJobSearchFilter1" runat="server" />
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:MultiView ID="MultiViewSearch" runat="server" ActiveViewIndex="0">
        <asp:View ID="ViewAdvancedSearch" runat="server">
            <div id="content">
                <div class="content-holder">
                    <uc2:ucAdvancedSearch ID="ucAdvancedSearch1" runat="server" IsAdvancedSearch="true"
                        IsDynamicWidget="" />
                </div>
            </div>
        </asp:View>
        <asp:View ID="ViewSearchResults" runat="server">
            <uc1:ucSearchResults ID="ucSearchResults1" runat="server" />
        </asp:View>
    </asp:MultiView>
</asp:Content>
