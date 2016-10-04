<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Job.Master" AutoEventWireup="true"
    CodeBehind="JobDetail.aspx.cs" Inherits="JXTPortal.Website.JobDetail" %>

<%@ Register Src="~/usercontrols/job/ucJobApply.ascx" TagName="ucJobApply" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:Literal ID="ltlMetaContent" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<ajaxToolkit:ToolkitScriptManager ID="toolkitScriptManager" runat="server">
    </ajaxToolkit:ToolkitScriptManager>--%>
    <div id="content">
        <div id="jobdetail-left-bg">
        <!-- Referrer - <asp:Literal ID="ltReferrer" runat="server" /> -->
            <JXTControl:JobPreview ID="ucJobPreview" runat="server" />
            <uc1:ucJobApply ID="ucJobApply1" runat="server" />
        </div>
    </div>
</asp:Content>
