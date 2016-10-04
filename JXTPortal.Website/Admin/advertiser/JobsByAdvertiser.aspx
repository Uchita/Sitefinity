<%@ Page Title="Advertiser - Jobs by Advertiser" Language="C#" MasterPageFile="~/MasterPages/admin.Master"
    AutoEventWireup="true" CodeBehind="JobsByAdvertiser.aspx.cs" Inherits="JXTPortal.Website.Admin.advertiser.JobsByAdvertiser" %>

<%@ Register Src="~/usercontrols/advertiser/ucHistoricalJobStatistics.ascx" TagName="ucHistoricalJobStatistics"
    TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Jobs By Advertiser
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <link rel="stylesheet" href="//images.jxt.net.au/COMMON/newdash/lib/bootstrap.min.css" />
    <link rel="stylesheet" href="/styles/lib/footable.core.css" />
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="toolkitScriptManager" runat="server" CombineScripts="true"
        ScriptMode="Release">
    </ajaxToolkit:ToolkitScriptManager>
    <div class="form-all">
        <span class="form-message">
            <asp:Label ID="lblMsg" runat="server" />
        </span>
        <ul class="form-section">
            <li class="form-line">
                <label class="form-label-left">
                    Job Status:</label>
                <div class="form-input-wide">
                    <asp:DropDownList ID="ddlJobStatus" runat="server" class="form-dropdown" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlJobStatus_SelectedIndexChanged">
                        <asp:ListItem Value="Current">Current Jobs</asp:ListItem>
                        <asp:ListItem Value="Pending">Pending Jobs</asp:ListItem>
                        <asp:ListItem Value="Declined">Declined Jobs</asp:ListItem>
                        <asp:ListItem Value="Draft">Draft Jobs</asp:ListItem>
                        <asp:ListItem Value="Archived">Archived Jobs</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </li>
        </ul>
        <asp:Repeater ID="rptJobCurrent" runat="server" OnItemDataBound="rptJobCurrent_ItemDataBound"
            Visible="false">
            <HeaderTemplate>
                <table cellpadding="3" border="0" class="grid">
                    <tbody>
                        <tr class="grid-header">
                            <th scope="col">
                                &nbsp;
                            </th>
                            <th scope="col">
                                Ref No
                            </th>
                            <th scope="col">
                                Job Title
                            </th>
                            <th scope="col">
                                Views
                            </th>
                            <th scope="col">
                                Applications
                            </th>
                            <th scope="col">
                                Posted
                            </th>
                            <th scope="col">
                                Expiry
                            </th>
                            <th scope="col">
                                Remaining
                            </th>
                        </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <a href='/admin/jobsedit.aspx?jobid=<%# Eval("JobID") %>&advertiserid=<%# AdvertiserID %>&advertiseruserid=<%# Eval("EnteredByAdvertiserUserID") %>'>
                            <asp:Literal ID="ltJobView" runat="server" Text="Edit" /></a>
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltJobRefno" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltJobName" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltViews" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltApplications" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltPosted" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltExpiry" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltRemaining" runat="server" />
                        days
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody></table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Repeater ID="rptJobDraft" runat="server" Visible="false" OnItemDataBound="rptJobDraft_ItemDataBound">
            <HeaderTemplate>
                <table cellpadding="3" border="0" class="grid">
                    <tbody>
                        <tr class="grid-header">
                            <th scope="col">
                                &nbsp;
                            </th>
                            <th scope="col">
                                RefNo
                            </th>
                            <th scope="col">
                                Job Title
                            </th>
                            <th scope="col">
                                Date posted
                            </th>
                            <th scope="col">
                                Status
                            </th>
                        </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <a href='/admin/jobsedit.aspx?jobid=<%# Eval("JobID") %>&advertiserid=<%# AdvertiserID %>&advertiseruserid=<%# Eval("EnteredByAdvertiserUserID") %>'>
                            <asp:Literal ID="ltJobView" runat="server" Text="Edit" /></a>
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltJobRefno" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltJobName" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltPosted" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltStatus" runat="server" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody></table>
            </FooterTemplate>
        </asp:Repeater>
        <uc1:ucHistoricalJobStatistics ID="ucHistoricalJobStatistics1" runat="server" IsAdmin="true" />
        <%--<asp:Repeater ID="rptJobArchived" runat="server" Visible="false" OnItemDataBound="rptJobArchived_ItemDataBound">
            <HeaderTemplate>
                <table cellpadding="3" border="0" class="grid">
                    <tbody>
                        <tr class="grid-header">
                            <th scope="col">
                                Ref No
                            </th>
                            <th scope="col">
                                Job Title
                            </th>
                            <th scope="col">
                                Views
                            </th>
                            <th scope="col">
                                Applications
                            </th>
                            <th scope="col">
                                Posted
                            </th>
                            <th scope="col">
                                Expiry
                            </th>
                        </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td scope="col">
                        <asp:Literal ID="ltJobRefno" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltJobName" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltViews" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltApplications" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltPosted" runat="server" />
                    </td>
                    <td scope="col">
                        <asp:Literal ID="ltExpiry" runat="server" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody></table>
            </FooterTemplate>
        </asp:Repeater>--%>
    </div>
    <script type="text/javascript">
        function LoadFooTable() {

            $("#jobsTable").footable();

        }
    </script>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/footable.js" type="text/javascript"></script>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/footable.sort.js" type="text/javascript"></script>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/footable.filter.js" type="text/javascript"></script>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/footable.paginate.js" type="text/javascript"></script>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/footable.bookmarkable.js"
        type="text/javascript"></script>
    <!--[if lt IE 9]>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/html5shiv.js" type="text/javascript"></script>
    <script src="//images.jxt.net.au/COMMON/newdash/lib/respond.min.js" type="text/javascript"></script>
    <![endif]-->
    <script src='//images.jxt.net.au/COMMON/newdash/lib/bootstrap.min.js'></script>
    <script src='//images.jxt.net.au/COMMON/newdash/newDash.js' type="text/javascript"></script>

</asp:Content>
