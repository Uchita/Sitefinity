<%@ Page Title="Advertiser Activity Report" Language="C#" MasterPageFile="~/MasterPages/admin.Master" AutoEventWireup="true" CodeBehind="AdvertiserActivity.aspx.cs" Inherits="JXTPortal.Website.Admin.reports.AdvertiserActivity"%>
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
    <script type="text/javascript">
        $(document).ready(function () {
            $('.input-daterange').datepicker({
                format: <%=DateFormat %>,
                keyboardNavigation: false,
                autoclose: true,
                todayHighlight: true
            });

            $('#mytable input').click(function () {
                var checked = $('#mytable').find('input[type="checkbox"]:checked').length;
                if (checked >= 2) {
                    $('#downloadSelectedInvoice').attr('disabled', 'disabled');
                } else {
                    $('#downloadSelectedInvoice').removeAttr('disabled', 'disabled');
                }
                if (checked < 2) {
                    $('#createInvoiceFrom').attr('disabled', 'disabled');
                } else {
                    $('#createInvoiceFrom').removeAttr('disabled', 'disabled');
                }
            });

            $('.selectpicker').selectpicker();

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
Advertiser Activity Report
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="scriptManager" runat="server" />
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
                                        Enter keyword</label>
                                    <asp:TextBox ID="tbKeyword" runat="server" CssClass="form-control" placeholder="Keyword search" />
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <label>
                                    Date Range</label>
                                <div class="input-daterange input-group" id="datepicker">
                                    <asp:TextBox ID="tbFrom" runat="server" CssClass="form-control" placeholder="From" />
                                    <span class="input-group-addon">to</span>
                                    <asp:TextBox ID="tbTo" runat="server" CssClass="form-control" placeholder="To" />
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="form-group">
                                    <label>
                                        Show records</label>
                                    <asp:DropDownList ID="ddlShowRecords" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="10">10 records</asp:ListItem>
                                        <asp:ListItem Value="20">20 records</asp:ListItem>
                                        <asp:ListItem Value="50">50 records</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="form-group">
                                    <label>
                                        Sort by column</label>
                                    <asp:DropDownList ID="ddlSortByColumn" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="">Select Column</asp:ListItem>
                                        <asp:ListItem Value="AdvertiserID">ID</asp:ListItem>
                                        <asp:ListItem Value="Email">Email</asp:ListItem>
                                        <asp:ListItem Value="RegisterDate">Acc. Created</asp:ListItem>
                                        <asp:ListItem Value="LastJobPost">Last Job Post</asp:ListItem>
                                        <asp:ListItem Value="AdvertiserAccountStatusID">Account Status</asp:ListItem>
                                        <asp:ListItem Value="JobsLive">Jobs Live</asp:ListItem>
                                        <asp:ListItem Value="TotalJobs">Total Posted</asp:ListItem>
                                        <asp:ListItem Value="LastLoginDate">Last Logged In</asp:ListItem>

                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="form-group">
                                    <label for="">&nbsp;</label>
                                    <asp:DropDownList ID="ddlOrder" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="false">Ascending</asp:ListItem>
                                        <asp:ListItem Value="true">Descending</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            
                            <div class="col-sm-12">
                                <div class="filterButtons">
                                    <asp:Button ID="btnFilter" runat="server" Text="Filter results" CssClass="btn btn-success"
                                        OnClick="btnFilter_Click" />
                                    <asp:Button ID="btnClear" runat="server" Text="Clear filters" CssClass="btn btn-default"
                                        OnClick="btnClear_Click" CausesValidation="false" />
                                        <asp:Button ID="ibDownloadAll" runat="server" CssClass="btn btn-default" Text="Download all to excel"
                OnClick="ibDownloadAll_Click" />
                                </div>
                                <asp:CustomValidator ID="cvDate" runat="server" OnServerValidate="cvDate_ServerValidate" />
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
    <div class="col-sm-12">
        <asp:Label ID="lblErrorMsg" runat="server" class="form-required" Visible="false"
            Text="No Record found" />
        <asp:Repeater ID="rptAdvertiserActivity" runat="server" 
            OnItemDataBound="rptAdvertiserActivity_ItemDataBound">
            <HeaderTemplate>
                <table class="table table-hover" id="mytable">
                    <thead>
                        <tr>
                            <th>
                                ID
                            </th>
                            <th>
                                Advertiser
                            </th>
                            <th>
                                Email
                            </th>
                            <th>
                                Acc. Created
                            </th>
                            <th>
                                Last Job Post
                            </th>
                            <th>
                                Account Status
                            </th>
                            <th>
                                Jobs Live
                            </th>
                            <th>
                                Total Posted
                            </th>
                            <th>
                                Last Logged In
                            </th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Literal ID="ltAdvertiserID" runat="server" />
                    </td>
                    <td>
                        <asp:HyperLink ID="hlAdvertiser" runat="server" Target="_blank" Title="click to view Advertiser" />
                    </td>
                    <td>
                        <asp:HyperLink ID="hlEmail" runat="server" Target="_blank" Title="click to view Advertiser User" />
                    </td>
                    <td>
                        <asp:Literal ID="ltAccCreated" runat="server" />
                    </td>
                    <td>
                        <asp:Literal ID="ltLastJobPost" runat="server" />
                    </td>
                    <td>
                        <asp:Literal ID="ltAccountStatus" runat="server" />
                    </td>
                    <td>
                        <asp:Literal ID="ltJobsLive" runat="server" />
                    </td>
                    <td>
                        <asp:Literal ID="ltTotalPosted" runat="server" />
                    </td>
                    <td>
                        <asp:Literal ID="ltLastLoggedIn" runat="server" />
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
                <nav>
                <ul class="pagination">
                    <li>
                        <asp:LinkButton ID="lbPrevious" runat="server" aria-label="Previous" CommandName="Previous">
                            <span aria-hidden="true">&laquo;</span>
                        </asp:LinkButton>
                    </li>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <asp:LinkButton ID="lbPage" runat="server" CommandName="Page" CausesValidation="false" /></li>
            </ItemTemplate>
            <FooterTemplate>
                <li>
                    <asp:LinkButton ID="lbNext" runat="server" aria-label="Next" CommandName="Next">
                            <span aria-hidden="true">&raquo;</span>
                    </asp:LinkButton>
                </li>
                </ul> </nav>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    </div>
    <script src="/scripts/bootstrap.min.js"></script>
    <script src="/scripts/bootstrap-datepicker.min.js"></script>
    <script src="/scripts/bootstrap-select.js"></script>
</asp:Content>
