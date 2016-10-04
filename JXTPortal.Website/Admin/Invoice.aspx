<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"
    CodeBehind="Invoice.aspx.cs" Inherits="Invoice" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    Invoice & Reports
</asp:Content>
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
        var dateformat = '<%=DateFormat %>';
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                                <label>
                                    Date range (Max 6 months)</label>
                                <div class="input-daterange input-group" id="datepicker">
                                    <asp:TextBox ID="tbFrom" runat="server" CssClass="form-control" placeholder="From" />
                                    <span class="input-group-addon">to</span>
                                    <asp:TextBox ID="tbTo" runat="server" CssClass="form-control" placeholder="To" />
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="form-group">
                                    <label>
                                        Advertiser</label>
                                    <asp:DropDownList ID="ddlAdvertiser" runat="server" CssClass="form-control selectpicker">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="form-group">
                                    <label for="">
                                        Invoice Number</label>
                                    <asp:TextBox ID="tbInvoiceNo" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="form-group">
                                    <label>
                                        Filter by item type</label>
                                    <asp:DropDownList ID="ddlItemType" runat="server" CssClass="form-control selectpicker">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-sm-4">
                                <div class="form-group">
                                    <label for="">
                                        Select advertiser type</label>
                                    <asp:DropDownList ID="ddlAdvertiserType" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="0">Please select type</asp:ListItem>
                                        <asp:ListItem Value="1">Account</asp:ListItem>
                                        <asp:ListItem Value="2">Credit Card</asp:ListItem>
                                    </asp:DropDownList>
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
    <asp:PlaceHolder ID="phDownload" runat="server">
        <div class="col-sm-8">
            <!--<button class="btn btn-default" id="createInvoiceFrom" disabled>Create statement from selected</button>-->
            <asp:Button ID="downloadSelectedInvoice" runat="server" CssClass="btn btn-default"
                Text="Download selected invoice" OnClick="ibDownloadSelected_Click" ClientIDMode="Static" />
        </div>
        <div class="col-sm-12">
            <hr />
        </div>
    </asp:PlaceHolder>
    <div class="col-sm-12">
        <asp:Label ID="lblErrorMsg" runat="server" class="form-required" Visible="false"
            Text="No Record found" />
        <asp:Repeater ID="rptInvoice" runat="server" 
            OnItemDataBound="rptInvoice_ItemDataBound" 
            onitemcommand="rptInvoice_ItemCommand">
            <HeaderTemplate>
                <table class="table table-hover" id="mytable">
                    <thead>
                        <tr>
                            <th>
                                #
                            </th>
                            <th>
                                Invoice No.
                            </th>
                            <!--<th>Job ID / Number</th>-->
                            <th>
                                Advertiser name
                            </th>
                            <th>
                                Advertiser type
                            </th>
                            <!--<th>Normal</th>-->
                            <!--<th>Standout</th>-->
                            <!--<th>Premium</th>-->
                            <th style="width: 35%;">
                                Items
                            </th>
                            <th>
                                Date
                            </th>
                            <th>
                                Total
                            </th>
                            <th>
                                Transaction ID
                            </th>
                            <th>
                                Is Paid
                            </th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:CheckBox ID="ckSelect" runat="server" />
                        <asp:HiddenField ID="hfOrderID" runat="server" />
                    </td>
                    <td>
                        <asp:HyperLink ID="hlInvoiceDetail" runat="server" Target="_blank" Title="click to view invoice" />
                    </td>
                    <td>
                        <asp:HyperLink ID="hlAdvertiserName" Target="_blank" runat="server" />
                    </td>
                    <td>
                        <asp:Literal ID="ltAdvertiserType" runat="server" />
                    </td>
                    <td>
                        <asp:Literal ID="ltItems" runat="server" />
                    </td>
                    <td>
                        <asp:Literal ID="ltDate" runat="server" />
                    </td>
                    <td>
                        <asp:Literal ID="ltTotal" runat="server" />
                    </td>
                    <td>
                        <asp:Literal ID="ltTransactionID" runat="server" />
                    </td>
                    <td>
                        <asp:Literal ID="ltIsPaid" runat="server" />
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
                    <asp:LinkButton ID="lbPage" runat="server" CommandName="Page" /></li>
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
    <script src="/scripts/report.js"></script>
</asp:Content>
