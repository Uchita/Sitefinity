<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true"
    CodeBehind="MemberActivity.aspx.cs" Inherits="JXTPortal.Website.Admin.reports.MemberActivity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <meta name="robots" content="nofollow" />
    <link rel="stylesheet" href="/styles/bootstrap.min.css" />
    <link rel="stylesheet" href="/styles/bootstrap-datepicker.min.css" />
    <link rel="stylesheet" href="/styles/bootstrap-select.min.css" />
    <link rel="stylesheet" href="/styles/report.css" />
    <meta charset="UTF-8">
    <style>
        .AdminAdvShowRecords
        {
            margin: 20px 0px;
            max-width: 180px;
        }
        
        .reportsContainer
        {
            width: 100%;
            display: block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Member Activity
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scriptManager" runat="server" />
    <asp:PlaceHolder ID="pnlSite" runat="server">
        <div class="container reportsContainer">
            <div class="row">
                <div class="panel panel-default" id="panel1">
                    <div class="panel-heading">
                        <h3 class="panel-title">
                            <!--   <a data-toggle="collapse" data-target="#collapseOne" 
                                href="#" title="click to expand filters">-->
                            Filter results
                        </h3>
                    </div>
                    <div id="collapseOne" class="panel-collapse">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-sm-4">
                                    <div class="form-group">
                                        <label>
                                            Site</label>
                                        <asp:DropDownList ID="ddlSite" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSite_SelectedIndexChanged" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-sm-12">
            <hr />
        </div>
    </asp:PlaceHolder>
    <div class="col-sm-12">
        <asp:Label ID="lblErrorMsg" runat="server" class="form-required" Visible="false"
            Text="No Record found" />
        <asp:Repeater ID="rptMemberActivity" runat="server" 
            OnItemDataBound="rptMemberActivity_ItemDataBound">
            <HeaderTemplate>
                <table class="table table-hover" id="mytable">
                    <thead>
                        <tr>
                            <th>
                                ID
                            </th>
                            <th>
                                First Name
                            </th>
                            <th>
                                Surname
                            </th>
                            <th>
                                Email
                            </th>
                            <th>
                                Last Modified
                            </th>
                            <th>
                                Last Logon
                            </th>
                            <th>
                                Registered Date
                            </th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:HyperLink ID="hlMember" runat="server" Target="_blank" Title="click to view Member" />
                    </td>
                    <td>
                        <asp:Literal ID="ltFirstName" runat="server" />
                    </td>
                    <td>
                        <asp:Literal ID="ltSurname" runat="server" />
                    </td>
                    <td>
                        <asp:Literal ID="ltEmail" runat="server" />
                    </td>
                    <td>
                        <asp:Literal ID="ltLastModified" runat="server" />
                    </td>
                    <td>
                        <asp:Literal ID="ltLastLogon" runat="server" />
                    </td>
                    <td>
                        <asp:Literal ID="ltRegisteredDate" runat="server" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody> </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <div class="col-sm-12">
        <hr />
    </div>
    <div class="col-sm-6">
       <asp:Repeater ID="rptPage" runat="server" OnItemCommand="rptPage_ItemCommand" OnItemDataBound="rptPage_ItemDataBound">
            <HeaderTemplate>
                <tfoot>
                    <tr>
                        <td colspan="8">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Literal ID="litPage" runat="server" Text="Page:" />
                                    </td>
            </HeaderTemplate>
            <ItemTemplate>
                <td>
                    <asp:LinkButton ID="lbPageNo" runat="server" CommandName="Page" />
                </td>
            </ItemTemplate>
            <FooterTemplate>
                </tr> </table> </td> </tr> </tfoot>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <script src="/scripts/bootstrap.min.js"></script>
    <script src="/scripts/bootstrap-datepicker.min.js"></script>
    <script src="/scripts/bootstrap-select.js"></script>
</asp:Content>
